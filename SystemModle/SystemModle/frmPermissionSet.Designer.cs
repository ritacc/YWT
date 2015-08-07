namespace SystemModle
{
    partial class frmPermissionSet
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
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.labName = new System.Windows.Forms.Label();
            this.tbxName = new System.Windows.Forms.TextBox();
            this.tbxDesc = new System.Windows.Forms.TextBox();
            this.labDesc = new System.Windows.Forms.Label();
            this.nudSort = new System.Windows.Forms.NumericUpDown();
            this.labSort = new System.Windows.Forms.Label();
            this.tbxCode = new System.Windows.Forms.TextBox();
            this.labCode = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudSort)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(68, 156);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(149, 156);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // labName
            // 
            this.labName.AutoSize = true;
            this.labName.Location = new System.Drawing.Point(12, 37);
            this.labName.Name = "labName";
            this.labName.Size = new System.Drawing.Size(65, 12);
            this.labName.TabIndex = 2;
            this.labName.Text = "权限名称：";
            // 
            // tbxName
            // 
            this.tbxName.Location = new System.Drawing.Point(83, 33);
            this.tbxName.Name = "tbxName";
            this.tbxName.Size = new System.Drawing.Size(183, 21);
            this.tbxName.TabIndex = 3;
            // 
            // tbxDesc
            // 
            this.tbxDesc.Location = new System.Drawing.Point(83, 86);
            this.tbxDesc.Multiline = true;
            this.tbxDesc.Name = "tbxDesc";
            this.tbxDesc.Size = new System.Drawing.Size(183, 64);
            this.tbxDesc.TabIndex = 5;
            // 
            // labDesc
            // 
            this.labDesc.AutoSize = true;
            this.labDesc.Location = new System.Drawing.Point(36, 86);
            this.labDesc.Name = "labDesc";
            this.labDesc.Size = new System.Drawing.Size(41, 12);
            this.labDesc.TabIndex = 4;
            this.labDesc.Text = "说明：";
            // 
            // nudSort
            // 
            this.nudSort.Location = new System.Drawing.Point(83, 59);
            this.nudSort.Name = "nudSort";
            this.nudSort.Size = new System.Drawing.Size(183, 21);
            this.nudSort.TabIndex = 9;
            // 
            // labSort
            // 
            this.labSort.AutoSize = true;
            this.labSort.Location = new System.Drawing.Point(36, 63);
            this.labSort.Name = "labSort";
            this.labSort.Size = new System.Drawing.Size(41, 12);
            this.labSort.TabIndex = 10;
            this.labSort.Text = "排序：";
            // 
            // tbxCode
            // 
            this.tbxCode.Location = new System.Drawing.Point(83, 7);
            this.tbxCode.Name = "tbxCode";
            this.tbxCode.Size = new System.Drawing.Size(183, 21);
            this.tbxCode.TabIndex = 12;
            // 
            // labCode
            // 
            this.labCode.AutoSize = true;
            this.labCode.Location = new System.Drawing.Point(12, 11);
            this.labCode.Name = "labCode";
            this.labCode.Size = new System.Drawing.Size(65, 12);
            this.labCode.TabIndex = 11;
            this.labCode.Text = "权限代码：";
            // 
            // frmPermissionSet
            // 
            this.AcceptButton = this.btnSave;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(292, 184);
            this.Controls.Add(this.tbxCode);
            this.Controls.Add(this.labCode);
            this.Controls.Add(this.labSort);
            this.Controls.Add(this.nudSort);
            this.Controls.Add(this.labDesc);
            this.Controls.Add(this.tbxDesc);
            this.Controls.Add(this.tbxName);
            this.Controls.Add(this.labName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPermissionSet";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "权限编辑";
            this.Load += new System.EventHandler(this.frmPermissionSet_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPermissionSet_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.nudSort)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label labName;
        private System.Windows.Forms.TextBox tbxName;
        private System.Windows.Forms.TextBox tbxDesc;
        private System.Windows.Forms.Label labDesc;
        private System.Windows.Forms.NumericUpDown nudSort;
        private System.Windows.Forms.Label labSort;
        private System.Windows.Forms.TextBox tbxCode;
        private System.Windows.Forms.Label labCode;
    }
}