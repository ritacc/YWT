using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Text.RegularExpressions;

namespace SystemModle.tempOR
{
    public class ListAspx:Common
    {        
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

        string m_mainKey;
        /// <summary>
        /// {2}:表主键
        /// </summary>
        public string MainKey
        {
            get { return m_mainKey; }
            set { m_mainKey = value; }
        }

        string m_gvShowName;
        /// <summary>
        /// {3}:gv显示内容
        /// </summary>
        public string GvShowName
        {
            get { return m_gvShowName; }
            set { m_gvShowName = value; }
        }

        string m_nullThShow;
        /// <summary>
        /// {4}:空显示内容TH
        /// </summary>
        public string NullThShow
        {
            get { return m_nullThShow; }
            set { m_nullThShow = value; }
        }

        string m_thNumber;
        /// <summary>
        /// {5}:th个数
        /// </summary>
        public string ThNumber
        {
            get { return m_thNumber; }
            set { m_thNumber = value; }
        }

        public void getContent(DataTable dt, SystemModle.Access.AccessDB accessDB, List<string> primaryKeys)
        {
            StringBuilder sb = new StringBuilder();
            StringBuilder sbSearch = new StringBuilder();
            StringBuilder sbTh = new StringBuilder();

            string column_name;
            string column_comments;
            string column_title;
            string validatorType;
            bool isAllShow = false;
            int showOrHideCount = 0;
            //如果没有添加是否全部显示则全部显示
            foreach(DataRow row in dt.Rows)
            {
                column_comments = row["comments"].ToString();
                if (!chckGvShowOrHide(column_comments))
                {
                    showOrHideCount++;
                }
            }
            if (showOrHideCount == dt.Rows.Count)
                isAllShow = true;
            int i_showCol=0;
            foreach (DataRow row in dt.Rows)
            {
                
               
                column_name = row["column_name"].ToString();
                column_comments = row["comments"].ToString();
               if(primaryKeys.Contains(column_name))
               {
                   continue;
               }

                string field = NameFormat(column_name);
                column_title = Regex.Match(column_comments, "^[^(]+").Value;
                string data_type = row["data_type"].ToString();
                validatorType = accessDB.GetValidatorType(data_type);
               
                    string strBoundFieldItem=string.Empty;
                    if(isAllShow)
                    {
                      strBoundFieldItem=  getBoundFieldItem(column_name,column_title,column_comments);
                    }
                    else
                    {
                        string strsh = getGvShowOrHide(column_comments);
                        if(strsh.IndexOf("-v")>0)
                        {
                            strBoundFieldItem=  getBoundFieldItem(column_name,column_title,column_comments);
                        }
                    }
                    if(!string.IsNullOrEmpty(strBoundFieldItem))
                    {
                        sbTh.AppendLine(string.Format("                                <th>{0}</th>", column_title.Replace("\r\n","")));
                        sb.Append(strBoundFieldItem);
                        i_showCol++;
                    }
                

                // 字段描述字段结尾包含*表示为过滤字段
                //if (Regex.Match(column_comments, @"\*[□]?$").Success)
                //{
                //    if (validatorType == "date")
                //    {
                //        sbSearch.AppendFormat("\r\n\t\t\t\t\t\t\t\t\t<td>{0}：</td><td><asp:TextBox ID=\"tbx{1}Begin\" runat=\"server\" onfocus=\"WdatePicker()\"  CssClass=\"textbox_skin\"></asp:TextBox>-<asp:TextBox ID=\"tbx{1}End\" runat=\"server\" onfocus=\"WdatePicker()\" CssClass=\"textbox_skin\"></asp:TextBox></td>", column_title, field);
                //    }
                //    else
                //    {
                //        sbSearch.AppendFormat("\r\n\t\t\t\t\t\t\t\t\t<td>{0}：</td><td><asp:TextBox ID=\"tbx{1}\" runat=\"server\"  CssClass=\"textbox_skin\"></asp:TextBox></td>", column_title, field);
                //    }
                //}
            }
            //th个数
            if (i_showCol > 0)
            {
                m_gvShowName = sb.ToString();
                m_nullThShow = sbTh.ToString();
                m_thNumber = i_showCol.ToString();
            }
        }

        //private string getBoundFieldItem(string column_name, string column_title,string column_comments)
        //{
        //    string regContent = Regex.Match(column_comments, "(?<=[(])([^()])+(?=[)])").Value;
        //  string gvreg = Regex.Match(regContent, "gv:([\\w- ]+);").Value;//发文字号(gv:-f d,;)            
        //  string fstr = Regex.Match(gvreg, "-f([\\w ]+),").Value;
        //    string DataFormatString = string.Empty;
        //    if(fstr.IndexOf("d")>0)
        //    {
        //        DataFormatString=" DataFormatString=\"{0:yyyy-MM-dd}\" ";
        //    }
        //    else if(fstr.IndexOf("dt")>0)
        //    {
        //         DataFormatString=" DataFormatString=\"{0:yyyy-MM-dd HH:mm:ss}\" ";
        //    }
        //    return string.Format("\r\n			<asp:BoundField DataField=\"{0}\" HeaderText=\"{1}\" {2} />", column_name, column_title, DataFormatString);
        //}
        private string getBoundFieldItem(string column_name, string column_title, string column_comments)
        {
            string regContent = Regex.Match(column_comments, "(?<=[(])([^()])+(?=[)])").Value;
            string gvreg = Regex.Match(regContent, "gv:([\\w- ]+);").Value;//发文字号(gv:-f d,;)            
            string fstr = Regex.Match(gvreg, "-f([\\w ]+),").Value;
            string DataFormatString = string.Empty;
            //if (fstr.IndexOf("d") > 0)
            //{
            //    DataFormatString = " DataFormatString=\"{0:yyyy-MM-dd}\" ";
            //}
            //else if (fstr.IndexOf("dt") > 0)
            //{
            //    DataFormatString = " DataFormatString=\"{0:yyyy-MM-dd HH:mm:ss}\" ";
            //}
            return string.Format("\r\n                    <td  class=\"ac\"><%= row[\"{0}\"]%></td>\r\n", column_name);//, column_title, DataFormatString);
        }

        public bool chckGvShowOrHide(string regContent)
        {
            regContent = Regex.Match(regContent, "(?<=[(])([^()])+(?=[)])").Value;
            regContent = Regex.Match(regContent, "gv:([\\w- ]+);").Value;
            return Regex.Match(regContent,"(-v)|(-h)").Success;
        }
         public string getGvShowOrHide(string regContent)
        {
            regContent = Regex.Match(regContent, "(?<=[(])([^()])+(?=[)])").Value;
            regContent = Regex.Match(regContent, "gv:([\\w- ]+);").Value;
            return Regex.Match(regContent, "(-v)|(-h)").Value;
        }

    }
}
