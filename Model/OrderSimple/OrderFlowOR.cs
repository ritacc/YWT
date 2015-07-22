using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace YWT.Model.Order
{
    /// <summary>
    /// 
    /// </summary>
    public class OrderFlowSimpleOR
    {
		/// <summary>
		/// 运维单状态
		/// </summary>
		public long Order_Status { get; set; }
		/// <summary>
		/// 状态显示名称
		/// </summary>
		public string Order_Status_Name { get; set; }
		/// <summary>
		/// 时间
		/// </summary>
		public DateTime Create_Date { get; set; }

		/// <summary>
		/// 操作人显示名称
		/// </summary>
		public string Create_USER_Name { get; set; } 
		 
		/// <summary>
		/// 
		/// </summary>
		public string Remark { get; set; }
		/// <summary>
		/// OrderFlow构造函数
		/// </summary>
		public OrderFlowSimpleOR()
		{

		}

		/// <summary>
		/// OrderFlow构造函数
		/// </summary>
        public OrderFlowSimpleOR(DataRow row)
		{
			 
			// 运维单状态
			if(row["Order_Status"]!= DBNull.Value)
                Order_Status=Convert.ToInt64(row["Order_Status"].ToString());
			// 状态显示名称
			Order_Status_Name=row["Order_Status_Name"].ToString().Trim();
			// 时间
			if(row["Create_Date"]!= DBNull.Value)
                Create_Date=Convert.ToDateTime(row["Create_Date"]);
			
			// 操作人显示名称
			Create_USER_Name=row["Create_USER_Name"].ToString().Trim();
			// 
			Remark=row["Remark"].ToString().Trim();
		}
    }
}

