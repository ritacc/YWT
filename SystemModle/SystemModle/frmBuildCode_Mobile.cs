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

        private void btnForApp_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            StringBuilder sbField = new StringBuilder();
            StringBuilder sbRow = new StringBuilder();

            string projectName = tbxProjectName.Text;
            string modelName;
            string className;
            string tableName;

            CheckedListBox.CheckedItemCollection checkedItems = clbTableList.CheckedItems;

            string tempPath = string.Format("{0}\\{1}", txtTempPath.Text, "spSave.sql");
            if (!File.Exists(tempPath))
            {
                MessageBox.Show("Controller.cs模板文件不存在！");
                return;
            }

            foreach (object item in checkedItems)
            {


                sb = new StringBuilder();
                sbRow = new StringBuilder();
                tableName = item.ToString();
                className = ClassNameFormat(tableName);
                modelName = GetModelName(tableName);
                if (string.IsNullOrEmpty(modelName))
                    modelName = txtEmptyModleName.Text;

                string FormartClassName = Common.NameFormat(tableName);
                className = FormartClassName;
                DataTable dt = accessDB.GetColumnsByTableName(tableName);

                SystemModle.tempOR.ORcs or = new SystemModle.tempOR.ORcs();
                or.Namespace = string.Format("{0}{1}{2}", tbxProjectName.Text, string.IsNullOrEmpty(modelName) ? "" : ".", modelName);
                or.TableName = className;
                List<string> primaryKeys = getPrimaryKeys(dt);

                string strPrimaryKey = string.Empty;
                string strKeyFormat = string.Empty;
                if (primaryKeys != null)
                {
                    if (primaryKeys.Count > 0)
                    {
                        strPrimaryKey = primaryKeys[0];//<#Key>
                        strKeyFormat = Common.NameFormat(strPrimaryKey);//<#KeyFormat>
                    }
                }
                string m_content = "";
                //tempPath = string.Format("{0}\\{1}", txtTempPath.Text, "Controller.cs");
                //string m_content = File.ReadAllText(tempPath);//从文件中读出模板的内容
                //or.getContent(dt, accessDB, primaryKeys);

                //m_content = m_content.Replace("<#ClassName>", className)
                //    .Replace("<#KeyFormat>", strKeyFormat)
                //    .Replace("<#Key>", strPrimaryKey);

                //BuildHelper.Save(GetSavePath() + "\\Controllers\\", className + "Controller.cs", m_content);

                //Create
                StringBuilder sbCreate = new StringBuilder();
                StringBuilder sbModel = new StringBuilder();
                StringBuilder sbContentSave = new StringBuilder();

                string[] ArrSaveHN = { "CREATED_BY", "CREATION_DATE", "LAST_UPDATED_BY", "LAST_UPDATE_DATE", strPrimaryKey };
                //Index
                StringBuilder sbListTh = new StringBuilder();
                StringBuilder sbListTd = new StringBuilder();
                // sql Save
                StringBuilder sbSavePara = new StringBuilder();
                StringBuilder sbAddFiles = new StringBuilder();
                StringBuilder sbAddValues = new StringBuilder();
                StringBuilder sbUpdateFiles = new StringBuilder();


                string strSavePara = "	@#FildsID		#DBType #nullDef,";
                string strAddFiles = "				#FildsID,";
                string strAddValues = "				@#FildsID,";
                string strUpdateFiles = "				#FildsID=@#FildsID,";
               
                //sql
                StringBuilder sbLoad = new StringBuilder();
                foreach (DataRow dr in dt.Rows)
                {
                    string colunName = dr["column_name"].ToString().ToUpper();

                    string[] ArrSavePara = { "CREATED_BY", "CREATION_DATE", "LAST_UPDATED_BY", "LAST_UPDATE_DATE" };
                    //Search Load

                    sbSavePara.AppendLine(HeadReplace(dr, strSavePara));
                    if (colunName != strPrimaryKey.ToUpper())//过滤掉，Key
                    {
                        sbAddFiles.AppendLine(HeadReplace(dr, strAddFiles));
                        sbAddValues.AppendLine(HeadReplace(dr, strAddValues));
                        sbUpdateFiles.AppendLine(HeadReplace(dr, strUpdateFiles));
                    }
                }
                string tableAllRemove_ = "";
                tableAllRemove_ = className.Replace("_", "");
                
                #region 存储过程 
                #region spSearchmin
                //Search
                tempPath = string.Format("{0}\\{1}", txtTempPath.Text, "spSearchmin.Sql");
                if (!File.Exists(tempPath))
                {
                    MessageBox.Show("spSearch.Sql模板文件不存在！");
                    return;
                }
                m_content = File.ReadAllText(tempPath, Encoding.Default);
                m_content = m_content.Replace("<#ClassName>", className)
                    .Replace("<#KeyFormat>", strKeyFormat)
                    .Replace("<#Key>", strPrimaryKey)
                    .Replace("<#Filds>", RepleseEndDH(sbLoad.ToString()))
                    .Replace("<#TableName>", tableName)
                    .Replace("<#TableAllRemove>", tableAllRemove_)
                    .Replace("<#Date>", DateTime.Now.ToString("yyyy-MM-dd"));

                BuildHelper.Save(GetSavePath() + "\\Sql", "sp_" + tableAllRemove_ + "_Search_Min.sql", m_content);
                #endregion

                #region spSearchpage
                //Search
                tempPath = string.Format("{0}\\{1}", txtTempPath.Text, "spSearchpage.Sql");
                if (!File.Exists(tempPath))
                {
                    MessageBox.Show("spSearchpage.Sql模板文件不存在！");
                    return;
                }
                m_content = File.ReadAllText(tempPath, Encoding.Default);
                m_content = m_content.Replace("<#ClassName>", className)
                    .Replace("<#KeyFormat>", strKeyFormat)
                    .Replace("<#Key>", strPrimaryKey)
                    .Replace("<#Filds>", RepleseEndDH(sbLoad.ToString()))
                    .Replace("<#TableName>", tableName)
                    .Replace("<#TableAllRemove>", tableAllRemove_)
                    .Replace("<#Date>", DateTime.Now.ToString("yyyy-MM-dd"));

                BuildHelper.Save(GetSavePath() + "\\Sql", "sp_" + tableAllRemove_ + "_Search_page.sql", m_content);
                #endregion
                
                #region spSave.sql
                tempPath = string.Format("{0}\\{1}", txtTempPath.Text, "spSave.sql");
                if (!File.Exists(tempPath))
                {
                    MessageBox.Show("spSave.Sql模板文件不存在！");
                    return;
                }
                m_content = File.ReadAllText(tempPath, Encoding.Default);
                m_content = m_content.Replace("<#ClassName>", className)
                    .Replace("<#Key>", strPrimaryKey)
                    .Replace("<#TableName>", tableName)
                    .Replace("<#TableAllRemove>",tableAllRemove_)
                    .Replace("<#Date>", DateTime.Now.ToString("yyyy-MM-dd"))
                    //内容 
                    .Replace("<#SavePara>", RepleseEndDH(sbSavePara.ToString()))
                    .Replace("<#AddFiles>", RepleseEndDH(sbAddFiles.ToString()))
                    .Replace("<#AddValues>", RepleseEndDH(sbAddValues.ToString()))
                    .Replace("<#UpdateFiles>", RepleseEndDH(sbUpdateFiles.ToString()));

                BuildHelper.Save(GetSavePath() + "\\Sql", "sp_" + tableAllRemove_ + "_Save.sql", m_content);
                #endregion

                #region spDelete.Sql

                //<#Key>	<#TableName> <#ClassName>	<#Date>
                tempPath = string.Format("{0}\\{1}", txtTempPath.Text, "spDelete.Sql");
                if (!File.Exists(tempPath))
                {
                    MessageBox.Show("Delete.Sql模板文件不存在！");
                    return;
                }
                m_content = File.ReadAllText(tempPath, Encoding.Default);
                m_content = m_content.Replace("<#ClassName>", className)
                    .Replace("<#Key>", strPrimaryKey)
                    .Replace("<#TableName>", tableName)
                    .Replace("<#TableAllRemove>", tableAllRemove_)
                    .Replace("<#Date>", DateTime.Now.ToString("yyyy-MM-dd"));

                BuildHelper.Save(GetSavePath() + "\\Sql", "sp_" + tableAllRemove_ + "_Delete.sql", m_content);
                #endregion

                #region spLoad
                //<#Filds>
                tempPath = string.Format("{0}\\{1}", txtTempPath.Text, "spLoad.Sql");
                if (!File.Exists(tempPath))
                {
                    MessageBox.Show("spLoad.Sql模板文件不存在！");
                    return;
                }
                m_content = File.ReadAllText(tempPath, Encoding.Default);
                m_content = m_content.Replace("<#ClassName>", className)
                    .Replace("<#Key>", strPrimaryKey)
                    .Replace("<#Filds>", RepleseEndDH(sbLoad.ToString()))
                    .Replace("<#TableName>", tableName)
                    .Replace("<#TableAllRemove>", tableAllRemove_)
                    .Replace("<#Date>", DateTime.Now.ToString("yyyy-MM-dd"));

                BuildHelper.Save(GetSavePath() + "\\Sql", "sp+" + tableAllRemove_ + "_Load.sql", m_content);
                #endregion
                #endregion
               


                
            } 

            SaveSetting();


        }


        private void btnDal_Click(object sender, EventArgs e)
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

                string tableAllRemove_ = "";
                tableAllRemove_ = className.Replace("_", "");

                //引用命名空间
                string usingNamespace = string.Format("using {0}{1}{2};\n", tbxProjectName.Text, string.IsNullOrEmpty(modelName) ? "" : ".", modelName);
                usingNamespace += tbxDALNamespace.Text;

                SystemModle.tempOR.DAcsBase da = DAcsAPPFactory.Create();
                da.Namespace = string.Format("{0}{1}{2}", tbxDALProjectName.Text, string.IsNullOrEmpty(modelName) ? "" : ".", modelName);
                da.ClassName = className;
                da.TableAllName = tableName;
                da.getContent(dt, accessDB, primaryKeys);

                string m_content = File.ReadAllText(tempPath);//从文件中读出模板的内容
                //m_content = string.Format(m_content, usingNamespace, da.Namespace, da.TableTitle, da.ClassName, da.OrContent)
                //    .Replace("≮", "{").Replace("≯", "}");
                m_content = m_content.Replace("<#usingNamespace>", usingNamespace)
                      .Replace("<#ClaseNameSpace>", da.Namespace)
                      .Replace("<#ClassTitle>", da.TableTitle)
                      .Replace("<#ClassName>", className)
                      .Replace("<#daContent>", da.OrContent);

                BuildHelper.Save(GetSavePath() + projectName + "\\" + modelName, className + "DA.cs", m_content);


                #region ashx
                //
                tempPath = string.Format("{0}\\{1}", txtTempPath.Text, "ashx.ashx.cs");
                if (!File.Exists(tempPath))
                {
                    MessageBox.Show("ashx.ashx.cs模板文件不存在！");
                    return;
                }
                ////引用命名空间
                //string usingNamespace = string.Empty;
                //usingNamespace += string.Format("using {0}{1}{2};\n", tbxProjectName.Text, string.IsNullOrEmpty(modelName) ? "" : ".", modelName);
                //usingNamespace += string.Format("using {0}{1}{2};\n", tbxDALProjectName.Text, string.IsNullOrEmpty(modelName) ? "" : ".", modelName);
                //usingNamespace += tbxBLLNamespace.Text;


                m_content = File.ReadAllText(tempPath, Encoding.Default);
                m_content = m_content.Replace("<#ClassName>", className)
                    .Replace("<#usingNamespace>", usingNamespace)
                    .Replace("<#TableAllRemove>", tableAllRemove_);

                BuildHelper.Save(GetSavePath() + "\\WEB", "HDL_" + tableAllRemove_ + ".ashx.cs", m_content);
                //ashx.ashx

                tempPath = string.Format("{0}\\{1}", txtTempPath.Text, "ashx.ashx");
                if (!File.Exists(tempPath))
                {
                    MessageBox.Show("ashx.ashx.cs模板文件不存在！");
                    return;
                }
                m_content = File.ReadAllText(tempPath, Encoding.Default);
                m_content = m_content.Replace("<#ClassName>", className).Replace("<#TableAllRemove>", tableAllRemove_);

                BuildHelper.Save(GetSavePath() + "\\WEB", "HDL_" + tableAllRemove_ + ".ashx", m_content);
                #endregion

            }


              tempPath = string.Format("{0}\\{1}", txtTempPath.Text, "BLL.cs");
            if (!File.Exists(tempPath))
            {
                MessageBox.Show("BLL.cs模板文件不存在！");
                return;
            }

            
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
                string key = "";
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
                      .Replace("<#ClassName>", className)
                      .Replace("<#daContent>", _bll.OrContent);

                BuildHelper.Save(GetSavePath() + projectName + "\\" + modelName, className + "BLL.cs", m_content);
            }

            SaveSetting();
        }

        


        
    }
}
