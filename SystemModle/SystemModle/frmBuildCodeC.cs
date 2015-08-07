using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data;
using SystemModle.tempOR;

namespace SystemModle
{
	public partial class frmBuildCode
	{
		private void btnMVC_Click(object sender, EventArgs e)
		{
			StringBuilder sb = new StringBuilder();
			StringBuilder sbField = new StringBuilder();
			StringBuilder sbRow = new StringBuilder();

			string projectName = tbxProjectName.Text;
			string modelName;
			string className;
			string tableName;

			CheckedListBox.CheckedItemCollection checkedItems = clbTableList.CheckedItems;

			string tempPath = string.Format("{0}\\{1}", txtTempPath.Text, "Controller.cs");
			if (!File.Exists(tempPath))
			{
				MessageBox.Show("Controller.cs模板文件不存在！");
				return;
			}
			StringBuilder CreateSB=new StringBuilder();
			CreateSB.AppendLine("            <tr>");
			CreateSB.AppendLine("                <td>");
			CreateSB.AppendLine("                    <%=<#ClassName>Text.#FildsFormart %>");
			CreateSB.AppendLine("                    <span class=\"asterisk\">＊</span>");
			CreateSB.AppendLine("                </td>");
			CreateSB.AppendLine("                <td>");
			CreateSB.AppendLine("                    <%=Html.TextBoxFor(m => m.#FildsFormart, htmlAttributes: new { maxlength = #maxlength, style = \"width:280px;\" })%>");
			CreateSB.AppendLine("                    <div>");
			CreateSB.AppendLine("                        <%:Html.ValidationMessageFor(m => m.#FildsFormart)%>");
			CreateSB.AppendLine("                    </div>");
			CreateSB.AppendLine("                </td> ");
			CreateSB.AppendLine("            </tr>");
			string CreateStr = CreateSB.ToString();

			string ModelStr = "		[DbField(\"#FildsID\")]\r\n"+
"		public #FildsType #FildsFormart { get; set; }";

			StringBuilder sbSave=new StringBuilder();
			sbSave.AppendLine("        [DbParameter(\"#FildsID\")]");
			sbSave.AppendLine("        public #FildsType #FildsFormart");
			sbSave.AppendLine("        {");
			sbSave.AppendLine("            get { return m_Parent.#FildsFormart; }");
			sbSave.AppendLine("            set { m_Parent.#FildsFormart = value; }");
			sbSave.AppendLine("        }");
			string SaveStr = sbSave.ToString();

			string LoadStr = "  <#TableName>.#FildsID,";

			string ListTh = "						<th class=\"w100 t_left\"><%=<#ClassName>Text.#FildsFormart %></th>";
			
			string ListTd = "						<td class=\"w100 t_left\"><%=item.#FildsFormart %></td>";
			
			//Save
			string strSavePara = "	@#FildsID		#DBType #nullDef,";
			string strAddFiles = "				#FildsID,";
			string strAddValues = "				@#FildsID,";
			string strUpdateFiles = "				#FildsID=@#FildsID,";

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

				tempPath = string.Format("{0}\\{1}", txtTempPath.Text, "Controller.cs");
				string m_content = File.ReadAllText(tempPath);//从文件中读出模板的内容
				or.getContent(dt, accessDB, primaryKeys);
								
				m_content = m_content.Replace("<#ClassName>", className)
					.Replace("<#KeyFormat>", strKeyFormat)
					.Replace("<#Key>", strPrimaryKey);

				BuildHelper.Save(GetSavePath() + "\\Controllers\\", className + "Controller.cs", m_content);

				//Create
				StringBuilder sbCreate = new StringBuilder();
				StringBuilder sbModel = new StringBuilder();
				StringBuilder sbContentSave = new StringBuilder();

				string[] ArrSaveHN = { "BU_CODE", "WH_CODE", "CREATED_BY", "CREATION_DATE", "LAST_UPDATED_BY", "LAST_UPDATE_DATE", strPrimaryKey };
				//Index
				StringBuilder sbListTh= new StringBuilder();
				StringBuilder sbListTd = new StringBuilder();
				// sql Save
				StringBuilder sbSavePara = new StringBuilder();
				StringBuilder sbAddFiles = new StringBuilder();
				StringBuilder sbAddValues = new StringBuilder();
				StringBuilder sbUpdateFiles = new StringBuilder();

				CreateStr = CreateStr.Replace("<#ClassName>", className);
				//sql
				StringBuilder sbLoad = new StringBuilder();
				foreach (DataRow dr in dt.Rows)
				{
					string colunName = dr["column_name"].ToString().ToUpper();

					if (!isHL(ArrSaveHN, colunName))
						sbCreate.AppendLine(HeadReplace(dr, CreateStr));

					sbModel.AppendLine(HeadReplace(dr, ModelStr));

					string[] ArrSavePara = { "BU_CODE", "WH_CODE", "SYS_CODE", "CREATED_BY", "CREATION_DATE", "LAST_UPDATED_BY", "LAST_UPDATE_DATE" };

					if (!isHL(ArrSavePara, colunName))
					{
						sbContentSave.AppendLine(HeadReplace(dr, SaveStr));
					}
					else
					{
						if (colunName == "BU_CODE")
						{
							sbContentSave.AppendLine(
@"		[DbParameter(<#>BU_CODE<#>)]
		public string BuCode
		{
			get { return App.Framework.Security.User.Current.BUCode; }
		}".Replace("<#>", "\""));
						}
						else if (colunName == "WH_CODE")
						{
							sbContentSave.AppendLine(
@"		[DbParameter(<#>WH_CODE<#>)]
		public string WhCode
		{
			get { return App.Framework.Security.User.Current.ShopCode; }
		}".Replace("<#>", "\""));
						}
						else if (colunName == "SYS_CODE")
						{
							sbContentSave.AppendLine(
@"		[DbParameter(<#>SYS_CODE<#>)]
		public string SYS_CODE
		{
			get { return SecurityPortal.ApplicationName; }
		}".Replace("<#>", "\""));
						}
					}


					//Search Load
					sbLoad.AppendLine(HeadReplace(dr, LoadStr));

					sbSavePara.AppendLine(HeadReplace(dr, strSavePara));
					if (colunName != strPrimaryKey.ToUpper())//过滤掉，Key
					{
						sbAddFiles.AppendLine(HeadReplace(dr, strAddFiles));
						sbAddValues.AppendLine(HeadReplace(dr, strAddValues));
						sbUpdateFiles.AppendLine(HeadReplace(dr, strUpdateFiles));
					}
					if (!isHL(ArrSaveHN, colunName))
					{
						sbListTh.AppendLine(HeadReplace(dr, ListTh));
						sbListTd.AppendLine(HeadReplace(dr, ListTd));
					}
				}

				#region Create.aspx
				tempPath = string.Format("{0}\\{1}", txtTempPath.Text, "Create.aspx");
				if (!File.Exists(tempPath))
				{
					MessageBox.Show("Create.aspx模板文件不存在！");
					return;
				}

				 m_content = File.ReadAllText(tempPath,Encoding.Default);
				m_content = m_content.Replace("<#ClassName>", className)
					.Replace("<#EditTr>", sbCreate.ToString());
				BuildHelper.Save(GetSavePath() + "\\View\\" + className, className + "Create.aspx", m_content);
				#endregion

				#region Edit
				//Edit
				tempPath = string.Format("{0}\\{1}", txtTempPath.Text, "Edit.aspx");
				if (!File.Exists(tempPath))
				{
					MessageBox.Show("Edit.aspx模板文件不存在！");
					return;
				}
				m_content = File.ReadAllText(tempPath, Encoding.Default);
				m_content = m_content.Replace("<#ClassName>", className)
					.Replace("<#KeyFormat>", strKeyFormat)
					.Replace("<#Key>", strPrimaryKey)
					.Replace("<#EditTr>", sbCreate.ToString());

				BuildHelper.Save(GetSavePath() + "\\View\\" + className, className + "Edit.aspx", m_content);
				#endregion

				#region Index
				//Edit
				tempPath = string.Format("{0}\\{1}", txtTempPath.Text, "List.aspx");
				if (!File.Exists(tempPath))
				{
					MessageBox.Show("Index.aspx模板文件不存在！");
					return;
				}
				m_content = File.ReadAllText(tempPath, Encoding.Default);
				m_content = m_content.Replace("<#tdlist>", sbListTd.ToString())
					.Replace("<#thList>", sbListTh.ToString())
					.Replace("<#KeyFormat>", strKeyFormat)
					.Replace("<#Key>", strPrimaryKey)
					.Replace("<#ClassName>", className)
					;

				BuildHelper.Save(GetSavePath() + "\\View\\" + className, className+"List.aspx", m_content);
				#endregion

				#region Model
				tempPath = string.Format("{0}\\{1}", txtTempPath.Text, "OR.cs");
				if (!File.Exists(tempPath))
				{
					MessageBox.Show("OR.cs模板文件不存在！");
					return;
				}
				m_content = File.ReadAllText(tempPath, Encoding.Default);
				m_content = m_content.Replace("<#ClassName>", className)
					.Replace("<#FieldModel>", sbModel.ToString())
					.Replace("<#KeyFormat>", strKeyFormat)
					.Replace("<#Key>", strPrimaryKey)
					.Replace("<#SaveFilds>", sbContentSave.ToString());

				BuildHelper.Save(GetSavePath() + "\\Model", className + ".cs", m_content);
				#endregion


				//存储过程 
				#region spSearch
				//Search
				tempPath = string.Format("{0}\\{1}", txtTempPath.Text, "spSearch.Sql");
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
					.Replace("<#Date>", DateTime.Now.ToString("yyyy-MM-dd"));

				BuildHelper.Save(GetSavePath() + "\\Sql", "spSearch" + className + ".sql", m_content);
				#endregion

				//Save
				//<#SavePara>	<#AddFiles>	<#AddValues>	<#UpdateFiles>
				//StringBuilder sbSavePara = new StringBuilder();
				//StringBuilder sbAddFiles = new StringBuilder();
				//StringBuilder sbAddValues = new StringBuilder();
				//StringBuilder sbUpdateFiles = new StringBuilder();
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
					.Replace("<#Date>", DateTime.Now.ToString("yyyy-MM-dd"))
					//内容 
					.Replace("<#SavePara>",RepleseEndDH( sbSavePara.ToString()))
					.Replace("<#AddFiles>",RepleseEndDH( sbAddFiles.ToString()))
					.Replace("<#AddValues>",RepleseEndDH( sbAddValues.ToString()))
					.Replace("<#UpdateFiles>",RepleseEndDH( sbUpdateFiles.ToString()));

				BuildHelper.Save(GetSavePath() + "\\Sql", "spSave" + className + ".sql", m_content);
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
					.Replace("<#Date>", DateTime.Now.ToString("yyyy-MM-dd"));

				BuildHelper.Save(GetSavePath() + "\\Sql", "spDelete" + className + ".sql", m_content);
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
					.Replace("<#Date>", DateTime.Now.ToString("yyyy-MM-dd"));

				BuildHelper.Save(GetSavePath() + "\\Sql", "spLoad" + className + ".sql", m_content);
				#endregion
			}
			SaveSetting();


		}

		public bool isHL(string[] arr, string val)
		{
			foreach (string str in arr)
			{
				if (str == val)
					return true;
			}
			return false;
		}


		private string HeadReplace(DataRow row, string Source)
		{
			if (row["nullable"].ToString().Trim() == "1")
			{
				Source = Source.Replace("<span class=\"asterisk\">＊</span>", "");
			}

			String str = Source.Replace("#FildsName", row["comments"].ToString());
			str = str.Replace("#FildsID", row["column_name"].ToString());
			string formartColumn = Common.NameFormat(row["column_name"].ToString());
			str = str.Replace("#FildsFormart", formartColumn);
			string dataType = accessDB.GetValidatorType(row["data_type"].ToString(), row["nullable"].ToString());
			str = str.Replace("#FildsType", dataType);
			//DBType
			string newType = accessDB.GetDataType(row["data_type"].ToString(), Convert.ToInt16(row["data_length"]));
			str = str.Replace("#DBType", newType);
			str = str.Replace("#maxlength", row["data_length"].ToString());

			string Repstr = "";
			if (row["nullable"].ToString().Trim() == "1")
			{
				string mtempType = newType;
				if (newType == "nvarchar")
					Repstr += " =N''";
				else if (mtempType == "DateTime" || mtempType == "int"
					 || mtempType == "decimal(11,2)" || mtempType == "float" || mtempType == "long")
				{
					Repstr += " =NULL";
				}//"bigint", "int", "DateTime", "long", "decimal", "float"
			}
			
			str = str.Replace("#nullDef", Repstr);
			if (newType == "int" || newType == "decimal(11,2)" || newType == "long" || newType == "float")
			{
				str = str.Replace("t_left", "t_right");
			}
			return str;
		}


		string RepleseEndDH(string value)
		{
			if (value.EndsWith(","))
				value= value.Substring(0, value.Length - 1);
			if (value.EndsWith(",\r\n"))
				value = value.Substring(0, value.Length - 3);
			return value;
		}
	}
}
