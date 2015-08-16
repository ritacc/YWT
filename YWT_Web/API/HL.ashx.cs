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
    public class HL : IHttpHandler
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
                case "sl"://仅供IOS原生态调用（高德）
                    context.Response.Write(setLocation(q0, q1, q2));
                    break;
                case "getsubxy"://查询运维商下面所有运维人员
                    context.Response.Write(GetSupplierAllUserPostionInfo(q0));
                    break;
                case "sj": //保存坐标数据，json
                    context.Response.Write(setLocation(q0));
                    break;
                //case "getusercoordinate"://获取10 供应商下面的司机最后一个坐标 99 全部 其它 自己
                //    context.Response.Write(GetCoordinate(q0));
                //    break;
                default:
                    context.Response.Write((new AjaxContentOR() { ReturnMsg = "no_action" }).ToJSON2());
                    break;
            }
        }
        #region 查询定位
        public string GetSupplierAllUserPostionInfo(string userid)
        {
            AjaxContentOR _result = new AjaxContentOR();
            try
            {
                int mResultType = 0;
                string mResultMessage = "";
                List<YWTUserPostionInfoOR> _UserObj = new YWTCoordinateBLL().GetSupplierAllUserPostionInfo(userid, out mResultType, out mResultMessage);
                if (mResultType == 0)
                {
                    _result.Status = true;
                    _result.ResultObject = _UserObj;
                    _result.ReturnMsg = "成功。";
                }
                else
                {
                    _result.Status = false;
                    _result.ReturnMsg = mResultMessage;
                }

            }
            catch (Exception ex)
            {
                _result.Status = false;
                _result.ReturnMsg = ex.Message.ToString();
                Utils.WriteLog("HDL_User.ashx/GetPostionInfo", ex.ToString());
            }
            return _result.ToJSON2();
        }
        #endregion

        
        /// <summary>
        /// 仅供IOS原生态调用（高德）
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="lng"></param>
        /// <param name="lat"></param>
        /// <returns></returns>
        private string setLocation(string UserID, string lng, string lat)
        {
            //AjaxContentOR _result = new AjaxContentOR();
            if (!string.IsNullOrEmpty(UserID))
            {
                try
                {
                    YWTCoordinateOR m = new YWTCoordinateOR();
                    m.CarID = "";
                    m.CreateDateTime = DateTime.Now;
                    m.ID = Guid.NewGuid().ToString();
                    m.longitude = lng;
                    m.latitude = lat;

                    long UserAutoID = 0;
                    if (long.TryParse(UserID, out UserAutoID))
                    {
                        m.UserAutoID = UserAutoID;
                    }
                    else
                    {
                        m.UserID = UserID ?? "";
                    }
                   
                    int mResultType = 0;
                    string mResultMessage = "";
                     new YWTCoordinateBLL().Insert(m, out mResultType, out mResultMessage); 
                }
                catch (Exception err)
                {
                    Utils.WriteLog("HDL_SaveLocation.ashx.setLocation", err.ToString());
                }
            } 
            return "{\"Status\":true}";
        }

        private string setLocation(string json)
        { 
            try
            {
                YWTCoordinateOR _obj = json.ParseJSON<YWTCoordinateOR>();
                if (_obj == null)
                {
                    // _result.ReturnMsg = "参数错误";
                }
                else
                {
                    _obj.longitude = _obj.X;
                    _obj.latitude = _obj.Y;
                    _obj.UserID = _obj.U;

                    int mResultType = 0;
                    string mResultMessage = "";
                    new YWTCoordinateBLL().Insert(_obj, out mResultType, out mResultMessage);
                }
            }
            catch (Exception err)
            {
                Utils.WriteLog("HDL_SaveLocation.ashx.setLocation", err.ToString());
            }
            return "{\"Status\":true}";
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