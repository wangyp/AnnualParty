using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using CICC.WR.AnnualPartyDAL;
using System.Threading;
using System.Runtime.InteropServices;
using log4net;
using CICC.WR.AnnualPartyControls;
using System.Configuration;
namespace CICC.WR.AnnualParty
{
    public partial class DrawLotteryForm : Form
    {

        [System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint = "SetForegroundWindow")]
        public static extern bool SetF(IntPtr hWnd);//设置此窗体为活动窗体

        private ILog log = LogManager.GetLogger(typeof(DrawLotteryForm));
        private int interval = 10;
        private IDictionary<int,IList<string>> AwardNames;
        public DrawLotteryForm()
        {
            InitializeComponent();
            LoadBackgroupImage();
            CurrentLottery = LoadAwardFromConfig();
            AwardNames = LoadAwardNameFromConfig();
            this.lbAwardLevelText.Text = CurrentLottery.AwardString;
        }

        private IDictionary<int, IList<string>> LoadAwardNameFromConfig()
        {
            var awardNames = new Dictionary<int, IList<string>>();
            var awardName = ConfigurationManager.AppSettings["AwardName"];
            foreach (var award in awardName.Split(';'))
            {
                var strs = award.Split(',');
                int level = Convert.ToInt32(strs[0]);
                IList<string> names = new List<string>();
                for (int i = 1; i < strs.Length; i++)
                {
                    names.Add(strs[i]);
                }
                awardNames.Add(level, names);
            }
            return awardNames;
        }

        private void LoadBackgroupImage()
        {
            string fileName = ConfigurationManager.AppSettings["backgroudImage"];
            Int32.TryParse( ConfigurationManager.AppSettings["IntervalMillisecond"],out interval);
            Bitmap bmp = new Bitmap(fileName);
            this.BackgroundImage = bmp;
        }
        private void DrawLotteryForm_Load(object sender, EventArgs e)
        {
            LoadEmployeeData();
        }
        private void LoadEmployeeData()
        {
            Splash.Status = "载入已签到员工列表……";
            GlobalData.Employees = AnnualPartySqlHelper.Instance.GetAllCheckInEmployee(false);
            Splash.Status = "载入已签到员工照片……";
            int i = 0;
            int count = GlobalData.Employees.Count;
            foreach (string number in GlobalData.Employees.Keys)
            {
                var photo = AnnualPartySqlHelper.Instance.GetEmployeePhoto(number);
                if (photo == null)
                {
                    //photo = ResourceLib.NoPhoto;
                }
                GlobalData.Employees[number].Photo = photo;
                GlobalData.EmployeeList.Add(GlobalData.Employees[number]);
                i++;
                Splash.Status = "载入员工照片 " + i + "/" + count;
            }
            Splash.Status = "载入数据完毕，初始化界面";

            Splash.Close();
            this.WindowState = FormWindowState.Maximized;
            SetF(this.Handle);
        }

