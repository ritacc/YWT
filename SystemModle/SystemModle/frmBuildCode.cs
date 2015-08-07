using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using SystemModle.Access;
using System.Text.RegularExpressions;
using System.IO;
using SystemModle.tempOR;

namespace SystemModle
{
    public partial class frmBuildCode : Form
    {
        public static string Privider = string.Empty;

        
        // 数据库连接
        private OleDbConnection _Connection = null;
        /// <summary>
        /// 数据库连接
        /// </summary>
        public OleDbConnection Connection
        {
            set { _Connection = value; }
        }

        // 数据库访问类
        private DBCommond db = new DBCommond();

        private AccessDB accessDB;

        // Ini文件访问类
        private IniFile _IniFile = null;

        /// <summary>
        /// 初始化Ini配置文件地址
        /// </summary>
        private void InitIniFile()
        {  
           
            if (null == _IniFile)
            {
                string path = Application.StartupPath + "\\setting.ini";
                _IniFile = new IniFile(path);
            }

            tbxProjectName.Text = _IniFile.ReadString("Model", "ProjectName", "Model");    
            txtTempPath.Text = _IniFile.ReadString("Model", "TempPath", "default");

            tbxBLLNamespace.Text=_IniFile.ReadString("BLL", "BLLNamespace","" );
            txtBLLProjectName.Text = _IniFile.ReadString("BLL", "BLLProjectName", "BLL");

            tbxDALProjectName.Text = _IniFile.ReadString("DAL", "ProjectName", "DAL");
            tbxDALInheritance.Text = _IniFile.ReadString("DAL", "Inheritance", "DALBase");
            cbDALBuildEx.Checked = _IniFile.ReadBoolean("DAL", "BuildEx", true);

            tbxUIProjectName.Text = _IniFile.ReadString("WEB", "ProjectName", "Web");
            tbxUIInheritance.Text = _IniFile.ReadString("WEB", "Inheritance", "Common.PageBase");
            //tbxUIModelName.Text = _IniFile.ReadString("WEB", "ModelName", "default");
            tbxAppName.Text = _IniFile.ReadString("WEB", "ApplicationName", "公路口岸关检系统");
            cbListAspx.Checked = _IniFile.ReadBoolean("WEB", "ListAspx", true);
            cbListCs.Checked = _IniFile.ReadBoolean("WEB", "ListCs", true);
            
            cbEditAspx.Checked = _IniFile.ReadBoolean("WEB", "EditAspx", true);
            cbEditCs.Checked = _IniFile.ReadBoolean("WEB", "EditCs", true);
            cbViewAspx.Checked = _IniFile.ReadBoolean("WEB", "ViewAspx", true);
            cbViewCs.Checked = _IniFile.ReadBoolean("WEB", "ViewCs", true);

            txtSavePath.Text = _IniFile.ReadString("WEB", "SavePath", "Web");
            txtEmptyModleName.Text = _IniFile.ReadString("WEB", "EmptyModleName", "");

            
        }
        private void SaveSetting()
        {
            _IniFile.WriteString("Model", "ProjectName", tbxProjectName.Text);
            _IniFile.WriteString("Model", "TempPath", txtTempPath.Text);

            _IniFile.WriteString("BLL", "BLLNamespace", tbxBLLNamespace.Text);
            _IniFile.WriteString("BLL", "BLLProjectName", txtBLLProjectName.Text);

            _IniFile.WriteString("DAL", "ProjectName", tbxDALProjectName.Text);
            _IniFile.WriteString("DAL", "Inheritance", tbxDALInheritance.Text);
            // _IniFile.WriteString("DAL", "ModelName", tbxDALModelName.Text);
            _IniFile.WriteBoolean("DAL", "BuildEx", cbDALBuildEx.Checked);

            
            _IniFile.WriteString("WEB", "ProjectName", tbxUIProjectName.Text);
            _IniFile.WriteString("WEB", "Inheritance", tbxUIInheritance.Text);
            //_IniFile.WriteString("WEB", "ModelName", tbxUIModelName.Text);
            _IniFile.WriteString("WEB", "ApplicationName", tbxAppName.Text);
            _IniFile.WriteBoolean("WEB", "ListAspx", cbListAspx.Checked);
            _IniFile.WriteBoolean("WEB", "ListCs", cbListCs.Checked);

            _IniFile.WriteBoolean("WEB", "EditAspx", cbEditAspx.Checked);
            _IniFile.WriteBoolean("WEB", "EditCs", cbEditCs.Checked);
            _IniFile.WriteBoolean("WEB", "ViewAspx", cbViewAspx.Checked);
            _IniFile.WriteBoolean("WEB", "ViewCs", cbViewCs.Checked);

            _IniFile.WriteString("WEB", "EmptyModleName", txtEmptyModleName.Text);
            
            _IniFile.WriteString("WEB", "SavePath", txtSavePath.Text);
        }
        public bool initFail = true;
        public frmBuildCode(string strCon)
        {
            InitializeComponent();
            try
            {
                _Connection = GetConnection(strCon);
                db.Connection = _Connection;
                frmBuildCode.Privider = _Connection.Provider;//设置访问类另
                accessDB = Access.Access.GetAccess(_Connection);
                BindTableList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void frmBuildCode_Load(object sender, EventArgs e)
        {
            // 初始化Ini配置文件地址
            InitIniFile();
        }
        public OleDbConnection GetConnection(string constr)
        {
            return new OleDbConnection(constr);
        }

        private void BindTableList()
        {

            DataTable dt = accessDB.GetAllTable();
            foreach (DataRow row in dt.Rows)
            {
                clbTableList.Items.Add(new ListItem(row["table_name"].ToString(), row["comments"].ToString()), false);
            }
        }

        private void clbTableList_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindColummsList(clbTableList.Items[clbTableList.SelectedIndex].ToString());
        }

        private void BindColummsList(string strTableName)
        {
            DataTable dt = accessDB.GetColumnsByTableName(strTableName);
            bsColumns.DataSource = dt.DefaultView;
            gvColumns.DataSource = bsColumns;
        }

        private string GetSavePath()
        {
            if (string.IsNullOrEmpty(txtSavePath.Text.Trim()))
            {
                MessageBox.Show("请选择路径！");
                txtSavePath.Text = Application.StartupPath;
            }
            if (txtSavePath.Text.EndsWith("\\"))
            {
                return txtSavePath.Text;
            }
            return txtSavePath.Text += "\\";
        }

        private void btnBuildCode_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            StringBuilder sbField = new StringBuilder();
            StringBuilder sbRow = new StringBuilder();

            string projectName = tbxProjectName.Text;
            string modelName;
            string className;
            string tableName;

            CheckedListBox.CheckedItemCollection checkedItems = clbTableList.CheckedItems;

            string tempPath = string.Format("{0}\\{1}", txtTempPath.Text, "OR.cs");
            if (!File.Exists(tempPath))
            {
                MessageBox.Show("OR.cs模板文件不存在！");
                return;
            }
           
            foreach (object item in checkedItems)
            {
                string m_content = File.ReadAllText(tempPath);//从文件中读出模板的内容
                sb = new StringBuilder();
                sbRow = new StringBuilder();
                tableName = item.ToString();
                className = ClassNameFormat(tableName);
                modelName = GetModelName(tableName);
                if (string.IsNullOrEmpty(modelName))
                    modelName = txtEmptyModleName.Text;

                DataTable dt = accessDB.GetColumnsByTableName(tableName);

                SystemModle.tempOR.ORcs or = new SystemModle.tempOR.ORcs();
                or.Namespace = string.Format("{0}{1}{2}", tbxProjectName.Text, string.IsNullOrEmpty(modelName) ? "" : ".", modelName);
                or.TableName = className; 
                List<string> primaryKeys = getPrimaryKeys(dt);
                or.getContent(dt, accessDB, primaryKeys);
              
               // m_content = string.Format(m_content, or.Namespace, or.TableTitle, or.TableName, or.OrContent).Replace("≮", "{").Replace("≯", "}");
                m_content = m_content.Replace("<#ClaseNameSpace>", or.Namespace)
                    .Replace("<#ClassTitle>", or.TableTitle)
                    .Replace("<#ClassName>",className)
                    .Replace("<#ORContent>", or.OrContent);

                BuildHelper.Save(GetSavePath()  + projectName + "\\" + modelName, className + "OR.cs", m_content);
            }
            SaveSetting();
        }

