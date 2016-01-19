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
    public partial class PhotoList2 : UserControl
    {
        public PhotoList2()
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
        private List<UserPhotoItem2> pics;
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
                //this.imageList1.ImageSize=new Size(w,h);
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
           pics = new  List<UserPhotoItem2> ();
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
                    UserPhotoItem2 p = new UserPhotoItem2();
                    p.ShowLabel = showLabel;
                    p.Size = pictureSize;

                    int width = pictureSize.Width + cellWidth;
                    int height = pictureSize.Height + cellHeight;
                    p.Location = new Point(column * width + pictureBorderWidth + adjustX, row * height + pictureBorderWidth + adjustY);
                    this.Controls.Add(p);
                    pics.Add(p);
                    c++;
                }
            }
        }


        List<Employee> empList;
        public void InitEmployeeInfo(List<Employee> emps)
        {
            empList = emps;
            //imageList1.Images.Clear();
            //foreach (var employee in emps)
            //{
            //    imageList1.Images.Add(employee.EmployeeNumber, employee.Photo);
            //}
        }


        public void ShowPhoto(List<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Employee emp = empList[list[i]];
                pics[i].Key = emp.EmployeeNumber;
                pics[i].Image = emp.Photo;
                //pics[i].Image = imageList1.Images[emp.EmployeeNumber];
                pics[i].Text = emp.Dept +" "+ emp.Name;
            }

        }

        public void ShowPhoto(string key, Image img)
        {
            pics[0].Image = img;
            pics[0].Key = key;
        }
      
        /// <summary>
        /// 获得中奖者的工号
        /// </summary>
        /// <returns></returns>
        public List<string> GetLotteryEmployeeNumber()
        {
            List<string> lotteries = new List<string>();
            foreach (UserPhotoItem2 item in pics)
            {
                lotteries.Add(item.Key);
            }
            return lotteries;
        }

       
    }
}
