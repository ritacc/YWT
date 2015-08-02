using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace YWT.Model.Other
{
    public class OnlineApproval_ForSelfListOR
    {
        /// <summary>
		/// 
		/// </summary>
		public long OnlineApproval_ID { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string ApplyNo { get; set; }
		/// <summary>
		/// 申请类型
		/// </summary>
		public string ApplyType { get; set; }
		/// <summary>
		/// 申请内容
		/// </summary>
		public string ApplyContent { get; set; }

		/// <summary>
		/// 申请日期
		/// </summary>
		public DateTime ApplyDate { get; set; }

		/// <summary>
		/// 审核状态
		/// </summary>
		public int ApprovalStatus { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string ApprovalStatusName { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string ApprovalResult { get; set; }
		/// <summary>
		/// 审核时间
		/// </summary>
		public DateTime ApprovalTime { get; set; }
		/// <summary>
		/// OnlineApproval构造函数
		/// </summary>
		public OnlineApproval_ForSelfListOR()
		{

		}

		/// <summary>
		/// OnlineApproval构造函数
		/// </summary>
        public OnlineApproval_ForSelfListOR(DataRow row)
		{
			// 
			if(row["OnlineApproval_ID"]!= DBNull.Value)
                OnlineApproval_ID=Convert.ToInt64(row["OnlineApproval_ID"].ToString());
			// 
			ApplyNo=row["ApplyNo"].ToString().Trim();
			// 申请类型
			ApplyType=row["ApplyType"].ToString().Trim();
			// 申请内容
			ApplyContent=row["ApplyContent"].ToString().Trim();
            //// 申请人
            //ApplyUserID=row["ApplyUserID"].ToString().Trim();
			// 申请日期
			if(row["ApplyDate"]!= DBNull.Value)
                ApplyDate=Convert.ToDateTime(row["ApplyDate"]);
			// 审核人
            //ApprovalUserID=row["ApprovalUserID"].ToString().Trim();
			// 审核状态
			if(row["ApprovalStatus"]!= DBNull.Value)
                ApprovalStatus=Convert.ToInt32(row["ApprovalStatus"]);
			// 
			ApprovalStatusName=row["ApprovalStatusName"].ToString().Trim();
			// 
			ApprovalResult=row["ApprovalResult"].ToString().Trim();
			// 审核时间
			if(row["ApprovalTime"]!= DBNull.Value)
                ApprovalTime=Convert.ToDateTime(row["ApprovalTime"]);
		}
    }
}
