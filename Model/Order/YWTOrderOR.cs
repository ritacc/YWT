using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace YWT.Model.Order
{
    /// <summary>
    /// 
    /// </summary>
    public class YWTOrderOR
    {
       
		/// <summary>
		/// 
		/// </summary>
		public string Order_ID { get; set; }
		/// <summary>
		/// 运单编号
		/// </summary>
		public string OrderNo { get; set; }

		/// <summary>
		/// 标题
		/// </summary>
		public string OrderTitle { get; set; }
		/// <summary>
		/// 运单类型
		/// </summary>
		public string OrderType { get; set; }
		/// <summary>
		/// 工作任务
		/// </summary>
		public string OrderTask { get; set; }
		/// <summary>
		/// 工作时长
		/// </summary>
		public decimal TaskTimeLen { get; set; }

        #region 地址
        /// <summary>
		/// 
		/// </summary>
		public string Task_Province { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string Task_City { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string Task_County { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string Task_Town { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string Task_Address { get; set; }
        #endregion

        /// <summary>
		/// 状态 0新建 1生效 2...
		/// </summary>
		public int Status { get; set; }
		/// <summary>
		/// 备注
		/// </summary>
		public string Remark { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string SupplierID { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string Creator { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public DateTime CreateDateTime { get; set; }
		/// <summary>
		/// 客户简称
		/// </summary>
		public string CustomerShort { get; set; }
		/// <summary>
		/// 联系人
		/// </summary>
		public string ContactMan { get; set; }
		/// <summary>
		/// 联系电话
		/// </summary>
		public string ContactMobile { get; set; }
		/// <summary>
		/// 是否发布到平台 0 否 1 是
		/// </summary>
		public bool IsPublishToPlat { get; set; }
		/// <summary>
		/// 运维费用
		/// </summary>
		public decimal Freight { get; set; }
		/// <summary>
		/// 需求人数
		/// </summary>
		public int PersonNum { get; set; }
		/// <summary>
		/// 能力要求
		/// </summary>
		public string AbilityRequest { get; set; }
		/// <summary>
		/// Order构造函数
		/// </summary>
		public YWTOrderOR()
		{

		}

		/// <summary>
		/// Order构造函数
		/// </summary>
        public YWTOrderOR(DataRow row)
		{
			// 
			Order_ID=row["Order_ID"].ToString().Trim();
			// 运单编号
			OrderNo=row["OrderNo"].ToString().Trim();

			// 标题
			OrderTitle=row["OrderTitle"].ToString().Trim();
			// 运单类型
			OrderType=row["OrderType"].ToString().Trim();
			// 工作任务
			OrderTask=row["OrderTask"].ToString().Trim();
			// 工作时长
			if(row["TaskTimeLen"]!= DBNull.Value)
                TaskTimeLen=Convert.ToDecimal(row["TaskTimeLen"]);
			// 
			Task_Province=row["Task_Province"].ToString().Trim();
			// 
			Task_City=row["Task_City"].ToString().Trim();
			// 
			Task_County=row["Task_County"].ToString().Trim();
			// 
			Task_Town=row["Task_Town"].ToString().Trim();
			// 
			Task_Address=row["Task_Address"].ToString().Trim();
			// 状态 0新建 1生效 2...
			if(row["Status"]!= DBNull.Value)
                Status=Convert.ToInt32(row["Status"]);
			// 备注
			Remark=row["Remark"].ToString().Trim();
			// 
			SupplierID=row["SupplierID"].ToString().Trim();
			// 
			Creator=row["Creator"].ToString().Trim();
			// 
			if(row["CreateDateTime"]!= DBNull.Value)
                CreateDateTime=Convert.ToDateTime(row["CreateDateTime"]);
			// 客户简称
			CustomerShort=row["CustomerShort"].ToString().Trim();
			// 联系人
			ContactMan=row["ContactMan"].ToString().Trim();
			// 联系电话
			ContactMobile=row["ContactMobile"].ToString().Trim();
			// 是否发布到平台 0 否 1 是
			if(row["IsPublishToPlat"]!= DBNull.Value)
                IsPublishToPlat=Convert.ToBoolean(row["IsPublishToPlat"]);
			// 运维费用
			if(row["Freight"]!= DBNull.Value)
                Freight=Convert.ToDecimal(row["Freight"]);
			// 需求人数
			if(row["PersonNum"]!= DBNull.Value)
                PersonNum=Convert.ToInt32(row["PersonNum"]);
			// 能力要求
			AbilityRequest=row["AbilityRequest"].ToString().Trim();
		}
    }
}

