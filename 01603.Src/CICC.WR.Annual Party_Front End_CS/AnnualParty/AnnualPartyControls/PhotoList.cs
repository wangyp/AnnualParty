using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using CICC.WR.AnnualPartyDAL;
using System.Drawing.Drawing2D;

namespace CICC.WR.AnnualPartyControls
{
    public partial class PhotoList : UserControl
    {
        public PhotoList()
        {
            InitializeComponent();
        }
        private int cellWidth = 45;
        [Browsable(true)]
        [Category("UserDefine")]
        [Description("照片间的宽度间隙")]
        public int CellWidth
        {
            get { return cellWidth; }
            set { cellWidth = value; }
        }
        private int cellHeight = 15;
        [Browsable(true)]
        [Category("UserDefine")]
        [Description("照片间的高度间隙")]
        public int CellHeight
        {
            get { return cellHeight; }
            set { cellHeight = value; }
        }

        private int rows = 4, columns = 5;
         [Browsable(true)]
         [Category("UserDefine")]
         [Description("照片显示的列数")]
        public int Columns
        {
            get { return columns; }
            set { columns = value; }
        }
        [Browsable(true)]
        [Category("UserDefine")]
        [Description("照片显示的行数，如果没有行数限制，将该值设为0")]
        public int Rows
        {
            get { return rows; }
            set { rows = value; }
        }
        private Size pictureSize=new Size(120,155);
        private List<UserPhotoItem> pics;
        [Browsable(true)]
        [Category("UserDefine")]
        [Description("照片和名字的大小")]
        public Size PictureSize
        {
            get { return pictureSize; }
            set { pictureSize = value; }
        }
        private int pictureBorderWidth = 4;
        [Browsable(true)]
        [Category("UserDefine")]
        [Description("照片和名字的边框宽度")]
        public int PictureBorderWidth
        {
            get { return pictureBorderWidth; }
            set { pictureBorderWidth = value; }
        }

        private bool showContextMenu = false;
        [Browsable(true)]
        [Category("UserDefine")]
        [Description("显示菜单")]
        public bool ShowContextMenu
        {
            get { return showContextMenu; }
            set { showContextMenu = value; }
        }

        private bool autoPictureSize = false;

        [Browsable(true)]
        [Category("UserDefine")]
        [Description("忽略用户指定的PictureSize属性，根据控件宽度和Columns属性自动计算图片的大小和位置")]
        public bool AutoPictureSize
        {
            get { return autoPictureSize; }
            set
            {
                autoPictureSize = value;
                AutoSetPictureSize();
            }
        }

        private bool showLabel = true;
        [Browsable(true)]
        [Category("UserDefine")]
        public bool ShowLabel
        {
            get { return showLabel; }
            set { showLabel = value; }
        }

        private void AutoSetPictureSize()
        {
            if (autoPictureSize)
            {
                var w = (this.Width - cellWidth * (columns - 1)) / columns - pictureBorderWidth * 2;
                var h =(int)( w * 1.3);
                var totalHeight = h*rows + cellHeight*(rows - 1);
                if (totalHeight > this.Height)
                {
                    w = w * this.Height / totalHeight;
                    h = (int)(w * 1.3);
                }
                this.pictureSize = new Size(w, h);
            }
        }
        private ContentAlignment itemAlign = ContentAlignment.MiddleLeft;

        public ContentAlignment ItemAlign
        {
            get { return itemAlign; }
            set { itemAlign = value; }
        }
        
        /// <summary>
        /// 初始化指定数量的照片控件
        /// </summary>
        /// <param name="count"></param>
        public void InitPictureBox(int count)
        {
            int c = 0;
           pics = new  List<UserPhotoItem> ();
           int rowMax = rows==0?99999:rows;
            //调整位置
           int adjustX = 0, adjustY = 0;
           if (itemAlign == ContentAlignment.MiddleCenter || itemAlign == ContentAlignment.MiddleLeft || itemAlign == ContentAlignment.MiddleRight)
           {
               int rowCount = (int)Math.Ceiling(count*1.0 / columns);
               var needY = rowCount * (pictureSize.Height + 2 * pictureBorderWidth) + (rowCount - 1) * cellHeight;
               adjustY = (this.Height - needY) / 2;
           }
           if (itemAlign == ContentAlignment.BottomCenter || itemAlign == ContentAlignment.MiddleCenter || itemAlign == ContentAlignment.TopCenter)
           {
               var needX = columns * (pictureSize.Width + 2 * pictureBorderWidth) + (columns - 1) * cellWidth;
               adjustX = (this.Width - needX) / 2;
           }
           if (itemAlign == ContentAlignment.BottomRight || itemAlign == ContentAlignment.MiddleRight || itemAlign == ContentAlignment.TopRight)
           {
               var needX = columns * (pictureSize.Width + 2 * pictureBorderWidth) + (columns - 1) * cellWidth;
               adjustX = this.Width - needX;
           }
            //初始化照片控件
           for (int row = 0; row < rowMax; row++)
            {
                for (int column = 0; column < Columns; column++)
                {
                    if (count == c)
                    {
                        return ;
                    }
                    UserPhotoItem p = new UserPhotoItem();
                    p.ShowLabel = showLabel;
                    p.Size = pictureSize;
                    p.ShowContextMenu = showContextMenu;
                    int width = pictureSize.Width + cellWidth;
                    int height = pictureSize.Height + cellHeight;
                    p.Location = new Point(column * width + pictureBorderWidth + adjustX, row * height + pictureBorderWidth + adjustY);
                    p.UserCheckin += new EventHandler(p_UserCheckin);
                    p.UserCheckout += new EventHandler(p_UserCheckout);
                    //p.LocationChanged += new EventHandler(p_LocationChanged);
                    this.Controls.Add(p);
                    this.Controls.Add(CreateBellPic(p));
                    pics.Add(p);
                    c++;
                }
            }
        }

