using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YWT.Common;
using YWT.Model.Common;
using YWT.Model.Warehouse;
using YWT.BLL.Other;

namespace YWT.API
{
    /// <summary>
    /// YWT_Warehouse 的摘要说明
    /// </summary>
    public class YWT_Warehouse : IHttpHandler
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
                case "edit"://修改
                    context.Response.Write(Edit(q0));
                    break;
                case "getlist"://获取列表
                    context.Response.Write(this.GetList(q0, q1));
                    break;
                case "getitem"://查询明细
                    context.Response.Write(this.GetItem(q0));
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
                WarehouseOR _logMain = json.ParseJSON<WarehouseOR>();

                if (_logMain == null)
                {
                    _result.Status = false;
                    _result.ReturnMsg = "参数错误。";
                }
                else
                {
                    int mResultType = 0;
                    string mResultMessage = "";

                    new WarehouseBLL().Insert(_logMain, out mResultType, out mResultMessage);
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

                Utils.WriteLog("YWT_Warehouse.ashx/Add", err.ToString());
            }
            return _result.ToJSON2();
        }

        private string Edit(string json)
        {
            AjaxContentOR _result = new AjaxContentOR();
            try
            {
                WarehouseOR _logMain = json.ParseJSON<WarehouseOR>();

                if (_logMain == null)
                {
                    _result.Status = false;
                    _result.ReturnMsg = "参数错误。";
                }
                else
                {
                    int mResultType = 0;
                    string mResultMessage = "";

                    new WarehouseBLL().Update(_logMain, out mResultType, out mResultMessage);
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

                Utils.WriteLog("YWT_Warehouse.ashx/Edit", err.ToString());
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

                var obj = new WarehouseBLL().SearchItem(id, out mResultType, out mResultMessage);
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

                Utils.WriteLog("YWT_Warehouse.ashx/GetItem", err.ToString());
            }
            return _result.ToJSON2();
        }

        private string GetList(string Create_User, string minid)
        {
            AjaxContentOR _result = new AjaxContentOR();
            try
            {
                int mResultType = 0;
                string mResultMessage = "";

                var obj = new WarehouseBLL().SearchList(Create_User, Convert.ToInt64(minid), out mResultType, out mResultMessage);
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

                Utils.WriteLog("YWT_Warehouse.ashx/GetList", err.ToString());
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