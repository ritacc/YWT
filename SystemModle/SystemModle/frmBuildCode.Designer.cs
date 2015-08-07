namespace SystemModle
{
    partial class frmBuildCode
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
            System.Windows.Forms.Label labAppName;
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gpTableList = new System.Windows.Forms.GroupBox();
            this.clbTableList = new System.Windows.Forms.CheckedListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancelAll = new System.Windows.Forms.Button();
            this.BtnSelectAll = new System.Windows.Forms.Button();
            this.gpColumnList = new System.Windows.Forms.GroupBox();
            this.gvColumns = new System.Windows.Forms.DataGridView();
            this.column_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.data_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.data_length = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nullable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.data_default = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comments = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iskey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsColumns = new System.Windows.Forms.BindingSource(this.components);
            this.btnBuildCode = new System.Windows.Forms.Button();
            this.tabBuild = new System.Windows.Forms.TabControl();
            this.tpBuildEntity = new System.Windows.Forms.TabPage();
            this.txtEmptyModleName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSavePath = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSavePath = new System.Windows.Forms.TextBox();
            this.btnSelect = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTempPath = new System.Windows.Forms.TextBox();
            this.labNamespace = new System.Windows.Forms.Label();
            this.tbxProjectName = new System.Windows.Forms.TextBox();
            this.tbBL = new System.Windows.Forms.TabPage();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbxBLLNamespace = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtBLLProjectName = new System.Windows.Forms.TextBox();
            this.btnBL = new System.Windows.Forms.Button();
            this.tpLogic = new System.Windows.Forms.TabPage();
            this.cbDALBuildEx = new System.Windows.Forms.CheckBox();
            this.labDALInheritance = new System.Windows.Forms.Label();
            this.tbxDALInheritance = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxDALNamespace = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxDALProjectName = new System.Windows.Forms.TextBox();
            this.btnDALBuild = new System.Windows.Forms.Button();
            this.tpBuildUI = new System.Windows.Forms.TabPage();
            this.cbViewCs = new System.Windows.Forms.CheckBox();
            this.cbViewAspx = new System.Windows.Forms.CheckBox();
            this.cbEditCs = new System.Windows.Forms.CheckBox();
            this.cbEditAspx = new System.Windows.Forms.CheckBox();
            this.cbListCs = new System.Windows.Forms.CheckBox();
            this.cbListAspx = new System.Windows.Forms.CheckBox();
            this.tbxAppName = new System.Windows.Forms.TextBox();
            this.labUIProject = new System.Windows.Forms.Label();
            this.tbxUIProjectName = new System.Windows.Forms.TextBox();
            this.labUIInheritance = new System.Windows.Forms.Label();
            this.tbxUIInheritance = new System.Windows.Forms.TextBox();
            this.btnUIBuild = new System.Windows.Forms.Button();
            this.labUINamespace = new System.Windows.Forms.Label();
            this.tbxUINamespace = new System.Windows.Forms.TextBox();
            this.tbforApp = new System.Windows.Forms.TabPage();
            this.btnForApp = new System.Windows.Forms.Button();
            this.tbConvert = new System.Windows.Forms.TabPage();
            this.btnDo = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtValueContent = new System.Windows.Forms.TextBox();
            this.txtNormal = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbMysql = new System.Windows.Forms.TabPage();
            this.btnMysqlInsert = new System.Windows.Forms.Button();
            this.rtbMysql = new System.Windows.Forms.RichTextBox();
            this.tbMVC = new System.Windows.Forms.TabPage();
            this.btnMVC = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.rtbResutlObj = new System.Windows.Forms.RichTextBox();
            this.btnExec = new System.Windows.Forms.Button();
            this.rtbsqlForOBj = new System.Windows.Forms.RichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.fbd = new System.Windows.Forms.FolderBrowserDialog();
            this.btnDal = new System.Windows.Forms.Button();
            labAppName = new System.Windows.Forms.Label();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.gpTableList.SuspendLayout();
            this.panel1.SuspendLayout();
            this.gpColumnList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvColumns)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsColumns)).BeginInit();
            this.tabBuild.SuspendLayout();
            this.tpBuildEntity.SuspendLayout();
            this.tbBL.SuspendLayout();
            this.tpLogic.SuspendLayout();
            this.tpBuildUI.SuspendLayout();
            this.tbforApp.SuspendLayout();
            this.tbConvert.SuspendLayout();
            this.tbMysql.SuspendLayout();
            this.tbMVC.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labAppName
            // 
            labAppName.AutoSize = true;
            labAppName.Location = new System.Drawing.Point(271, 65);
            labAppName.Name = "labAppName";
            labAppName.Size = new System.Drawing.Size(65, 12);
            labAppName.TabIndex = 25;
            labAppName.Text = "系统名称：";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 197);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gpTableList);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gpColumnList);
            this.splitContainer1.Size = new System.Drawing.Size(790, 415);
            this.splitContainer1.SplitterDistance = 262;
            this.splitContainer1.TabIndex = 0;
            // 
            // gpTableList
            // 
            this.gpTableList.Controls.Add(this.clbTableList);
            this.gpTableList.Controls.Add(this.panel1);
            this.gpTableList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpTableList.Location = new System.Drawing.Point(0, 0);
            this.gpTableList.Name = "gpTableList";
            this.gpTableList.Size = new System.Drawing.Size(262, 415);
            this.gpTableList.TabIndex = 0;
            this.gpTableList.TabStop = false;
            this.gpTableList.Text = "Tables";
            // 
            // clbTableList
            // 
            this.clbTableList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clbTableList.FormattingEnabled = true;
            this.clbTableList.Location = new System.Drawing.Point(3, 51);
            this.clbTableList.Name = "clbTableList";
            this.clbTableList.Size = new System.Drawing.Size(256, 361);
            this.clbTableList.TabIndex = 0;
            this.clbTableList.SelectedIndexChanged += new System.EventHandler(this.clbTableList_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancelAll);
            this.panel1.Controls.Add(this.BtnSelectAll);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(256, 34);
            this.panel1.TabIndex = 2;
            // 
            // btnCancelAll
            // 
            this.btnCancelAll.Location = new System.Drawing.Point(90, 3);
            this.btnCancelAll.Name = "btnCancelAll";
            this.btnCancelAll.Size = new System.Drawing.Size(75, 23);
            this.btnCancelAll.TabIndex = 2;
            this.btnCancelAll.Text = "反选";
            this.btnCancelAll.UseVisualStyleBackColor = true;
            this.btnCancelAll.Click += new System.EventHandler(this.btnCancelAll_Click);
            // 
            // BtnSelectAll
            // 
            this.BtnSelectAll.Location = new System.Drawing.Point(9, 3);
            this.BtnSelectAll.Name = "BtnSelectAll";
            this.BtnSelectAll.Size = new System.Drawing.Size(75, 23);
            this.BtnSelectAll.TabIndex = 1;
            this.BtnSelectAll.Text = "全选";
            this.BtnSelectAll.UseVisualStyleBackColor = true;
            this.BtnSelectAll.Click += new System.EventHandler(this.BtnSelectAll_Click);
            // 
            // gpColumnList
            // 
            this.gpColumnList.Controls.Add(this.gvColumns);
            this.gpColumnList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpColumnList.Location = new System.Drawing.Point(0, 0);
            this.gpColumnList.Name = "gpColumnList";
            this.gpColumnList.Size = new System.Drawing.Size(524, 415);
            this.gpColumnList.TabIndex = 1;
            this.gpColumnList.TabStop = false;
            this.gpColumnList.Text = "Columns";
            // 
            // gvColumns
            // 
            this.gvColumns.AllowUserToAddRows = false;
            this.gvColumns.AllowUserToDeleteRows = false;
            this.gvColumns.AllowUserToResizeRows = false;
            this.gvColumns.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.gvColumns.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.gvColumns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gvColumns.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.column_name,
            this.data_type,
            this.data_length,
            this.nullable,
            this.data_default,
            this.comments,
            this.iskey});
            this.gvColumns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvColumns.GridColor = System.Drawing.SystemColors.Control;
            this.gvColumns.Location = new System.Drawing.Point(3, 17);
            this.gvColumns.Name = "gvColumns";
            this.gvColumns.ReadOnly = true;
            this.gvColumns.RowHeadersVisible = false;
            this.gvColumns.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gvColumns.RowTemplate.Height = 23;
            this.gvColumns.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvColumns.Size = new System.Drawing.Size(518, 395);
            this.gvColumns.TabIndex = 0;
            // 
            // column_name
            // 
            this.column_name.DataPropertyName = "column_name";
            this.column_name.HeaderText = "字段名称";
            this.column_name.Name = "column_name";
            this.column_name.ReadOnly = true;
            this.column_name.Width = 78;
            // 
            // data_type
            // 
            this.data_type.DataPropertyName = "data_type";
            this.data_type.HeaderText = "字段类型";
            this.data_type.Name = "data_type";
            this.data_type.ReadOnly = true;
            this.data_type.Width = 78;
            // 
            // data_length
            // 
            this.data_length.DataPropertyName = "data_length";
            this.data_length.HeaderText = "长度";
            this.data_length.Name = "data_length";
            this.data_length.ReadOnly = true;
            this.data_length.Width = 54;
            // 
            // nullable
            // 
            this.nullable.DataPropertyName = "nullable";
            this.nullable.HeaderText = "允许空值";
            this.nullable.Name = "nullable";
            this.nullable.ReadOnly = true;
            this.nullable.Width = 78;
            // 
            // data_default
            // 
            this.data_default.DataPropertyName = "data_default";
            this.data_default.HeaderText = "缺省值";
            this.data_default.Name = "data_default";
            this.data_default.ReadOnly = true;
            this.data_default.Width = 66;
            // 
            // comments
            // 
            this.comments.DataPropertyName = "comments";
            this.comments.HeaderText = "描述";
            this.comments.Name = "comments";
            this.comments.ReadOnly = true;
            this.comments.Width = 54;
            // 
            // iskey
            // 
            this.iskey.HeaderText = "是否主键";
            this.iskey.Name = "iskey";
            this.iskey.ReadOnly = true;
            this.iskey.Width = 78;
            // 
            // btnBuildCode
            // 
            this.btnBuildCode.Location = new System.Drawing.Point(308, 129);
            this.btnBuildCode.Name = "btnBuildCode";
            this.btnBuildCode.Size = new System.Drawing.Size(75, 23);
            this.btnBuildCode.TabIndex = 0;
            this.btnBuildCode.Text = "生成实体类";
            this.btnBuildCode.UseVisualStyleBackColor = true;
            this.btnBuildCode.Click += new System.EventHandler(this.btnBuildCode_Click);
            // 
            // tabBuild
            // 
            this.tabBuild.Controls.Add(this.tpBuildEntity);
            this.tabBuild.Controls.Add(this.tbBL);
            this.tabBuild.Controls.Add(this.tpLogic);
            this.tabBuild.Controls.Add(this.tpBuildUI);
            this.tabBuild.Controls.Add(this.tbforApp);
            this.tabBuild.Controls.Add(this.tbConvert);
            this.tabBuild.Controls.Add(this.tbMysql);
            this.tabBuild.Controls.Add(this.tbMVC);
            this.tabBuild.Controls.Add(this.tabPage1);
            this.tabBuild.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabBuild.Location = new System.Drawing.Point(0, 0);
            this.tabBuild.Name = "tabBuild";
            this.tabBuild.SelectedIndex = 0;
            this.tabBuild.Size = new System.Drawing.Size(790, 197);
            this.tabBuild.TabIndex = 1;
            // 
            // tpBuildEntity
            // 
            this.tpBuildEntity.Controls.Add(this.txtEmptyModleName);
            this.tpBuildEntity.Controls.Add(this.label7);
            this.tpBuildEntity.Controls.Add(this.btnSavePath);
            this.tpBuildEntity.Controls.Add(this.label4);
            this.tpBuildEntity.Controls.Add(this.txtSavePath);
            this.tpBuildEntity.Controls.Add(this.btnSelect);
            this.tpBuildEntity.Controls.Add(this.label1);
            this.tpBuildEntity.Controls.Add(this.txtTempPath);
            this.tpBuildEntity.Controls.Add(this.labNamespace);
            this.tpBuildEntity.Controls.Add(this.tbxProjectName);
            this.tpBuildEntity.Controls.Add(this.btnBuildCode);
            this.tpBuildEntity.Location = new System.Drawing.Point(4, 22);
            this.tpBuildEntity.Name = "tpBuildEntity";
            this.tpBuildEntity.Padding = new System.Windows.Forms.Padding(3);
            this.tpBuildEntity.Size = new System.Drawing.Size(782, 171);
            this.tpBuildEntity.TabIndex = 0;
            this.tpBuildEntity.Text = "生成实体类";
            this.tpBuildEntity.UseVisualStyleBackColor = true;
            // 
            // txtEmptyModleName
            // 
            this.txtEmptyModleName.Location = new System.Drawing.Point(144, 94);
            this.txtEmptyModleName.Name = "txtEmptyModleName";
            this.txtEmptyModleName.Size = new System.Drawing.Size(130, 21);
            this.txtEmptyModleName.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 101);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(113, 12);
            this.label7.TabIndex = 11;
            this.label7.Text = "无模块，模块名称：";
            // 
            // btnSavePath
            // 
            this.btnSavePath.Location = new System.Drawing.Point(466, 67);
            this.btnSavePath.Name = "btnSavePath";
            this.btnSavePath.Size = new System.Drawing.Size(30, 23);
            this.btnSavePath.TabIndex = 10;
            this.btnSavePath.Text = "…";
            this.btnSavePath.UseVisualStyleBackColor = true;
            this.btnSavePath.Click += new System.EventHandler(this.btnSavePath_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "保存路径：";
            // 
            // txtSavePath
            // 
            this.txtSavePath.Location = new System.Drawing.Point(89, 67);
            this.txtSavePath.Name = "txtSavePath";
            this.txtSavePath.Size = new System.Drawing.Size(371, 21);
            this.txtSavePath.TabIndex = 8;
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(466, 40);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(30, 23);
            this.btnSelect.TabIndex = 7;
            this.btnSelect.Text = "…";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "模板路径：";
            // 
            // txtTempPath
            // 
            this.txtTempPath.Location = new System.Drawing.Point(89, 37);
            this.txtTempPath.Name = "txtTempPath";
            this.txtTempPath.Size = new System.Drawing.Size(371, 21);
            this.txtTempPath.TabIndex = 5;
            // 
            // labNamespace
            // 
            this.labNamespace.AutoSize = true;
            this.labNamespace.Location = new System.Drawing.Point(25, 10);
            this.labNamespace.Name = "labNamespace";
            this.labNamespace.Size = new System.Drawing.Size(65, 12);
            this.labNamespace.TabIndex = 2;
            this.labNamespace.Text = "项目名称：";
            // 
            // tbxProjectName
            // 
            this.tbxProjectName.Location = new System.Drawing.Point(89, 10);
            this.tbxProjectName.Name = "tbxProjectName";
            this.tbxProjectName.Size = new System.Drawing.Size(199, 21);
            this.tbxProjectName.TabIndex = 1;
            this.tbxProjectName.Text = "Model";
            // 
            // tbBL
            // 
            this.tbBL.Controls.Add(this.checkBox1);
            this.tbBL.Controls.Add(this.label10);
            this.tbBL.Controls.Add(this.tbxBLLNamespace);
            this.tbBL.Controls.Add(this.label11);
            this.tbBL.Controls.Add(this.txtBLLProjectName);
            this.tbBL.Controls.Add(this.btnBL);
            this.tbBL.Location = new System.Drawing.Point(4, 22);
            this.tbBL.Name = "tbBL";
            this.tbBL.Padding = new System.Windows.Forms.Padding(3);
            this.tbBL.Size = new System.Drawing.Size(782, 171);
            this.tbBL.TabIndex = 7;
            this.tbBL.Text = "生成BLL类";
            this.tbBL.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(487, 40);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(108, 16);
            this.checkBox1.TabIndex = 23;
            this.checkBox1.Text = "是否创建扩展类";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(17, 14);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 20;
            this.label10.Text = "添加引用：";
            // 
            // tbxBLLNamespace
            // 
            this.tbxBLLNamespace.Location = new System.Drawing.Point(19, 35);
            this.tbxBLLNamespace.Multiline = true;
            this.tbxBLLNamespace.Name = "tbxBLLNamespace";
            this.tbxBLLNamespace.Size = new System.Drawing.Size(221, 46);
            this.tbxBLLNamespace.TabIndex = 19;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(262, 14);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 12);
            this.label11.TabIndex = 18;
            this.label11.Text = "项目名称：";
            // 
            // txtBLLProjectName
            // 
            this.txtBLLProjectName.Location = new System.Drawing.Point(264, 35);
            this.txtBLLProjectName.Name = "txtBLLProjectName";
            this.txtBLLProjectName.Size = new System.Drawing.Size(199, 21);
            this.txtBLLProjectName.TabIndex = 17;
            this.txtBLLProjectName.Text = "BLL";
            // 
            // btnBL
            // 
            this.btnBL.Location = new System.Drawing.Point(602, 33);
            this.btnBL.Name = "btnBL";
            this.btnBL.Size = new System.Drawing.Size(75, 23);
            this.btnBL.TabIndex = 16;
            this.btnBL.Text = "生成BLL类";
            this.btnBL.UseVisualStyleBackColor = true;
            this.btnBL.Click += new System.EventHandler(this.btnBL_Click);
            // 
            // tpLogic
            // 
            this.tpLogic.Controls.Add(this.btnDal);
            this.tpLogic.Controls.Add(this.cbDALBuildEx);
            this.tpLogic.Controls.Add(this.labDALInheritance);
            this.tpLogic.Controls.Add(this.tbxDALInheritance);
            this.tpLogic.Controls.Add(this.label2);
            this.tpLogic.Controls.Add(this.tbxDALNamespace);
            this.tpLogic.Controls.Add(this.label3);
            this.tpLogic.Controls.Add(this.tbxDALProjectName);
            this.tpLogic.Controls.Add(this.btnDALBuild);
            this.tpLogic.Location = new System.Drawing.Point(4, 22);
            this.tpLogic.Name = "tpLogic";
            this.tpLogic.Padding = new System.Windows.Forms.Padding(3);
            this.tpLogic.Size = new System.Drawing.Size(782, 171);
            this.tpLogic.TabIndex = 1;
            this.tpLogic.Text = "生成DAL类";
            this.tpLogic.UseVisualStyleBackColor = true;
            // 
            // cbDALBuildEx
            // 
            this.cbDALBuildEx.AutoSize = true;
            this.cbDALBuildEx.Location = new System.Drawing.Point(509, 83);
            this.cbDALBuildEx.Name = "cbDALBuildEx";
            this.cbDALBuildEx.Size = new System.Drawing.Size(108, 16);
            this.cbDALBuildEx.TabIndex = 15;
            this.cbDALBuildEx.Text = "是否创建扩展类";
            this.cbDALBuildEx.UseVisualStyleBackColor = true;
            // 
            // labDALInheritance
            // 
            this.labDALInheritance.AutoSize = true;
            this.labDALInheritance.Location = new System.Drawing.Point(498, 13);
            this.labDALInheritance.Name = "labDALInheritance";
            this.labDALInheritance.Size = new System.Drawing.Size(53, 12);
            this.labDALInheritance.TabIndex = 14;
            this.labDALInheritance.Text = "继承类：";
            // 
            // tbxDALInheritance
            // 
            this.tbxDALInheritance.Location = new System.Drawing.Point(500, 34);
            this.tbxDALInheritance.Name = "tbxDALInheritance";
            this.tbxDALInheritance.Size = new System.Drawing.Size(199, 21);
            this.tbxDALInheritance.TabIndex = 13;
            this.tbxDALInheritance.Text = "DALBase";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "添加引用：";
            // 
            // tbxDALNamespace
            // 
            this.tbxDALNamespace.Location = new System.Drawing.Point(28, 34);
            this.tbxDALNamespace.Multiline = true;
            this.tbxDALNamespace.Name = "tbxDALNamespace";
            this.tbxDALNamespace.Size = new System.Drawing.Size(221, 92);
            this.tbxDALNamespace.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(271, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "项目名称：";
            // 
            // tbxDALProjectName
            // 
            this.tbxDALProjectName.Location = new System.Drawing.Point(273, 34);
            this.tbxDALProjectName.Name = "tbxDALProjectName";
            this.tbxDALProjectName.Size = new System.Drawing.Size(199, 21);
            this.tbxDALProjectName.TabIndex = 7;
            this.tbxDALProjectName.Text = "DAL";
            // 
            // btnDALBuild
            // 
            this.btnDALBuild.Location = new System.Drawing.Point(624, 76);
            this.btnDALBuild.Name = "btnDALBuild";
            this.btnDALBuild.Size = new System.Drawing.Size(75, 23);
            this.btnDALBuild.TabIndex = 6;
            this.btnDALBuild.Text = "生成DAL类";
            this.btnDALBuild.UseVisualStyleBackColor = true;
            this.btnDALBuild.Click += new System.EventHandler(this.btnDALBuild_Click);
            // 
            // tpBuildUI
            // 
            this.tpBuildUI.Controls.Add(this.cbViewCs);
            this.tpBuildUI.Controls.Add(this.cbViewAspx);
            this.tpBuildUI.Controls.Add(this.cbEditCs);
            this.tpBuildUI.Controls.Add(this.cbEditAspx);
            this.tpBuildUI.Controls.Add(this.cbListCs);
            this.tpBuildUI.Controls.Add(this.cbListAspx);
            this.tpBuildUI.Controls.Add(labAppName);
            this.tpBuildUI.Controls.Add(this.tbxAppName);
            this.tpBuildUI.Controls.Add(this.labUIProject);
            this.tpBuildUI.Controls.Add(this.tbxUIProjectName);
            this.tpBuildUI.Controls.Add(this.labUIInheritance);
            this.tpBuildUI.Controls.Add(this.tbxUIInheritance);
            this.tpBuildUI.Controls.Add(this.btnUIBuild);
            this.tpBuildUI.Controls.Add(this.labUINamespace);
            this.tpBuildUI.Controls.Add(this.tbxUINamespace);
            this.tpBuildUI.Location = new System.Drawing.Point(4, 22);
            this.tpBuildUI.Name = "tpBuildUI";
            this.tpBuildUI.Size = new System.Drawing.Size(782, 171);
            this.tpBuildUI.TabIndex = 2;
            this.tpBuildUI.Text = "生成UI文件";
            this.tpBuildUI.UseVisualStyleBackColor = true;
            // 
            // cbViewCs
            // 
            this.cbViewCs.AutoSize = true;
            this.cbViewCs.Checked = true;
            this.cbViewCs.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbViewCs.Enabled = false;
            this.cbViewCs.Location = new System.Drawing.Point(554, 113);
            this.cbViewCs.Name = "cbViewCs";
            this.cbViewCs.Size = new System.Drawing.Size(102, 16);
            this.cbViewCs.TabIndex = 33;
            this.cbViewCs.Text = "*View.aspx.cs";
            this.cbViewCs.UseVisualStyleBackColor = true;
            // 
            // cbViewAspx
            // 
            this.cbViewAspx.AutoSize = true;
            this.cbViewAspx.Checked = true;
            this.cbViewAspx.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbViewAspx.Enabled = false;
            this.cbViewAspx.Location = new System.Drawing.Point(470, 113);
            this.cbViewAspx.Name = "cbViewAspx";
            this.cbViewAspx.Size = new System.Drawing.Size(84, 16);
            this.cbViewAspx.TabIndex = 32;
            this.cbViewAspx.Text = "*View.aspx";
            this.cbViewAspx.UseVisualStyleBackColor = true;
            // 
            // cbEditCs
            // 
            this.cbEditCs.AutoSize = true;
            this.cbEditCs.Checked = true;
            this.cbEditCs.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbEditCs.Location = new System.Drawing.Point(363, 132);
            this.cbEditCs.Name = "cbEditCs";
            this.cbEditCs.Size = new System.Drawing.Size(102, 16);
            this.cbEditCs.TabIndex = 31;
            this.cbEditCs.Text = "*Edit.aspx.cs";
            this.cbEditCs.UseVisualStyleBackColor = true;
            // 
            // cbEditAspx
            // 
            this.cbEditAspx.AutoSize = true;
            this.cbEditAspx.Checked = true;
            this.cbEditAspx.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbEditAspx.Location = new System.Drawing.Point(273, 132);
            this.cbEditAspx.Name = "cbEditAspx";
            this.cbEditAspx.Size = new System.Drawing.Size(84, 16);
            this.cbEditAspx.TabIndex = 30;
            this.cbEditAspx.Text = "*Edit.aspx";
            this.cbEditAspx.UseVisualStyleBackColor = true;
            // 
            // cbListCs
            // 
            this.cbListCs.AutoSize = true;
            this.cbListCs.Checked = true;
            this.cbListCs.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbListCs.Location = new System.Drawing.Point(363, 110);
            this.cbListCs.Name = "cbListCs";
            this.cbListCs.Size = new System.Drawing.Size(102, 16);
            this.cbListCs.TabIndex = 27;
            this.cbListCs.Text = "*List.aspx.cs";
            this.cbListCs.UseVisualStyleBackColor = true;
            // 
            // cbListAspx
            // 
            this.cbListAspx.AutoSize = true;
            this.cbListAspx.Checked = true;
            this.cbListAspx.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbListAspx.Location = new System.Drawing.Point(273, 110);
            this.cbListAspx.Name = "cbListAspx";
            this.cbListAspx.Size = new System.Drawing.Size(84, 16);
            this.cbListAspx.TabIndex = 26;
            this.cbListAspx.Text = "*List.aspx";
            this.cbListAspx.UseVisualStyleBackColor = true;
            // 
            // tbxAppName
            // 
            this.tbxAppName.Location = new System.Drawing.Point(273, 80);
            this.tbxAppName.Name = "tbxAppName";
            this.tbxAppName.Size = new System.Drawing.Size(199, 21);
            this.tbxAppName.TabIndex = 24;
            this.tbxAppName.Text = "公路口岸关检协同系统";
            // 
            // labUIProject
            // 
            this.labUIProject.AutoSize = true;
            this.labUIProject.Location = new System.Drawing.Point(271, 13);
            this.labUIProject.Name = "labUIProject";
            this.labUIProject.Size = new System.Drawing.Size(65, 12);
            this.labUIProject.TabIndex = 23;
            this.labUIProject.Text = "项目名称：";
            // 
            // tbxUIProjectName
            // 
            this.tbxUIProjectName.Location = new System.Drawing.Point(273, 34);
            this.tbxUIProjectName.Name = "tbxUIProjectName";
            this.tbxUIProjectName.Size = new System.Drawing.Size(199, 21);
            this.tbxUIProjectName.TabIndex = 22;
            this.tbxUIProjectName.Text = "Web";
            // 
            // labUIInheritance
            // 
            this.labUIInheritance.AutoSize = true;
            this.labUIInheritance.Location = new System.Drawing.Point(498, 13);
            this.labUIInheritance.Name = "labUIInheritance";
            this.labUIInheritance.Size = new System.Drawing.Size(53, 12);
            this.labUIInheritance.TabIndex = 21;
            this.labUIInheritance.Text = "继承类：";
            // 
            // tbxUIInheritance
            // 
            this.tbxUIInheritance.Location = new System.Drawing.Point(500, 34);
            this.tbxUIInheritance.Name = "tbxUIInheritance";
            this.tbxUIInheritance.Size = new System.Drawing.Size(199, 21);
            this.tbxUIInheritance.TabIndex = 20;
            this.tbxUIInheritance.Text = "Common.PageBase";
            // 
            // btnUIBuild
            // 
            this.btnUIBuild.Location = new System.Drawing.Point(657, 125);
            this.btnUIBuild.Name = "btnUIBuild";
            this.btnUIBuild.Size = new System.Drawing.Size(75, 23);
            this.btnUIBuild.TabIndex = 15;
            this.btnUIBuild.Text = "生成UI文件";
            this.btnUIBuild.UseVisualStyleBackColor = true;
            this.btnUIBuild.Click += new System.EventHandler(this.btnUIBuild_Click);
            // 
            // labUINamespace
            // 
            this.labUINamespace.AutoSize = true;
            this.labUINamespace.Location = new System.Drawing.Point(26, 13);
            this.labUINamespace.Name = "labUINamespace";
            this.labUINamespace.Size = new System.Drawing.Size(65, 12);
            this.labUINamespace.TabIndex = 6;
            this.labUINamespace.Text = "添加引用：";
            // 
            // tbxUINamespace
            // 
            this.tbxUINamespace.Location = new System.Drawing.Point(28, 34);
            this.tbxUINamespace.Multiline = true;
            this.tbxUINamespace.Name = "tbxUINamespace";
            this.tbxUINamespace.Size = new System.Drawing.Size(221, 92);
            this.tbxUINamespace.TabIndex = 5;
            // 
            // tbforApp
            // 
            this.tbforApp.Controls.Add(this.btnForApp);
            this.tbforApp.Location = new System.Drawing.Point(4, 22);
            this.tbforApp.Name = "tbforApp";
            this.tbforApp.Size = new System.Drawing.Size(782, 171);
            this.tbforApp.TabIndex = 8;
            this.tbforApp.Text = "APP";
            this.tbforApp.UseVisualStyleBackColor = true;
            // 
            // btnForApp
            // 
            this.btnForApp.Location = new System.Drawing.Point(278, 33);
            this.btnForApp.Name = "btnForApp";
            this.btnForApp.Size = new System.Drawing.Size(75, 23);
            this.btnForApp.TabIndex = 0;
            this.btnForApp.Text = "生成";
            this.btnForApp.UseVisualStyleBackColor = true;
            this.btnForApp.Click += new System.EventHandler(this.btnForApp_Click);
            // 
            // tbConvert
            // 
            this.tbConvert.Controls.Add(this.btnDo);
            this.tbConvert.Controls.Add(this.label6);
            this.tbConvert.Controls.Add(this.txtValueContent);
            this.tbConvert.Controls.Add(this.txtNormal);
            this.tbConvert.Controls.Add(this.label5);
            this.tbConvert.Location = new System.Drawing.Point(4, 22);
            this.tbConvert.Name = "tbConvert";
            this.tbConvert.Size = new System.Drawing.Size(782, 171);
            this.tbConvert.TabIndex = 3;
            this.tbConvert.Text = "模板转换";
            this.tbConvert.UseVisualStyleBackColor = true;
            // 
            // btnDo
            // 
            this.btnDo.Location = new System.Drawing.Point(705, 107);
            this.btnDo.Name = "btnDo";
            this.btnDo.Size = new System.Drawing.Size(48, 37);
            this.btnDo.TabIndex = 4;
            this.btnDo.Text = "生成";
            this.btnDo.UseVisualStyleBackColor = true;
            this.btnDo.Click += new System.EventHandler(this.btnDo_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 99);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 12);
            this.label6.TabIndex = 3;
            this.label6.Text = "生成内容:";
            // 
            // txtValueContent
            // 
            this.txtValueContent.Location = new System.Drawing.Point(71, 95);
            this.txtValueContent.Multiline = true;
            this.txtValueContent.Name = "txtValueContent";
            this.txtValueContent.Size = new System.Drawing.Size(628, 69);
            this.txtValueContent.TabIndex = 2;
            // 
            // txtNormal
            // 
            this.txtNormal.Location = new System.Drawing.Point(71, 5);
            this.txtNormal.Multiline = true;
            this.txtNormal.Name = "txtNormal";
            this.txtNormal.Size = new System.Drawing.Size(628, 84);
            this.txtNormal.TabIndex = 1;
            this.txtNormal.Text = "字段名称： #FildsName 字段内容：#FildsID 转换：#FildsFormart \r\n类型：#FildsType DB类型： #DBType\r\n\r\n" +
                "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "模板信息：";
            // 
            // tbMysql
            // 
            this.tbMysql.Controls.Add(this.btnMysqlInsert);
            this.tbMysql.Controls.Add(this.rtbMysql);
            this.tbMysql.Location = new System.Drawing.Point(4, 22);
            this.tbMysql.Name = "tbMysql";
            this.tbMysql.Size = new System.Drawing.Size(782, 171);
            this.tbMysql.TabIndex = 4;
            this.tbMysql.Text = "InsetMySql";
            this.tbMysql.UseVisualStyleBackColor = true;
            // 
            // btnMysqlInsert
            // 
            this.btnMysqlInsert.Location = new System.Drawing.Point(453, 4);
            this.btnMysqlInsert.Name = "btnMysqlInsert";
            this.btnMysqlInsert.Size = new System.Drawing.Size(75, 23);
            this.btnMysqlInsert.TabIndex = 1;
            this.btnMysqlInsert.Text = "生成";
            this.btnMysqlInsert.UseVisualStyleBackColor = true;
            this.btnMysqlInsert.Click += new System.EventHandler(this.btnMysqlInsert_Click);
            // 
            // rtbMysql
            // 
            this.rtbMysql.Location = new System.Drawing.Point(3, 0);
            this.rtbMysql.Name = "rtbMysql";
            this.rtbMysql.Size = new System.Drawing.Size(443, 155);
            this.rtbMysql.TabIndex = 0;
            this.rtbMysql.Text = "";
            // 
            // tbMVC
            // 
            this.tbMVC.Controls.Add(this.btnMVC);
            this.tbMVC.Location = new System.Drawing.Point(4, 22);
            this.tbMVC.Name = "tbMVC";
            this.tbMVC.Size = new System.Drawing.Size(782, 171);
            this.tbMVC.TabIndex = 5;
            this.tbMVC.Text = "MVC";
            this.tbMVC.UseVisualStyleBackColor = true;
            // 
            // btnMVC
            // 
            this.btnMVC.Location = new System.Drawing.Point(627, 19);
            this.btnMVC.Name = "btnMVC";
            this.btnMVC.Size = new System.Drawing.Size(75, 23);
            this.btnMVC.TabIndex = 0;
            this.btnMVC.Text = "生成";
            this.btnMVC.UseVisualStyleBackColor = true;
            this.btnMVC.Click += new System.EventHandler(this.btnMVC_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.rtbResutlObj);
            this.tabPage1.Controls.Add(this.btnExec);
            this.tabPage1.Controls.Add(this.rtbsqlForOBj);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(782, 171);
            this.tabPage1.TabIndex = 6;
            this.tabPage1.Text = "Sql For OBject";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // rtbResutlObj
            // 
            this.rtbResutlObj.Location = new System.Drawing.Point(38, 51);
            this.rtbResutlObj.Name = "rtbResutlObj";
            this.rtbResutlObj.Size = new System.Drawing.Size(639, 117);
            this.rtbResutlObj.TabIndex = 3;
            this.rtbResutlObj.Text = "";
            // 
            // btnExec
            // 
            this.btnExec.Location = new System.Drawing.Point(694, 21);
            this.btnExec.Name = "btnExec";
            this.btnExec.Size = new System.Drawing.Size(75, 23);
            this.btnExec.TabIndex = 2;
            this.btnExec.Text = "生成";
            this.btnExec.UseVisualStyleBackColor = true;
            this.btnExec.Click += new System.EventHandler(this.btnExec_Click);
            // 
            // rtbsqlForOBj
            // 
            this.rtbsqlForOBj.Location = new System.Drawing.Point(38, 11);
            this.rtbsqlForOBj.Name = "rtbsqlForOBj";
            this.rtbsqlForOBj.Size = new System.Drawing.Size(639, 34);
            this.rtbsqlForOBj.TabIndex = 1;
            this.rtbsqlForOBj.Text = "";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 11);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(23, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "sql";
            // 
            // btnDal
            // 
            this.btnDal.Location = new System.Drawing.Point(624, 129);
            this.btnDal.Name = "btnDal";
            this.btnDal.Size = new System.Drawing.Size(113, 23);
            this.btnDal.TabIndex = 16;
            this.btnDal.Text = "生成DAL类APP";
            this.btnDal.UseVisualStyleBackColor = true;
            this.btnDal.Click += new System.EventHandler(this.btnDal_Click);
            // 
            // frmBuildCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 612);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.tabBuild);
            this.Name = "frmBuildCode";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "代码生成工具";
            this.Load += new System.EventHandler(this.frmBuildCode_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.gpTableList.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.gpColumnList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvColumns)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsColumns)).EndInit();
            this.tabBuild.ResumeLayout(false);
            this.tpBuildEntity.ResumeLayout(false);
            this.tpBuildEntity.PerformLayout();
            this.tbBL.ResumeLayout(false);
            this.tbBL.PerformLayout();
            this.tpLogic.ResumeLayout(false);
            this.tpLogic.PerformLayout();
            this.tpBuildUI.ResumeLayout(false);
            this.tpBuildUI.PerformLayout();
            this.tbforApp.ResumeLayout(false);
            this.tbConvert.ResumeLayout(false);
            this.tbConvert.PerformLayout();
            this.tbMysql.ResumeLayout(false);
            this.tbMVC.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox gpTableList;
        private System.Windows.Forms.CheckedListBox clbTableList;
        private System.Windows.Forms.GroupBox gpColumnList;
        private System.Windows.Forms.DataGridView gvColumns;
        private System.Windows.Forms.BindingSource bsColumns;
        private System.Windows.Forms.Button btnBuildCode;
        private System.Windows.Forms.TabControl tabBuild;
        private System.Windows.Forms.TabPage tpLogic;
        private System.Windows.Forms.TabPage tpBuildEntity;
        private System.Windows.Forms.Label labNamespace;
        private System.Windows.Forms.TextBox tbxProjectName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxDALNamespace;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxDALProjectName;
        private System.Windows.Forms.Button btnDALBuild;
        private System.Windows.Forms.Label labDALInheritance;
        private System.Windows.Forms.TextBox tbxDALInheritance;
        private System.Windows.Forms.TabPage tpBuildUI;
        private System.Windows.Forms.Label labUIInheritance;
        private System.Windows.Forms.TextBox tbxUIInheritance;
        private System.Windows.Forms.Button btnUIBuild;
        private System.Windows.Forms.Label labUINamespace;
        private System.Windows.Forms.TextBox tbxUINamespace;
        private System.Windows.Forms.CheckBox cbDALBuildEx;
        private System.Windows.Forms.Label labUIProject;
        private System.Windows.Forms.TextBox tbxUIProjectName;
        private System.Windows.Forms.TextBox tbxAppName;
        private System.Windows.Forms.CheckBox cbListAspx;
        private System.Windows.Forms.CheckBox cbListCs;
        private System.Windows.Forms.CheckBox cbViewCs;
        private System.Windows.Forms.CheckBox cbViewAspx;
        private System.Windows.Forms.CheckBox cbEditCs;
        private System.Windows.Forms.CheckBox cbEditAspx;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancelAll;
        private System.Windows.Forms.Button BtnSelectAll;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTempPath;
        private System.Windows.Forms.FolderBrowserDialog fbd;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn data_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn data_length;
        private System.Windows.Forms.DataGridViewTextBoxColumn nullable;
        private System.Windows.Forms.DataGridViewTextBoxColumn data_default;
        private System.Windows.Forms.DataGridViewTextBoxColumn comments;
        private System.Windows.Forms.DataGridViewTextBoxColumn iskey;
        private System.Windows.Forms.Button btnSavePath;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSavePath;
        private System.Windows.Forms.TabPage tbConvert;
        private System.Windows.Forms.Button btnDo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtValueContent;
        private System.Windows.Forms.TextBox txtNormal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtEmptyModleName;
        private System.Windows.Forms.TabPage tbMysql;
        private System.Windows.Forms.Button btnMysqlInsert;
        private System.Windows.Forms.RichTextBox rtbMysql;
		private System.Windows.Forms.TabPage tbMVC;
		private System.Windows.Forms.Button btnMVC;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnExec;
        private System.Windows.Forms.RichTextBox rtbsqlForOBj;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RichTextBox rtbResutlObj;
        private System.Windows.Forms.TabPage tbBL;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbxBLLNamespace;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtBLLProjectName;
        private System.Windows.Forms.Button btnBL;
        private System.Windows.Forms.TabPage tbforApp;
        private System.Windows.Forms.Button btnForApp;
        private System.Windows.Forms.Button btnDal;

    }
}