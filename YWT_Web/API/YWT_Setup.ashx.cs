using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YWT.Common;
using YWT.Model.Common;
using YWT.BLL.Pub;

namespace YWT.API
{
    /// <summary>
    /// YWT_Setup 的摘要说明
    /// </summary>
    public class YWT_Setup : IHttpHandler
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
                case "setup"://仅供IOS原生态调用（高德）
                    context.Response.Write(Setup(q0, q1, q2));
                    break;
                default:
                    context.Response.Write((new AjaxContentOR() { ReturnMsg = "no_action" }).ToJSON2());
                    break;
            }
        }

        public string Setup(string IMEI, string OS, string Manufacturer)
        {
            AjaxContentOR _result = new AjaxContentOR();
            try
            {
                int mResultType = 0;
                string mResultMessage = string.Empty;
                if (string.IsNullOrEmpty(IMEI))
                {
                    _result.ReturnMsg = "IMEI不能为空。";
                }
                else
                {
                    new YWTSetupBLL().Setup(IMEI, OS, Manufacturer, out mResultType, out mResultMessage);
                    if (mResultType == 0)
                    {
                        _result.Status = true;
                        _result.ReturnMsg = "";
                    }
                    else
                    {
                        _result.ReturnMsg = mResultMessage;
                    }
                }
            }
            catch (Exception err)
            {
                _result.Status = true;
                _result.ReturnMsg = err.Message;

                Common.Utils.WriteLog("HDL_SaveLocation.ashx.setLocation", err.ToString());
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