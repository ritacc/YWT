using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace SystemModle.tempOR
{
    public class ORcs : Common
    {
        string m_namespace;
        /// <summary>
        /// {0}命名空间
        /// </summary>
        public string Namespace
        {
            get { return m_namespace; }
            set { m_namespace = value; }
        }
        string m_tableTitle;
        /// <summary>
        /// {1}表标题
        /// </summary>
        public string TableTitle
        {
            get { return m_tableTitle; }
            set { m_tableTitle = value; }
        }

        string m_tableName;
        /// <summary>
        /// {2}表名
        /// </summary>
        public string TableName
        {
            get { return m_tableName; }
            set { m_tableName = value; }
        }

        string m_orContent;
        /// <summary>
        /// {3}内容
        /// </summary>
        public string OrContent
        {
            get { return m_orContent; }
            set { m_orContent = value; }
        }

        public void getContent(DataTable dt, Access.AccessDB accessDB, List<string> primaryKeys)
        {
            StringBuilder sb = new StringBuilder();
            StringBuilder sbRow = new StringBuilder();
            string column_name = string.Empty;
            string column_comments = string.Empty;

            string className = m_tableName;//类名
            string keyCol = string.Empty;
            foreach (DataRow row in dt.Rows)
            {
                

               // column_name = NameFormat(row["column_name"].ToString());
                column_name =row["column_name"].ToString();
              bool  isKey = primaryKeys.Contains(column_name.ToUpper());
                if (isKey)
                {
                    keyCol = column_name;
                }

                column_comments = row["comments"].ToString().Replace("\r\n", "").Replace("\n", " ");
                string dataType = accessDB.GetValidatorType(row["data_type"].ToString());
                //sb.AppendFormat("\n\t\tprivate {0} _", dataType);
                //sb.Append(column_name);
                //sb.Append(";");
                sb.Append("\n\t\t/// <summary>");
                sb.Append("\n\t\t/// ");
                sb.Append(column_comments);
                sb.Append("\n\t\t/// </summary>");
                sb.AppendFormat("\n\t\tpublic {0} ", dataType);
                sb.Append(column_name);
                //sb.Append("\n\t\t{\n\t\t\tget { return _");
                //sb.Append(column_name);
                //sb.Append("; }\n\t\t\tset { _");
                //sb.Append(column_name);
                //sb.Append(" = value; }\n\t\t}\n");
                sb.Append(" { get; set; }");

                sbRow.Append("\n\t\t\t// ");
                sbRow.Append(column_comments);
                sbRow.Append("\n\t\t\t");
                //sbRow.Append(column_name);
                //sbRow.Append(" = ");
                sbRow.Append(getDrToConvert(column_name,dataType, row["column_name"].ToString()));               
            }

            sb.Append("\n\t\t/// <summary>");
            sb.Append("\n\t\t/// ");
            sb.Append(className);
            sb.Append("构造函数\n\t\t/// </summary>");
            sb.Append("\n\t\tpublic ");
            sb.Append(className);
            sb.Append("OR()\n\t\t{\n");
            if (keyCol.ToUpper()=="GUID")
            {
                sb.Append("_Guid = System.Guid.NewGuid().ToString();\n");               
            }
            //if ( keyCol.ToLower() == "id")
            //{
            //    sb.Append("_Id = System.Guid.NewGuid().ToString();\n");
            //}
            sb.Append("\n\t\t}\n");

            sb.Append("\n\t\t/// <summary>");
            sb.Append("\n\t\t/// ");
            sb.Append(className);
            sb.Append("构造函数\n\t\t/// </summary>");
            sb.Append("\n\t\tpublic ");
            sb.Append(className);
            sb.Append("OR(DataRow row)\n\t\t{");
            sb.Append(sbRow);
            sb.Append("\n\t\t}");

            m_orContent = sb.ToString();
        }

        private string getDrToConvert(string column_name, string m_type, string m_word)
        {
            string converdata = string.Empty;
            //if (m_type == "string")

            if (m_type == "DateTime")
            {
                converdata = string.Format("if(row[\"{0}\"]!= DBNull.Value)\r\n                {1}=Convert.ToDateTime(row[\"{0}\"]);", m_word, column_name);
            }
            else if (m_type == "decimal")
            {
                converdata = string.Format("if(row[\"{0}\"]!= DBNull.Value)\r\n                {1}=Convert.ToDecimal(row[\"{0}\"]);", m_word, column_name);
            }
            else if (m_type == "int")
            {
                converdata = string.Format("if(row[\"{0}\"]!= DBNull.Value)\r\n                {1}=Convert.ToInt32(row[\"{0}\"]);", m_word, column_name);
            }
            else if (m_type == "float")
            {
                converdata = string.Format("if(row[\"{0}\"]!= DBNull.Value)\r\n                {1}=float.Parse(row[\"{0}\"].ToString());", m_word, column_name);
            }
            else if (m_type == "long")
            {
                converdata = string.Format("if(row[\"{0}\"]!= DBNull.Value)\r\n                {1}=Convert.ToInt64(row[\"{0}\"].ToString());", m_word, column_name);
            }
            else if (m_type == "bool")
            {
                converdata = string.Format("if(row[\"{0}\"]!= DBNull.Value)\r\n                {1}=Convert.ToBoolean(row[\"{0}\"]);", m_word, column_name);
            }
            else if (m_type.ToLower() == "decimal")
            {
                converdata = string.Format("if(row[\"{0}\"]!= DBNull.Value)\r\n                {1}=Decimal.Parse(row[\"{0}\"].ToString());", m_word, column_name);
            }
             else if (m_type == "Int64" || m_type.ToLower() == "long")
            {
                converdata = string.Format("if(row[\"{0}\"]!= DBNull.Value)\r\n                {1}=Convert.ToInt64(row[\"{0}\"]);", m_word, column_name);
            }
            else
            {
                converdata = string.Format("{1}=row[\"{0}\"].ToString().Trim();", m_word, column_name);
            }
            return converdata;
        }

    }
}
