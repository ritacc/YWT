using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YWT.Common; 
using YWT.Model.Other;
using YWT.BLL.Other;
using YWT.Model.Common;

namespace YWT.API
{
    /// <summary>
    /// YWT_OnlineApproval 的摘要说明
    /// </summary>
    public class YWT_OnlineApproval : IHttpHandler
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
                case "add"://内部单
                    context.Response.Write(Add(q0));
                    break;
                //case "edit"://内部单
                //    context.Response.Write(Edit(q0, q1));
                //    break;
                case "getlist"://获取自己的列表
                    context.Response.Write(this.GetList(q0, q1));
                    break;                 
                case "getitem"://查询明细
                    context.Response.Write(this.GetItem(q0));
                    break;

                case "getcompanylist"://审核列表 分为：未审核、已审核 全部 0,1，-1
                    context.Response.Write(this.GetCompanyList(q0, q1,q2));                          
                    break;
                case "approval"://审核
                    context.Response.Write(this.Approval(q0, q1, q2, q3));
                    break; 
                default:
                    context.Response.Write((new AjaxContentOR() { ReturnMsg = "未知异常:no_action" }).ToJSON2());
                    break;
            }
        }
        /// <summary>
        /// 添加日志、修改日志
        /// </summary>
        /// <param name="json"></param>
        /// <param name="Create_User"></param>
        /// <returns></returns>
        private string Add(string json)
        {
            AjaxContentOR _result = new AjaxContentOR();
            try
            {
                OnlineApprovalOR _logMain = json.ParseJSON<OnlineApprovalOR>();              

                if (_logMain == null)
                {
                    _result.Status = false;
                    _result.ReturnMsg = "参数错误。";
                }
                else
                {
                    int mResultType = 0;
                    string mResultMessage = "";

                    new OnlineApprovalBLL().Insert(_logMain, out mResultType, out mResultMessage);
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

        private string Edit(string json, string Create_User)
        {
            AjaxContentOR _result = new AjaxContentOR();
            try
            {
                OnlineApprovalOR _logMain = json.ParseJSON<OnlineApprovalOR>();

                if (_logMain == null)
                {
                    _result.Status = false;
                    _result.ReturnMsg = "参数错误。";
                }
                else
                {
                    int mResultType = 0;
                    string mResultMessage = "";

                    new OnlineApprovalBLL().Update(_logMain, out mResultType, out mResultMessage);
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

        private string GetItem(string id)
        {
            AjaxContentOR _result = new AjaxContentOR();
            try
            {
                int mResultType = 0;
                string mResultMessage = "";

                var obj = new OnlineApprovalBLL().SearchItem(id, out mResultType, out mResultMessage);
                if (mResultType == 0)
                {
                    _result.Status = true;
                    _result.ReturnMsg = "Success";
                    _result.ResultObject = obj;
                }
                else
                {
                    _result.ReturnMsg = mResultMessage;
                }   
            }
            catch (Exception err)
            {
                _result.ReturnMsg = err.ToString();

                Utils.WriteLog("YWT_YWLog..ashx/AddOrder", err.ToString());
            }
            return _result.ToJSON2();
        }

        private string GetList(string Create_User,string num)
        {
            AjaxContentOR _result = new AjaxContentOR();
            try
            {
                int inum = int.Parse(num);
                int StartIndex = inum * 10;
                int EndIndex = (inum + 1) * 10;

                int mResultType = 0;
                string mResultMessage = "";

                var obj = new OnlineApprovalBLL().SearchList(Create_User, StartIndex, EndIndex, out mResultType, out mResultMessage);
                if (mResultType == 0)
                {
                    _result.Status = true;
                    _result.ReturnMsg = "Success";
                    _result.ResultObject = obj;
                }
                else
                {
                    _result.ReturnMsg = mResultMessage;
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
        /// 运维商审核列表
        /// </summary>
        /// <param name="Create_User"></param>
        /// /// <param name="num"></param>
        /// <param name="searchType">-1 全部 0 未审核  1 已审核</param>
        /// <returns></returns>
        private string GetCompanyList(string Create_User, string num,string searchType)
        {
            AjaxContentOR _result = new AjaxContentOR();
            try
            {
                int inum = int.Parse(num);
                int StartIndex = inum * 10;
                int EndIndex = (inum + 1) * 10;

                int mResultType = 0;
                string mResultMessage = "";

                var obj = new OnlineApprovalBLL().SearchListForComapny(Create_User, StartIndex, EndIndex, out mResultType, out mResultMessage);
                if (mResultType == 0)
                {
                    _result.Status = true;
                    _result.ReturnMsg = "Success";
                    _result.ResultObject = obj;
                }
                else
                {
                    _result.ReturnMsg = mResultMessage;
                }
            }
            catch (Exception err)
            {
                _result.ReturnMsg = err.ToString();

                Utils.WriteLog("YWT_YWLog..ashx/GetCompanyList", err.ToString());
            }
            return _result.ToJSON2();
        }

        /// <summary>
        /// 审核列表
        /// </summary>
        /// <param name="OnlineApproval_ID">申请ID OnlineApproval_ID</param>
        /// <param name="ApprovalUserID">审核人ID</param>
        /// <param name="ApprovalStatus">1 同意  2 不同意</param>
        /// <param name="ApprovalResult">审批意见 审核人填写</param>
        /// <returns></returns>
        private string Approval(string OnlineApproval_ID, string ApprovalUserID, string ApprovalStatus, string ApprovalResult)
        {
            AjaxContentOR _result = new AjaxContentOR();
            try
            {
                int mResultType = 0;
                string mResultMessage = "";

                new OnlineApprovalBLL().Approval(OnlineApproval_ID, ApprovalUserID, ApprovalStatus, ApprovalResult, out  mResultType, out  mResultMessage);
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

                Utils.WriteLog("YWT_YWLog..ashx/Approval", err.ToString());
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