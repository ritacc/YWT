using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace YWT.Model.User
{
    public class YWTUserOrderNumOR
    {
        /// <summary>
        /// 全部数量
        /// </summary>
        public int AllNum { get; set; }
        /// <summary>
        /// 完成数量
        /// </summary>
        public int FinishNum { get; set; }
        /// <summary>
        /// 未完成数量
        /// </summary>
        public int NOFinishNum { get; set; }

        public YWTUserOrderNumOR(DataRow _row)
        {
            AllNum = Convert.ToInt32(_row["AllNum"]);
            FinishNum = Convert.ToInt32(_row["FinishNum"]);
            NOFinishNum = Convert.ToInt32(_row["NOFinishNum"]);
        }
    }
}
