using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YWT.Model.Log;
using System.Data;

namespace YWT.Model.YWLog
{
    public class YWLogDetailOR : YWLogOR
    {
        /// <summary>
        /// 创建人姓名
        /// </summary>
        public string RealName { get; set; }
        /// <summary>
        /// 创建人头像
        /// </summary>
        public string UserImg { get; set; }

        public YWLogDetailOR(DataRow _row)
            : base(_row)
        {
            RealName = _row["RealName"].ToString();
            UserImg = _row["UserImg"].ToString();
        }
        /// <summary>
        /// 运维日志图片附件
        /// </summary>
        public List<YWLogFileOR> LogFiles { get; set; }
        /// <summary>
        /// 回复信息
        /// </summary>
        public List<YWLogReplyDetailOR> Replys { get; set; }
    }
}
