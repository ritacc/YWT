using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace YWT.Model.Order
{
    /// <summary>
    /// 申请运维单的用户
    /// 主要显示给运维商，查看申请人的详细信息
    /// </summary>
    public class YWTOrderPlatformApplyUserOR
    {
        #region 申请运维人员 信用相关信息
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

        public YWTOrderPlatformApplyUserOR(DataRow row)            
        {
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
