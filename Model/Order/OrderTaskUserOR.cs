using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace YWT.Model.Order
{
    /// <summary>
    /// 运维单已经分配人员。
    /// </summary>
    public class OrderTaskUserOR
    {
		/// <summary>
		/// 
		/// </summary>
		public long Task_User_ID { get; set; }
		/// <summary>
		/// 运维单ID
		/// </summary>
		public string Order_ID { get; set; }
		/// <summary>
		/// 分配人用户ID
		/// </summary>
		public string UserID { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public DateTime Create_Date { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string Create_User { get; set; }

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
		public OrderTaskUserOR()
		{

		}

		/// <summary>
		/// OrderTaskUser构造函数
		/// </summary>
		public OrderTaskUserOR(DataRow row)
		{
			// 
			if(row["Task_User_ID"]!= DBNull.Value)
                Task_User_ID=Convert.ToInt64(row["Task_User_ID"].ToString());
			// 运维单ID
			Order_ID=row["Order_ID"].ToString().Trim();
			// 分配人用户ID
			UserID=row["UserID"].ToString().Trim();
			// 
			if(row["Create_Date"]!= DBNull.Value)
                Create_Date=Convert.ToDateTime(row["Create_Date"]);
			// 
			Create_User=row["Create_User"].ToString().Trim();


            RealName = row["RealName"].ToString().Trim();
            UserImg = row["UserImg"].ToString().Trim();
            Mobile = row["Mobile"].ToString().Trim();
		}
    }
}

