using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YWT.DAL.User;
using YWT.Model.User;

namespace YWT.BLL.User
{
    public class YWTUserBLL
    { 
        #region 注册 登录 修改密码

        public void Insert(YWTUserOR sNRUser, out int mResultType, out string mResultMessage)
        {
            new YWTUserDA().InsertUpdate(sNRUser, "ADD", out   mResultType, out   mResultMessage);
        }

        public void AlertPwd(string userid, string oldpwd, string newpwd, out int mResultType, out string mResultMessage)
        {
            new YWTUserDA().AlertPwd(userid, oldpwd, newpwd, "pwd", out   mResultType, out   mResultMessage);
        }

        /// <summary>
        /// 登录验证
        /// </summary>
        public YWTUserOR LoginCheck(string UserNameOrMobile, string password, string IMEI, string OS, string Manufacturer, int LoginType, out int mResultType, out string mResultMessage)
        {
            return new YWTUserDA().LoginCheck(UserNameOrMobile, password, IMEI, OS, Manufacturer, LoginType, out   mResultType, out   mResultMessage);
        }

        /// <summary>
        /// 登录验证
        /// </summary>
        public YWTUserOR LoginCheck(string UserNameOrMobile, string password, string IMEI, string OS, string Manufacturer, out int mResultType, out string mResultMessage)
        {
            return new YWTUserDA().LoginCheck(UserNameOrMobile, password, IMEI, OS, Manufacturer, 0, out   mResultType, out   mResultMessage);
        }

        
        #endregion
    }
}
