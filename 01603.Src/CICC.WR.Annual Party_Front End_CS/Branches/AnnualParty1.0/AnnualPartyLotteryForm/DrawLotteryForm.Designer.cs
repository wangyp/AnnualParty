using CICC.WR.AnnualPartyControls;
namespace CICC.WR.AnnualParty
{
    partial class DrawLotteryForm
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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.lbAwardLevelText = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.photoList1 = new CICC.WR.AnnualPartyControls.PhotoList2();
            this.SuspendLayout();
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // lbAwardLevelText
            // 
            this.lbAwardLevelText.BackColor = System.Drawing.Color.Transparent;
            this.lbAwardLevelText.Font = new System.Drawing.Font("KaiTi_GB2312", 40F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbAwardLevelText.ForeColor = System.Drawing.Color.Yellow;
            this.lbAwardLevelText.Location = new System.Drawing.Point(7, 12);
            this.lbAwardLevelText.Name = "lbAwardLevelText";
            this.lbAwardLevelText.Size = new System.Drawing.Size(56, 168);
            this.lbAwardLevelText.TabIndex = 3;
            this.lbAwardLevelText.Text = "四等奖";
            this.lbAwardLevelText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("KaiTi_GB2312", 40F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(831, 393);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 299);
            this.label1.TabIndex = 4;
            this.label1.Text = "幸运大抽奖";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // photoList1
            // 
            this.photoList1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.photoList1.AutoPictureSize = true;
            this.photoList1.BackColor = System.Drawing.Color.Transparent;
            this.photoList1.CellHeight = 10;
            this.photoList1.CellWidth = 20;
            this.photoList1.Columns = 5;
            this.photoList1.ItemAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.photoList1.Location = new System.Drawing.Point(67, 5);
            this.photoList1.Name = "photoList1";
            this.photoList1.PictureBorderWidth = 4;
            this.photoList1.PictureSize = new System.Drawing.Size(122, 157);
            this.photoList1.Rows = 4;
            this.photoList1.ShowContextMenu = false;
            this.photoList1.Size = new System.Drawing.Size(762, 706);
            this.photoList1.TabIndex = 2;
            // 
            // DrawLotteryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(900, 718);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbAwardLevelText);
            this.Controls.Add(this.photoList1);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.Name = "DrawLotteryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "年会抽奖";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DrawLotteryForm_FormClosing);
            this.Load += new System.EventHandler(this.DrawLotteryForm_Load);
            this.DoubleClick += new System.EventHandler(this.DrawLotteryForm_DoubleClick);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DrawLotteryForm_KeyDown);
            this.Resize += new System.EventHandler(this.DrawLotteryForm_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private PhotoList2 photoList1;
        private System.Windows.Forms.Label lbAwardLevelText;
        private System.Windows.Forms.Label label1;
    }
}