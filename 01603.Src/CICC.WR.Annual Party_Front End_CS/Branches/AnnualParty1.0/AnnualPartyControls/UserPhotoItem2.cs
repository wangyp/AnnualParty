using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace CICC.WR.AnnualPartyControls
{
    public partial class UserPhotoItem2 : UserControl
    {
        public UserPhotoItem2()
        {
            InitializeComponent();
        
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
      
     
        private int borderWidth = 0;
       

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
        public Control LinkedControl { get; set; }
        private Image realPhoto;

    }
}
