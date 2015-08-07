namespace SystemModle
{
    partial class frmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.ofdSiteMap = new System.Windows.Forms.OpenFileDialog();
            this.gpMain = new System.Windows.Forms.GroupBox();
            this.rbtLevel3 = new System.Windows.Forms.RadioButton();
            this.rbtLevel2 = new System.Windows.Forms.RadioButton();
            this.labLevel = new System.Windows.Forms.Label();
            this.labConnectString = new System.Windows.Forms.Label();
            this.tbxConnectString = new System.Windows.Forms.TextBox();
            this.btnSet = new System.Windows.Forms.Button();
            this.btnBrowser = new System.Windows.Forms.Button();
            this.labSiteMapPath = new System.Windows.Forms.Label();
            this.tbxPath = new System.Windows.Forms.TextBox();
            this.btnBuildMod = new System.Windows.Forms.Button();
            this.btnBuildCodeFile = new System.Windows.Forms.Button();
            this.btnSetPermission = new System.Windows.Forms.Button();
            this.gpMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // ofdSiteMap
            // 
            this.ofdSiteMap.FileName = "openFileDialog1";
            // 
            // gpMain
            // 
            this.gpMain.Controls.Add(this.rbtLevel3);
            this.gpMain.Controls.Add(this.rbtLevel2);
            this.gpMain.Controls.Add(this.labLevel);
            this.gpMain.Controls.Add(this.labConnectString);
            this.gpMain.Controls.Add(this.tbxConnectString);
            this.gpMain.Controls.Add(this.btnSet);
            this.gpMain.Controls.Add(this.btnBrowser);
            this.gpMain.Controls.Add(this.labSiteMapPath);
            this.gpMain.Controls.Add(this.tbxPath);
            this.gpMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.gpMain.Location = new System.Drawing.Point(0, 0);
            this.gpMain.Name = "gpMain";
            this.gpMain.Size = new System.Drawing.Size(520, 107);
            this.gpMain.TabIndex = 12;
            this.gpMain.TabStop = false;
            this.gpMain.Text = "设置";
            // 
            // rbtLevel3
            // 
            this.rbtLevel3.AutoSize = true;
            this.rbtLevel3.Checked = true;
            this.rbtLevel3.Location = new System.Drawing.Point(183, 77);
            this.rbtLevel3.Name = "rbtLevel3";
            this.rbtLevel3.Size = new System.Drawing.Size(71, 16);
            this.rbtLevel3.TabIndex = 22;
            this.rbtLevel3.TabStop = true;
            this.rbtLevel3.Text = "三级菜单";
            this.rbtLevel3.UseVisualStyleBackColor = true;
            // 
            // rbtLevel2
            // 
            this.rbtLevel2.AutoSize = true;
            this.rbtLevel2.Location = new System.Drawing.Point(106, 77);
            this.rbtLevel2.Name = "rbtLevel2";
            this.rbtLevel2.Size = new System.Drawing.Size(71, 16);
            this.rbtLevel2.TabIndex = 21;
            this.rbtLevel2.Text = "两级菜单";
            this.rbtLevel2.UseVisualStyleBackColor = true;
            // 
            // labLevel
            // 
            this.labLevel.AutoSize = true;
            this.labLevel.Location = new System.Drawing.Point(35, 79);
            this.labLevel.Name = "labLevel";
            this.labLevel.Size = new System.Drawing.Size(65, 12);
            this.labLevel.TabIndex = 20;
            this.labLevel.Text = "菜单级别：";
            // 
            // labConnectString
            // 
            this.labConnectString.AutoSize = true;
            this.labConnectString.Location = new System.Drawing.Point(23, 51);
            this.labConnectString.Name = "labConnectString";
            this.labConnectString.Size = new System.Drawing.Size(77, 12);
            this.labConnectString.TabIndex = 19;
            this.labConnectString.Text = "数据库连接：";
            // 
            // tbxConnectString
            // 
            this.tbxConnectString.Location = new System.Drawing.Point(106, 48);
            this.tbxConnectString.Name = "tbxConnectString";
            this.tbxConnectString.ReadOnly = true;
            this.tbxConnectString.Size = new System.Drawing.Size(327, 21);
            this.tbxConnectString.TabIndex = 18;
            // 
            // btnSet
            // 
            this.btnSet.Location = new System.Drawing.Point(439, 46);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(75, 23);
            this.btnSet.TabIndex = 17;
            this.btnSet.Text = "配置";
            this.btnSet.UseVisualStyleBackColor = true;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // btnBrowser
            // 
            this.btnBrowser.Location = new System.Drawing.Point(439, 18);
            this.btnBrowser.Name = "btnBrowser";
            this.btnBrowser.Size = new System.Drawing.Size(75, 23);
            this.btnBrowser.TabIndex = 14;
            this.btnBrowser.Text = "浏览";
            this.btnBrowser.UseVisualStyleBackColor = true;
            this.btnBrowser.Click += new System.EventHandler(this.btnBrowser_Click);
            // 
            // labSiteMapPath
            // 
            this.labSiteMapPath.AutoSize = true;
            this.labSiteMapPath.Location = new System.Drawing.Point(11, 23);
            this.labSiteMapPath.Name = "labSiteMapPath";
            this.labSiteMapPath.Size = new System.Drawing.Size(89, 12);
            this.labSiteMapPath.TabIndex = 13;
            this.labSiteMapPath.Text = "站点地图路径：";
            // 
            // tbxPath
            // 
            this.tbxPath.Location = new System.Drawing.Point(106, 20);
            this.tbxPath.Name = "tbxPath";
            this.tbxPath.ReadOnly = true;
            this.tbxPath.Size = new System.Drawing.Size(327, 21);
            this.tbxPath.TabIndex = 12;
            // 
            // btnBuildMod
            // 
            this.btnBuildMod.Enabled = false;
            this.btnBuildMod.Location = new System.Drawing.Point(232, 113);
            this.btnBuildMod.Name = "btnBuildMod";
            this.btnBuildMod.Size = new System.Drawing.Size(90, 23);
            this.btnBuildMod.TabIndex = 20;
            this.btnBuildMod.Text = "生成系统模块";
            this.btnBuildMod.UseVisualStyleBackColor = true;
            this.btnBuildMod.Click += new System.EventHandler(this.btnBuildMod_Click);
            // 
            // btnBuildCodeFile
            // 
            this.btnBuildCodeFile.Enabled = false;
            this.btnBuildCodeFile.Location = new System.Drawing.Point(328, 113);
            this.btnBuildCodeFile.Name = "btnBuildCodeFile";
            this.btnBuildCodeFile.Size = new System.Drawing.Size(90, 23);
            this.btnBuildCodeFile.TabIndex = 21;
            this.btnBuildCodeFile.Text = "生成代码文件";
            this.btnBuildCodeFile.UseVisualStyleBackColor = true;
            this.btnBuildCodeFile.Click += new System.EventHandler(this.btnBuildCodeFile_Click);
            // 
            // btnSetPermission
            // 
            this.btnSetPermission.Enabled = false;
            this.btnSetPermission.Location = new System.Drawing.Point(424, 113);
            this.btnSetPermission.Name = "btnSetPermission";
            this.btnSetPermission.Size = new System.Drawing.Size(90, 23);
            this.btnSetPermission.TabIndex = 22;
            this.btnSetPermission.Text = "配置权限列表";
            this.btnSetPermission.UseVisualStyleBackColor = true;
            this.btnSetPermission.Click += new System.EventHandler(this.btnSetPermission_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 138);
            this.Controls.Add(this.btnSetPermission);
            this.Controls.Add(this.btnBuildCodeFile);
            this.Controls.Add(this.btnBuildMod);
            this.Controls.Add(this.gpMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "模块生成";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.gpMain.ResumeLayout(false);
            this.gpMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog ofdSiteMap;
        private System.Windows.Forms.GroupBox gpMain;
        private System.Windows.Forms.Button btnBrowser;
        private System.Windows.Forms.Label labSiteMapPath;
        private System.Windows.Forms.TextBox tbxPath;
        private System.Windows.Forms.TextBox tbxConnectString;
        private System.Windows.Forms.Button btnSet;
        private System.Windows.Forms.Label labConnectString;
        private System.Windows.Forms.Button btnBuildMod;
        private System.Windows.Forms.Button btnBuildCodeFile;
        private System.Windows.Forms.Button btnSetPermission;
        private System.Windows.Forms.RadioButton rbtLevel3;
        private System.Windows.Forms.RadioButton rbtLevel2;
        private System.Windows.Forms.Label labLevel;
    }
}

