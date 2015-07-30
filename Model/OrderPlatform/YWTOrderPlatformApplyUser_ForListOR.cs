using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace YWT.Model.OrderPlatform
{
   public class YWTOrderPlatformApplyUser_ForListOR
    {
        /// <summary>
        /// 申请用户ID
        /// </summary>
        public string Platform_Apply_ID { get; set; }
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
        
        #endregion

        /// <summary>
        /// 申请内容
        /// </summary>
        public string Apply_Content { get; set; }
        /// <summary>
        /// 申请时间
        /// </summary>
        public DateTime Apply_Date { get; set; }
        /// <summary>
        /// 联系人
        /// </summary>
        public string ContactMan { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string ContactMobile { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string RealName { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        public string UserImg { get; set; } 

        public YWTOrderPlatformApplyUser_ForListOR(DataRow row)
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


            Apply_Content = row["Apply_Content"].ToString();
             Apply_Date =Convert.ToDateTime( row["Apply_Date"].ToString());
             ContactMan = row["ContactMan"].ToString();
             ContactMobile = row["ContactMobile"].ToString();
             RealName = row["RealName"].ToString();
             UserImg = row["UserImg"].ToString();
             
             Platform_Apply_ID = row["Platform_Apply_ID"].ToString();
        }
    }
}
