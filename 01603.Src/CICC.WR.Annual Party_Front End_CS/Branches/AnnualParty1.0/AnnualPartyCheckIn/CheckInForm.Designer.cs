using CICC.WR.AnnualPartyControls;
namespace CICC.WR.AnnualParty
{
    partial class CheckInForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lbCheckinCount = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txbEmployeeSearch = new CICC.WR.AnnualPartyControls.DelayTextBox();
            this.photoList1 = new CICC.WR.AnnualPartyControls.PhotoList();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbCheckinCount
            // 
            this.lbCheckinCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbCheckinCount.AutoSize = true;
            this.lbCheckinCount.BackColor = System.Drawing.Color.Transparent;
            this.lbCheckinCount.Font = new System.Drawing.Font("SimSun", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbCheckinCount.ForeColor = System.Drawing.Color.Yellow;
            this.lbCheckinCount.Location = new System.Drawing.Point(456, 10);
            this.lbCheckinCount.Name = "lbCheckinCount";
            this.lbCheckinCount.Size = new System.Drawing.Size(104, 20);
            this.lbCheckinCount.TabIndex = 4;
            this.lbCheckinCount.Text = "已签到0人";
            // 
            // timer1
            // 
            this.timer1.Interval = 10000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("SimSun", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "请输入姓名拼音";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lbCheckinCount);
            this.panel1.Controls.Add(this.txbEmployeeSearch);
            this.panel1.Location = new System.Drawing.Point(169, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(598, 44);
            this.panel1.TabIndex = 6;
            // 
            // txbEmployeeSearch
            // 
            this.txbEmployeeSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txbEmployeeSearch.DelayMillisecond = 500;
            this.txbEmployeeSearch.Font = new System.Drawing.Font("SimSun", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txbEmployeeSearch.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txbEmployeeSearch.Location = new System.Drawing.Point(172, 7);
            this.txbEmployeeSearch.Name = "txbEmployeeSearch";
            this.txbEmployeeSearch.Size = new System.Drawing.Size(254, 30);
            this.txbEmployeeSearch.TabIndex = 0;
            this.txbEmployeeSearch.DelayTextChanged += new System.EventHandler(this.txbEmployeeSearch_TextChanged);
            // 
            // photoList1
            // 
            this.photoList1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.photoList1.AutoPictureSize = false;
            this.photoList1.AutoScroll = true;
            this.photoList1.BackColor = System.Drawing.Color.Transparent;
            this.photoList1.CellHeight = 25;
            this.photoList1.CellWidth = 45;
            this.photoList1.Columns = 5;
            this.photoList1.ItemAlign = System.Drawing.ContentAlignment.TopCenter;
            this.photoList1.Location = new System.Drawing.Point(78, 80);
            this.photoList1.Name = "photoList1";
            this.photoList1.PictureBorderWidth = 4;
            this.photoList1.PictureSize = new System.Drawing.Size(120, 155);
            this.photoList1.Rows = 0;
            this.photoList1.ShowContextMenu = true;
            this.photoList1.Size = new System.Drawing.Size(845, 700);
            this.photoList1.TabIndex = 3;
            this.photoList1.UserCheckin += new System.EventHandler(this.photoList1_UserCheckin);
            this.photoList1.UserCheckout += new System.EventHandler(this.photoList1_UserCheckout);
            this.photoList1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.photoList1_Scroll);
            // 
            // CheckInForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(924, 785);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.photoList1);
            this.DoubleBuffered = true;
            this.Name = "CheckInForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "年会签到";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.CheckInForm_Load);
            this.DoubleClick += new System.EventHandler(this.CheckInForm_DoubleClick);
            this.Resize += new System.EventHandler(this.CheckInForm_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DelayTextBox txbEmployeeSearch;
        private PhotoList photoList1;
        private System.Windows.Forms.Label lbCheckinCount;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
    }
}

