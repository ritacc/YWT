using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace YWT.Model.Order
{
    public class YWTOrderDetaillOR : YWTOrderOR
    {
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
        #endregion

        /// <summary>
        /// 运维人员
        /// </summary>
        public List<OrderTaskUserOR> OrderUsers { get; set; }

        /// <summary>
        /// 运维流程
        /// </summary>
        public List<OrderFlowOR> OrderFlows { get; set; }

        public YWTOrderDetaillOR(DataRow row)
            : base(row)
        {
            Status_Name = row["Status_Name"].ToString();
            OrderType_Name = row["OrderType_Name"].ToString();
        }

        /// <summary>
        /// 获取下一步骤状态
        /// </summary>
        public void SetNexStatus()
        {  
            bool isHvaeStatus = false;
            int OrderType = 1;
            if (this.IsPublishToPlat)
            {
                OrderType = 2;
            }
            foreach (OrderStatusItem item in OrderStatus.OrderStatusItems)
            {
                if (isHvaeStatus && OrderType == item.OrderType)
                {
                    this.Next_Status = item.Status;
                    this.Next_Status_Name = item.StatusName;
                    break;
                }
                
                if (OrderType == item.OrderType && this.Status == item.Status)
                {
                    isHvaeStatus = true;
                }
            }
        }

    }
}
