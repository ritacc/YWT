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
    /// YWT_Supplier 的摘要说明
    /// </summary>
    public class YWT_Supplier : IHttpHandler
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
                case "addupdate":
                    context.Response.Write(AddUpdate(q0, q1));
                    break;
                case "get":
                    context.Response.Write(GetSupplier(q0));
                    break;
                default:
                    context.Response.Write((new AjaxContentOR() { ReturnMsg = "未知异常" }).ToJSON2());
                    break;
            }
        }

        public string AddUpdate(string json, string UserID)
        {
            AjaxContentOR _result = new AjaxContentOR();
            try
            {
                YWTSupplierOR _obj = json.ParseJSON<YWTSupplierOR>();
                int mResultType = 0;
                string mResultMessage = "";
                if (_obj == null || string.IsNullOrEmpty(UserID))
                {
                    _result.ReturnMsg = "参数错误";
                }
                else
                {
                    if (string.IsNullOrEmpty(_obj.ID))
                        _obj.ID = Guid.NewGuid().ToString();

                    new YWTSupplierBLL().InsertUpdate(_obj, UserID, out mResultType, out mResultMessage);

                    if (mResultType == 0)
                    {
                        _result.Status = true;
                        _result.ReturnMsg = "参数错误";
                    }
                    else
                    {
                        _result.Status = false;
                        _result.ReturnMsg = mResultMessage;
                    }
                    _result.ResultObject = _obj;
                }
            }
            catch (Exception ex)
            {
                _result.ReturnMsg = ex.Message.ToString();
                Utils.WriteLog("HDL_Supplier.ashx/UpdateSupplier", ex.ToString());
            }
            return _result.ToJSON2();
        }

        public string GetSupplier(string id)
        {
            AjaxContentOR _result = new AjaxContentOR();
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    _result.ReturnMsg = "参数错误。";
                }
                else if (id.Length != 36)
                {
                    _result.ReturnMsg = "参数错误:36";
                }
                else
                {
                    YWTSupplierOR obj = new YWTSupplierBLL().selectARowDate(id);
                    if (obj == null)
                    {
                        _result.Status = false;
                        _result.ReturnMsg = "无法获取到对象";
                    }
                    else
                    {
                        _result.Status = true;
                        _result.ReturnMsg = "Success";
                        _result.ResultObject = obj;
                    }
                }
            }
            catch (Exception ex)
            {
                _result.ReturnMsg = ex.Message.ToString();
                Utils.WriteLog("HDL_Supplier.ashx/UpdateSupplier", ex.ToString());
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