        private void DrawLotteryForm_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Space && isRunning) //运行时按空格停止抽奖
            {
                isRunning = false;
            }
            if (!e.Control && e.KeyCode == Keys.D1 && !backgroundWorker1.IsBusy) //停止时按1抽一个人的奖
            {
                isRunning = true;
                photoList1.Controls.Clear();
                photoList1.Columns = 1;
                photoList1.PictureSize = new Size(450, 600);
                photoList1.AutoPictureSize = false;
                photoList1.InitPictureBox(1);

                photoList1.InitEmployeeInfo(GlobalData.EmployeeList);

                backgroundWorker1.RunWorkerAsync(1);
            }
            if (e.KeyCode == Keys.Enter && !backgroundWorker1.IsBusy) //停止时按回车开始抽奖
            {
                //如果当前奖项已经抽完，跳到下一奖项
                if (CurrentLottery.Winners.Count >= CurrentLottery.OnePageCount*CurrentLottery.PageCount)
                {
                    if (CurrentLottery.NextDrawLottery == null) //特等奖都抽完了
                    {
                        MessageBox.Show("抽奖已经全部完毕,请按Alt+F4退出");
                        return;
                    }
                    else
                    {
                        CurrentLottery = CurrentLottery.NextDrawLottery;
                    }
                }

                this.lbAwardLevelText.Text = CurrentLottery.AwardString;
                if (CurrentLottery.Award == 2) //2等奖要调整行间距
                {
                    photoList1.CellHeight = 200;
                }
                else
                {
                    photoList1.CellHeight = 10;
                }

                isRunning = true;
                photoList1.Controls.Clear();

                photoList1.ShowLabel = true;
                photoList1.Columns = CurrentLottery.OnePageColumn;
                photoList1.Rows = (int) Math.Ceiling(1.0*CurrentLottery.OnePageCount/CurrentLottery.OnePageColumn);
                if (CurrentLottery.Award == 1) //照片不需要那么大
                {
                    photoList1.PictureSize = new Size(450, 600);
                    photoList1.AutoPictureSize = false;
                }
                else
                {
                    photoList1.AutoPictureSize = true;
                }
                photoList1.InitPictureBox(CurrentLottery.OnePageCount);
                photoList1.InitEmployeeInfo(GlobalData.EmployeeList);

                backgroundWorker1.RunWorkerAsync(CurrentLottery.OnePageCount);

            }
            if (e.Control && !backgroundWorker1.IsBusy)
            {
                //切换到一等奖
                if (e.KeyCode == Keys.D1)
                {
                    CurrentLottery = LoadAward(1);
                }
                if (e.KeyCode == Keys.D2)
                {
                    CurrentLottery = LoadAward(2);
                }
                if (e.KeyCode == Keys.D3)
                {
                    CurrentLottery = LoadAward(3);
                }
                if (e.KeyCode == Keys.D4)
                {
                    CurrentLottery = LoadAward(4);
                }
                if (e.KeyCode == Keys.D0)
                {
                    CurrentLottery = LoadAward(0);
                }
                this.lbAwardLevelText.Text = CurrentLottery.AwardString;
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            DrawingLottery((int) e.Argument);

        }

        private string currentAwardName = "";
        private object lockHandle=new object();
        private void DrawingLottery(int onePageCount)
        {
            int max = GlobalData.EmployeeList.Count;
            while (isRunning)
            {
                var rList = GetRandomNumber(onePageCount, max);
                lock (lockHandle)
                {
                    SetPhoto(rList);
                    SetAwardName(RamdomAwardName());
                    Thread.Sleep(interval);
                }
            }
            //产生中奖结果
            currentAwardName = lbAwardName.Text;
            //中奖结果写入数据库
            List<string> numbers = photoList1.GetLotteryEmployeeNumber();
            foreach (string number in numbers)
            {
                try
                {
                    AnnualPartySqlHelper.Instance.UpdateAward(number, (int)CurrentLottery.Award, currentAwardName);
                }
                catch (Exception ex)
                {
                    log.Error(number + "更新数据库失败", ex);
                }
                log.Info(CurrentLottery.AwardString+ "获奖人：" + number);
            }
            var winner = GlobalData.EmployeeList.FindAll(e => numbers.Contains(e.EmployeeNumber));
            CurrentLottery.Winners.AddRange(winner);
            //中奖员工不再参与抽奖
            GlobalData.EmployeeList.RemoveAll(e => numbers.Contains(e.EmployeeNumber));
            //中奖礼品被移除
            if(currentAwardName!="")
            {
                AwardNames[CurrentLottery.Award].Remove(currentAwardName);
            }

        }
        private void SetPhoto(List<int> rList)
        {
            //不注释才对，但是不注释反应很慢，不知道为什么
            if (this.photoList1.InvokeRequired)
            {
                SetPhotoCallback p = new SetPhotoCallback(SetPhoto);
                photoList1.Invoke(p, new object[] { rList });
            }
            else
            {
                photoList1.ShowPhoto(rList);
            }
        }
        private void SetAwardName(string name)
        {
            if (lbAwardName.InvokeRequired)
            {
                SetText st= new SetText(SetAwardName);
                lbAwardName.Invoke(st,new object[]{name});
            }
            else
            {
                lbAwardName.Text = name;
            }
        }
        private delegate void SetPhotoCallback(List<int> rList);

        private delegate void SetText(string text);
        private bool isRunning = false;
       private IList<string> DoneAward=new List<string>();
        private int count = 0;
        private string RamdomAwardName()
        {
            if (AwardNames.ContainsKey(CurrentLottery.Award))
            {
                var list = AwardNames[CurrentLottery.Award];
                if (list.Count > 0)
                {
                    var i = count++%list.Count;
                    return list[i];
                }
                return "";
            }
            else
            {
                return "";
            }
        }


        private List<int> GetRandomNumber(int count, int max)
        {
            List<int> list = new List<int>();
            int i = 0;
            while (list.Count < count)
            {
                int r = new Random(DateTime.Now.Millisecond + i++).Next(max);
                if (!list.Contains(r))
                {
                    list.Add(r);
                }
            }
            return list;
        }
        private DrawLottery CurrentLottery;
      

        /// <summary>
        /// 根据ID载入指定的奖项级其后面的奖项
        /// </summary>
        /// <param name="award"></param>
        /// <returns></returns>
        private DrawLottery LoadAward(int award)
        {
            var lottery = LoadAwardFromConfig();
            while (lottery != null)
            {
                if (lottery.Award == award)
                {
                    return lottery;
                }
                lottery = lottery.NextDrawLottery;
            }
            return null;
        }
        private DrawLottery LoadAwardFromConfig()
        {
            DrawLottery drawLottery = null;
            string awards = ConfigurationManager.AppSettings["AwardConfig"];
            string[] awardArray = awards.Split(';');
            DrawLottery point=null;
            foreach (string award in awardArray)
            {
                var a = InitLottery(award);
               
                if (drawLottery == null)
                {                    
                    drawLottery = a;
                }
                else
                {
                    point.NextDrawLottery = a;
                }
                point = a;
            }
            return drawLottery;
        }
        private DrawLottery InitLottery(string str)
        {
            string[] items = str.Split(',');
            DrawLottery a3 = new DrawLottery(Convert.ToInt32(items[0]));
            a3.AwardString = items[1];
            a3.OnePageCount =Convert.ToInt32( items[2]);
            a3.PageCount = Convert.ToInt32(items[3]);
            a3.OnePageColumn = Convert.ToInt32(items[4]);
            return a3;
        }
        private void DrawLotteryForm_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                this.ShowInTaskbar = false;
                this.TopMost = true;
                //隐藏任务栏： 
                IntPtr handle = FindWindowEx(IntPtr.Zero, IntPtr.Zero, "Shell_TrayWnd ", null);
                ShowWindow(handle, 0);
            }
            else
            {
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
                this.ShowInTaskbar = true;
                this.TopMost = false;
                //显示： 
                IntPtr handle = FindWindowEx(IntPtr.Zero, IntPtr.Zero, "Shell_TrayWnd ", null);
                ShowWindow(handle, 1);
            }
        }
      
        [DllImport("User32.dll ")]
        public static extern IntPtr FindWindowEx(IntPtr ph, IntPtr ch, String cn, String wn);
        [DllImport("User32.dll ")]
        public static extern bool ShowWindow(IntPtr hWnd, long nCmdShow);


        private void DrawLotteryForm_DoubleClick(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void DrawLotteryForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CurrentLottery.NextDrawLottery != null)
            {
                if (MessageBox.Show("抽奖未结束，确认要退出抽奖程序？", "确认关闭", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.Yes)
                {
                    e.Cancel = true;
                }
            }
        }
    }
   

}
