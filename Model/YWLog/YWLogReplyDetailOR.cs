using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace YWT.Model.YWLog
{
    /// <summary>
    /// 
    /// </summary>
    public class YWLogReplyDetailOR:YWLogReplyOR
    {
       
		 /// <summary>
        ///评论人姓名
        /// </summary>
        public string RealName { get; set; }
        /// <summary>
        /// 评论人头像
        /// </summary>
        public string UserImg { get; set; }

        public YWLogReplyDetailOR(DataRow _row)
            : base(_row)
        {
            RealName = _row["RealName"].ToString();
            UserImg = _row["UserImg"].ToString();
        }

		
    }
}

