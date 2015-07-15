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
        /// <summary>
        /// 生日
        /// </summary>
        public DateTime Birthday { get; set; }
        /// <summary>
        /// 毕业学院
        /// </summary>
        public string Finish_School { get; set; }
        /// <summary>
        /// 学历
        /// </summary>
        public string HighestEducation { get; set; }
        /// <summary>
        /// 毕业时间
        /// </summary>
        public string GraduationData { get; set; }

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
           

             Apply_Content = row[""].ToString();
             Apply_Date =Convert.ToDateTime( row["Apply_Date"].ToString());
             ContactMan = row["ContactMan"].ToString();
             ContactMobile = row["ContactMobile"].ToString();
             RealName = row["RealName"].ToString();
             UserImg = row["UserImg"].ToString();
             Birthday =Convert.ToDateTime( row["Birthday"]);
             Finish_School = row["Finish_School"].ToString();
             HighestEducation = row["HighestEducation"].ToString();
             GraduationData = row["GraduationData"].ToString();
        }
    }
}
