using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Text.RegularExpressions;
using SystemModle.Access;

namespace SystemModle.tempOR
{
    public class EditAspxcs:Common
    {
//{0}:需要引用的命名空间
//{1}:表名
//{2}:继承类
//{3}:loadData()内容
//{4}:setValue内容

        string m_className;
        /// <summary>
        /// {1}:表名,<类显示名称>
        /// </summary>
        public string ClassName
        {
            get { return m_className; }
            set { m_className = value; }
        }

        string m_loadDate;
        /// <summary>
        /// {3}:loadData()内容
        /// </summary>
        public string LoadDate
        {
            get { return m_loadDate; }
            set { m_loadDate = value; }
        }

        string m_setValue;
        /// <summary>
        /// {4}:setValue内容
        /// </summary>
        public string SetValue
        {
            get { return m_setValue; }
            set { m_setValue = value; }
        }

        string m_keyColum;
        /// <summary>
        /// 主键字段名
        /// </summary>
        public string KeyColum
        {
            get { return m_keyColum; }
            set { m_keyColum = value; }
        }

        public void getContent(DataTable dt, List<string> primaryKeys, AccessDB accessDB)
        {
            StringBuilder sbSetValue = new StringBuilder();
            StringBuilder sbLoadValue = new StringBuilder();
            string column_name = string.Empty;
            string data_type = string.Empty;
            string data_length = string.Empty;
            string column_comments = string.Empty;
            string field = string.Empty;
            string column_title = string.Empty;
            bool isKey = false;
           
          
             

            string strSc = getSC(m_className);
            sbSetValue.AppendLine(string.Format("            {0}OR {1} = new {0}OR();", ClassName, strSc));

            sbLoadValue.Append("            string m_id = Request[\"id\"];\n");
            sbLoadValue.Append(string.Format("            {0}OR {1} = new {0}BLL().selectARowDate(m_id);\n", ClassName, strSc));
            if (primaryKeys != null && primaryKeys.Count > 0)
            {
                //获取主键数据类型
                string _KeyDataType = string.Empty;
                foreach (DataRow dr in dt.Rows)
                {
                    column_name = dr["column_name"].ToString();
                    data_type = dr["data_type"].ToString();
                    data_type = accessDB.GetValidatorType(data_type);

                    isKey = primaryKeys.Contains(column_name);
                    if (isKey)
                    {
                        _KeyDataType = data_type;
                        break;
                    }
                }
                if (_KeyDataType.ToLower() == "long")
                {
                    sbSetValue.AppendLine("            if (!string.IsNullOrEmpty(Request[\"id\"]))");
                    sbSetValue.AppendFormat("                {0}.{1} = Convert.ToInt64(Request[\"id\"]);",strSc, primaryKeys[0]);
                    sbSetValue.AppendLine("");
                }
                else
                {
                    sbSetValue.AppendLine(string.Format(@"
            if (Request[<'>id<'>] != null)
                {0}.{1} = Request[<'>id<'>];", strSc, primaryKeys[0]).Replace("<'>", "\""));
                }
            }
            foreach (DataRow dr in dt.Rows)
            {
                column_name = dr["column_name"].ToString();
                data_type = dr["data_type"].ToString();
                data_type = accessDB.GetValidatorType(data_type);
                data_length = dr["data_length"].ToString();
                column_comments = dr["comments"].ToString();
                field = NameFormat(column_name);
                column_title = Regex.Match(column_comments, "^[^(]+").Value;

                isKey = primaryKeys.Contains(column_name);
                if (!isKey)
                {
                    sbSetValue.Append(getSetValue(field, column_title, strSc, data_type));
                    sbLoadValue.Append(getLoadData(field, column_title, strSc, data_type));
                }
            }
            sbSetValue.Append(string.Format("            return {0};", strSc));
            m_loadDate = sbLoadValue.ToString();
            m_setValue = sbSetValue.ToString();
            
        }

        private string getLoadData(string worrd, string strRemard, string strSc, string strType)
        {
            string LoadData = string.Empty;

            if (strType == "int" || strType == "Int64" || strType == "float" || strType == "decimal" || strType.ToLower() == "long")
            {
                LoadData = string.Format("                txt{0}.Text = {1}.{0}.ToString();//{2}\n", worrd, strSc, strRemard);
            }
            else if (strType == "DateTime")
            {
                LoadData = string.Format("                txt{0}.Text = {1}.{0}.ToString(\"yyyy-MM-dd\");//{2}\n", worrd, strSc, strRemard);
            }
            //else if (strType == "float")
            //{
            //    LoadData = string.Format("        txt{0}.Text = {1}.{0}.ToString();//{2}\n", worrd, strSc, strRemard);
            //}
            else if (strType == "bool")
            {
                LoadData = string.Format("                cb{0}.Checked = {1}.{0};//{2}\n", worrd, strSc, strRemard);
            } 
            else
            {
                LoadData = string.Format("                txt{0}.Text = {1}.{0};//{2}\n", worrd, strSc, strRemard);
            }
            return LoadData;
        }

        private string getSetValue(string worrd, string strRemard, string strSc, string strType)
        {            
            string SetValue = string.Empty; ;
            if (strType == "int")
            {
                SetValue = string.Format("            {0}.{1} = int.Parse(txt{1}.Text);//{2}\n", strSc, worrd, strRemard);
            }
            else if (strType == "Int64" || strType.ToLower() == "long")
            {
                SetValue = string.Format("            {0}.{1} = Convert.ToInt64(txt{1}.Text);//{2}\n", strSc, worrd, strRemard);
            }
            else if (strType == "DateTime")
            {
                SetValue = string.Format("            {0}.{1} = Convert.ToDateTime(txt{1}.Text);//{2}\n", strSc, worrd, strRemard);
            }
            else if (strType == "float")
            {
                SetValue = string.Format("            {0}.{1} = float.Parse(txt{1}.Text);//{2}\n", strSc, worrd, strRemard);
            }
            else if (strType == "bool")
            {
                SetValue = string.Format("            {0}.{1} = cb{1}.Checked;//{2}\n", strSc, worrd, strRemard);
            }
            else if (strType == "decimal")
            {
                SetValue = string.Format("            {0}.{1} = Decimal.Parse(txt{1}.Text);//{2}\n", strSc, worrd, strRemard);
            }
            else
            {
                SetValue = string.Format("            {0}.{1} = txt{1}.Text;//{2}\n", strSc, worrd, strRemard);
            }
            return SetValue;
        }
    }
}
