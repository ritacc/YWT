using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YWT.Model.Common
{
    public class AjaxContentOR
    {
        public AjaxContentOR()
        {
            Status = false;
            ReturnMsg = "失败";
        }
        /// <summary>
        /// 状态
        /// </summary>
        public bool Status { get; set; }

        /// <summary>
        /// 返回信息
        /// </summary>
        public string ReturnMsg { get; set; }
        /// <summary>
        /// 返回状态，数字
        /// </summary>
        public int ReturnType { get; set; }

        /// <summary>
        /// 查询结果对象
        /// </summary>
        public Object ResultObject { get; set; }
    }

    public class AjaxContentFileOR:AjaxContentOR
    {
        public AjaxContentFileOR()
        {
            Status = false;
            ReturnMsg = "失败";
        }
        

        /// <summary>
        /// 返回信息
        /// </summary>
        public string ReturnMsgIcon { get; set; }
        
    }
}
