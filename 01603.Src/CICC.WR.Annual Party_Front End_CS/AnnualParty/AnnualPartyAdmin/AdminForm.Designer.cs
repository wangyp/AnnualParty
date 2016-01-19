namespace AnnualPartyAdmin
{
    partial class AdminForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txbEmployeePhotoFolder = new System.Windows.Forms.TextBox();
            this.txbEmployeeListFile = new System.Windows.Forms.TextBox();
            this.btnImportPhoto = new System.Windows.Forms.Button();
            this.btnImportEmployee = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnOpenFolder = new System.Windows.Forms.Button();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnDeleteData = new System.Windows.Forms.Button();
            this.lbTotalEmployee = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClearAward = new System.Windows.Forms.Button();
            this.btnClearCheckin = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.rtbSQL = new System.Windows.Forms.RichTextBox();
            this.txbDBDbName = new System.Windows.Forms.TextBox();
            this.txbDBPassword = new System.Windows.Forms.TextBox();
            this.txbDBUserName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txbDBServer = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnImportFromDB = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label10 = new System.Windows.Forms.Label();
            this.btnNotLottery = new System.Windows.Forms.Button();
            this.rtbNotLotteryEmployeeNumbers = new System.Windows.Forms.RichTextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(323, 317);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txbEmployeePhotoFolder);
            this.tabPage1.Controls.Add(this.txbEmployeeListFile);
            this.tabPage1.Controls.Add(this.btnImportPhoto);
            this.tabPage1.Controls.Add(this.btnImportEmployee);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.btnOpenFolder);
            this.tabPage1.Controls.Add(this.btnOpenFile);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(315, 292);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "员工&照片导入";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txbEmployeePhotoFolder
            // 
            this.txbEmployeePhotoFolder.Location = new System.Drawing.Point(91, 166);
            this.txbEmployeePhotoFolder.Name = "txbEmployeePhotoFolder";
            this.txbEmployeePhotoFolder.Size = new System.Drawing.Size(183, 21);
            this.txbEmployeePhotoFolder.TabIndex = 5;
            // 
            // txbEmployeeListFile
            // 
            this.txbEmployeeListFile.Location = new System.Drawing.Point(91, 76);
            this.txbEmployeeListFile.Name = "txbEmployeeListFile";
            this.txbEmployeeListFile.Size = new System.Drawing.Size(183, 21);
            this.txbEmployeeListFile.TabIndex = 4;
            // 
            // btnImportPhoto
            // 
            this.btnImportPhoto.Location = new System.Drawing.Point(123, 209);
            this.btnImportPhoto.Name = "btnImportPhoto";
            this.btnImportPhoto.Size = new System.Drawing.Size(75, 23);
            this.btnImportPhoto.TabIndex = 3;
            this.btnImportPhoto.Text = "导入照片";
            this.btnImportPhoto.UseVisualStyleBackColor = true;
            this.btnImportPhoto.Click += new System.EventHandler(this.btnImportPhoto_Click);
            // 
            // btnImportEmployee
            // 
            this.btnImportEmployee.Location = new System.Drawing.Point(123, 117);
            this.btnImportEmployee.Name = "btnImportEmployee";
            this.btnImportEmployee.Size = new System.Drawing.Size(75, 23);
            this.btnImportEmployee.TabIndex = 3;
            this.btnImportEmployee.Text = "导入员工";
            this.btnImportEmployee.UseVisualStyleBackColor = true;
            this.btnImportEmployee.Click += new System.EventHandler(this.btnImportEmployee_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 175);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "照片文件夹：";
            this.toolTip1.SetToolTip(this.label4, "照片的文件名为工号");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "员工信息：";
            this.toolTip1.SetToolTip(this.label3, "员工信息包含：工号、姓名、部门，用逗号分隔，每行一个员工");
            // 
            // btnOpenFolder
            // 
            this.btnOpenFolder.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOpenFolder.Location = new System.Drawing.Point(278, 164);
            this.btnOpenFolder.Name = "btnOpenFolder";
            this.btnOpenFolder.Size = new System.Drawing.Size(29, 23);
            this.btnOpenFolder.TabIndex = 0;
            this.btnOpenFolder.Text = "..";
            this.btnOpenFolder.UseVisualStyleBackColor = false;
            this.btnOpenFolder.Click += new System.EventHandler(this.btnOpenFolder_Click);
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOpenFile.Location = new System.Drawing.Point(280, 74);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(29, 23);
            this.btnOpenFile.TabIndex = 0;
            this.btnOpenFile.Text = "..";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnRefresh);
            this.tabPage2.Controls.Add(this.btnDeleteData);
            this.tabPage2.Controls.Add(this.lbTotalEmployee);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.btnClearAward);
            this.tabPage2.Controls.Add(this.btnClearCheckin);
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(315, 292);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "结果清空";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(117, 6);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 9;
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnDeleteData
            // 
            this.btnDeleteData.ForeColor = System.Drawing.Color.Red;
            this.btnDeleteData.Location = new System.Drawing.Point(117, 251);
            this.btnDeleteData.Name = "btnDeleteData";
            this.btnDeleteData.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteData.TabIndex = 8;
            this.btnDeleteData.Text = "清空员工";
            this.btnDeleteData.UseVisualStyleBackColor = true;
            this.btnDeleteData.Click += new System.EventHandler(this.btnDeleteData_Click);
            // 
            // lbTotalEmployee
            // 
            this.lbTotalEmployee.AutoSize = true;
            this.lbTotalEmployee.Location = new System.Drawing.Point(91, 236);
            this.lbTotalEmployee.Name = "lbTotalEmployee";
            this.lbTotalEmployee.Size = new System.Drawing.Size(53, 12);
            this.lbTotalEmployee.TabIndex = 7;
            this.lbTotalEmployee.Text = "总人数：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(91, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "中奖人数：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(91, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "签到人数：";
            // 
            // btnClearAward
            // 
            this.btnClearAward.Location = new System.Drawing.Point(117, 162);
            this.btnClearAward.Name = "btnClearAward";
            this.btnClearAward.Size = new System.Drawing.Size(75, 23);
            this.btnClearAward.TabIndex = 5;
            this.btnClearAward.Text = "清空中奖";
            this.btnClearAward.UseVisualStyleBackColor = true;
            this.btnClearAward.Click += new System.EventHandler(this.btnClearAward_Click);
            // 
            // btnClearCheckin
            // 
            this.btnClearCheckin.Location = new System.Drawing.Point(117, 72);
            this.btnClearCheckin.Name = "btnClearCheckin";
            this.btnClearCheckin.Size = new System.Drawing.Size(75, 23);
            this.btnClearCheckin.TabIndex = 4;
            this.btnClearCheckin.Text = "清空签到";
            this.btnClearCheckin.UseVisualStyleBackColor = false;
            this.btnClearCheckin.Click += new System.EventHandler(this.btnClearCheckin_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.rtbSQL);
            this.tabPage3.Controls.Add(this.txbDBDbName);
            this.tabPage3.Controls.Add(this.txbDBPassword);
            this.tabPage3.Controls.Add(this.txbDBUserName);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.txbDBServer);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.btnImportFromDB);
            this.tabPage3.Location = new System.Drawing.Point(4, 21);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(315, 292);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "数据库导入";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 173);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 4;
            this.label9.Text = "SQL:";
            // 
            // rtbSQL
            // 
            this.rtbSQL.Location = new System.Drawing.Point(48, 170);
            this.rtbSQL.Name = "rtbSQL";
            this.rtbSQL.Size = new System.Drawing.Size(249, 79);
            this.rtbSQL.TabIndex = 3;
            this.rtbSQL.Text = resources.GetString("rtbSQL.Text");
            // 
            // txbDBDbName
            // 
            this.txbDBDbName.Location = new System.Drawing.Point(128, 134);
            this.txbDBDbName.Name = "txbDBDbName";
            this.txbDBDbName.Size = new System.Drawing.Size(129, 21);
            this.txbDBDbName.TabIndex = 2;
            this.txbDBDbName.Text = "hrdb2";
            // 
            // txbDBPassword
            // 
            this.txbDBPassword.Location = new System.Drawing.Point(128, 97);
            this.txbDBPassword.Name = "txbDBPassword";
            this.txbDBPassword.PasswordChar = '*';
            this.txbDBPassword.Size = new System.Drawing.Size(129, 21);
            this.txbDBPassword.TabIndex = 2;
            // 
            // txbDBUserName
            // 
            this.txbDBUserName.Location = new System.Drawing.Point(128, 61);
            this.txbDBUserName.Name = "txbDBUserName";
            this.txbDBUserName.Size = new System.Drawing.Size(129, 21);
            this.txbDBUserName.TabIndex = 2;
            this.txbDBUserName.Text = "HRphotoTemp";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(69, 137);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 1;
            this.label8.Text = "数据库：";
            // 
            // txbDBServer
            // 
            this.txbDBServer.Location = new System.Drawing.Point(128, 26);
            this.txbDBServer.Name = "txbDBServer";
            this.txbDBServer.Size = new System.Drawing.Size(129, 21);
            this.txbDBServer.TabIndex = 2;
            this.txbDBServer.Text = "192.168.142.98";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(81, 100);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 1;
            this.label7.Text = "密码：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(69, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 1;
            this.label6.Text = "用户名：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "数据库服务器：";
            // 
            // btnImportFromDB
            // 
            this.btnImportFromDB.Location = new System.Drawing.Point(106, 255);
            this.btnImportFromDB.Name = "btnImportFromDB";
            this.btnImportFromDB.Size = new System.Drawing.Size(102, 31);
            this.btnImportFromDB.TabIndex = 0;
            this.btnImportFromDB.Text = "清空并重新导入";
            this.btnImportFromDB.UseVisualStyleBackColor = true;
            this.btnImportFromDB.Click += new System.EventHandler(this.btnImportFromDB_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.label10);
            this.tabPage4.Controls.Add(this.btnNotLottery);
            this.tabPage4.Controls.Add(this.rtbNotLotteryEmployeeNumbers);
            this.tabPage4.Location = new System.Drawing.Point(4, 21);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(315, 292);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "不抽奖";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoEllipsis = true;
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(4, 11);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(305, 12);
            this.label10.TabIndex = 2;
            this.label10.Text = "请将不参加抽奖的员工号粘贴到下面文本框中，一行一个";
            // 
            // btnNotLottery
            // 
            this.btnNotLottery.Location = new System.Drawing.Point(232, 261);
            this.btnNotLottery.Name = "btnNotLottery";
            this.btnNotLottery.Size = new System.Drawing.Size(75, 23);
            this.btnNotLottery.TabIndex = 1;
            this.btnNotLottery.Text = "确定";
            this.btnNotLottery.UseVisualStyleBackColor = true;
            this.btnNotLottery.Click += new System.EventHandler(this.btnNotLottery_Click);
            // 
            // rtbNotLotteryEmployeeNumbers
            // 
            this.rtbNotLotteryEmployeeNumbers.Location = new System.Drawing.Point(8, 33);
            this.rtbNotLotteryEmployeeNumbers.Name = "rtbNotLotteryEmployeeNumbers";
            this.rtbNotLotteryEmployeeNumbers.Size = new System.Drawing.Size(299, 222);
            this.rtbNotLotteryEmployeeNumbers.TabIndex = 0;
            this.rtbNotLotteryEmployeeNumbers.Text = "";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 317);
            this.Controls.Add(this.tabControl1);
            this.MaximizeBox = false;
            this.Name = "AdminForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "年会程序配置管理";
            this.Load += new System.EventHandler(this.AwardOperation_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClearAward;
        private System.Windows.Forms.Button btnClearCheckin;
        private System.Windows.Forms.TextBox txbEmployeePhotoFolder;
        private System.Windows.Forms.TextBox txbEmployeeListFile;
        private System.Windows.Forms.Button btnImportPhoto;
        private System.Windows.Forms.Button btnImportEmployee;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnOpenFolder;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnDeleteData;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox txbDBDbName;
        private System.Windows.Forms.TextBox txbDBPassword;
        private System.Windows.Forms.TextBox txbDBUserName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txbDBServer;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnImportFromDB;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RichTextBox rtbSQL;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lbTotalEmployee;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnNotLottery;
        private System.Windows.Forms.RichTextBox rtbNotLotteryEmployeeNumbers;
    }
}