        private void btnDALBuild_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
           
            StringBuilder sbDbNull = new StringBuilder(); // 当时间为''值时 录入DbNull.Value

            string nameSpace = tbxDALNamespace.Text;
            string projectName = tbxDALProjectName.Text;
            string inheritanceClass = tbxDALInheritance.Text;
            string modelName;
            string className;
            string tableName;

            string tempPath = string.Format("{0}\\{1}", txtTempPath.Text, "DA.cs");
            if (!File.Exists(tempPath))
            {
                MessageBox.Show("DA.cs模板文件不存在！");
                return;
            }

            CheckedListBox.CheckedItemCollection checkedItems = clbTableList.CheckedItems;
            foreach (object item in checkedItems)
            {
                sb = new StringBuilder();
                tableName = item.ToString();
                className = ClassNameFormat(tableName);
                modelName = GetModelName(tableName);
                if (string.IsNullOrEmpty(modelName))
                    modelName = txtEmptyModleName.Text;

                DataTable dt = accessDB.GetColumnsByTableName(tableName);
                List<string> primaryKeys = getPrimaryKeys(dt);

                //引用命名空间
                string usingNamespace =  string.Format("using {0}{1}{2};\n", tbxProjectName.Text,string.IsNullOrEmpty(modelName)?"":".", modelName);
                usingNamespace +=tbxDALNamespace.Text;

                SystemModle.tempOR.DAcsBase da = DAcsFactory.Create();
                da.Namespace = string.Format("{0}{1}{2}", tbxDALProjectName.Text, string.IsNullOrEmpty(modelName) ? "" : ".", modelName);
                da.ClassName = className;
                da.TableAllName = tableName;
                da.getContent(dt, accessDB, primaryKeys);

                string m_content = File.ReadAllText(tempPath);//从文件中读出模板的内容
                //m_content = string.Format(m_content, usingNamespace, da.Namespace, da.TableTitle, da.ClassName, da.OrContent)
                //    .Replace("≮", "{").Replace("≯", "}");
              m_content=  m_content.Replace("<#usingNamespace>", usingNamespace)
                    .Replace("<#ClaseNameSpace>",da.Namespace)
                    .Replace("<#ClassTitle>", da.TableTitle)
                    .Replace("<#ClassName>", className)
                    .Replace("<#daContent>", da.OrContent);

                BuildHelper.Save(GetSavePath() + projectName + "\\" + modelName, className + "DA.cs", m_content);
            }
            SaveSetting();
        }

