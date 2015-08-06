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
        public YWTUser_ForLoginOR LoginCheck(string UserNameOrMobile, string password, string IMEI, string OS, string Manufacturer, int LoginType, out int mResultType, out string mResultMessage)
        {
            return new YWTUserDA().LoginCheck(UserNameOrMobile, password, IMEI, OS, Manufacturer, LoginType, out   mResultType, out   mResultMessage);
        }

        /// <summary>
        /// 登录验证
        /// </summary>
        public YWTUser_ForLoginOR LoginCheck(string UserNameOrMobile, string password, string IMEI, string OS, string Manufacturer, out int mResultType, out string mResultMessage)
        {
            return new YWTUserDA().LoginCheck(UserNameOrMobile, password, IMEI, OS, Manufacturer, 0, out   mResultType, out   mResultMessage);
        }

        
        #endregion

        #region 供应商用户管理

        /// <summary>
        /// 供应商用户管理 添加
        /// </summary>
        /// <param name="_user"></param>
        /// <param name="mResultType"></param>
        /// <param name="mResultMessage"></param>
        /// <returns></returns>
        public bool SuplierAddUser(YWTUserDetailOR _user, out int mResultType, out string mResultMessage)
        {
            return new YWTUserDA().SuplierAddUser(_user,"ADD", out   mResultType, out   mResultMessage);
        }

        /// <summary>
        /// 供应商用户管理 更新
        /// </summary>
        /// <param name="_user"></param>
        /// <param name="mResultType"></param>
        /// <param name="mResultMessage"></param>
        /// <returns></returns>
        public bool SuplierUpdateUser(YWTUserDetailOR _user, out int mResultType, out string mResultMessage)
        {
            return new YWTUserDA().SuplierAddUser(_user, "EDIT", out   mResultType, out   mResultMessage);
        }
         /// <summary>
        /// 供应商用户管理 更新
        /// </summary>
        /// <param name="_user"></param>
        /// <param name="mResultType"></param>
        /// <param name="mResultMessage"></param>
        /// <returns></returns>
        public bool EditSelfInfo(YWTUserInfoOR _user, out int mResultType, out string mResultMessage)
        {
            return new YWTUserDA().EditSelfInfo(_user,  out   mResultType, out   mResultMessage);
        }
        
        /// <summary>
        /// 查询运维商用户详细信息
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="Create_User"></param>
        /// <param name="mResultType"></param>
        /// <param name="mResultMessage"></param>
        /// <returns></returns>
        public YWTUserDetailOR GetADetail(string UserID, string Create_User, out int mResultType, out string mResultMessage)
        {
            return new YWTUserDA().GetADetail(UserID, Create_User, out  mResultType, out  mResultMessage);
        }

        public YWTUserOR GetItem(string UserID, out int mResultType, out string mResultMessage)
        {
            return new YWTUserDA().GetItem(UserID, out  mResultType, out  mResultMessage);
        }
        /// <summary>
        /// 获取运维商用户
        /// </summary>
        /// <param name="startNum"></param>
        /// <param name="EndNum"></param>
        /// <param name="UserID"></param>
        /// <param name="Create_User"></param>
        /// <param name="mResultType"></param>
        /// <param name="mResultMessage"></param>
        /// <returns></returns>
        public List<YWTSupplierUserOR> GetSupplierUser(int startNum, int EndNum,   string Create_User, out int mResultType, out string mResultMessage)
        {
            return new YWTUserDA().GetSupplierUser(startNum, EndNum,   Create_User, out  mResultType, out  mResultMessage);
        }

        #endregion

        #region 认证
        /// <summary>
        /// 查询认证文件
        /// </summary>
        /// <param name="Create_User"></param>
        /// <param name="CertifyType"></param>
        /// <param name="mResultType"></param>
        /// <param name="mResultMessage"></param>
        /// <returns></returns>
        public List<UserCertifyTypeOR> GetCertifyFile(string Create_User, string CertifyType, out int mResultType, out string mResultMessage)
        {
            return new YWTUserDA().GetCertifyFile(Create_User, CertifyType, out   mResultType, out   mResultMessage);
        }

        #endregion
    }
}
