using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace YWT.Model.Order
{
    /// <summary>
    /// 
    /// </summary>
    public class OrderPlatformApplyOR
    {
       
		/// <summary>
		/// 
		/// </summary>
		public long Platform_Apply_ID { get; set; }
		/// <summary>
		/// 运维单ID
		/// </summary>
		public string Order_ID { get; set; }
		/// <summary>
		/// 申请人ID
		/// </summary>
		public string Apply_UserID { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public DateTime Create_Date { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string Create_User { get; set; }
		/// <summary>
		/// OrderPlatformApply构造函数
		/// </summary>
		public OrderPlatformApplyOR()
		{

		}

		/// <summary>
		/// OrderPlatformApply构造函数
		/// </summary>
		public OrderPlatformApplyOR(DataRow row)
		{
			// 
			if(row["Platform_Apply_ID"]!= DBNull.Value)
                Platform_Apply_ID=Convert.ToInt64(row["Platform_Apply_ID"].ToString());
			// 运维单ID
			Order_ID=row["Order_ID"].ToString().Trim();
			// 申请人ID
			Apply_UserID=row["Apply_UserID"].ToString().Trim();
			// 
			if(row["Create_Date"]!= DBNull.Value)
                Create_Date=Convert.ToDateTime(row["Create_Date"]);
			// 
			Create_User=row["Create_User"].ToString().Trim();
		}
    }
}

