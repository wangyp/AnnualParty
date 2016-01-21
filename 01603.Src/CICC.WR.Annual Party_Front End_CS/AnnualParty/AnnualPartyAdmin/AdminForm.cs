using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using CICC.WR.AnnualPartyDAL;
using AnnualPartyAdmin.Properties;
using log4net;
namespace AnnualPartyAdmin
{
    public partial class AdminForm : Form
    {
        private ILog log = LogManager.GetLogger(typeof(AdminForm));
        public AdminForm()
        {
            InitializeComponent();
            SinglePinYin = new Dictionary<char, string>();
            string[] chars = Resources.SinglePinYin.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string str in chars)
            {
                SinglePinYin.Add(str.Split(',')[0][0], str.Split(',')[1]);
            }

        }
        private void AwardOperation_Load(object sender, EventArgs e)
        {
            ShowDbStatus();
        }

        private void ShowDbStatus()
        {
            this.label1.Text = "签到人数：" + AnnualPartySqlHelper.Instance.GetCheckInCount();
            this.label2.Text = "中奖人数：" + AnnualPartySqlHelper.Instance.GetAwardUserCount();
            this.lbTotalEmployee.Text = "总人数：" + AnnualPartySqlHelper.Instance.GetTotalUserCount() + ",总照片数：" +
                                        AnnualPartySqlHelper.Instance.GetTotalUserPhotoCount();
        }

        private void btnClearCheckin_Click(object sender, EventArgs e)
        {
            AnnualPartySqlHelper.Instance.ClearCheckIn();
            AwardOperation_Load(null, null);
        }

        private void btnClearAward_Click(object sender, EventArgs e)
        {
            AnnualPartySqlHelper.Instance.ClearAward();
            AwardOperation_Load(null, null);
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.txbEmployeeListFile.Text = openFileDialog1.FileName;
            }
        }

        private void btnOpenFolder_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txbEmployeePhotoFolder.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void btnImportEmployee_Click(object sender, EventArgs e)
        {
            string txt = "";
            try
            {
                StreamReader sr = new StreamReader(txbEmployeeListFile.Text);
                txt = sr.ReadToEnd();
                sr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            string[] empList = txt.Split(new string[] {"\r\n"}, StringSplitOptions.RemoveEmptyEntries);
            foreach (string empstr in empList)
            {
                string[] empinfo = empstr.Split(',');
                MyEmployee emp = new MyEmployee() {EmployeeNumber = empinfo[0], Name = empinfo[1], Dept = empinfo[2]};
                string shortpy = "";
                emp.Pinyin = GetPinyin(emp.Name, out shortpy);
                emp.ShortPinyin = shortpy;
                AnnualPartySqlHelper.Instance.InitEmployee(emp);
            }
            MessageBox.Show("成功导入员工" + empList.Length + "个");

        }
        /// <summary>
        /// 获得名字的拼音和拼音缩写
        /// </summary>
        /// <param name="name"></param>
        /// <param name="shortPinyin"></param>
        /// <returns></returns>
        private string GetPinyin(string name,out string shortPinyin)
        {
            string py="";
            string shortpy="";
            foreach (char c in name)
            {
                try
                {
                    var p=SinglePinYin[c];
                    py += p;
                    shortpy += p[0];
                }
                catch(Exception ex)
                {
                    log.Error(c + "找不到拼音", ex);
                }
            }
            shortPinyin = shortpy;
            return py;
        }
        private Dictionary<char, string> SinglePinYin
        {
            get;
            set;
        }

        private void btnDeleteData_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认要清空员工和照片内容？该操作将无法恢复", "确认删除", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                AnnualPartySqlHelper.Instance.DeleteTableData();
                MessageBox.Show("清空完成");
            }
        }

        private void btnImportPhoto_Click(object sender, EventArgs e)
        {
            DirectoryInfo dir = new DirectoryInfo(this.txbEmployeePhotoFolder.Text);
            foreach (FileInfo file in dir.GetFiles("*.jpg"))
            {
                try
                {
                    Image img = new Bitmap(file.FullName);
                    string number = Path.GetFileNameWithoutExtension(file.FullName);

                    AnnualPartySqlHelper.Instance.InitPhoto(number, img);
                }
                catch (Exception ex)
                {
                    log.Error("导入照片" + file.FullName + "发生异常", ex);
                }
            }
            MessageBox.Show("导入后的照片总数：" + AnnualPartySqlHelper.Instance.GetPhotoCount());
        }

        private void btnImportFromDB_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("导入将会导致所有现有数据清空，并且导入过程可能需要等待几分钟的时间，确认要进行导入？", "确认导入", MessageBoxButtons.YesNo) != System.Windows.Forms.DialogResult.Yes)
            {
                return;
            }
            //photo8668!
            string conn = "server=" + txbDBServer.Text + ";database=" + txbDBDbName.Text + ";uid=" + txbDBUserName.Text +
                          ";password=" + txbDBPassword.Text;
            Pinyin py = new Pinyin();
            try
            {
                List<MyEmployee> empList = AnnualPartySqlHelper.Instance.GetAllEmployeeFromHrDB(conn, rtbSQL.Text);
                MessageBox.Show("从HR系统读取了" + empList.Count + "个用户，点击确定开始导入");
                AnnualPartySqlHelper.Instance.DeleteTableData();
                foreach (MyEmployee emp in empList)
                {
                    try
                    {
                        emp.ShortPinyin = py.GetPinyinShort(emp.Name);
                    }
                    catch (Exception ex)
                    {
                        log.Error(emp.Name + "拼音获取有误", ex);
                    }
                    AnnualPartySqlHelper.Instance.InitEmployee(emp);
                    if (emp.Photo != null)
                    {
                        AnnualPartySqlHelper.Instance.InitPhoto(emp.EmployeeNumber, emp.Photo);
                    }
                }
                MessageBox.Show("成功导入员工信息" + empList.Count + "个");
            }
            catch(Exception ex)
            {
                MessageBox.Show("导入失败，错误消息：" + ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ShowDbStatus();
        }

        private void btnNotLottery_Click(object sender, EventArgs e)
        {
            var eNumbers = rtbNotLotteryEmployeeNumbers.Text.Split(new char[] {'\r', '\n'},
                                                                   StringSplitOptions.RemoveEmptyEntries);
            foreach (var number in eNumbers)
            {
                AnnualPartySqlHelper.Instance.UpdateAward(number, 5, "不参加抽奖");
            }
            MessageBox.Show("处理完成");
        }

        private void btnCheckinAll_Click(object sender, EventArgs e)
        {
            AnnualPartySqlHelper.Instance.CheckInAll();
            MessageBox.Show("处理完成");
        }
    }
}
