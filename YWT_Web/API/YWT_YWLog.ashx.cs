using System.Web;
using YWT.Common;
using YWT.Model.Common;

namespace YWT.API
{
    /// <summary>
    /// YWT_YWLog 运维日志
    /// </summary>
    public class YWT_YWLog : IHttpHandler
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
                case "addlog"://内部单
                    //context.Response.Write(AddOrder(q0, q1));
                    break;
                case "getlist"://获取自己的列表
                    break;
                case "getcompanylist"://查询点评列表
                    break;
                case "getitem"://查询明细
                    break;
                case "logreply"://点评日志
                    break;
                case "getitemreply"://采用最后一个ID的方式进行查询，避免重复加载。
                    break;
                default:
                    context.Response.Write((new AjaxContentOR() { ReturnMsg = "未知异常:no_action" }).ToJSON2());
                    break;
            }
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