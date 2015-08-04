using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YWT.Common;
using YWT.Model.Common;
using YWT.Model.Other;
using YWT.BLL.Other;

namespace YWT.API
{
    /// <summary>
    /// YWT_Registration 的摘要说明
    /// </summary>
    public class YWT_Registration : IHttpHandler
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
                case "add"://添加
                    context.Response.Write(Add(q0));
                    break;
                //case "edit"://修改
                //    context.Response.Write(Edit(q0, q1));
                //    break;
                case "getlist"://获取自己的列表
                    context.Response.Write(this.GetList(q0, q1));
                    break;
                case "getcompanylist"://查询员工打卡记录
                    context.Response.Write(this.GetCompanyList(q0, q1, q2, q3));
                    break;
                //case "getitem"://查询明细
                //    context.Response.Write(this.GetItem(q0));
                //    break;
                default:
                    context.Response.Write((new AjaxContentOR() { ReturnMsg = "未知异常:no_action" }).ToJSON2());
                    break;
            }
        }
        /// <summary>
        /// 添加打卡
        /// </summary>
        /// <param name="json"></param>
        /// <param name="Create_User"></param>
        /// <returns></returns>
        private string Add(string json)//, string Create_User)
        {
            AjaxContentOR _result = new AjaxContentOR();
            try
            {
                RegistrationOR _logMain = json.ParseJSON<RegistrationOR>();
                if (_logMain == null)
                {
                    _result.Status = false;
                    _result.ReturnMsg = "参数错误。";
                }
                else
                {
                    int mResultType = 0;
                    string mResultMessage = "";

                    new RegistrationBLL().Insert(_logMain, out mResultType, out mResultMessage);
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

                Utils.WriteLog("YWT_Registration.ashx/AddOrder", err.ToString());
            }
            return _result.ToJSON2();
        }

        //private string Edit(string json, string Create_User)
        //{
        //    AjaxContentOR _result = new AjaxContentOR();
        //    try
        //    {
        //        RegistrationOR _logMain = json.ParseJSON<RegistrationOR>();

        //        if (_logMain == null)
        //        {
        //            _result.Status = false;
        //            _result.ReturnMsg = "参数错误。";
        //        }
        //        else
        //        {
        //            int mResultType = 0;
        //            string mResultMessage = "";

        //            new RegistrationBLL().Update(_logMain, out mResultType, out mResultMessage);
        //            if (mResultType == 0)
        //            {
        //                _result.Status = true;
        //                _result.ReturnMsg = "Success";
        //            }
        //            else
        //            {
        //                _result.ReturnMsg = mResultMessage;
        //            }
        //        }
        //    }
        //    catch (Exception err)
        //    {
        //        _result.ReturnMsg = err.ToString();

        //        Utils.WriteLog("YWT_Registration.ashx/AddOrder", err.ToString());
        //    }
        //    return _result.ToJSON2();
        //}

        //private string GetItem(string id)
        //{
        //    AjaxContentOR _result = new AjaxContentOR();
        //    try
        //    {
        //        int mResultType = 0;
        //        string mResultMessage = "";

        //        var obj = new RegistrationBLL().SearchItem(id, out mResultType, out mResultMessage);
        //        if (mResultType == 0)
        //        {
        //            _result.Status = true;
        //            _result.ReturnMsg = "Success";
        //            _result.ResultObject = obj;
        //        }
        //        else
        //        {
        //            _result.ReturnMsg = mResultMessage;
        //        }
        //    }
        //    catch (Exception err)
        //    {
        //        _result.ReturnMsg = err.ToString();

        //        Utils.WriteLog("YWT_Registration.ashx/AddOrder", err.ToString());
        //    }
        //    return _result.ToJSON2();
        //}

        private string GetList(string Create_User, string minid)
        {
            AjaxContentOR _result = new AjaxContentOR();
            try
            {
                int mResultType = 0;
                string mResultMessage = "";

                var obj = new RegistrationBLL().SearchList(Create_User, Convert.ToInt64(minid), out mResultType, out mResultMessage);
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

                Utils.WriteLog("YWT_Registration.ashx/AddOrder", err.ToString());
            }
            return _result.ToJSON2();
        }

        /// <summary>
        /// 公司查询运维人员打卡信息
        /// </summary>
        /// <param name="Create_User"></param>
        /// <param name="UserID">打卡人ID</param>
        /// <param name="StartTime">开始时间</param>
        /// <param name="EndTime">结束时间</param>
        /// <param name="minid">最小ID</param>
        /// <returns></returns>
        private string GetCompanyList(string Create_User,string UserID,string SearchType, string minid)
        {
            AjaxContentOR _result = new AjaxContentOR();
            try
            {
                DateTime StartTime=DateTime.Now;

                //day 当日   7day 7天内  cmonth 本月   pmonth   上月   3month
                DateTime _Now = DateTime.Now;
                DateTime EndTime = Convert.ToDateTime(_Now.ToString("yyyy-MM-dd") + " 23:59:59");
               
                if (SearchType == "7day")
                {
                    StartTime = Convert.ToDateTime(_Now.AddDays(-7).ToString("yyyy-MM-dd"));
                }
                else if (SearchType == "cmonth")//本月
                {
                    StartTime = Convert.ToDateTime(string.Format("{0}-{1}-01", _Now.Year, _Now.Month));
                }
                else if (SearchType == "pmonth")//上月
                {
                    _Now = DateTime.Now.AddMonths(-1);
                    StartTime = Convert.ToDateTime(string.Format("{0}-{1}-01",_Now.Year,_Now.Month));
                    EndTime = StartTime.AddMonths(1).AddSeconds(-1);
                }
                else if (SearchType == "3month")//本月
                {
                    StartTime = Convert.ToDateTime(_Now.AddMonths(-3).ToString("yyyy-MM-dd"));
                }
                else//day
                {
                    StartTime = Convert.ToDateTime(_Now.ToString("yyyy-MM-dd"));
                }

                int mResultType = 0;
                string mResultMessage = "";
                var obj = new RegistrationBLL().SearchCompanyList(Create_User, UserID, StartTime, EndTime, minid, out mResultType, out mResultMessage);
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

                Utils.WriteLog("YWT_Registration.ashx/AddOrder", err.ToString());
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