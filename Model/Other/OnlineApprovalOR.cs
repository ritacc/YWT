using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace YWT.Model.Other
{
    /// <summary>
    /// 
    /// </summary>
    public class OnlineApprovalOR
    {
       
		/// <summary>
		/// 
		/// </summary>
		public long OnlineApproval_ID { get; set; }
		/// <summary>
		/// 申请类型
		/// </summary>
		public string ApplyType { get; set; }
		/// <summary>
		/// 申请内容
		/// </summary>
		public string ApplyContent { get; set; }
		/// <summary>
		/// 申请人
		/// </summary>
		public string ApplyUserID { get; set; }
		/// <summary>
		/// 申请日期
		/// </summary>
		public DateTime ApplyDate { get; set; }
		/// <summary>
		/// 审核人
		/// </summary>
		public string Approval_UserID { get; set; }
		/// <summary>
		/// 审核状态
		/// </summary>
		public string Approval_Status { get; set; }
		/// <summary>
		/// 审核时间
		/// </summary>
		public DateTime Approval_Time { get; set; }
		/// <summary>
		/// OnlineApproval构造函数
		/// </summary>
		public OnlineApprovalOR()
		{

		}

		/// <summary>
		/// OnlineApproval构造函数
		/// </summary>
		public OnlineApprovalOR(DataRow row)
		{
			// 
			if(row["OnlineApproval_ID"]!= DBNull.Value)
                OnlineApproval_ID=Convert.ToInt64(row["OnlineApproval_ID"].ToString());
			// 申请类型
			ApplyType=row["ApplyType"].ToString().Trim();
			// 申请内容
			ApplyContent=row["ApplyContent"].ToString().Trim();
			// 申请人
			ApplyUserID=row["ApplyUserID"].ToString().Trim();
			// 申请日期
			if(row["ApplyDate"]!= DBNull.Value)
                ApplyDate=Convert.ToDateTime(row["ApplyDate"]);
			// 审核人
			Approval_UserID=row["Approval_UserID"].ToString().Trim();
			// 审核状态
			Approval_Status=row["Approval_Status"].ToString().Trim();
			// 审核时间
			if(row["Approval_Time"]!= DBNull.Value)
                Approval_Time=Convert.ToDateTime(row["Approval_Time"]);
		}
    }
}

