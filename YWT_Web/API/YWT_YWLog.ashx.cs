using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YWT.Common;
using YWT.Model.Common;
using YWT.Model.Log;
using YWT.BLL.Log;
using YWT.Model.YWLog;


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
                case "addedit"://内部单
                    context.Response.Write(AddLog(q0, q1));
                    break;
                case "getlist"://获取自己的列表
                    context.Response.Write(this.LogSearchForSelf(q0, q1));
                    break;
                case "getcompanylist"://查询点评列表
                    context.Response.Write(this.LogSearchForCompany(q0, q1));
                    break;
                case "getitem"://查询明细
                    context.Response.Write(this.GetLogItem(q0, q1));
                    break;
                case "logreply"://点评日志
                    context.Response.Write(LogReply(q0, q1,q2));// 日志ID 点评人ID 点评内容
                    break;
                case "getitemreply"://采用最后一个ID的方式进行查询，避免重复加载。
                    context.Response.Write(this.LogReplySearch(q0, q1,q2));
                    break;
                default:
                    context.Response.Write((new AjaxContentOR() { ReturnMsg = "未知异常:no_action" }).ToJSON2());
                    break;
            }
        }
        #region 添加 点评
        /// <summary>
        /// 添加日志、修改日志
        /// </summary>
        /// <param name="json"></param>
        /// <param name="fileJson"></param>
        /// <returns></returns>
        private string AddLog(string json, string fileJson)
        {
            AjaxContentOR _result = new AjaxContentOR();
            try
            {
                YWLogOR _logMain = json.ParseJSON<YWLogOR>();
                List<YWLogFileOR> _lsitFiles = fileJson.ParseJSON<List<YWLogFileOR>>();

                if (_logMain == null)
                {
                    _result.Status = false;
                    _result.ReturnMsg = "参数错误。";
                }
                else
                {
                    int mResultType = 0;
                    string mResultMessage = "";

                    new YWLogBLL().InsertUpdate(_logMain, _lsitFiles, out mResultType, out mResultMessage);
                    if (mResultType == 0)
                    {
                        _result.Status = true;
                        _result.ReturnMsg = "Success";
                    }
                    else
                    {
                        _result.ReturnMsg = mResultMessage;
                    }
                }
            }
            catch (Exception err)
            {
                _result.ReturnMsg = err.ToString();

                Utils.WriteLog("YWT_YWLog..ashx/AddOrder", err.ToString());
            }
            return _result.ToJSON2();
        }

        /// <summary>
        /// 点评运维日志
        /// </summary>
        /// <param name="LogID"></param>
        /// <param name="Reply_UserID"></param>
        /// <param name="ReplyContent"></param>
        /// <returns></returns>
        private string LogReply(string LogID, string Reply_UserID, string ReplyContent)
        {
            AjaxContentOR _result = new AjaxContentOR();
            try
            {
                int mResultType = 0;
                string mResultMessage = "";
                new YWLogBLL().LogReply(LogID, Reply_UserID, ReplyContent, out mResultType, out mResultMessage);
                if (mResultType == 0)
                {
                    _result.Status = true;
                    _result.ReturnMsg = "Success";
                }
                else
                {
                    _result.ReturnMsg = mResultMessage;
                }
            }
            catch (Exception err)
            {
                _result.ReturnMsg = err.ToString();
                Utils.WriteLog("YWT_YWLog..ashx/LogApply", err.ToString());
            }
            return _result.ToJSON2();
        }
        #endregion

        #region 查询
        public string LogSearchForCompany(string Creator, string _MinID)
        {
            AjaxContentOR _result = new AjaxContentOR();
            try
            {
                long MinID = 0;
                if (!long.TryParse(_MinID, out MinID))
                {
                    _result.ReturnMsg = "MinID 错误。";
                }
                else
                {
                    int mResultType = 0;
                    string mResultMessage = string.Empty;
                    List<YWLogDetailOR> _list = new YWLogBLL().LogSearchForCompany(Creator, MinID, out   mResultType, out   mResultMessage);
                    _result.Status = true;
                    _result.ReturnMsg = "";
                    _result.ResultObject = _list;
                }
            }
            catch (Exception ex)
            {
                _result.ReturnMsg = ex.Message.ToString();
                Utils.WriteLog("YWT_YWLog.ashx/LogSearchForCompany", ex.ToString());
            }
            return _result.ToJSON2();
        }
        /// <summary>
        ///  查询自己的日志
        /// </summary>
        /// <param name="Creator"></param>
        /// <param name="MinID"></param>
        /// <param name="mResultType"></param>
        /// <param name="mResultMessage"></param>
        /// <returns></returns>
        public string  LogSearchForSelf(string Creator, string _MinID)
        {
            AjaxContentOR _result = new AjaxContentOR();
            try
            {
                long MinID = 0;
                if (!long.TryParse(_MinID, out MinID))
                {
                    _result.ReturnMsg = "MinID 错误。";
                }
                else
                {
                    int mResultType = 0;
                    string mResultMessage = string.Empty;
                    List<YWLogDetailOR> _list = new YWLogBLL().LogSearchForSelf(Creator, MinID, out   mResultType, out   mResultMessage);
                    _result.Status = true;
                    _result.ReturnMsg = "";
                    _result.ResultObject = _list;
                }
            }
            catch (Exception ex)
            {
                _result.ReturnMsg = ex.Message.ToString();
                Utils.WriteLog("YWT_YWLog.ashx/LogSearchForCompany", ex.ToString());
            }
            return _result.ToJSON2();
        }

        /// <summary>
        ///  查询日志明细 + 最新评论
        /// </summary>
        /// <param name="Creator"></param>
        /// <param name="LogID"></param>
        /// <param name="mResultType"></param>
        /// <param name="mResultMessage"></param>
        /// <returns></returns>
        public string  GetLogItem(string Creator, string LogID)
        {
            AjaxContentOR _result = new AjaxContentOR();
            try
            { 
                    int mResultType = 0;
                    string mResultMessage = string.Empty;
                    YWLogDetailOR ItemOR = new YWLogBLL().GetLogItem(Creator, LogID, out   mResultType, out   mResultMessage);
                    _result.Status = true;
                    _result.ReturnMsg = "";
                    _result.ResultObject = ItemOR;
                
            }
            catch (Exception ex)
            {
                _result.ReturnMsg = ex.Message.ToString();
                Utils.WriteLog("YWT_YWLog.ashx/LogSearchForCompany", ex.ToString());
            }
            return _result.ToJSON2();
        }

        /// <summary>
        ///  查询运维日志评论
        /// </summary>
        /// <param name="Creator"></param>
        /// <param name="MinID"></param>
        /// <param name="mResultType"></param>
        /// <param name="mResultMessage"></param>
        /// <returns></returns>
        public string  LogReplySearch(string Creator, string LogID, string _MinID)
        {
            AjaxContentOR _result = new AjaxContentOR();
            try
            {
                long MinID = 0;
                if (!long.TryParse(_MinID, out MinID))
                {
                    _result.ReturnMsg = "MinID 错误。";
                }
                else
                {
                    int mResultType = 0;
                    string mResultMessage = string.Empty;
                    List<YWLogReplyDetailOR> _list = new YWLogBLL().LogReplySearch(Creator, LogID, MinID, out   mResultType, out   mResultMessage);
                    _result.Status = true;
                    _result.ReturnMsg = "";
                    _result.ResultObject = _list;
                }
            }
            catch (Exception ex)
            {
                _result.ReturnMsg = ex.Message.ToString();
                Utils.WriteLog("YWT_YWLog.ashx/LogReplySearch", ex.ToString());
            }
            return _result.ToJSON2();
        }
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