using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace YWT.Model.Order
{
    /// <summary>
    /// 
    /// </summary>
    public class OrderAssessOR
    {
       
		/// <summary>
		/// 
		/// </summary>
		public long Order_ASSESS_ID { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string Order_ID { get; set; }
		/// <summary>
		/// 评价类型，内单0,外单对应流程状态
		/// </summary>
		public int Assess_Type { get; set; }
		/// <summary>
		/// 运维完成结果（完成、未完成）
		/// </summary>
		public string YW_Result { get; set; }
		/// <summary>
		/// 运维得分（1-5）
		/// </summary>
		public int Score { get; set; }
		/// <summary>
		/// 填写运维评价
		/// </summary>
		public string AssessContent { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string Reply { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public DateTime Reply_Time { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string Reply_User { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string Reply_RealName { get; set; }
		/// <summary>
		/// 是否获取积分
		/// </summary>
		public bool IsAddIntegral { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string Creator { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public DateTime CreateDateTime { get; set; }
		/// <summary>
		/// OrderAssess构造函数
		/// </summary>
		public OrderAssessOR()
		{

		}

		/// <summary>
		/// OrderAssess构造函数
		/// </summary>
		public OrderAssessOR(DataRow row)
		{
			// 
			if(row["Order_ASSESS_ID"]!= DBNull.Value)
                Order_ASSESS_ID=Convert.ToInt64(row["Order_ASSESS_ID"].ToString());
			// 
			Order_ID=row["Order_ID"].ToString().Trim();
			// 评价类型，内单0,外单对应流程状态
			if(row["Assess_Type"]!= DBNull.Value)
                Assess_Type=Convert.ToInt32(row["Assess_Type"]);

			// 运维完成结果（完成、未完成）
			YW_Result=row["YW_Result"].ToString().Trim();
			// 运维得分（1-5）
			if(row["Score"]!= DBNull.Value)
                Score=Convert.ToInt32(row["Score"]);
			// 填写运维评价
			AssessContent=row["AssessContent"].ToString().Trim();
			// 
			Reply=row["Reply"].ToString().Trim();
			// 
			if(row["Reply_Time"]!= DBNull.Value)
                Reply_Time=Convert.ToDateTime(row["Reply_Time"]);
			// 
			Reply_User=row["Reply_User"].ToString().Trim();
			// 
			Reply_RealName=row["Reply_RealName"].ToString().Trim();
			// 是否获取积分
			if(row["IsAddIntegral"]!= DBNull.Value)
                IsAddIntegral=Convert.ToBoolean(row["IsAddIntegral"]);
			// 
			Creator=row["Creator"].ToString().Trim();
			// 
			if(row["CreateDateTime"]!= DBNull.Value)
                CreateDateTime=Convert.ToDateTime(row["CreateDateTime"]);
		}
    }
}

