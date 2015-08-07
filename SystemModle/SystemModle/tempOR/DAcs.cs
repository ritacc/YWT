using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Text.RegularExpressions;

namespace SystemModle.tempOR
{
    public abstract class DAcsBase:Common
    {

      protected  string m_usingNamespace;
        /// <summary>
        /// {0}:引用命名空间
        /// </summary>
        public string UsingNamespace
        {
            get { return m_usingNamespace; }
            set { m_usingNamespace = value; }
        }

        protected string m_namespace;
        /// <summary>
        /// {1}命名空间
        /// </summary>
        public string Namespace
        {
            get { return m_namespace; }
            set { m_namespace = value; }
        }
        protected string m_tableTitle;
        /// <summary>
        /// {2}表标题
        /// </summary>
        public string TableTitle
        {
            get { return m_tableTitle; }
            set { m_tableTitle = value; }
        }

        protected string m_className;
        /// <summary>
        /// {3}表名
        /// </summary>
        public string ClassName
        {
            get { return m_className; }
            set { m_className = value; }
        }

        protected string m_orContent;
        /// <summary>
        /// {4}内容
        /// </summary>
        public string OrContent
        {
            get { return m_orContent; }
            set { m_orContent = value; }
        }

        protected string m_tableAllName;
        /// <summary>
        /// 数据库中表的名称,上面的为，最后的名称，没有t_<模块>
        /// </summary>
        public string TableAllName
        {
            get { return m_tableAllName; }
            set { m_tableAllName = value; }
        }

        public abstract void getContent(DataTable dt, SystemModle.Access.AccessDB accessDB, List<string> primaryKeys);


