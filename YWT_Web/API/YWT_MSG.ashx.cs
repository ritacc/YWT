using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YWT.Model.Common;
using YWT.Common;
using YWT.Model.Msg;
using YWT.BLL.Msg;

namespace YWT.API
{
    /// <summary>
    /// YWT_MSG 的摘要说明
    /// </summary>
    public class YWT_MSG : IHttpHandler
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
                case "get":
                    context.Response.Write(GetMsg(q0));
                    break;
                case "rt"://刷新时间
                    context.Response.Write(GetRefTime());
                    break;
                default:
                    context.Response.Write((new AjaxContentOR() { ReturnMsg = "未知异常" }).ToJSON2());
                    break;
            }
        }
        public string GetRefTime()
        {
            return "15";
        }
        public string GetMsg(string userid)
        {
            int mResultType = 0;
            string mResultMessage = "";
            try
            {
                List<YWTMsgOR> _lisMsg = new List<YWTMsgOR>();
                _lisMsg = new YWTMsgBLL().GetMsg(userid, out mResultType, out mResultMessage);


                //_List.Add(new MsgOR() { Title = "标题-11", Content = "运单发货了。", MsgType = 1, MsgType_Name ="运单信息"});
                //_List.Add(new MsgOR() { Title = "标题2-2-审核通过了", Content = "关于额度申请，审核通过了。", MsgType = 2, MsgType_Name  ="送哪儿系统信息"});
                if (_lisMsg != null && _lisMsg.Count > 0)
                {
                    List<MsgOR> _List = new List<MsgOR>();
                    foreach (YWTMsgOR _obj in _lisMsg)
                    {
                        _List.Add(new MsgOR() { Title = _obj.Title, Content = _obj.Msg_Content, MsgType = _obj.MsgType, MsgType_Name = _obj.MsgType_Name });
                    }
                    return _List.ToJSON2();
                }
            }
            catch (Exception ex)
            {
                return "";
            }
            return "";
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