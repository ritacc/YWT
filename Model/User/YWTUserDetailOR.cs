using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YWT.Model.User
{
    /// <summary>
    /// 注册表及详细信息
    /// </summary>
    public class YWTUserDetailOR
    {
        /// <summary>
        /// 注册信息
        /// </summary>
        public YWTUserOR User{get;set;}
        /// <summary>
        /// 详细信息
        /// </summary>
        public YWTUserInfoOR UserInfo { get; set; }
    }
}
