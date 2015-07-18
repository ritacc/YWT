using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YWT.Common;
using YWT.Model.Common;
using YWT.BLL.pub;

namespace YWT.API
{
    /// <summary>
    /// VerifyCode 的摘要说明
    /// </summary>
    public class VerifyCode : IHttpHandler
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
                case "sendverifycode"://仅供IOS原生态调用（高德）
                    context.Response.Write(SendVerifyCode(q0, q1));
                    break;
                case "checkverifycode": //保存坐标数据，json
                    context.Response.Write(CheckVerifyCode(q0, q1, q2));
                    break;
                default:
                    context.Response.Write((new AjaxContentOR() { ReturnMsg = "未知异常" }).ToJSON2());
                    break;
            }
        }
        /// <summary>
        /// 发送验证码
        /// </summary>
        /// <param name="phone"></param>
        /// <param name="imei"></param>
        private string SendVerifyCode(string Phone, string IMEI)
        {
            Random rd = new Random();
            long Verifycode = rd.Next(1006, 9909);
            AjaxContentOR _result = new AjaxContentOR();
            try
            {
                int mResultType = 0;
                string mResultMessage = string.Empty;

                if (string.IsNullOrEmpty(IMEI))
                {
                    _result.Status = false;
                    _result.ReturnMsg = "未传入IMEI。";
                }
                else
                {
                    new YWTVerifyCodeBLL().VerifyCode_Save(Phone, IMEI, Verifycode.ToString(), out   mResultType, out   mResultMessage);
                    if (mResultType == 0)//保存到数据库成功。
                    {
                        //发送短信
                        string KEY = System.Web.Configuration.WebConfigurationManager.AppSettings["VerifyCode_Msg_Key"];
                        string _content = string.Format("注册码：{0}，欢迎使用送哪儿！", Verifycode);
                        //CBSCS_SWTMsg.SWTMsg swtmsg = new CBSCS_SWTMsg.SWTMsg();
                        //swtmsg.Url = Common.ConfigHelper.GetapplicationSettingsValue("Songner.Web", "Songner_Web_CBSCS_SWTMsg_SWTMsg");
                        //string Resutl = swtmsg.SendMsg_VerificationCode(Phone, _content, "songer", IMEI, KEY);
                        string Resutl = "";
                        if (Resutl.IndexOf("成功") > 0)
                        {
                            _result.Status = true;
                            _result.ReturnMsg = "成功。";
                        }
                        else
                        {
                            _result.ReturnMsg = "发送验证码失败。";
                        }
                    }
                    else
                    {
                        _result.ReturnMsg = mResultMessage;
                    }
                }
            }
            catch (Exception ex)
            {
                _result.Status = false;
                _result.ReturnMsg = ex.Message.ToString();
                Common.Utils.WriteLog("SendVerifyCode.ashx/SendVerifyCode", ex.ToString());
            }
            return _result.ToJSON2();
        }
        /// <summary>
        /// 检测验证码
        /// </summary>
        /// <param name="Phone"></param>
        /// <param name="IMEI"></param>
        /// <param name="VerifyCode"></param>
        /// <returns></returns>
        private string CheckVerifyCode(string Phone, string IMEI, string VerifyCode)
        {
            AjaxContentOR _result = new AjaxContentOR();
            try
            {
                int mResultType = 0;
                string mResultMessage = string.Empty;

                new YWTVerifyCodeBLL().VerifyCode_Check(Phone, IMEI, VerifyCode, out   mResultType, out   mResultMessage);
                if (mResultType == 0)//保存到数据库成功。
                {
                    _result.Status = true;
                    _result.ReturnMsg = "成功。";
                }
                else
                {
                    _result.ReturnMsg = mResultMessage;
                }
            }
            catch (Exception ex)
            {
                _result.Status = false;
                _result.ReturnMsg = ex.Message.ToString();
                Common.Utils.WriteLog("SendVerifyCode.ashx/SendVerifyCode", ex.ToString());
            }
            return _result.ToJSON2();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}