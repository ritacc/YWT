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
        public YWTUserOR Insert(YWTUserOR YWTUser, out int mResultType, out string mResultMessage)
        {
           return new YWTUserDA().InsertUpdate(YWTUser, "ADD", out   mResultType, out   mResultMessage);
        }
        /// <summary>
        /// 更新
        /// </summary>
        public void UpdateUserInfo(YWTUserOR YWTUser, out int mResultType, out string mResultMessage)
        {
            new YWTUserDA().InsertUpdate(YWTUser, "EDIT", out   mResultType, out   mResultMessage);
        }

        public void AlertPwd(string userid, string oldpwd, string newpwd, out int mResultType, out string mResultMessage)
        {
            new YWTUserDA().AlertPwd(userid, oldpwd, newpwd, "pwd", out   mResultType, out   mResultMessage);
        }

        /// <summary>
        /// 登录验证
        /// </summary>
        public YWTUserSupplierNameOR LoginCheck(string UserNameOrMobile, string password, string IMEI, string OS, string Manufacturer, int LoginType, out int mResultType, out string mResultMessage)
        {
            return new YWTUserDA().LoginCheck(UserNameOrMobile, password, IMEI, OS, Manufacturer, LoginType, out   mResultType, out   mResultMessage);
        }

        /// <summary>
        /// 登录验证
        /// </summary>
        public YWTUserSupplierNameOR LoginCheck(string UserNameOrMobile, string password, string IMEI, string OS, string Manufacturer, out int mResultType, out string mResultMessage)
        {
            return new YWTUserDA().LoginCheck(UserNameOrMobile, password, IMEI, OS, Manufacturer, 0, out   mResultType, out   mResultMessage);
        }

        
        #endregion
        
       
    }
}
