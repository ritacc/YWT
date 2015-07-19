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
using YWT.BLL.Order;
using YWT.Model.Order;
using YWT.Model.OrderPlatform;

namespace YWT.API
{
    /// <summary>
    /// YWT_OrderPlatform 的摘要说明
    /// </summary>
    public class YWT_OrderPlatform : IHttpHandler
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
                case "addexternal"://外部单
                    context.Response.Write(AddOrder(q0, q1));
                    break;
               case "getlist"://查请没有结束的平台运维单
                    context.Response.Write(PlatformOrderListSearch(int.Parse(q0)));
                    break;
               case "getitem"://查询一条平台运维单 
                    context.Response.Write(PlatformOrderItemSearch(q0,q1)); //q0 orderid,q1 Create_User
                    break;
               case "applyyw"://申请运维单
                    context.Response.Write(OrderPlatformApply(q0,q1));  
                    break;
                case "selectapplyuser": //确定第三方运维人
                    context.Response.Write(OrderPlatformSelectApplyUser(q0, q1,q2));    // orderID,   Platform_Apply_ID,   Create_User
                    break;
                case "ywusergetlist": //第三方人员查询申请成功、申请过的
                    context.Response.Write(PlatformOrderList_ApplySuccess_Search(int.Parse(q0), q1));   //sNum,Create_User
                    break;
                case "applyrecord": //第三方人员查询运维单记录
                    context.Response.Write(PlatformOrderList_Apply_Search(int.Parse(q0), q1));   //sNum,Create_User
                    break;                    
                case "assess":
                    context.Response.Write(PlatformOrder_Assess_Save(q0,q1,q2,int.Parse(q3), q4,q5));   //Order_ID,   Assess_Type,   YW_Result,  Score,   AssessContent,   Create_User
                    break;
                default:
                    context.Response.Write((new AjaxContentOR() { ReturnMsg = "未知异常:no_action" }).ToJSON2());
                    break;
            }
        }
        #region 运维单添加，查询，明细
        /// <summary>
        /// 添加运单
        /// </summary>
        /// <param name="json">json数据</param>
        /// <param name="IsPublishToPlat">是否平台订单</param>
        /// <param name="CreateUser"></param>
        /// <returns></returns>
        private string AddOrder(string json,  string CreateUser)
        {
            AjaxContentOR _result = new AjaxContentOR();
            try
            {
                YWTOrderAdminOR _OrderAdmin = json.ParseJSON<YWTOrderAdminOR>();
                if (_OrderAdmin == null)
                {
                    _result.Status = false;
                    _result.ReturnMsg = "参数错误。";
                }
                else
                {
                    int mResultType = 0;
                    string mResultMessage = "";
                    _OrderAdmin.OrderMain.IsPublishToPlat = true;
                    _OrderAdmin.OrderMain.Creator = CreateUser;
                    new YWTOrderBLL().Insert(_OrderAdmin, out mResultType, out mResultMessage);
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
                _result.ReturnMsg = err.ToString();// "错误 CODE-035684";

                Utils.WriteLog("YWT_Order.ashx/AddOrder", err.ToString());
            }
            return _result.ToJSON2();
        }

        /// <summary>
        /// 查询平台运维单
        /// </summary>
        /// <param name="sNum"></param>
        /// <returns></returns>
        public string PlatformOrderListSearch(int sNum)
        {
            int PageSize = 10;
            int StartIndex = sNum  * PageSize;
            int endIndex = (sNum + 1) * PageSize;             
            AjaxContentOR _result = new AjaxContentOR();
            try
            {
                    int mResultType = 0;
                    string mResultMessage = string.Empty;
                    List < YWTOrderPlatform_ForListOR > _list= new YWTOrderPlatformBLL().PlatformOrderListSearch(StartIndex, endIndex, out   mResultType, out   mResultMessage);
                    if (mResultType == 0)
                    {
                        _result.Status = true;
                        _result.ReturnMsg = "Success";
                        _result.ResultObject = _list;
                    }
                    else
                    {
                        _result.ReturnMsg = mResultMessage;
                    }
                
            }
            catch (Exception ex)
            {
                _result.ReturnMsg = ex.Message.ToString();
                Utils.WriteLog("YWT_Order.ashx/OrderPlatformApply", ex.ToString());
            }
            return _result.ToJSON2();
            
        } 

        /// <summary>
        /// 查询一条平台运维单 
        /// 运单主体\申请人员列表
        /// </summary>
        /// <param name="mResultType"></param>
        /// <param name="mResultMessage"></param>
        /// <returns></returns>
        public string  PlatformOrderItemSearch(string Order_ID, string Create_User)
        {
            AjaxContentOR _result = new AjaxContentOR();
            try
            {
                int mResultType = 0;
                string mResultMessage = string.Empty;
                YWTOrderPlatform_ForItemOR item = new YWTOrderPlatformBLL().PlatformOrderItemSearch(Order_ID, Create_User, out mResultType, out mResultMessage);
                if (mResultType == 0)
                {
                    _result.Status = true;
                    _result.ReturnMsg = "Success";
                    _result.ResultObject = item;
                }
                else
                {
                    _result.ReturnMsg = mResultMessage;
                }
            }
            catch (Exception ex)
            {
                _result.ReturnMsg = ex.Message.ToString();
                Utils.WriteLog("YWT_Order.ashx/PlatformOrderItemSearch", ex.ToString());
            }
            return _result.ToJSON2();
        }
        #endregion

        /// <summary>
        /// 第三方人员 申请运维单
        /// </summary>
        /// <param name="orderPlatformApply">{ Order_ID,Apply_UserID,Apply_Content,ContactMan,ContactMobile}</param>
        /// <param name="mResultType"></param>
        /// <param name="mResultMessage"></param>
        public string OrderPlatformApply(string josnApply, string Create_User)
        {
            AjaxContentOR _result = new AjaxContentOR();
            try
            {
                YWTOrderPlatformApplyOR orderPlatformApply = josnApply.ParseJSON<YWTOrderPlatformApplyOR>();
                if (orderPlatformApply == null)
                {
                    _result.Status = false;
                    _result.ReturnMsg = "解析参数出错。";
                }
                else
                {
                    if (Create_User != orderPlatformApply.Apply_UserID)
                    {
                        _result.Status = false;
                        _result.ReturnMsg = "参数错误c_u。";
                    }
                    else
                    {
                        int mResultType = 0;
                        string mResultMessage = string.Empty;
                        new YWTOrderPlatformBLL().OrderPlatformApply(orderPlatformApply, out   mResultType, out   mResultMessage);
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
            }
            catch (Exception ex)
            {
                _result.ReturnMsg = ex.Message.ToString();
                Utils.WriteLog("YWT_Order.ashx/OrderPlatformApply", ex.ToString());
            }
            return _result.ToJSON2();
        }


        /// <summary>
        /// 选定运给人员 
        /// 第三方人员申请后，运维商选定人员
        /// </summary>
        /// <param name="orderID"></param>
        /// <param name="Platform_Apply_ID"></param>
        /// <param name="Create_User"></param>
        /// <param name="mResultType"></param>
        /// <param name="mResultMessage"></param>
        public string OrderPlatformSelectApplyUser(string orderID, string Platform_Apply_ID, string Create_User)
        {
            AjaxContentOR _result = new AjaxContentOR();
            try
            {
                int mResultType = 0;
                string mResultMessage = string.Empty;
                new YWTOrderPlatformBLL().OrderPlatformSelectApplyUser(orderID, Platform_Apply_ID, Create_User, out   mResultType, out   mResultMessage);
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
            catch (Exception ex)
            {
                _result.ReturnMsg = ex.Message.ToString();
                Utils.WriteLog("YWT_Order.ashx/PlatformOrderItemSearch", ex.ToString());
            }
            return _result.ToJSON2();
        }


        /// <summary>
        /// 第三方人员申请成功运维单
        /// </summary>
        /// <param name="sNum"></param>
        /// <param name="Create_User"></param>
        /// <returns></returns>
        public string PlatformOrderList_ApplySuccess_Search(int sNum, string Create_User)
        {
            AjaxContentOR _result = new AjaxContentOR();
            try
            {
                int PageSize = 10;
                int StartIndex = sNum * PageSize;
                int endIndex = (sNum + 1) * PageSize; 

                int mResultType = 0;
                string mResultMessage = string.Empty;
                List<YWTOrderPlatform_ForListOR> item = new YWTOrderPlatformBLL().PlatformOrderList_ApplySuccess_Search(StartIndex, endIndex, Create_User, out   mResultType, out   mResultMessage);
                if (mResultType == 0)
                {
                    _result.Status = true;
                    _result.ReturnMsg = "Success";
                    _result.ResultObject = item;
                }
                else
                {
                    _result.ReturnMsg = mResultMessage;
                }
            }
            catch (Exception ex)
            {
                _result.ReturnMsg = ex.Message.ToString();
                Utils.WriteLog("YWT_Order.ashx/PlatformOrderItemSearch", ex.ToString());
            }
            return _result.ToJSON2();
        }

        /// <summary>
        /// 第三方人员查询申请记录查询
        /// </summary>
        /// <param name="sNum"></param>
        /// <param name="Create_User"></param>
        /// <returns></returns>
        public string PlatformOrderList_Apply_Search(int sNum, string Create_User)
        {
            AjaxContentOR _result = new AjaxContentOR();
            try
            {
                int PageSize = 10;
                int StartIndex = sNum * PageSize;
                int endIndex = (sNum + 1) * PageSize;

                int mResultType = 0;
                string mResultMessage = string.Empty;
                List<YWTOrderPlatform_ForListOR> item = new YWTOrderPlatformBLL().PlatformOrderList_Apply_Search(StartIndex, endIndex, Create_User, out   mResultType, out   mResultMessage);
                if (mResultType == 0)
                {
                    _result.Status = true;
                    _result.ReturnMsg = "Success";
                    _result.ResultObject = item;
                }
                else
                {
                    _result.ReturnMsg = mResultMessage;
                }
            }
            catch (Exception ex)
            {
                _result.ReturnMsg = ex.Message.ToString();
                Utils.WriteLog("YWT_Order.ashx/PlatformOrderItemSearch", ex.ToString());
            }
            return _result.ToJSON2();
        }


        /// <summary>
        /// 运维人员评价
        /// 运维商评价
        /// </summary>
        /// <param name="Order_ID"></param>
        /// <param name="Assess_Type">评价类型: 91 第三方运维人员 92 运维商</param>
        /// <param name="YW_Result">运维结果: 完成 未完成</param>
        /// <param name="Score">评分</param>
        /// <param name="AssessContent">评价内容</param>
        /// <param name="Create_User">操作人</param>
        /// <returns></returns>
        public string PlatformOrder_Assess_Save(string Order_ID, string Assess_Type, string YW_Result,int Score, string AssessContent, string Create_User)
        {
            AjaxContentOR _result = new AjaxContentOR();
            try
            {
                int mResultType = 0;
                string mResultMessage = string.Empty;
                new YWTOrderPlatformBLL().PlatformOrder_Assess_Save(Order_ID, Assess_Type, YW_Result, Score, AssessContent, Create_User, out mResultType, out mResultMessage);
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
            catch (Exception ex)
            {
                _result.ReturnMsg = ex.Message.ToString();
                Utils.WriteLog("YWT_Order.ashx/PlatformOrderItemSearch", ex.ToString());
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