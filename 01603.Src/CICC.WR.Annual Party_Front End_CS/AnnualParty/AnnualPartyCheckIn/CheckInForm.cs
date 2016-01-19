using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.Runtime.InteropServices;
using CICC.WR.AnnualPartyDAL;
using System.IO;
using CICC.WR.AnnualPartyControls;
using System.Configuration;
using log4net;

namespace CICC.WR.AnnualParty
{
    public partial class CheckInForm : Form
    {

        [System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint = "SetForegroundWindow")]
        public static extern bool SetF(IntPtr hWnd);//设置此窗体为活动窗体
        private ILog log = LogManager.GetLogger(typeof(CheckInForm));
        public CheckInForm()
        {
            InitializeComponent();
            LoadBackgroupImage();
            //this.Cursor = CursorHelper.GetDefineCursor();
        }

        private void LoadBackgroupImage()
        {
            string fileName = ConfigurationManager.AppSettings["backgroudImage"];
            Bitmap bmp = new Bitmap(fileName);
            this.BackgroundImage = bmp;
        }

        private void txbEmployeeSearch_TextChanged(object sender, EventArgs e)
        {
            var input = txbEmployeeSearch.Text.Replace(" ", "");
            if (input.Length >= 2)
            {
                var enumbers = AnnualPartySqlHelper.Instance.SearchEmployee(input);
            
                foreach (Employee emp in enumbers)
                {
                    emp.Photo = GlobalData.EmployeePhotos[emp.EmployeeNumber];
                }
                photoList1.ShowPhoto(enumbers);
            }
        }

        private void CheckInForm_Load(object sender, EventArgs e)
        {
            LoadEmployeeData();            
        }
        private void LoadEmployeeData()
        {
            Splash.Status = "载入员工列表……";
            GlobalData.Employees = AnnualPartySqlHelper.Instance.GetAllEmployee(false);
            Splash.Status = "载入员工照片……";
            int i = 0;
            int count=GlobalData.Employees.Count;
            foreach(string number in GlobalData.Employees.Keys)
            {
                GlobalData.EmployeePhotos.Add(number, AnnualPartySqlHelper.Instance.GetEmployeePhoto(number));
                i++;
                Splash.Status = "载入员工照片 " + i + "/" + count;
            }
            Splash.Status = "载入数据完毕，初始化界面";
            Splash.Close();
            this.WindowState = FormWindowState.Maximized;
            timer1.Start();
            timer1_Tick(null, null);
            SetF(this.Handle);
        }


        [DllImport("User32.dll ")]
        public static extern IntPtr FindWindowEx(IntPtr ph, IntPtr ch, String cn, String wn);
        [DllImport("User32.dll ")]
        public static extern bool ShowWindow(IntPtr hWnd, long nCmdShow);

        private void CheckInForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                this.ShowInTaskbar = false;
                //隐藏任务栏： 
                IntPtr handle = FindWindowEx(IntPtr.Zero, IntPtr.Zero, "Shell_TrayWnd ", null);
                ShowWindow(handle, 0);
            }
            else
            {
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
                this.ShowInTaskbar = true;
                //显示： 
                IntPtr handle = FindWindowEx(IntPtr.Zero, IntPtr.Zero, "Shell_TrayWnd ", null);
                ShowWindow(handle, 1);
            }
            AdjustControlSize();
        }

        private void AdjustControlSize()
        {
            if (this.Height == 1024)
            {
                this.panel1.Location = new Point(this.panel1.Location.X, 50);
                this.photoList1.Location = new Point(this.photoList1.Location.X, 130);
            }           
            if (this.Height == 864)
            {
                this.panel1.Location = new Point(this.panel1.Location.X, 40);
                this.photoList1.Location = new Point(this.photoList1.Location.X, 120);
            }
            if (this.Height == 768)
            {
                this.panel1.Location = new Point(this.panel1.Location.X, 30);
                this.photoList1.Location = new Point(this.photoList1.Location.X, 80);
                this.photoList1.CellHeight = 20;
            }
            if (this.Width == 1280 || this.Width == 1152)
            {
                this.panel1.Location = new Point(300, this.panel1.Location.Y);
            }
            if (this.Width == 1024)
            {
                this.panel1.Location = new Point(250, this.panel1.Location.Y);
            }
        }

        private void CheckInForm_DoubleClick(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void photoList1_UserCheckin(object sender, EventArgs e)
        {
            var item = sender as UserPhotoItem;
            var number = item.Key;
            if (AnnualPartySqlHelper.Instance.CheckIn(number))
            {
                log.Info("员工"+number + "签到");
                //item.BorderWidth = pictureBorderWidth;
                //item.BorderColor = Color.Yellow;
                //item.Size = new Size(item.Width + pictureBorderWidth * 2, item.Height + pictureBorderWidth * 2);
                //item.Location = new Point(item.Location.X - pictureBorderWidth, item.Location.Y - pictureBorderWidth);
                item.ShowBorder = true;
                //MessageBox.Show("签到成功");
                timer1_Tick(null, null);
                this.txbEmployeeSearch.Text = "";
                txbEmployeeSearch.Focus();
            }
        
        }

        private void photoList1_UserCheckout(object sender, EventArgs e)
        {
            var item = sender as UserPhotoItem;
            if (MessageBox.Show("确认要取消签到，取消签到将不会参与抽奖", "确认取消", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (AnnualPartySqlHelper.Instance.CheckOut(item.Key))
                {
                    log.Info("员工" + item.Key + "被取消签到");
                    item.ShowBorder = false;
                    timer1_Tick(null, null);
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.lbCheckinCount.Text = "已签到" + AnnualPartySqlHelper.Instance.GetCheckInCount() + "人";
        }

        private void photoList1_Scroll(object sender, ScrollEventArgs e)
        {

            photoList1.Refresh();
        }
    }
}
