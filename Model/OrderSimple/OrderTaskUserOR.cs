using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace YWT.Model.Order
{
    /// <summary>
    /// 运维单已经分配人员。
    /// </summary>
    public class OrderTaskUserSimpleOR
    { 
        /// <summary>
        /// 运维人员姓名
        /// </summary>
        public string RealName { get; set; }
        /// <summary>
        /// 运维人员头像
        /// </summary>
        public string UserImg { get; set; }
        /// <summary>
        /// 运维人员电话
        /// </summary>
        public string Mobile { get; set; }

		/// <summary>
		/// OrderTaskUser构造函数
		/// </summary>
		public OrderTaskUserSimpleOR()
		{

		}

		/// <summary>
		/// OrderTaskUser构造函数
		/// </summary>
        public OrderTaskUserSimpleOR(DataRow row)
		{
            RealName = row["RealName"].ToString().Trim();
            UserImg = row["UserImg"].ToString().Trim();
            Mobile = row["Mobile"].ToString().Trim();
		}
    }
}

