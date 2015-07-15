using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace YWT.Model.OrderPlatform
{
    /// <summary>
    /// 平台运维单
    /// </summary>
    public class YWTOrderPlatform_ForItemOR
    {
        #region 运维单
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
        #endregion

        #region 扩展属性
        /// <summary>
        /// 状态名称
        /// </summary>
        public string Status_Name { get; set; }
        /// <summary>
        /// 订单类型名称
        /// </summary>
        public string OrderType_Name { get; set; }

        /// <summary>
        /// 下一个状态
        /// </summary>
        public int Next_Status { get; set; }
        /// <summary>
        /// 下一个状态名称
        /// </summary>
        public string Next_Status_Name { get; set; }

        #region 运维商信用相关信息
        /// <summary>
        /// 星级
        /// </summary>
        public int Stars { get; set; }
        /// <summary>
        /// 完成订单数量
        /// </summary>
        public int OrderFinishNum { get; set; }
        /// <summary>
        /// 平均平价
        /// </summary>
        public int ScoreAvg { get; set; }
        /// <summary>
        /// 公司名称
        /// </summary>
        public string Company { get; set; }
        #endregion

        #endregion

        public YWTOrderPlatform_ForItemOR(DataRow row)
        {

            #region 运单相关
            Order_ID = row["Order_ID"].ToString().Trim();
            // 运单编号
            OrderNo = row["OrderNo"].ToString().Trim();

            // 标题
            OrderTitle = row["OrderTitle"].ToString().Trim();
            // 运单类型
            OrderType = row["OrderType"].ToString().Trim();
            // 工作任务
            OrderTask = row["OrderTask"].ToString().Trim();
            // 工作时长
            if (row["TaskTimeLen"] != DBNull.Value)
                TaskTimeLen = Convert.ToDecimal(row["TaskTimeLen"]);
            // 
            Task_Province = row["Task_Province"].ToString().Trim();
            // 
            Task_City = row["Task_City"].ToString().Trim();
            // 
            Task_County = row["Task_County"].ToString().Trim();
            // 
            Task_Town = row["Task_Town"].ToString().Trim();
            // 
            Task_Address = row["Task_Address"].ToString().Trim();
            // 状态 0新建 1生效 2...
            if (row["Status"] != DBNull.Value)
                Status = Convert.ToInt32(row["Status"]);
            // 备注
            Remark = row["Remark"].ToString().Trim();
            // 
            SupplierID = row["SupplierID"].ToString().Trim();
            // 
            Creator = row["Creator"].ToString().Trim();
            // 
            if (row["CreateDateTime"] != DBNull.Value)
                CreateDateTime = Convert.ToDateTime(row["CreateDateTime"]);
            // 客户简称
            CustomerShort = row["CustomerShort"].ToString().Trim();
            // 联系人
            ContactMan = row["ContactMan"].ToString().Trim();
            // 联系电话
            ContactMobile = row["ContactMobile"].ToString().Trim();
            // 是否发布到平台 0 否 1 是
            if (row["IsPublishToPlat"] != DBNull.Value)
                IsPublishToPlat = Convert.ToBoolean(row["IsPublishToPlat"]);
            // 运维费用
            if (row["Freight"] != DBNull.Value)
                Freight = Convert.ToDecimal(row["Freight"]);
            // 需求人数
            if (row["PersonNum"] != DBNull.Value)
                PersonNum = Convert.ToInt32(row["PersonNum"]);
            // 能力要求
            AbilityRequest = row["AbilityRequest"].ToString().Trim();
            #endregion

            Status_Name = row["Status_Name"].ToString();
            OrderType_Name = row["OrderType_Name"].ToString();

            if (row["Stars"] != DBNull.Value)
            {
                Stars = Convert.ToInt32(row["Stars"]);
            }

            if (row["OrderFinishNum"] != DBNull.Value)
            {
                OrderFinishNum = Convert.ToInt32(row["OrderFinishNum"]);
            }
            if (row["ScoreAvg"] != DBNull.Value)
            {
                ScoreAvg = Convert.ToInt32(row["ScoreAvg"]);
            }
            Company = row["Company"].ToString();
        }

        

    }
}
