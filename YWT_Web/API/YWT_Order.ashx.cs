﻿using System;
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


namespace YWT.API
{
    /// <summary>
    /// YWT_Order 的摘要说明
    /// </summary>
    public class YWT_Order : IHttpHandler
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
                case "addinternal"://内部单
                    context.Response.Write(AddOrder(q0, q1));
                    break;
               
                case "getlist"://获取列表
                    context.Response.Write(GetList(q0, q1, q2));    //开始页数;用户ID，类型(-1 全部 0 运维中)
                    break; 
                case "getitem":
                    context.Response.Write(GetItem(q0, q1));    //运维单ID,用户ID
                    break;
                case "saveorderflow"://保存订单流程 30 90 二个状态使用此接口进行提交。
                    context.Response.Write(SaveOrderFlow(q0, q1, q2, q3, q4, q5, q6,q7)); //  Order_ID,   Order_Status,   Create_User, fileJosn,  x1,  x2,  position, remark
                    break;
                case "designateuser"://指派运维人员
                    context.Response.Write(DesignateUser(q0,q1,q2)); // 选择的用户 selectUser Json，Order_ID,   Create_User
                    break;
                case "orderassess"://运维单评价
                    context.Response.Write(OrderAssess(q0)); // Json
                    break;  
                case "monthview"://绩效统计 运维人员，看自己的。
                    context.Response.Write(MonthView(q0)); // Json
                    break;
                case "monthviewaadmin"://绩效统计 管理人员，看所有员工的。
                    context.Response.Write(MonthViewAadmin(q0,q1)); // Json
                    break;
                //现场拍照
                case "imgviewstart":// 
                    context.Response.Write(ImgViewStart(q0,q1)); //  UserID,   PageIndex
                    break;
                case "imgviewstartitem":// 
                    context.Response.Write(ImgViewStartItem(q0, q1)); // OrderID,  UserID 
                    break;
                //效果查询，过程还原
                case "imgviewend":// 
                    context.Response.Write(ImgViewEnd(q0, q1)); //  UserID,   PageIndex
                    break;
                case "imgviewenditem":// 
                    context.Response.Write(ImgViewEndItem(q0, q1)); // OrderID,  UserID 
                    break;
                default:
                    context.Response.Write((new AjaxContentOR() { ReturnMsg = "未知异常:no_action" }).ToJSON2());
                    break;
            }
        }

        #region 现场拍照
        public string ImgViewStart(string UserID, string PageIndex)
        {
            AjaxContentOR _result = new AjaxContentOR();

            int Page = 0;
            if (!int.TryParse(PageIndex,out Page))
            {
                _result.ReturnMsg = "分页参数错误。";
                return _result.ToJSON2();
            }
             
            try
            {
                int mResultType = 0;
                string mResultMessage = string.Empty;
                var result = new YWTOrderImgViewBLL().ImgViewStart(UserID, Page, out mResultType, out mResultMessage);
                if (mResultType == 0)
                {
                    _result.Status = true;
                    _result.ResultObject = result;
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
                Utils.WriteLog("YWT_Order.ashx/ImgViewStart", ex.ToString());
            }
            return _result.ToJSON2();
        }

        public string ImgViewStartItem(string OrderID, string UserID)
        {
            AjaxContentOR _result = new AjaxContentOR();
            try
            {
                int mResultType = 0;
                string mResultMessage = string.Empty;
                var result = new YWTOrderImgViewBLL().ImgViewStartItem(UserID, OrderID, out mResultType, out mResultMessage);
                if (mResultType == 0)
                {
                    _result.Status = true;
                    _result.ResultObject = result;
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
                Utils.WriteLog("YWT_Order.ashx/ImgViewStart", ex.ToString());
            }
            return _result.ToJSON2();
        }
        #endregion

        #region 效果查询，过程还原
        public string ImgViewEnd(string UserID, string PageIndex)
        {
            AjaxContentOR _result = new AjaxContentOR();

            int Page = 0;
            if (!int.TryParse(PageIndex, out Page))
            {
                _result.ReturnMsg = "分页参数错误。";
                return _result.ToJSON2();
            }

            try
            {
                int mResultType = 0;
                string mResultMessage = string.Empty;
                var result = new YWTOrderImgViewBLL().ImgViewEnd(UserID, Page, out mResultType, out mResultMessage);
                if (mResultType == 0)
                {
                    _result.Status = true;
                    _result.ResultObject = result;
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
                Utils.WriteLog("YWT_Order.ashx/ImgViewStart", ex.ToString());
            }
            return _result.ToJSON2();
        }

        public string ImgViewEndItem(string OrderID,string UserID)
        {
            AjaxContentOR _result = new AjaxContentOR(); 
            try
            {
                int mResultType = 0;
                string mResultMessage = string.Empty;
                var result = new YWTOrderImgViewBLL().ImgViewEndItem(UserID, OrderID, out mResultType, out mResultMessage);
                if (mResultType == 0)
                {
                    _result.Status = true;
                    _result.ResultObject = result;
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
                Utils.WriteLog("YWT_Order.ashx/ImgViewStart", ex.ToString());
            }
            return _result.ToJSON2();
        }
        #endregion

        #region 添加 列表 一条详细
        /// <summary>
        /// 添加运单
        /// </summary>
        /// <param name="json">json数据</param>
        /// <param name="IsPublishToPlat">是否平台订单</param>
        /// <param name="CreateUser"></param>
        /// <returns></returns>
        private string AddOrder(string json,string CreateUser)
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
                         _OrderAdmin.OrderMain.IsPublishToPlat = false;
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
        /// 查询属于它的运维单列表
        /// </summary>
        /// <param name="StartNum"></param>
        /// <param name="CreateUserID"></param>
        /// <param name="StatusType"></param>
        /// <returns></returns>
        private string GetList(string StartNum, string UserID, string StatusType)
        {
            AjaxContentOR _result = new AjaxContentOR();
            int sNum = 0;
            if (!int.TryParse(StartNum, out sNum))
            {
                sNum = 0;
            }
            int PageSize = 10;
            int eNum = (sNum + 1) * PageSize;
            sNum = sNum * PageSize + 1;
            try
            {
                int mResultType = 0;
                string mResultMessage = string.Empty;
                List<YWTOrderForListOR> _list = new YWTOrderBLL().GetOrderList(StatusType, UserID, sNum, eNum, out mResultType, out mResultMessage);
                _result.Status = true;
                _result.ReturnMsg = "";
                _result.ResultObject = _list;
            }
            catch (Exception ex)
            {
                _result.ReturnMsg = ex.Message.ToString();
                Utils.WriteLog("YWT_Order.ashx/GetOrderList", ex.ToString());
            }
            return _result.ToJSON2();
        }

        /// <summary>
        /// 获取运维单详细信息
        /// </summary>
        /// <param name="OrderID"></param>
        /// <param name="UserID"></param>
        /// <returns></returns>
        private string GetItem(string OrderID, string UserID)
        {
            AjaxContentOR _result = new AjaxContentOR();
            try
            {
                int mResultType = 0;
                string mResultMessage = string.Empty;
                YWTOrderDetaill_FroItemOR ItemOR = new YWTOrderBLL().GetOrderItem(OrderID, UserID, out mResultType, out mResultMessage);
                _result.Status = true;
                _result.ReturnMsg = "";
                _result.ResultObject = ItemOR;
            }
            catch (Exception ex)
            {
                _result.ReturnMsg = ex.Message.ToString();
                Utils.WriteLog("YWT_Order.ashx/GetOrderList", ex.ToString());
            }
            return _result.ToJSON2();
        }
        #endregion

        #region 流程处理
        /// <summary>
        /// 保存流程状态
        /// </summary>
        /// <param name="Order_ID"></param>
        /// <param name="Order_Status"></param>
        /// <param name="Create_User"></param>
        /// <param name="fileJosn"></param>
        /// <param name="x1"></param>
        /// <param name="x2"></param>
        /// <param name="position"></param>
        /// <param name="remark"></param>
        /// <returns></returns>
        public string SaveOrderFlow(string Order_ID, string Order_Status, string Create_User, string x1, string x2, string position, string remark, string fileJosn)
        {
            AjaxContentOR _result = new AjaxContentOR();
            List<OrderFileOR> _lsitFiles = null;
            if (!string.IsNullOrEmpty(fileJosn))
            {
                _lsitFiles = fileJosn.ParseJSON<List<OrderFileOR>>();
            }
            try
            {
                int mResultType = 0;
                string mResultMessage = string.Empty;
                new YWTOrderBLL().UpdateOrderFlow(Order_ID, Order_Status, Create_User, _lsitFiles, x1, x2, position, remark, out mResultType, out mResultMessage);
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
                Utils.WriteLog("YWT_Order.ashx/SaveOrderFlow", ex.ToString());
            }
            return _result.ToJSON2();
        }
        
        /// <summary>
        /// 运单分配运维人员
        /// </summary>
        /// <param name="josnUsers">[{"UserID":"afafafeee"},{"UserID":"gggggg"}] 人员数组</param>
        /// <param name="OrderID">运单ID</param>
        /// <param name="Create_User">操作人员</param>
        /// <returns></returns>
        public string DesignateUser(string josnUsers, string OrderID, string Create_User) //指源用户 用户ID，指派用户ID    
        {
            AjaxContentOR _result = new AjaxContentOR();
            try
            {
                List<OrderTaskUserOR> _lsitOrder = josnUsers.ParseJSON<List<OrderTaskUserOR>>();
                if (_lsitOrder == null)
                {
                    _result.Status = false;
                    _result.ReturnMsg = "解析参数出错。";
                }
                else
                {
                    int mResultType = 0;
                    string mResultMessage = string.Empty;
                    new YWTOrderBLL().DesignateUser(_lsitOrder, OrderID, Create_User, out mResultType, out mResultMessage);
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
            catch (Exception ex)
            {
                _result.ReturnMsg = ex.Message.ToString();
                Utils.WriteLog("YWT_Order.ashx/DesignateUser", ex.ToString());
            }
            return _result.ToJSON2();
        }


        /// <summary>
        /// 运维单评价
        /// </summary>
        /// <param name="josnAssess"></param>
        /// <returns></returns>
        public string OrderAssess(string josnAssess) 
        {
            AjaxContentOR _result = new AjaxContentOR();
            try
            {
                OrderAssessOR _assess = josnAssess.ParseJSON<OrderAssessOR>();
                if (_assess == null)
                {
                    _result.Status = false;
                    _result.ReturnMsg = "解析参数出错。";
                }
                else
                {
                    int mResultType = 0;
                    string mResultMessage = string.Empty;
                    //_assess.Creator = Create_User;
                    new YWTOrderBLL().OrderAssess(_assess, out mResultType, out mResultMessage);
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
            catch (Exception ex)
            {
                _result.ReturnMsg = ex.Message.ToString();
                Utils.WriteLog("YWT_Order.ashx/DesignateUser", ex.ToString());
            }
            return _result.ToJSON2();
        }        
        #endregion

        #region 绩效统计
        private string MonthViewAadmin(string UserID, string mType)
        {
            AjaxContentOR _result = new AjaxContentOR();
            try
            {
                int mResultType = 0;
                string mResultMessage = string.Empty;
                var result = new YWTOrderBLL().MonthViewAadmin(UserID, mType, out mResultType, out mResultMessage);
                _result.Status = true;
                _result.ReturnMsg = "";
                _result.ResultObject = result;
            }
            catch (Exception ex)
            {
                _result.ReturnMsg = ex.Message.ToString();
                Utils.WriteLog("YWT_Order.ashx/GetOrderList", ex.ToString());
            }
            return _result.ToJSON2();
        }
        private string MonthView(string UserID)
        {
            AjaxContentOR _result = new AjaxContentOR();
            try
            {
                int mResultType = 0;
                string mResultMessage = string.Empty;
                var result = new YWTOrderBLL().MonthView(UserID, out mResultType, out mResultMessage);
                _result.Status = true;
                _result.ReturnMsg = "";
                _result.ResultObject = result;
            }
            catch (Exception ex)
            {
                _result.ReturnMsg = ex.Message.ToString();
                Utils.WriteLog("YWT_Order.ashx/GetOrderList", ex.ToString());
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