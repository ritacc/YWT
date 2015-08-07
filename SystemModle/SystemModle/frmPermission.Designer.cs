namespace SystemModle
{
    partial class frmPermission
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
            this.components = new System.ComponentModel.Container();
            this.gpSet = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gpMod = new System.Windows.Forms.GroupBox();
            this.tvMod = new System.Windows.Forms.TreeView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gvPermissions = new System.Windows.Forms.DataGridView();
            this.bsPermissions = new System.Windows.Forms.BindingSource(this.components);
            this.code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.permission_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mod_url = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.permission_desc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gpSet.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.gpMod.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvPermissions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPermissions)).BeginInit();
            this.SuspendLayout();
            // 
            // gpSet
            // 
            this.gpSet.Controls.Add(this.btnDelete);
            this.gpSet.Controls.Add(this.btnEdit);
            this.gpSet.Controls.Add(this.btnAdd);
            this.gpSet.Dock = System.Windows.Forms.DockStyle.Top;
            this.gpSet.Location = new System.Drawing.Point(0, 0);
            this.gpSet.Name = "gpSet";
            this.gpSet.Size = new System.Drawing.Size(634, 46);
            this.gpSet.TabIndex = 0;
            this.gpSet.TabStop = false;
            this.gpSet.Text = "配置权限";
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(168, 12);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Enabled = false;
            this.btnEdit.Location = new System.Drawing.Point(87, 12);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "编辑";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Enabled = false;
            this.btnAdd.Location = new System.Drawing.Point(6, 12);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "添加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gpMod);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel2.Controls.Add(this.gpSet);
            this.splitContainer1.Size = new System.Drawing.Size(843, 433);
            this.splitContainer1.SplitterDistance = 205;
            this.splitContainer1.TabIndex = 1;
            // 
            // gpMod
            // 
            this.gpMod.Controls.Add(this.tvMod);
            this.gpMod.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpMod.Location = new System.Drawing.Point(0, 0);
            this.gpMod.Name = "gpMod";
            this.gpMod.Size = new System.Drawing.Size(205, 433);
            this.gpMod.TabIndex = 0;
            this.gpMod.TabStop = false;
            this.gpMod.Text = "模块列表";
            // 
            // tvMod
            // 
            this.tvMod.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvMod.HideSelection = false;
            this.tvMod.Location = new System.Drawing.Point(3, 17);
            this.tvMod.Name = "tvMod";
            this.tvMod.ShowNodeToolTips = true;
            this.tvMod.Size = new System.Drawing.Size(199, 413);
            this.tvMod.TabIndex = 0;
            this.tvMod.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvMod_AfterSelect);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gvPermissions);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 46);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(634, 387);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "权限列表";
            // 
            // gvPermissions
            // 
            this.gvPermissions.AllowUserToAddRows = false;
            this.gvPermissions.AllowUserToDeleteRows = false;
            this.gvPermissions.AllowUserToResizeRows = false;
            this.gvPermissions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvPermissions.BackgroundColor = System.Drawing.SystemColors.HighlightText;
            this.gvPermissions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gvPermissions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.code,
            this.permission_name,
            this.mod_url,
            this.permission_desc});
            this.gvPermissions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvPermissions.Location = new System.Drawing.Point(3, 17);
            this.gvPermissions.MultiSelect = false;
            this.gvPermissions.Name = "gvPermissions";
            this.gvPermissions.ReadOnly = true;
            this.gvPermissions.RowHeadersVisible = false;
            this.gvPermissions.RowTemplate.Height = 23;
            this.gvPermissions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvPermissions.Size = new System.Drawing.Size(628, 367);
            this.gvPermissions.TabIndex = 0;
            this.gvPermissions.SelectionChanged += new System.EventHandler(this.gvPermissions_SelectionChanged);
            // 
            // code
            // 
            this.code.DataPropertyName = "code";
            this.code.HeaderText = "代码";
            this.code.Name = "code";
            this.code.ReadOnly = true;
            // 
            // permission_name
            // 
            this.permission_name.DataPropertyName = "permission_name";
            this.permission_name.HeaderText = "名称";
            this.permission_name.Name = "permission_name";
            this.permission_name.ReadOnly = true;
            // 
            // mod_url
            // 
            this.mod_url.DataPropertyName = "mod_url";
            this.mod_url.HeaderText = "模块地址";
            this.mod_url.Name = "mod_url";
            this.mod_url.ReadOnly = true;
            // 
            // permission_desc
            // 
            this.permission_desc.DataPropertyName = "permission_desc";
            this.permission_desc.HeaderText = "说明";
            this.permission_desc.Name = "permission_desc";
            this.permission_desc.ReadOnly = true;
            // 
            // frmPermission
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 433);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmPermission";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "权限列表";
            this.Load += new System.EventHandler(this.frmPermission_Load);
            this.gpSet.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.gpMod.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvPermissions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPermissions)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpSet;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox gpMod;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TreeView tvMod;
        private System.Windows.Forms.DataGridView gvPermissions;
        private System.Windows.Forms.BindingSource bsPermissions;
        private System.Windows.Forms.DataGridViewTextBoxColumn code;
        private System.Windows.Forms.DataGridViewTextBoxColumn permission_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn mod_url;
        private System.Windows.Forms.DataGridViewTextBoxColumn permission_desc;
    }
}