        private string GetModelName(string name)
        {
            string sResult = Regex.Match(name, "(?i)(?<=[t][_])[A-Za-z]+(?=_)").Value;           
            return sResult;
        }

        private string NameFormat(string name)
        {
            if (name.IndexOf("_") > -1)
            {
                name = Regex.Replace(name.ToLower(), "^t_", "");
                Regex reg = new Regex("^[A-Za-z]|[_][A-Za-z]", RegexOptions.IgnoreCase);
                MatchCollection matchs = reg.Matches(name);
                int len = matchs.Count;
                foreach (Match match in matchs)
                {
                    name = name.Remove(match.Index, match.Length);
                    name = name.Insert(match.Index, match.Value.ToUpper());
                }
                return name.Replace("_", "");
            }
            return name.Substring(0, 1).ToUpper() + name.Substring(1).ToLower();
        }

        private string ClassNameFormat(string name)
        {
            if (name.IndexOf("T_") > -1)
            {
                name = Regex.Replace(name, "^T_", "");
                if (name.IndexOf("_") > -1)
                {
                    name = Regex.Replace(name, "^[A-Za-z]+", "");
                    Regex reg = new Regex("[_][A-Za-z]", RegexOptions.IgnoreCase);
                    MatchCollection matchs = reg.Matches(name);
                    int len = matchs.Count;
                    foreach (Match match in matchs)
                    {
                        name = name.Remove(match.Index, match.Length);
                        name = name.Insert(match.Index, match.Value);
                    }
                    return name.Replace("_", "");
                }
            }
            return name.Substring(0, 1).ToUpper() + name.Substring(1).Replace("_", "");
        }

        

        private void btnUIBuild_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            StringBuilder sbSearch = new StringBuilder(); // list页面做searc, add页面做验证
            StringBuilder sbKey = new StringBuilder(); // edit label
            

            string appName = tbxAppName.Text;
            string nameSpace = tbxUINamespace.Text;
            string projectName = tbxUIProjectName.Text;
            string inheritanceClass = tbxUIInheritance.Text == "" ? "System.Web.UI.Page" : tbxUIInheritance.Text;
            string modelName;
            string className;
            string tableName;
            string tableTitle; // 表显示名称
            string tableComments;          
          
