using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Text.RegularExpressions;

namespace SystemModle.tempOR
{
    public class EditAspx : Common
    {
        //       {0}:表名
        //{1}:<title>{1}</title> 
        //{2}:显示内容，跟据表所生成的东西

        string m_className;
        /// <summary>
        /// {0}:表名,<类显示名称>
        /// </summary>
        public string ClassName
        {
            get { return m_className; }
            set { m_className = value; }
        }

        string m_classTile;
        /// <summary>
        /// {1}:表说明HTML标题
        /// </summary>
        public string ClassTile
        {
            get { return m_classTile; }
            set { m_classTile = value; }
        }

        string m_showContent;
        /// <summary>
        /// 显示内容
        /// </summary>
        public string ShowContent
        {
            get { return m_showContent; }
            set { m_showContent = value; }
        }

         string m_Desi;
        /// <summary>
        /// 显示内容
        /// </summary>
        public string Desi
        {
            get { return m_Desi; }
            set { m_Desi = value; }
        }

        
        public void setContent(DataTable dt, List<string> primaryKeys)
        {
            StringBuilder sb = new StringBuilder();
            StringBuilder sbDesi = new StringBuilder();
            string column_name = string.Empty;
            string data_type = string.Empty;
            string data_length = string.Empty;
            string column_comments = string.Empty;
            string field = string.Empty;
            string column_title = string.Empty;
            bool isKey = false;

            for (int j = 0; j < dt.Rows.Count; j++)
            {
                column_name = dt.Rows[j]["column_name"].ToString();
                data_type = dt.Rows[j]["data_type"].ToString();
                data_length = dt.Rows[j]["data_length"].ToString();
                column_comments = dt.Rows[j]["comments"].ToString();
                field = NameFormat(column_name);
                column_title = Regex.Match(column_comments, "^[^(]+").Value;

                isKey = primaryKeys.Contains(column_name);
                if (!isKey)
                {

                    //后面跟备注进行处理
                    sb.Append(string.Format("            <tr{0}>\r\n", isKey ? " class=\"nowShow\"" : ""));
                    sb.Append("                <td class=\"tdRight\">\r\n");
                    sb.Append("                    " + column_title +"\r\n");
                    sb.Append("                </td>\r\n");
                    sb.Append("                <td class=\"tdLeft\">\r\n");
                    string strDesiginItemNorm =
    @"
        /// <summary>
        /// {0} 控件。
        /// </summary>
        /// <remarks>
        /// 自动生成的字段。
        /// 若要进行修改，请将字段声明从设计器文件移到代码隐藏文件。
        /// </remarks>
        protected global::System.Web.UI.WebControls.{1} {0};
";
                    string strFildsname = "";
                    string ControType = "TextBox";
                    if (data_type == "bit")
                    {
                        sb.Append("                    <asp:CheckBox ID=\"cb" + field + "\" runat=\"server\"/>\r\n");
                        strFildsname = "cb" + field;
                        ControType = "CheckBox";
                    }
                    else if (data_type == "datetime")
                    {
                        sb.Append("                    <asp:TextBox  ID=\"txt" + field + "\" CssClass=\"textbox_skin\"  onfocus=\"WdatePicker();\"  runat=\"server\"/>\r\n");
                        strFildsname = "txt" + field;
                    }
                    else
                    {
                        sb.Append("                    <asp:TextBox  runat=\"server\" ID=\"txt" + field + "\" CssClass=\"textbox_skin\" />\r\n");
                        strFildsname = "txt" + field;
                    }
                    sbDesi.AppendFormat(strDesiginItemNorm, strFildsname, ControType);

                    sb.Append("                </td>\r\n");
                    sb.Append("            </tr>\r\n");
                }
            }
            m_showContent = sb.ToString();
            m_Desi = sbDesi.ToString();
        
        }


    }
}