        void p_LocationChanged(object sender, EventArgs e)
        {
            var item = sender as UserPhotoItem;
            item.LinkedControl.Location = new Point(item.Location.X - 20, item.Location.Y - 9);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void p_UserCheckout(object sender, EventArgs e)
        {
            if (UserCheckout != null)
            {
                //var item = sender as UserPhotoItem;
                //item.UserCheckout -= new EventHandler(p_UserCheckout);
                //item.UserCheckin += new EventHandler(p_UserCheckin);

                UserCheckout(sender, e);
                //this.Refresh();
                ShowCheckinFlag(sender as UserPhotoItem);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void p_UserCheckin(object sender, EventArgs e)
        {
            if (UserCheckin != null)
            {
                //var item = sender as UserPhotoItem;
                //item.UserCheckin -= new EventHandler(p_UserCheckin);
                //item.UserCheckout += new EventHandler(p_UserCheckout);
                UserCheckin(sender, e);
                //this.Refresh();
                ShowCheckinFlag(sender as UserPhotoItem);
            }
        }
        List<MyEmployee> empList;
        public void InitEmployeeInfo(List<MyEmployee> emps)
        {
            empList = emps;
        }


        public void ShowPhoto(List<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                MyEmployee emp = empList[list[i]];
                pics[i].Key = emp.EmployeeNumber;
                pics[i].Image = emp.Photo;
                pics[i].Text = emp.Dept + " " + emp.Name;
            }

        }

        public void ShowPhoto(string key, Image img)
        {
            pics[0].Image = img;
            pics[0].Key = key;
        }
        /// <summary>
        /// 显示员工照片
        /// </summary>
        /// <param name="list"></param>
        public void ShowPhoto(List<MyEmployee> list)
        {
            this.Controls.Clear();
            InitPictureBox(list.Count);
          
            for (int i = 0; i < list.Count; i++)
            {
                MyEmployee emp = list[i];
                var item=pics[i];
                item.Key = emp.EmployeeNumber;
                item.Image = emp.Photo;
                item.Text = emp.Dept + " " + emp.Name;
                item.ShowBorder = emp.Checkin;
                ShowCheckinFlag(item);
            }
            //this.Refresh();
        }
        /// <summary>
        /// 获得中奖者的工号
        /// </summary>
        /// <returns></returns>
        public List<string> GetLotteryEmployeeNumber()
        {
            List<string> lotteries = new List<string>();
            foreach (UserPhotoItem item in pics)
            {
                lotteries.Add(item.Key);
            }
            return lotteries;
        }

        public event EventHandler UserCheckin;

        public event EventHandler UserCheckout;

        private void PhotoList_Paint(object sender, PaintEventArgs e)
        {
            //var g = e.Graphics;
            //Pen p = new Pen(Color.Gold, 12);
            //foreach (Control i in this.Controls)
            //{
            //    if (i is UserPhotoItem)
            //    {
            //        var item = i as UserPhotoItem;
            //        if (item.ShowBorder)
            //        {
            //            //g.DrawRectangle(p, );
            //            //g.DrawPath(p,CreateRoundedRectanglePath(new Rectangle(item.Location.X, item.Location.Y, item.Width, item.Height),5));
            //            //g.DrawImage(ResourceLib.bell, item.Location.X-20, item.Location.Y-10);
            //            item.LinkedControl.Visible = true;
            //        }
            //        else
            //        {
            //            item.LinkedControl.Visible = false;
            //        }
            //        item.ShowRealPhoto(!item.ShowBorder);
            //    }
            //}
        }

        private void ShowCheckinFlag(UserPhotoItem item)
        {
            item.LinkedControl.Location = new Point(item.Location.X - 20, item.Location.Y - 9);
            item.LinkedControl.Visible = item.ShowBorder;
            item.ShowRealPhoto(!item.ShowBorder);
        }

        private PictureBox CreateBellPic(UserPhotoItem item)
        {
            PictureBox p = new PictureBox();
            p.Image = ResourceLib.outbell;
            p.Size = new System.Drawing.Size(33, 42);
            p.Location = new Point(item.Location.X-20,item.Location.Y-9);
            p.Visible = false;
            item.LinkedControl = p;
            return p;
        }
        //GraphicsPath CreateRoundedRectanglePath(Rectangle rect, int cornerRadius)
        //{
        //    GraphicsPath roundedRect = new GraphicsPath();
        //    roundedRect.AddArc(rect.X, rect.Y, cornerRadius * 2, cornerRadius * 2, 180, 90);
        //    roundedRect.AddLine(rect.X + cornerRadius, rect.Y, rect.Right - cornerRadius * 2, rect.Y);
        //    roundedRect.AddArc(rect.X + rect.Width - cornerRadius * 2, rect.Y, cornerRadius * 2, cornerRadius * 2, 270, 90);
        //    roundedRect.AddLine(rect.Right, rect.Y + cornerRadius * 2, rect.Right, rect.Y + rect.Height - cornerRadius * 2);
        //    roundedRect.AddArc(rect.X + rect.Width - cornerRadius * 2, rect.Y + rect.Height - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 0, 90);
        //    roundedRect.AddLine(rect.Right - cornerRadius * 2, rect.Bottom, rect.X + cornerRadius * 2, rect.Bottom);
        //    roundedRect.AddArc(rect.X, rect.Bottom - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 90, 90);
        //    roundedRect.AddLine(rect.X, rect.Bottom - cornerRadius * 2, rect.X, rect.Y + cornerRadius * 2);
        //    roundedRect.CloseFigure();
        //    return roundedRect;
        //}
    }
}