            string dalName; // 实体类 如 SysMods
            string paramClassName; // 实体类的参数 如 SysMods 其声明的参数 为 sysMods
            string paramDALName; // DAL类的参数 如 DALSysMods 其声明参数为 DSysMods          
            string validatorType = string.Empty; // 验证类型

            CheckedListBox.CheckedItemCollection checkedItems = clbTableList.CheckedItems;
            foreach (object item in checkedItems)
            {               
                tableName = item.ToString();
                className = ClassNameFormat(tableName);
                tableComments = (item as ListItem).Value;
                tableTitle = Regex.Match(tableComments, "^[^(]+").Value;
                modelName = GetModelName(tableName);
                if (string.IsNullOrEmpty(modelName))
                    modelName = txtEmptyModleName.Text;

                paramClassName = className.Substring(0, 1).ToLower() + className.Substring(1);
                dalName = tbxDALProjectName.Text + className;
                paramDALName = tbxDALProjectName.Text.Substring(0, 1).ToLower() + className;
                DataTable dt = accessDB.GetColumnsByTableName(tableName);//查询字段

                

                List<string> primaryKeys = getPrimaryKeys(dt);
              
                string commandArgumentKey = string.Empty; // 模板列绑定参数
                string deleteArgKey = string.Empty; // 删除参数
                string editArgKey = string.Empty; // 编辑参数
                string defineArg = string.Empty; // 多个主键时定义分开参数
                string queryString = string.Empty; // 类似如"if (null != Request.QueryString["guid"])" 中的null != Request.QueryString["guid"]
                string paramString = string.Empty; // 类似如 "Model.sys.Roles roles = dRoles.GetRoles(strGuid);" 中的 strGuid
                string key=string.Empty;
                string keyCoulmn = string.Empty;
                if (primaryKeys.Count > 0)
                {
                    key = NameFormat(primaryKeys[0]);
                    keyCoulmn = primaryKeys[0];
                }
                string usingNamespace=string.Empty;//页面需要引用的命名空间
                usingNamespace = string.Format("using {0}{1}{2};\n", tbxProjectName.Text, string.IsNullOrEmpty(modelName) ? "" : ".", modelName);
                usingNamespace += string.Format("using {0}{1}{2};\n", txtBLLProjectName.Text, string.IsNullOrEmpty(modelName) ? "" : ".", modelName);
                string UINamespace = string.Format("{0}{1}", tbxUIProjectName.Text, string.IsNullOrEmpty(modelName) ? "" : "." + modelName);

                // list页面aspx文件
                if (cbListAspx.Checked)
                {
                    string tempPath = string.Format("{0}\\{1}", txtTempPath.Text, "List.aspx");
                    if (!File.Exists(tempPath))
                    {
                        MessageBox.Show("List.aspx模板文件不存在！");
                        return;
                    }
                    ListAspx lsAspx = new ListAspx();
                    lsAspx.ClassName = className;
                    lsAspx.ClassTile = tableTitle;
                    lsAspx.getContent(dt, accessDB,primaryKeys);

                    string m_content =  File.ReadAllText(tempPath);//从文件中读出模板的内容
                    m_content = m_content.Replace("<#keyFild>", keyCoulmn)
                        .Replace("<#ClassName>", className)
                        .Replace("<#ClassTitle>", tableTitle)
                        .Replace("<#ListSerch>","")
                        .Replace("<#FolderPath>", "../")
                        .Replace("<#GridViewThcolspan>", lsAspx.ThNumber)
                        .Replace("<#BoundFieldItem>", lsAspx.GvShowName)
                        .Replace("<#GridViewTh>", lsAspx.NullThShow)
                        .Replace("<#ClaseNameSpace>", UINamespace);

                    //m_content = string.Format(m_content, lsAspx.ClassName,string.IsNullOrEmpty(modelName)?"./":"../",lsAspx.ClassTile,key,lsAspx.GvShowName,lsAspx.NullThShow,lsAspx.ThNumber)
                    //    .Replace("≮", "{").Replace("≯", "}");

                    BuildHelper.Save(GetSavePath() + projectName + "\\" + modelName, className + "List.aspx", m_content);


                    tempPath = string.Format("{0}\\{1}", txtTempPath.Text, "List.aspx.designer.cs");
                    if (!File.Exists(tempPath))
                    {
                        MessageBox.Show("List.aspx模板文件不存在！");
                        return;
                    }
                     m_content = File.ReadAllText(tempPath);//从文件中读出模板的内容
                  m_content=  m_content.Replace("<#ClassName>", className)
                        .Replace("<#ClaseNameSpace>", UINamespace);

                    BuildHelper.Save(GetSavePath() + projectName + "\\" + modelName, className + "List.aspx.designer.cs", m_content); 
                }

                // list页面aspx.cs文件
                if (cbListCs.Checked)
                {
                    string tempPath = string.Format("{0}\\{1}", txtTempPath.Text, "List.aspx.cs");
                    if (!File.Exists(tempPath))
                    {
                        MessageBox.Show("List.aspx模板文件不存在！");
                        return;
                    }

                    string m_content = File.ReadAllText(tempPath);//从文件中读出模板的内容
                    //m_content = string.Format(m_content, usingNamespace, className, inheritanceClass)
                    //    .Replace("≮", "{").Replace("≯", "}");

                    m_content = m_content.Replace("<#usingNamespace>", usingNamespace)
                    .Replace("<#ClaseNameSpace>", UINamespace)
                    .Replace("<#ClassName>", className);
                    BuildHelper.Save(GetSavePath()+ projectName + "\\" + modelName, className + "List.aspx.cs", m_content);  
                }                
              

                // edit页面aspx文件
                if (cbEditAspx.Checked)
                {
                    string tempPath = string.Format("{0}\\{1}", txtTempPath.Text, "Edit.aspx");
                    if (!File.Exists(tempPath))
                    {
                        MessageBox.Show("Edit.aspx模板文件不存在！");
                        return;
                    }
                    SystemModle.tempOR.EditAspx edAspx = new EditAspx();
                    edAspx.ClassName = className;
                    edAspx.setContent(dt,primaryKeys);                    

                    string m_content = File.ReadAllText(tempPath);//从文件中读出模板的内容
                    //m_content = string.Format(m_content, className, tableTitle, edAspx.ShowContent)
                    //   .Replace("≮", "{").Replace("≯", "}");
                  m_content=  m_content.Replace("<#yzList>", "").Replace("<#editTrList>", edAspx.ShowContent)
                        .Replace("<#ClassName>", className)
                        .Replace("<#ClaseNameSpace>", UINamespace);

                    BuildHelper.Save(GetSavePath() + projectName + "\\" + modelName, className + "Edit.aspx", m_content);

                    tempPath = string.Format("{0}\\{1}", txtTempPath.Text, "Edit.aspx.designer.cs");
                    if (!File.Exists(tempPath))
                    {
                        MessageBox.Show("Edit.aspx.designer.cs模板文件不存在！");
                        return;
                    }

                    m_content = File.ReadAllText(tempPath);//从文件中读出模板的内容
                    //m_content = string.Format(m_content, className, tableTitle, edAspx.ShowContent)
                    //   .Replace("≮", "{").Replace("≯", "}");
                    m_content = m_content.Replace("<#ClaseNameSpace>",UINamespace)
                        .Replace("<#ClassName>",className)
                        .Replace("<#EditDesignerItem>", edAspx.Desi);

                    BuildHelper.Save(GetSavePath() + projectName + "\\" + modelName, className + "Edit.aspx.designer.cs", m_content); 
                }
               

                // edit页面aspx.cs文件
                if (cbEditCs.Checked)
                {
                    string tempPath = string.Format("{0}\\{1}", txtTempPath.Text, "Edit.aspx.cs");
                    if (!File.Exists(tempPath))
                    {
                        MessageBox.Show("Edit.aspx.cs模板文件不存在！");
                        return;
                    }
                    EditAspxcs edAspxCs=new EditAspxcs();
                    edAspxCs.ClassName = className;
                    edAspxCs.getContent(dt,primaryKeys,accessDB);
                    string m_content = File.ReadAllText(tempPath);//从文件中读出模板的内容
                    //m_content = string.Format(m_content, usingNamespace, className, inheritanceClass, edAspxCs.LoadDate, edAspxCs.SetValue)
                    //   .Replace("≮", "{").Replace("≯", "}");
                  m_content=  m_content.Replace("<#ClaseNameSpace>",UINamespace)
                       .Replace("<#ClassName>",className)
                        .Replace("<#editLoadData>",edAspxCs.LoadDate)
                        .Replace("<#editSetValue>",edAspxCs.SetValue)
                        .Replace("<#usingNamespace>", usingNamespace);
                    BuildHelper.Save(GetSavePath() + projectName + "\\" + modelName, className + "Edit.aspx.cs", m_content);        
                }
            }
            SaveSetting();
        }

        private void BtnSelectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < clbTableList.Items.Count; i++)
            {
                clbTableList.SetItemChecked(i, true);
            }
        }

        private void btnCancelAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < clbTableList.Items.Count; i++)
            {
                clbTableList.SetItemChecked(i, !clbTableList.GetItemChecked(i));
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            fbd.Description = "选择模板路径：";
            fbd.SelectedPath = Application.StartupPath;
            //fbd.RootFolder = System.Environment.SpecialFolder.Startup;
            fbd.ShowNewFolderButton = false;
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                txtTempPath.Text = fbd.SelectedPath;    
            }            
        }

        private List<string> getPrimaryKeys(DataTable dt)
        {
            DataRow[] keyRow = dt.Select("iskey = 'Y'");
            List<string> primaryKeys = new List<string>(); 
            //主键
            if (keyRow.Length >= 1)
            {
                primaryKeys.Add(keyRow[0]["column_name"].ToString());
            }
            else if (dt.Select("column_name = 'id'").Length == 1)
            {
                primaryKeys.Add("ID");
            }
            else if (dt.Select("column_name = 'GUID'").Length == 1)
            {
                primaryKeys.Add("GUID");
            }
            else
            {
                primaryKeys.Add(dt.Rows[0]["column_name"].ToString());
            }
            return primaryKeys;
        }

        private void btnSavePath_Click(object sender, EventArgs e)
        {
            fbd.Description = "选择保存路径：";
            fbd.SelectedPath = Application.StartupPath;
            //fbd.RootFolder = System.Environment.SpecialFolder.Startup;
            fbd.ShowNewFolderButton = false;
            if (fbd.ShowDialog() == DialogResult.OK)
            {

                txtSavePath.Text = fbd.SelectedPath;
			}//foreign key
        }

        private void btnDo_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            CheckedListBox.CheckedItemCollection checkedItems = clbTableList.CheckedItems;
            //字段名称： #FildsName 字段内容：#FildsID
            foreach (object item in checkedItems)
            {
                string tableName = item.ToString();
                DataTable dt = accessDB.GetColumnsByTableName(tableName);
				Common cm = new Common();
                foreach (DataRow row in dt.Rows)
                {
                    String str=txtNormal.Text.Replace("#FildsName",row["comments"].ToString());
                    str=str.Replace("#FildsID", row["column_name"].ToString());
					string formartColumn = Common.NameFormat(row["column_name"].ToString());
					str = str.Replace("#FildsFormart", formartColumn);
					string dataType = accessDB.GetValidatorType(row["data_type"].ToString());
					str = str.Replace("#FildsType", dataType);
					//DBType
					string newType = accessDB.GetDataType(row["data_type"].ToString(), Convert.ToInt16(row["data_length"]));
					str = str.Replace("#DBType", newType);
					str = str.Replace("#maxlength", row["data_length"].ToString());
                    sb.AppendLine(str);
                }
            }

            txtValueContent.Text = sb.ToString();
        }

        private void btnMysqlInsert_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            StringBuilder sbDbNull = new StringBuilder(); // 当时间为''值时 录入DbNull.Value

            string nameSpace = tbxDALNamespace.Text;
            string projectName = tbxDALProjectName.Text;
            string inheritanceClass = tbxDALInheritance.Text;
            string modelName;
            string className;
            string tableName;

            string tempPath = string.Format("{0}\\{1}", txtTempPath.Text, "DA.cs");
            if (!File.Exists(tempPath))
            {
                MessageBox.Show("DA.cs模板文件不存在！");
                return;
            }

            CheckedListBox.CheckedItemCollection checkedItems = clbTableList.CheckedItems;
            foreach (object item in checkedItems)
            {
                sb = new StringBuilder();
                tableName = item.ToString();
                className = ClassNameFormat(tableName);
                modelName = GetModelName(tableName);
                if (string.IsNullOrEmpty(modelName))
                    modelName = txtEmptyModleName.Text;

                DataTable dt = accessDB.GetColumnsByTableName(tableName);
                List<string> primaryKeys = getPrimaryKeys(dt);


                SystemModle.tempOR.DACsMysql da = new DACsMysql();
                da.Namespace = string.Format("{0}{1}{2}", tbxDALProjectName.Text, string.IsNullOrEmpty(modelName) ? "" : ".", modelName);
                da.ClassName = className;
                da.TableAllName = tableName;
                da.getContent(dt, accessDB, primaryKeys);

                rtbMysql.AppendText( da.OrContent);

                rtbMysql.AppendText("\r\n\r\n\r\n");
               
            }
            SaveSetting();
        }

        private void btnExec_Click(object sender, EventArgs e)
        { 
            DataTable dtMain = db.ExecuteQuery(rtbsqlForOBj.Text);
            if (dtMain == null)
            {
                MessageBox.Show("没有数据。");
                return;
            } 
                 
                StringBuilder sb_pro=new StringBuilder();
                StringBuilder sb_Dr = new StringBuilder();

                sb_pro.AppendLine("public class xx ");
                sb_pro.AppendLine("{");
                foreach (DataColumn dc in dtMain.Columns)
                {
                   string dcType= dc.DataType.ToString();
                   string cName = dc.ColumnName;
                   string str = "public string " + cName + " { get; set; }";
                   sb_pro.AppendLine(str);

                   str = "this." + cName + "=row[\"" + cName + "\"].ToString().Trim();";
                   sb_Dr.AppendLine(str);
                }

                sb_pro.AppendLine("public xx(DataRow row)");
                sb_pro.AppendLine("{");
                sb_pro.AppendLine(sb_Dr.ToString());

                sb_pro.AppendLine("}");
                sb_pro.AppendLine("}");

                rtbResutlObj.AppendText(sb_pro.ToString());        
        }

        private void btnBL_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            StringBuilder sbDbNull = new StringBuilder(); // 当时间为''值时 录入DbNull.Value

            string nameSpace = tbxBLLNamespace.Text;
            string projectName = txtBLLProjectName.Text;
            //string inheritanceClass = tbxDALInheritance.Text;
            string modelName;
            string className;
            string tableName;

            string tempPath = string.Format("{0}\\{1}", txtTempPath.Text, "BLL.cs");
            if (!File.Exists(tempPath))
            {
                MessageBox.Show("BLL.cs模板文件不存在！");
                return;
            }

            CheckedListBox.CheckedItemCollection checkedItems = clbTableList.CheckedItems;
            foreach (object item in checkedItems)
            {
                sb = new StringBuilder();
                tableName = item.ToString();
                className = ClassNameFormat(tableName);
                modelName = GetModelName(tableName);
                if (string.IsNullOrEmpty(modelName))
                    modelName = txtEmptyModleName.Text;

                DataTable dt = accessDB.GetColumnsByTableName(tableName);
                List<string> primaryKeys = getPrimaryKeys(dt);

                //引用命名空间
                string usingNamespace = string.Empty;
                usingNamespace += string.Format("using {0}{1}{2};\n", tbxProjectName.Text, string.IsNullOrEmpty(modelName) ? "" : ".", modelName);
                usingNamespace += string.Format("using {0}{1}{2};\n", tbxDALProjectName.Text, string.IsNullOrEmpty(modelName) ? "" : ".", modelName);
                usingNamespace += tbxBLLNamespace.Text;

                SystemModle.tempOR.BLLcs _bll = BLLcsFactory.Create();
                _bll.Namespace = string.Format("{0}{1}{2}", txtBLLProjectName.Text, string.IsNullOrEmpty(modelName) ? "" : ".", modelName);
                _bll.ClassName = className;
                _bll.TableAllName = tableName;
                _bll.getContent(dt, accessDB, primaryKeys);

                string m_content = File.ReadAllText(tempPath);//从文件中读出模板的内容
                m_content = m_content.Replace("<#usingNamespace>", usingNamespace)
                      .Replace("<#ClaseNameSpace>", _bll.Namespace)
                      .Replace("<#ClassTitle>", _bll.TableTitle)
                      .Replace("<#ClassName>", className)
                      .Replace("<#daContent>", _bll.OrContent);

                BuildHelper.Save(GetSavePath() + projectName + "\\" + modelName, className + "BLL.cs", m_content);
            }
            SaveSetting();
        }

        

      

		
    }
}