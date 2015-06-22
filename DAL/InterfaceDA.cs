using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CBSCS.DBUtility;
using YWT.Model.Interface;

namespace YWT.DAL
{
    public class InterfaceDA
    {

        public List<InterfaceParaOR> SelectPara()
        {
            string sql = "SELECT * FROM YWT_Inerface_PARA";
           DataTable dt= DbHelperSQL.QueryTable(sql);
           List<InterfaceParaOR> _list = new List<InterfaceParaOR>();
           foreach (DataRow _row in dt.Rows)
           {
               _list.Add(new InterfaceParaOR(_row));
           }
           return _list;
        }

        /// <summary>
        /// 参数
        /// </summary>
        /// <returns></returns>
        public List<InterfaceActionOR> SelectAction()
        {
            string sql = "SELECT * FROM YWT_Inerface";
            
            DataTable dt = DbHelperSQL.QueryTable(sql);
            List<InterfaceActionOR> _list = new List<InterfaceActionOR>();
            foreach (DataRow _row in dt.Rows)
            {
                _list.Add(new InterfaceActionOR(_row));
            }
            return _list;
        }
    }
}