        public string GetSelectFileds(DataTable dt)
        {
            string selectField = string.Empty;
            string column_name;
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                column_name = dt.Rows[j]["column_name"].ToString();
                selectField += column_name;
                if (j < dt.Rows.Count - 1)
                {
                    selectField += ", ";
                }
            }
            return selectField;
        }

       
        #region 插入
        /// <summary>
        /// 插入values
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public string GetParameterFiledsInsert(DataTable dt)
        {
            string FiledsInsert = string.Empty;
            string column_name;
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                column_name = dt.Rows[j]["column_name"].ToString();
                if (column_name.ToLower() == "create_date" || column_name.ToLower() == "last_modify_date")
                {
                    FiledsInsert += "getdate()";
                }
                else
                {
                    FiledsInsert += "@" + column_name;
                }
                if (j < dt.Rows.Count - 1)
                {
                    FiledsInsert += ", ";
                }
            }
            return FiledsInsert;
        }
        public StringBuilder GetParameterInsert(DataTable dt, SystemModle.Access.AccessDB accessDB, string paramClassName)
        {
            StringBuilder sbParameter = new StringBuilder();
            string column_name;
            string column_title; // 字段显示名称
            string column_comments;
            string data_type;
            string data_length;
            string field;
            string validatorType;
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                column_name = dt.Rows[j]["column_name"].ToString();
                data_type = dt.Rows[j]["data_type"].ToString();
                data_length = dt.Rows[j]["data_length"].ToString();
                column_comments = dt.Rows[j]["comments"].ToString();
                field = NameFormat(column_name);
                column_title = Regex.Match(column_comments, "^[^(]+").Value;
                validatorType = accessDB.GetValidatorType(data_type);
                if (column_name.ToLower() != "create_date" && column_name.ToLower() != "last_modify_date")
                {
                    sbParameter.Append(
                        string.Format("                new SqlParameter(\"@{0}\", SqlDbType.{1}, {2}, ParameterDirection.Input, false, 0, 0, \"{0}\", DataRowVersion.Default, {3}.{4})",
                        column_name, accessDB.GetDataType(data_type), data_length, paramClassName, field));

                    if (j < dt.Rows.Count - 1)
                    {
                        sbParameter.AppendLine(",");
                    }
                }

                //if (dt.Rows[j]["nullable"].ToString() == "Y" && validatorType == "date")
                //{
                //    sbDbNull.AppendFormat("\n\n\t\t\t// {0}\n\t\t\tif (string.IsNullOrEmpty({1}.{2}))\n\t\t\t{\n\t\t\t\tparameters[{3}].Value = DBNull.Value;\n\t\t\t}",
                //        column_title, paramClassName, field, j);
                //}
            }
            return sbParameter;
        }
        #endregion
        #region Update
        List<string> UpdatePCFids = new List<string>() { "creator_user", "create_date" };
        public StringBuilder GetParameterUpdate(DataTable dt, SystemModle.Access.AccessDB accessDB, string paramClassName)
        {
            StringBuilder sbParameter = new StringBuilder();
            string column_name;
            string column_title; // 字段显示名称
            string column_comments;
            string data_type;
            string data_length;
            string field;
            string validatorType;
           
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                column_name = dt.Rows[j]["column_name"].ToString();
                if (UpdatePCFids.Contains(column_name.ToLower()))
                    continue;
                data_type = dt.Rows[j]["data_type"].ToString();
                data_length = dt.Rows[j]["data_length"].ToString();
                column_comments = dt.Rows[j]["comments"].ToString();
                field = NameFormat(column_name);
                column_title = Regex.Match(column_comments, "^[^(]+").Value;
                validatorType = accessDB.GetValidatorType(data_type);
                if (column_name.ToLower() != "last_modify_date")
                {
                    sbParameter.Append(
                        string.Format("                new SqlParameter(\"@{0}\", SqlDbType.{1}, {2}, ParameterDirection.Input, false, 0, 0, \"{0}\", DataRowVersion.Default, {3}.{4})",
                        column_name, accessDB.GetDataType(data_type), data_length, paramClassName, field));
                    if (j < dt.Rows.Count - 1)
                    {
                        sbParameter.AppendLine(",");
                    }
                }
            }
            return sbParameter;
        }
        /// <summary>
        /// 更新字段。
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="primaryKeys"></param>
        /// <returns></returns>
        public string GetUpdateFilds(DataTable dt, List<string> primaryKeys)
        {
            string updateField = string.Empty;
            string column_name;
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                column_name = dt.Rows[j]["column_name"].ToString();
                if (UpdatePCFids.Contains(column_name.ToLower()))
                    continue;

                bool isKey = primaryKeys.Contains(column_name);
                if (!isKey)
                {
                    if (column_name.ToLower() == "last_modify_date")
                    {
                        updateField += "" + column_name + "=getdate()";
                    }
                    else
                    {
                        updateField +=   column_name + "=@" + column_name;
                    }
                }
                if (j < dt.Rows.Count - 1)
                {
                    if (!isKey)
                    {
                        updateField += ",";
                    }
                }
            }
            return updateField;
        }
        #endregion
    }

    public class DACsOracle:DAcsBase
    {
        public override void getContent(DataTable dt, SystemModle.Access.AccessDB accessDB, List<string> primaryKeys)
         {            
            StringBuilder sbKeyParameter = new StringBuilder();
            StringBuilder sbParameter = new StringBuilder();
            StringBuilder sbDbNull = new StringBuilder();
            string column_name;
            string column_title; // 字段显示名称
            string column_comments;
            string data_type;
            string data_length;
            string paramClassName;  // 实体类的参数 如 SysMods 其声明的参数 为 sysMods
            bool isKey;
            string validatorType = string.Empty; // 验证类型

            string modelName;
            string m_SC = getSC(m_className);
            StringBuilder sb = new StringBuilder();

            modelName = m_namespace;
            paramClassName = m_className.Substring(0, 1).ToLower() + m_className.Substring(1);


            string paramKey = string.Empty;
            string whereKey = string.Empty;
            string formatKey = string.Empty;
            string updateKey = string.Empty;
            string s = string.Empty;
            string key;


            sbKeyParameter = new StringBuilder();

            for (int i = 0; i < primaryKeys.Count; i++)
            {
                key = NameFormat(primaryKeys[i]);
                paramKey += "string str" + key;
                whereKey += " " + primaryKeys[i] + " = @" + primaryKeys[i];
                sbKeyParameter.Append("new OracleParameter(\":");
                sbKeyParameter.Append(primaryKeys[i]);
                sbKeyParameter.Append("\", ");
                sbKeyParameter.Append("str" + key);
                sbKeyParameter.Append(")");
                if (i < primaryKeys.Count - 1)
                {
                    s = "s";
                    paramKey += ", ";
                    whereKey += " and ";
                    formatKey += ", ";
                    updateKey += ", ";
                    sbKeyParameter.Append("\n\t\t\t\t,");
                }
            }

            string selectField = string.Empty;
            string updateField = string.Empty;
            string paramField = string.Empty;
            string field;
            sbParameter = new StringBuilder();
            sbDbNull = new StringBuilder();
            
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                column_name = dt.Rows[j]["column_name"].ToString();
                data_type = dt.Rows[j]["data_type"].ToString();
                data_length = dt.Rows[j]["data_length"].ToString();
                column_comments = dt.Rows[j]["comments"].ToString();
                field = NameFormat(column_name);
                column_title = Regex.Match(column_comments, "^[^(]+").Value;
                selectField += column_name;
                isKey = primaryKeys.Contains(column_name);
                paramField += ":" + column_name;
                validatorType = accessDB.GetValidatorType(data_type);
                if (!isKey)
                {
                    updateField += " " + column_name + " = :" + column_name;
                }
               
                sbParameter.AppendFormat("\n\t\t\t\tnew OracleParameter(\":{0}\", OracleType.{1}, {2}, ParameterDirection.Input, false, 0, 0, \"{0}\", DataRowVersion.Default, {3}.{4})",
                    column_name, accessDB.GetDataType(data_type), data_length, paramClassName, field);
                if (j < dt.Rows.Count - 1)
                {
                    selectField += ", ";
                    if (!isKey)
                    {
                        updateField += ", ";
                    }
                    paramField += ", ";
                    sbParameter.Append(",");
                }

                if (dt.Rows[j]["nullable"].ToString() == "Y" && validatorType == "date")
                {
                    sbDbNull.AppendFormat("\n\n\t\t\t// {0}\n\t\t\tif (string.IsNullOrEmpty({1}.{2}))\n\t\t\t{\n\t\t\t\tparameters[{3}].Value = DBNull.Value;\n\t\t\t}",
                        column_title, paramClassName, field, j);
                }
            }

           
            //据跟据条件查询数
            sb.Append("\n\t\t#region 查询\n");
            sb.Append("public DataTable selectAllDateByWhere(int pageCrrent, int pageSize, out int pageCount, string where)");
            sb.Append("\n{");
            sb.Append(string.Format("\nstring sql = \"select * from {0}\"", m_tableAllName));
            sb.Append(";\n");
            sb.Append("if (!string.IsNullOrEmpty(where))");
            sb.Append("{\n");
            sb.Append("sql = string.Format(\" {0} where {1}\", sql, where);");
            sb.Append("\n}\n");
            sb.Append(" DataTable dt = null;\n");
            sb.Append("int returnC = 0;");
            sb.Append("try\n");
            sb.Append(" {\n");
            sb.Append("     dt = db.ExecutPaginationQuery(pageCrrent, pageSize, sql, out returnC);\n");
            sb.Append("  }\n");
            sb.Append("  catch (Exception ex)\n");
            sb.Append("  {\n");
            sb.Append("    throw ex;\n");
            sb.Append("  }\n");
            sb.Append(" pageCount = returnC;\n");
            sb.Append("  return dt;\n");
            sb.Append("}\n\n");


            //选择一条数据
            sb.Append(string.Format("public {0}OR selectARowDate(string m_id)", m_className));
            sb.Append("\n{");
            sb.Append(string.Format("string sql = string.Format(\"select * from {0} where {1}", m_tableAllName, paramKey));
            sb.Append("='{0}'\",m_id);\n ");
            sb.Append(" DataTable dt = null;\n");
            sb.Append("try\n");
            sb.Append(" {\n dt = db.ExecuteQuery(sql);\n}\n");
            sb.Append("  catch (Exception ex)\n{\n throw ex;\n  }\n");
            sb.Append("if (dt == null)\n");
            sb.Append(" return null;\n");
            sb.Append("if (dt.Rows.Count == 0)\n");
            sb.Append("return null;\n");
            sb.Append("DataRow dr = dt.Rows[0];\n");
            sb.Append(string.Format("{0}OR {1}=new {0}OR(dr); \n return {1};", m_className, m_SC));
            sb.Append("\n\n}\n");

            sb.Append("\n\t\t#endregion\n");

            // INSERT
            sb.Append("\n\t\t#region 插入\n\t\t/// <summary>\n\t\t/// 插入");
            sb.Append(m_tableAllName);
            sb.Append("\n\t\t/// </summary>\n\t\tpublic virtual bool Insert");            
            sb.Append("(");
            sb.Append(m_className);
            sb.Append("OR ");
            sb.Append(paramClassName);
            sb.Append(")\n\t\t{\n\t\t\tstring sql = \"insert into ");
            sb.Append(m_tableAllName);
            sb.Append(" (");
            sb.Append(selectField);
            sb.Append(") values (");
            sb.Append(paramField);
            sb.Append(")\";\n\t\t\tOracleParameter [] parameters = new OracleParameter[]\n\t\t\t{");
            sb.Append(sbParameter);
            sb.Append("\n\t\t\t};");
            sb.Append(sbDbNull.Replace("{", "{").Replace("}", "}"));
            sb.Append("\n\t\t\treturn db.ExecuteNoQuery(sql, parameters) > -1;\n\t\t}\n\t\t#endregion\n");

            // UPDATE
            sb.Append("\n\t\t#region 修改\n\t\t/// <summary>\n\t\t/// 更新");
            sb.Append(m_tableAllName);
            sb.Append("\n\t\t/// </summary>\n\t\tpublic virtual bool Update");           
            sb.Append("(");
            sb.Append(m_className);
            sb.Append("OR ");
            sb.Append(paramClassName);
            sb.Append(")\n\t\t{\n\t\t\tstring sql = \"update ");
            sb.Append(m_tableAllName);
            sb.Append(" set ");
            sb.Append(updateField);
            sb.Append(" where ");
            sb.Append(whereKey);
            sb.Append("\";\n\t\t\tOracleParameter [] parameters = new OracleParameter[]\n\t\t\t{");
            sb.Append(sbParameter);
            sb.Append("\n\t\t\t};");
            sb.Append(sbDbNull.Replace("{", "{").Replace("}", "}"));
            sb.Append("\n\t\t\treturn db.ExecuteNoQuery(sql, parameters) > -1;\n\t\t}\n\t\t#endregion\n");

            // DELETE
            sb.Append("\n\t\t#region DELETE\n\t\t/// <summary>\n\t\t/// 删除");
            sb.Append(m_tableAllName);
            sb.Append("\n\t\t/// </summary>\n\t\tpublic virtual bool Delete");           
            sb.Append("(");
            sb.Append(paramKey);
            sb.Append(")\n\t\t{\n\t\t\tstring sql = \"delete from ");
            sb.Append(m_tableAllName);
            sb.Append(" where ");
            sb.Append(whereKey);
            sb.Append("\";\n\t\t\tOracleParameter ");
            if (string.IsNullOrEmpty(s))
            {
                sb.Append("parameter = ");
                sb.Append(sbKeyParameter);
            }
            else
            {
                sb.Append("[] parameters = new OracleParameter[]\n\t\t\t{\n\t\t\t\t");
                sb.Append(sbKeyParameter);
                sb.Append("\n\t\t\t}");
            }
            sb.Append(";\n\t\t\treturn db.ExecuteNoQuery(sql, parameter");
            sb.Append(s);
            sb.Append(") > -1;\n\t\t}\n\t\t#endregion");

            

            m_orContent = sb.ToString();
        }
    }

    public class DACsSql : DAcsBase
    {
        public override void getContent(DataTable dt, SystemModle.Access.AccessDB accessDB, List<string> primaryKeys)
        {
            StringBuilder sbKeyParameter = new StringBuilder();
            StringBuilder sbParameterInsert = new StringBuilder();
            StringBuilder sbParameterUpdate = new StringBuilder();
            //StringBuilder sbDbNull = new StringBuilder();
            //string column_name;
            //string column_title; // 字段显示名称
            //string column_comments;
            //string data_type;
            //string data_length;
            string paramClassName;  // 实体类的参数 如 SysMods 其声明的参数 为 sysMods
            //bool isKey;
            string validatorType = string.Empty; // 验证类型

            string modelName;
            string m_SC = getSC(m_className);
            StringBuilder sb = new StringBuilder();

            modelName = m_namespace;
            paramClassName = m_className.Substring(0, 1).ToLower() + m_className.Substring(1);

           


            string paramKey = string.Empty;
            string whereKey = string.Empty;
            string formatKey = string.Empty;
            string updateKey = string.Empty;
            string s = string.Empty;
            string key=string.Empty;


            sbKeyParameter = new StringBuilder();

            for (int i = 0; i < primaryKeys.Count; i++)
            {
                key = NameFormat(primaryKeys[i]);
                paramKey += " " + key;
                whereKey += " " + primaryKeys[i] + " = @" + primaryKeys[i];
                sbKeyParameter.Append("new SqlParameter(\"@");
                sbKeyParameter.Append(primaryKeys[i]);
                sbKeyParameter.Append("\", ");
                sbKeyParameter.Append("str" + key);
                sbKeyParameter.Append(")");
                if (i < primaryKeys.Count - 1)
                {
                    s = "s";
                    paramKey += ", ";
                    whereKey += " and ";
                    formatKey += ", ";
                    updateKey += ", ";
                    sbKeyParameter.Append("\n\t\t\t\t,");
                }
            }
           
            //string selectField = string.Empty;
            string updateField = GetUpdateFilds(dt,primaryKeys);
            string paramField = GetParameterFiledsInsert(dt);
            //string field;
            sbParameterInsert = GetParameterInsert(dt,accessDB,paramClassName);
            sbParameterUpdate = GetParameterUpdate(dt, accessDB, paramClassName);
            //sbDbNull = new StringBuilder();
            

            //据跟据条件查询数
            sb.AppendLine("        #region 生成代码");
            sb.AppendLine("        #region 查询");
            sb.AppendLine("        public DataTable SelectAllByWhere(string strWhere, int startIndex, int endIndex, out int RecordCount)");
            sb.AppendLine("        {");
            sb.AppendLine("            RecordCount = 0;");
            sb.AppendLine("            string sql = string.Format(@\"");
            sb.Append("SELECT COUNT(1) FROM " + m_tableAllName + " WHERE 1=1 {0}");
            sb.AppendLine(@"
SELECT
    ITEM.*
FROM
(
    SELECT");
            sb.AppendLine("        " + m_tableAllName + ".*");
            sb.AppendLine("        ,ROW_NUMBER() over(order by " + paramKey + " desc) rowid ");
            sb.AppendLine("    FROM ");
            sb.AppendLine("        " + m_tableAllName);
            sb.AppendLine("    WHERE");
            sb.AppendLine("        1=1 {0}");
            sb.AppendLine(") AS ITEM");
            sb.AppendLine("WHERE ITEM.rowid BETWEEN {1} AND {2}");
            //sb.Append("ORDER BY ITEM.creatdate DESC");
            sb.AppendLine(" \",strWhere, startIndex, endIndex);");
            sb.AppendLine("            DataSet ds = DbHelperSQL.Query(sql);");

            sb.AppendLine("            if (ds.Tables.Count == 2)");
            sb.AppendLine("            {");
            sb.AppendLine("                RecordCount = (int)ds.Tables[0].Rows[0][0];");
            sb.AppendLine("                return ds.Tables[1];");
            sb.AppendLine("            }");
            sb.AppendLine("            else");
            sb.AppendLine("            {");
            sb.AppendLine("                return null;");
            sb.AppendLine("            }");
            sb.AppendLine("        }");
             
              
            //选择一条数据
            sb.AppendLine(string.Format("        public {0}OR selectARowDate(string m_id)", m_className));
            sb.AppendLine("        {");
            sb.Append(string.Format("            string sql = string.Format(\"select * from {0} where {1}", m_tableAllName, paramKey));
            sb.AppendLine("='{0}'\",m_id); ");
            sb.AppendLine("            DataTable dt = null;");
            sb.AppendLine("            try");
            sb.AppendLine("            {");
            sb.AppendLine("                dt = DbHelperSQL.QueryTable(sql);");
            sb.AppendLine("            }");
            sb.AppendLine("            catch (Exception ex)");
            sb.AppendLine("            {");
            sb.AppendLine("                throw ex;");
            sb.AppendLine("            }");
            sb.AppendLine("            if (dt == null)");
            sb.AppendLine("                return null;");
            sb.AppendLine("            if (dt.Rows.Count == 0)");
            sb.AppendLine("                return null;\n");
            sb.AppendLine("            DataRow dr = dt.Rows[0];");
            sb.AppendLine(string.Format("            {0}OR {1}=new {0}OR(dr); \n            return {1};\n", m_className, m_SC));
            sb.AppendLine("        }");
            sb.AppendLine("        #endregion");

            // INSERT
            sb.AppendLine("        #region 插入");
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// 插入");
            sb.AppendLine("        /// </summary>");
            sb.Append("        public virtual bool Insert");
            sb.Append("(");
            sb.Append(m_className);
            sb.Append("OR ");
            sb.Append(paramClassName);
            sb.AppendLine(")");
            sb.AppendLine("        {");
            sb.Append("        string sql = @\"insert into ");
            sb.Append(m_tableAllName);
            sb.Append(" (");
            sb.Append(GetSelectFileds(dt));
            sb.AppendLine(")");
            sb.Append("values (");
            sb.Append(paramField);
            sb.AppendLine(")\";");
            sb.AppendLine("            SqlParameter [] parameters = new SqlParameter[]");
            sb.AppendLine("			{");
            sb.Append(sbParameterInsert);
            sb.AppendLine();
            sb.AppendLine("			};");
            //sb.Append(sbDbNull.Replace("{", "{").Replace("}", "}"));
            sb.AppendLine("			return DbHelperSQL.ExecuteSql(sql, parameters) > -1;");
            sb.AppendLine("		}");
            sb.AppendLine("		#endregion");

            // UPDATE
            sb.AppendLine("        #region 更新");
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// 更新");
            sb.AppendLine("        /// </summary>");
            sb.Append("        public virtual bool Update");
            sb.Append("(");
            sb.Append(m_className);
            sb.Append("OR ");
            sb.Append(paramClassName);
            sb.AppendLine(")");
            sb.AppendLine("        {");
            sb.Append("			string sql = @\"update ");
            sb.Append(m_tableAllName);
            sb.Append(" set ");
            sb.Append(updateField);
            sb.Append(" where ");
            sb.Append(whereKey);
            sb.AppendLine("\";");
            sb.AppendLine("            SqlParameter [] parameters = new SqlParameter[]");
            sb.AppendLine("			{");
            sb.Append(sbParameterUpdate);
            sb.AppendLine();
            sb.AppendLine("			};");
            //sb.Append(sbDbNull.Replace("{", "{").Replace("}", "}"));
            sb.AppendLine("			return DbHelperSQL.ExecuteSql(sql, parameters) > -1;");
            sb.AppendLine("		}");
            sb.AppendLine("		#endregion");
            

            // DELETE
            sb.AppendLine("        #region 删除");
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// 删除");
            sb.AppendLine("        /// </summary>");
            sb.Append("        public virtual bool Delete(string str");            
            sb.Append(paramKey.Trim());
            sb.AppendLine(")");
            sb.AppendLine("        {");
            sb.Append("			string sql = @\"delete from ");
            sb.Append(m_tableAllName);
            sb.Append(" where ");
            sb.Append(whereKey);
            sb.AppendLine("\";");
            sb.Append("			SqlParameter ");
            if (string.IsNullOrEmpty(s))
            {
                sb.Append("parameter = ");
                sb.Append(sbKeyParameter);
                sb.AppendLine(";");
            }
            else
            {
                sb.AppendLine("[] parameters = new SqlParameter[]");
                sb.AppendLine("			{");
                sb.Append(sbKeyParameter);
                sb.AppendLine(";");
                sb.AppendLine("			};");
            }
            sb.AppendLine("			return DbHelperSQL.ExecuteSql(sql, parameter) > -1;");
            sb.AppendLine("		}");
            sb.AppendLine("		#endregion");
            sb.AppendLine("		#endregion");
            sb.AppendLine("		#region 调整代码");
            sb.AppendLine("		#endregion");
            m_orContent = sb.ToString();
        }
    }

    public class DACsAPPSql : DAcsBase
    {
        public override void getContent(DataTable dt, SystemModle.Access.AccessDB accessDB, List<string> primaryKeys)
        {
            StringBuilder sbKeyParameter = new StringBuilder();
            StringBuilder sbParameterInsert = new StringBuilder();
            StringBuilder sbParameterUpdate = new StringBuilder();
            //StringBuilder sbDbNull = new StringBuilder();
            //string column_name;
            //string column_title; // 字段显示名称
            //string column_comments;
            //string data_type;
            //string data_length;
            string paramClassName;  // 实体类的参数 如 SysMods 其声明的参数 为 sysMods
            //bool isKey;
            string validatorType = string.Empty; // 验证类型

            string modelName;
            string m_SC = getSC(m_className);
            StringBuilder sb = new StringBuilder();

            modelName = m_namespace;
            paramClassName = m_className.Substring(0, 1).ToLower() + m_className.Substring(1);




            string paramKey = string.Empty;
            string whereKey = string.Empty;
            string formatKey = string.Empty;
            string updateKey = string.Empty;
            string s = string.Empty;
            string key = string.Empty;
            
            string tableAllRemove_ = "";
            tableAllRemove_ = TableAllName.Replace("_", "");
            sbKeyParameter = new StringBuilder();

            for (int i = 0; i < primaryKeys.Count; i++)
            {
                key = NameFormat(primaryKeys[i]);
                paramKey += " " + key;
                whereKey += " " + primaryKeys[i] + " = @" + primaryKeys[i];
                sbKeyParameter.Append("new SqlParameter(\"@");
                sbKeyParameter.Append(primaryKeys[i]);
                sbKeyParameter.Append("\", ");
                sbKeyParameter.Append( key);
                sbKeyParameter.Append(")");
                if (i < primaryKeys.Count - 1)
                {
                    s = "s";
                    paramKey += ", ";
                    whereKey += " and ";
                    formatKey += ", ";
                    updateKey += ", ";
                    sbKeyParameter.Append("\n\t\t\t\t,");
                }
            }

            //string selectField = string.Empty;
            string updateField = GetUpdateFilds(dt, primaryKeys);
            string paramField = GetParameterFiledsInsert(dt);
            //string field;
            sbParameterInsert = GetParameterInsert(dt, accessDB, paramClassName);
            sbParameterUpdate = GetParameterUpdate(dt, accessDB, paramClassName);
            //sbDbNull = new StringBuilder();

            sb.AppendLine("        public List<<#ClassName>OR> SearchList(string Create_User,long MinID, out int mResultType, out string mResultMessage)".Replace("<#ClassName>", m_className));
            sb.AppendLine("        {");
            sb.AppendLine("            SqlParameter[] parameters = new SqlParameter[]");
            sb.AppendLine("            {");
            sb.AppendLine("                new SqlParameter(\"@Create_User\", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, \"Create_User\", DataRowVersion.Default,Create_User),");
            sb.AppendLine("                new SqlParameter(\"@MinID\", SqlDbType.BigInt,10, ParameterDirection.Input, false, 0, 0, \"MinID\", DataRowVersion.Default, MinID),");
            sb.AppendLine("            };");
            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine("            DataSet ds = DbHelperSQL.ExecuteProcedure(\"SP_" + tableAllRemove_ + "_Search\", parameters, out    mResultType, out   mResultMessage);");
            sb.AppendLine("            if (ds.Tables.Count == 1)");
            sb.AppendLine("            {");
            sb.AppendLine("                List<<#ClassName>OR> _lis = new List<<#ClassName>OR>();".Replace("<#ClassName>", m_className));
            sb.AppendLine("                foreach (DataRow _row in ds.Tables[0].Rows)");
            sb.AppendLine("                {");
            sb.AppendLine("                    _lis.Add(new <#ClassName>OR(_row));".Replace("<#ClassName>", m_className));
            sb.AppendLine("                }");
            sb.AppendLine("                return _lis;");
            sb.AppendLine("            }");
            sb.AppendLine("            return null;");
            sb.AppendLine("        }");

            sb.AppendLine("        public List<<#ClassName>OR> SearchList(string Create_User,int StartIndex,int EndIndex, out int mResultType, out string mResultMessage)".Replace("<#ClassName>", m_className));
            sb.AppendLine("        {");
            sb.AppendLine("            SqlParameter[] parameters = new SqlParameter[]");
            sb.AppendLine("            {");
            sb.AppendLine("                new SqlParameter(\"@Create_User\", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, \"Create_User\", DataRowVersion.Default,Create_User),");
            sb.AppendLine("                new SqlParameter(\"@StartIndex\", SqlDbType.Int,8, ParameterDirection.Input, false, 0, 0, \"StartIndex\", DataRowVersion.Default, StartIndex),");
            sb.AppendLine("                new SqlParameter(\"@EndIndex\", SqlDbType.Int,8, ParameterDirection.Input, false, 0, 0, \"EndIndex\", DataRowVersion.Default, EndIndex),");
            sb.AppendLine("            };");
            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine("            DataSet ds = DbHelperSQL.ExecuteProcedure(\"SP_" + tableAllRemove_ + "_Search\", parameters, out    mResultType, out   mResultMessage);");
            sb.AppendLine("            if (ds.Tables.Count == 1)");
            sb.AppendLine("            {");
            sb.AppendLine("                List<<#ClassName>OR> _lis = new List<<#ClassName>OR>();".Replace("<#ClassName>", m_className));
            sb.AppendLine("                foreach (DataRow _row in ds.Tables[0].Rows)");
            sb.AppendLine("                {");
            sb.AppendLine("                    _lis.Add(new <#ClassName>OR(_row));".Replace("<#ClassName>", m_className));
            sb.AppendLine("                }");
            sb.AppendLine("                return _lis;");
            sb.AppendLine("            }");
            sb.AppendLine("            return null;");
            sb.AppendLine("        }");


            sb.AppendLine("        public <#ClassName>OR SearchItem(string  <#paramKey>, out int mResultType, out string mResultMessage)"
                .Replace("<#ClassName>", m_className).Replace("<#paramKey>", paramKey));
            sb.AppendLine("        {");
            sb.AppendLine("            SqlParameter[] parameters = new SqlParameter[]");
            sb.AppendLine("            {");
            sb.AppendLine("                new SqlParameter(\"@<#paramKey>\", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, \"<#paramKey>\", DataRowVersion.Default,<#paramKey>),"
                .Replace("<#paramKey>", paramKey.Trim()));
            sb.AppendLine("            };");
            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine("            DataSet ds = DbHelperSQL.ExecuteProcedure(\"SP_" + tableAllRemove_ + "_Load\", parameters, out    mResultType, out   mResultMessage);");
            sb.AppendLine("            if (ds.Tables.Count == 1)");
            sb.AppendLine("            {");
            sb.AppendLine("                foreach (DataRow _row in ds.Tables[0].Rows)");
            sb.AppendLine("                {");
            sb.AppendLine("                    return new <#ClassName>OR(_row);".Replace("<#ClassName>", m_className));
            sb.AppendLine("                }");
            sb.AppendLine("            }");
            sb.AppendLine("            return null;");
            sb.AppendLine("        }");
		 


            // INSERT
            sb.Append("        public void InsertuUpdate(" + m_className + "OR " + paramClassName + ", string RecordStatus, out int mResultType, out string mResultMessage)");
            sb.AppendLine("        {");
            sb.AppendLine("            string sql = \"SP_" + tableAllRemove_ + "_Save\";");
            sb.AppendLine("            SqlParameter[] parameters = new SqlParameter[]");
            sb.AppendLine("			{");
            sb.Append(sbParameterInsert);
            sb.AppendLine();
            sb.AppendLine("			};");
            sb.AppendLine("            DbHelperSQL.ExecuteProcedureNonQuery(sql, parameters, out   mResultType, out   mResultMessage);");
            sb.AppendLine("		}");


            sb.AppendLine("        public void Delete(string " + key + ",out int mResultType, out string mResultMessage)");
            sb.AppendLine("        {");
            sb.AppendLine("            SqlParameter[] parameters = new SqlParameter[]");
            sb.AppendLine("			{");
            sb.Append("                ");
            sb.Append(sbKeyParameter);
            sb.AppendLine("");
            sb.AppendLine("			};");
            sb.AppendLine("            DbHelperSQL.ExecuteProcedureNonQuery( \"SP_" + tableAllRemove_ + "_Delete\", parameters, out   mResultType, out   mResultMessage);");
            sb.AppendLine("		}");

        
            m_orContent = sb.ToString();
        }
    }
    public class DACsMysql :DAcsBase
    {
        public override void getContent(DataTable dt, SystemModle.Access.AccessDB accessDB, List<string> primaryKeys)
        {
            StringBuilder sbKeyParameter = new StringBuilder();
            StringBuilder sbParameter = new StringBuilder();
            StringBuilder sbDbNull = new StringBuilder();
            string column_name;
            string column_title; // 字段显示名称
            string column_comments;
            string data_type;
            string data_length;
            string paramClassName;  // 实体类的参数 如 SysMods 其声明的参数 为 sysMods
            bool isKey;
            string validatorType = string.Empty; // 验证类型

            string modelName;
            string m_SC = getSC(m_className);
            StringBuilder sb = new StringBuilder();

            modelName = m_namespace;
            paramClassName = m_className.Substring(0, 1).ToLower() + m_className.Substring(1);




            string paramKey = string.Empty;
            string whereKey = string.Empty;
            string formatKey = string.Empty;
            string updateKey = string.Empty;
            string s = string.Empty;
            string key;


            sbKeyParameter = new StringBuilder();

            for (int i = 0; i < primaryKeys.Count; i++)
            {
                key = NameFormat(primaryKeys[i]);
                paramKey += " " + key;
                whereKey += " " + primaryKeys[i] + " = @" + primaryKeys[i];
                sbKeyParameter.Append("new SqlParameter(\"@");
                sbKeyParameter.Append(primaryKeys[i]);
                sbKeyParameter.Append("\", ");
                sbKeyParameter.Append("str" + key);
                sbKeyParameter.Append(")");
                if (i < primaryKeys.Count - 1)
                {
                    s = "s";
                    paramKey += ", ";
                    whereKey += " and ";
                    formatKey += ", ";
                    updateKey += ", ";
                    sbKeyParameter.Append("\n\t\t\t\t,");
                }
            }

            string selectField = string.Empty;
          
            string paramField = string.Empty;
            string field;
            sbParameter = new StringBuilder();
            sbDbNull = new StringBuilder();

            for (int j = 0; j < dt.Rows.Count; j++)
            {
                column_name = dt.Rows[j]["column_name"].ToString();
                data_type = dt.Rows[j]["data_type"].ToString();
               
                column_comments = dt.Rows[j]["comments"].ToString();
                field = NameFormat(column_name);
                column_title = Regex.Match(column_comments, "^[^(]+").Value;
                validatorType = accessDB.GetValidatorType(data_type);

                if (j > 0)
                {
                    selectField += ",";
                    paramField += ",";
                }
                if (j > 0 && j % 5 == 0)
                {
                    selectField += "\r\n";
                    paramField += "\r\n";
                }
                selectField += column_name;                
                paramField +=GetInsertValues(validatorType, column_name);

                sbParameter.AppendFormat("\n\t\t\t\t  sql = sql.Replace(\"@{0}\", {1});\t//{2}",column_name
                    , GetRepleceVariable(validatorType, paramClassName + "." + field)
                    ,column_comments);
            }

            // INSERT
            sb.Append("#region 更新业务类型");
            sb.Append(string.Format("\r\npublic void Update{0}(List<{0}OR> list{1})", m_className, paramClassName));
            sb.Append("\r\n{");
            sb.Append(string.Format("\r\n string sql = \"truncate table {0}\";", m_tableAllName));
            sb.Append("\r\nList<string> listCmd = new List<string>();");
            sb.Append("\r\nlistCmd.Add(sql);");
            sb.AppendLine();
            sb.Append(string.Format("\r\nforeach ({0}OR obj in list{1})", m_className, paramClassName));
            sb.Append("\r\n{");
            sb.Append("\r\nsql = GetInsertSql(obj);");
            sb.Append("\r\n listCmd.Add(sql);");
            sb.Append("\r\n}");
            sb.Append("\r\ndbMySql.ExecuteNoQueryTran(listCmd);");
            sb.Append("\r\n}");
            sb.AppendLine();



            sb.Append("\n\t\t/// <summary>\n\t\t/// 获取插入数据");            
            sb.Append("\n\t\t/// </summary>\n\t\tpublic string GetInsertSql");
            sb.Append("(");
            sb.Append(m_className);
            sb.Append("OR ");
            sb.Append(paramClassName);
            sb.Append(")\n\t\t{\n\t\t\tstring sql = @\"insert into ");
            sb.Append(m_tableAllName);
            sb.Append(" (");
            sb.Append(selectField);
            sb.Append(")\r\nvalues (");
            sb.Append(paramField);
            sb.Append(")\";");
            sb.Append(sbParameter);
            sb.Append("\n\t\t\t");
            sb.Append(sbDbNull.Replace("{", "{").Replace("}", "}"));
            sb.Append("\n\t\t\treturn sql;\r\n}\n\t\t#endregion\n");

            

            m_orContent = sb.ToString();
        }

        private string GetRepleceVariable(string dataType, string Filds)
        {
            if (dataType == "string")
                return Filds;
            else if (dataType == "bool")
                return string.Format("boolGetFlag({0})", Filds);
            else if (dataType == "int")
                return string.Format("{0}.ToString()", Filds);
            else
                return Filds;
        }

        private string GetInsertValues(string dataType, string Filds)
        {
            if (dataType == "string")
                return string.Format("'@{0}'", Filds);
            else
                return Filds;
        }
    }

    public class DAcsFactory
    {
        public static DAcsBase Create()
        {
            DAcsBase da = null;
            if (frmBuildCode.Privider == "MSDAORA")
            {
                da = new DACsOracle();
            }
            else if (frmBuildCode.Privider == "SQLOLEDB")
            {
                da = new DACsSql();
            }
            return da;           
        }
    }
    public class DAcsAPPFactory
    {
        public static DAcsBase Create()
        {
            DAcsBase da = null;
            if (frmBuildCode.Privider == "MSDAORA")
            {
                da = new DACsOracle();
            }
            else if (frmBuildCode.Privider == "SQLOLEDB")
            {
                da = new DACsAPPSql();
            }
            return da;
        }
    }
}
