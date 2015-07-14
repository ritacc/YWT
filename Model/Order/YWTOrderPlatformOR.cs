using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace YWT.Model.Order
{
    public class YWTOrderPlatformOR : YWTOrderOR
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

        public YWTOrderPlatformOR(DataRow row)
            : base(row)
        {
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
