using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace YWT.Model.Order
{
    public class YWTOrderDetaillOR : YWTOrderOR
    {
        /// <summary>
        /// 状态名称
        /// </summary>
        public string Status_Name { get; set; }
        /// <summary>
        /// 订单类型名称
        /// </summary>
        public string OrderType_Name { get; set; }

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

    }
}
