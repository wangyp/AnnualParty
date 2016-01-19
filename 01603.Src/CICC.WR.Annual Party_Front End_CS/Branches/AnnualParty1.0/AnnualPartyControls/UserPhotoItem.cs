using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace CICC.WR.AnnualPartyControls
{
    public partial class UserPhotoItem : UserControl
    {
        public UserPhotoItem()
        {
            InitializeComponent();
            this.picBell.Parent = pictureBox1;
        }

        private bool showBorder = false;
        [Browsable(true)]
        [Category("UserDefine")]
        public bool ShowBorder
        {
            get { return showBorder; }
            set
            {
                showBorder = value;

                if (showBorder)
                {
                    checkinToolStripMenuItem.Visible = false;
                    checkoutToolStripMenuItem.Visible = true;
                }
                else
                {
                    checkoutToolStripMenuItem.Visible = false;
                    checkinToolStripMenuItem.Visible = true;
                }
            }
        }
        private bool showContextMenu = false;

        public bool ShowContextMenu
        {
            get { return showContextMenu; }
            set
            {
                showContextMenu = value;
                if (showContextMenu)
                {
                    this.pictureBox1.ContextMenuStrip = contextMenuStrip1;
                }
                else
                {
                    this.pictureBox1.ContextMenuStrip = null;
                }
            }
        }
        public  bool ShowLabel
        {
            get { return this.label1.Visible; }
            set { label1.Visible = value; }
        }

        private string key;
        [Browsable(true)]
        [Category("UserDefine")]
        public string Key
        {
            get { return key; }
            set { key = value; }
        }
        public event EventHandler UserCheckin;
        public event EventHandler UserCheckout;
        [Browsable(true)]
        [Category("UserDefine")]
        public Image Image
        {
            get
            {
                return this.pictureBox1.Image;
            }
            set
            {
                realPhoto = value;
                this.pictureBox1.Image = realPhoto;
            }
        }
        public override string Text
        {

            get
            {
                return this.label1.Text;
            }
            set
            {
                this.label1.Text = value;
            }
        }
        [Browsable(true)]
        [Category("UserDefine")]
        [Description("文本的背景色")]
        public Color TextBackColor
        {
            get
            {
                return this.label1.BackColor;
            }
            set
            {
                label1.BackColor = value;
            }
        }
     
        private int borderWidth = 0;
        //[Browsable(true)]
        //[Category("UserDefine")]
        //public int BorderWidth
        //{
        //    get { return borderWidth; }
        //    set
        //    {
        //        var oldWidth = borderWidth;
        //        borderWidth = value;
        //        if (oldWidth != borderWidth)
        //        {
        //            ResetLocationAndWidthByBorderWidth(oldWidth, borderWidth);
        //        }
        //    }
        //}
        //private void ResetLocationAndWidthByBorderWidth(int oldWidth, int borderWidth)
        //{
        //    if (borderWidth == 0)
        //    {
        //        this.Location = new Point(this.Location.X + oldWidth, this.Location.Y + oldWidth);
        //        this.Size = new Size(this.Width - oldWidth * 2, this.Height - oldWidth * 2);
        //    }
        //    else
        //    {
        //        this.Location = new Point(this.Location.X - borderWidth, this.Location.Y - borderWidth);
        //        this.Size = new Size(this.Width + borderWidth * 2, this.Height + borderWidth * 2);
        //    }
        //}
       

        private void UserPhotoItem_SizeChanged(object sender, EventArgs e)
        {
            var size = this.Size;
            var labelHeight = size.Height / 6;
            if (!ShowLabel)
            {
                labelHeight = 0;
            }
            this.pictureBox1.Location = new Point(borderWidth, borderWidth);
            this.pictureBox1.Size = new Size(size.Width - borderWidth * 2, size.Height - labelHeight - borderWidth * 2);
            if (ShowLabel)
            {
                this.label1.Location = new Point(borderWidth, size.Height - labelHeight - borderWidth);
                this.label1.Size = new Size(size.Width - borderWidth*2, labelHeight);
                this.label1.Font = new Font("宋体", labelHeight*0.65f, FontStyle.Bold);
            }
        }
        public void ShowRealPhoto(bool show)
        {
            if (show)
            {
                //this.pictureBox1.Image = realPhoto;
                this.picBell.Visible = false;
            }
            else
            {
                //this.pictureBox1.Image = ResourceLib.checkinUser;
                this.picBell.Visible = true;               
            }
        }
        public Control LinkedControl { get; set; }
        private Image realPhoto;
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MouseEventArgs Mouse_e = e as MouseEventArgs;
            if (Mouse_e == null)
            {
                return;
            }
            if (Mouse_e.Clicks > 1)
            {
                return;
            }
            if (Mouse_e.Button == MouseButtons.Left && UserCheckin != null)
            {
                UserCheckin(this, e);
            }
        }
        //private void pictureBox1_DoubleClick(object sender, EventArgs e)
        //{
        //    MouseEventArgs Mouse_e = e as MouseEventArgs;
        //    if (Mouse_e == null)
        //    {
        //        return;
        //    }
        //    if (Mouse_e.Button == MouseButtons.Left && PicDoubleClick != null)
        //    {
        //        PicDoubleClick(this, e);
        //    }
        //}

        private void checkinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (UserCheckin != null)
            {
                UserCheckin(this, e);
            }
        }

        private void checkoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (UserCheckout != null)
            {
                UserCheckout(this, e);
            }
        }
    }
}
