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
		public DateTime Apply_Date { get; set; }
		/// <summary>
		/// 申请描述
		/// </summary>
		public string Apply_Content { get; set; }
		/// <summary>
		/// 联系人
		/// </summary>
		public string ContactMan { get; set; }
		/// <summary>
		/// 联系电话
		/// </summary>
		public string ContactMobile { get; set; }
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
			if(row["Apply_Date"]!= DBNull.Value)
                Apply_Date=Convert.ToDateTime(row["Apply_Date"]);
			// 申请描述
			Apply_Content=row["Apply_Content"].ToString().Trim();
			// 联系人
			ContactMan=row["ContactMan"].ToString().Trim();
			// 联系电话
			ContactMobile=row["ContactMobile"].ToString().Trim();
		}
    }
}

