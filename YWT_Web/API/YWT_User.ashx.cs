using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YWT.Common;
using YWT.Model.Common;
using YWT.BLL.Coordinate;
using YWT.Model.Coordinate;
using YWT.Model.User;
using YWT.BLL.User;

namespace YWT.API
{
    /// <summary>
    /// YWT_User 的摘要说明
    /// </summary>
    public class YWT_User : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string action = context.Request["action"];
            string q0 = (context.Request["q0"]).TrimDangerousCharacter();
            string q1 = (context.Request["q1"]).TrimDangerousCharacter();
            string q2 = (context.Request["q2"]).TrimDangerousCharacter();
            string q3 = (context.Request["q3"]).TrimDangerousCharacter();
            string q4 = (context.Request["q4"]).TrimDangerousCharacter();
            string q5 = (context.Request["q5"]).TrimDangerousCharacter();
            string q6 = (context.Request["q6"]).TrimDangerousCharacter();
            string q7 = (context.Request["q7"]).TrimDangerousCharacter();
            string q8 = (context.Request["q8"]).TrimDangerousCharacter();
            string q9 = (context.Request["q9"]).TrimDangerousCharacter();
                        if (string.IsNullOrEmpty(action))
            {
                context.Response.Write((new AjaxContentOR() { ReturnMsg = "no_action" }).ToJSON2());
                return;
            }
            switch (action.ToLower())
            {
                case "reg":
                    context.Response.Write(reg(q0));
                    break;
                case "login":
                    context.Response.Write(login(q0, q1, q2, q3, q4));//UserName,   password,   IMEI,   OS,   Manufacturer
                    break;
                case "alertpwd":
                    context.Response.Write(AlertPwd(q0,q1, q2));
                    break;
                case "edit":
                    context.Response.Write(UpdateUserInfo(q0));
                    break;
                case "addsupuser": //添加供应商用户
                    context.Response.Write(AddSupplierUser(q0,"add"));
                    break;
                case "editsupuser": //修改供应商用户
                    context.Response.Write(AddSupplierUser(q0, "edit"));
                    break;
                case "getsupuser": //获取供应商下面的用户用户信息
                    context.Response.Write(GetSupplierUsers(q0, "0")); 
                    break;
                case "getasupuser": //获取供应商下面一个用户数据
                    context.Response.Write(GetASupplierUsers(q0, q1)); 
                    break;
                //获取文件
                case "getcertifyfile":
                    context.Response.Write(GetCertifyFile(q0, q1)); 
                    break;
                default:
                    context.Response.Write((new AjaxContentOR() { ReturnMsg = "未知异常:no_action:no_action" }).ToJSON2());
                    break;
            }
        }

        #region 注册 登录 修改密码
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="mobile"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        private string reg(string json)
        {
            AjaxContentOR _result = new AjaxContentOR();

            YWTUserOR _userOR = json.ParseJSON<YWTUserOR>();
            YWTUserOR m = new YWTUserOR();
            m.UserName = string.IsNullOrEmpty(_userOR.UserName) ? "" : _userOR.UserName;
            m.Mobile = _userOR.Mobile;
            m.RealName = string.IsNullOrEmpty(_userOR.RealName) ? "" : _userOR.RealName;
            m.UserType = _userOR.UserType;//== 0 ? 1 : _userOR.UserType; 
            m.Active = true;// _userOR.Active;
            m.SupplierID = string.IsNullOrEmpty(_userOR.SupplierID) ? "" : _userOR.SupplierID; //_userOR.SupplierID;
            m.PassWord = DES.Encrypt(_userOR.PassWord);
            YWTUserBLL bll = new YWTUserBLL();
            if (!PageValidate.IsMobile(m.Mobile))
            {
                _result.ReturnMsg = "手机号码格式不正确";
            }
            else
            {
                try
                {
                    int mResultType = 0;
                    string mResultMessage = "";

                    YWTUserOR OBJ = bll.Insert(m, out mResultType, out mResultMessage);
                    if (mResultType == 0)
                    {
                        _result.Status = true;
                        _result.ReturnMsg = "Success";
                        _result.ResultObject = OBJ;
                    }
                    else
                    {
                        _result.ReturnMsg = mResultMessage;
                    }
                }
                catch (Exception err)
                {
                    _result.ReturnMsg = err.ToString();// "错误 CODE-035684";

                    Utils.WriteLog("HDL_User.ashx/reg", err.ToString());
                }
            }

            return _result.ToJSON2();
        }

        public string UpdateUserInfo(string json)
        {
            AjaxContentOR _result = new AjaxContentOR();
            try
            {
                YWTUserOR userOR = json.ParseJSON<YWTUserOR>();
                if (userOR == null)
                {
                    _result.Status = false;
                    _result.ReturnMsg = "参数错误。";
                }
                else
                {
                    int mResultType = 0;
                    string mResultMessage = "";
                    
                    new YWTUserBLL().UpdateUserInfo(userOR, out   mResultType, out   mResultMessage);
                    if (mResultType == 0)
                    {
                        _result.Status = true;
                        _result.ReturnMsg = "成功。";
                    }
                    else
                    {
                        _result.Status = false;
                        _result.ReturnMsg = mResultMessage;
                    }
                }
            }
            catch (Exception ex)
            {
                _result.Status = false;
                _result.ReturnMsg = ex.Message.ToString();
                Utils.WriteLog("HDL_User.ashx/UpdateSupplier", ex.ToString());
            }
            return _result.ToJSON2();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="password"></param>
        /// <param name="IMEI"></param>
        /// <param name="OS"></param>
        /// <param name="Manufacturer">版本号</param>
        /// <returns></returns>
        private string login(string UserName, string password, string IMEI, string OS, string Manufacturer)
        {
            AjaxContentOR _result = new AjaxContentOR();

            int mResultType = 0;
            string mResultMessage = string.Empty;
            YWTUserSupplierNameOR _user = new YWTUserBLL().LoginCheck(UserName, DES.Encrypt(password), IMEI, OS, Manufacturer, out   mResultType, out   mResultMessage);
            if (!(mResultType == 0))
            {
                _result.ReturnMsg = mResultMessage;

            }
            else
            {
                _result.Status = true;
                _result.ResultObject = _user;
                _result.ReturnMsg = "Success";
            }
            return _result.ToJSON2();
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="oldpwd"></param>
        /// <param name="newpwd"></param>
        /// <returns></returns>
        public string AlertPwd(string userid, string oldpwd, string newpwd)
        {
            oldpwd = DES.Encrypt(oldpwd);
            newpwd = DES.Encrypt(newpwd);

            AjaxContentOR _result = new AjaxContentOR();
            int mResultType = 0;
            string mResultMessage = string.Empty;
            new YWTUserBLL().AlertPwd(userid, oldpwd, newpwd, out   mResultType, out   mResultMessage);
            if (!(mResultType == 0))
            {
                _result.ReturnMsg = mResultMessage;
            }
            else
            {
                _result.Status = true;
                _result.ReturnMsg = "Success";
            }
            return _result.ToJSON2();
        }
        #endregion 

        #region 供应商用户管理
        /// <summary>
        /// 添加供应商用户
        /// </summary>
        /// <param name="josnval"></param>
        /// <returns></returns>
        public string AddSupplierUser(string josnval,string type)
        {
            AjaxContentOR _result = new AjaxContentOR();
            YWTUserDetailOR userOR = josnval.ParseJSON<YWTUserDetailOR>();
            if (userOR == null)
            {
                _result.Status = false;
                _result.ReturnMsg = "参数错误。";
            } 
             
            int mResultType = 0;
            string mResultMessage = string.Empty;
            if (type == "add")
            {
                new YWTUserBLL().SuplierAddUser(userOR, out mResultType, out mResultMessage);
            }
            else if (type == "edit")
            {
                new YWTUserBLL().SuplierUpdateUser(userOR, out mResultType, out mResultMessage);
            }
            if (!(mResultType == 0))
            {
                _result.ReturnMsg = mResultMessage;
            }
            else
            {
                _result.Status = true;
                _result.ReturnMsg = "Success";
            }
            return _result.ToJSON2();
        }

        /// <summary>
        /// 查询供应商下面的用户 一个用户详细信息
        /// </summary>
        /// <param name="StartNum"></param>
        /// <param name="UserID"></param>
        /// <param name="Create_User"></param>
        /// <returns></returns>
        public string GetSupplierUsers(  string Create_User, string StartNum)
        {
            //开始数量，操作用户ID
            AjaxContentOR _result = new AjaxContentOR();
            int mResultType = 0;
            string mResultMessage = string.Empty;
            var result = new YWTUserBLL().GetSupplierUser(0, 200,   Create_User, out mResultType, out mResultMessage);
            if (!(mResultType == 0))
            {
                _result.ReturnMsg = mResultMessage;
            }
            else
            {
                _result.Status = true;
                _result.ReturnMsg = "Success";
                _result.ResultObject = result;
            }
            return _result.ToJSON2();
        }

        /// <summary>
        ///  查询供应商下面的用户
        /// </summary>
        /// <param name="UserID">查询用户ID</param>
        /// <param name="Create_User">操作用户ID</param>
        /// <returns></returns>
        public string GetASupplierUsers(string UserID, string Create_User) //
        {
            AjaxContentOR _result = new AjaxContentOR();
            int mResultType = 0;
            string mResultMessage = string.Empty;
            var result = new YWTUserBLL().GetADetail(UserID, Create_User, out mResultType, out mResultMessage);
            if (!(mResultType == 0))
            {
                _result.ReturnMsg = mResultMessage;
            }
            else
            {
                _result.Status = true;
                _result.ReturnMsg = "Success";
                _result.ResultObject = result;
            }
            return _result.ToJSON2();
        }
        

        #endregion

        #region 认证
        
        /// <summary>
        /// 获取谁证文件
        /// </summary>
        /// <param name="Create_User">操作用户ID</param>
        /// <param name="CertifyType"> 谁证类型 P个人， E 运维商</param>
        /// <returns></returns>
        public string GetCertifyFile(string Create_User, string CertifyType) //
        {
            AjaxContentOR _result = new AjaxContentOR();
            int mResultType = 0;
            string mResultMessage = string.Empty;
            var result = new YWTUserBLL().GetCertifyFile(Create_User, CertifyType, out mResultType, out mResultMessage);
            if (!(mResultType == 0))
            {
                _result.ReturnMsg = mResultMessage;
            }
            else
            {
                _result.Status = true;
                _result.ReturnMsg = "Success";
                _result.ResultObject = result;
            }
            return _result.ToJSON2();
        }
        //提交
        #endregion
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}