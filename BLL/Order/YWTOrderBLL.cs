using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YWT.DAL.Order;
using YWT.Model.Order;

namespace YWT.BLL.Order
{
    public class YWTOrderBLL
    {
        #region 基础操作
        /// <summary>
        /// 保存运维单
        /// </summary>
        /// <param name="order"></param>
        /// <param name="mResultType"></param>
        /// <param name="mResultMessage"></param>
        public void Insert(YWTOrderAdminOR _Order, out int mResultType, out string mResultMessage)
        {
            new YWTOrderDA().Insert(_Order, out  mResultType, out  mResultMessage);
        }
        /// <summary>
        /// 查询可以办理的列表
        /// </summary>
        /// <param name="StatusType"></param>
        /// <param name="Create_User"></param>
        /// <param name="StartIndex"></param>
        /// <param name="endIndex"></param>
        /// <param name="mResultType"></param>
        /// <param name="mResultMessage"></param>
        /// <returns></returns>
        public List<YWTOrderForListOR> GetOrderList(string StatusType, string Create_User, int StartIndex, int endIndex, out  int mResultType, out string mResultMessage)
        {
            return new YWTOrderDA().GetOrderList(StatusType, Create_User, StartIndex, endIndex, out   mResultType, out  mResultMessage);
        }

        /// <summary>
        /// 查询一个运维单详细
        /// </summary>
        /// <param name="Order_ID"></param>
        /// <param name="Create_User"></param>
        /// <param name="mResultType"></param>
        /// <param name="mResultMessage"></param>
        /// <returns></returns>
        public YWTOrderDetaill_FroItemOR GetOrderItem(string Order_ID, string Create_User, out  int mResultType, out string mResultMessage)
        {
            return new YWTOrderDA().GetOrderItem(Order_ID, Create_User, out   mResultType, out  mResultMessage);
        }
        #endregion
        #region 流程操作
        public void DesignateUser(List<OrderTaskUserOR> _lsitOrder, string Order_ID, string Create_User, out  int mResultType, out string mResultMessage)
        {
            new YWTOrderDA().DesignateUser(_lsitOrder, Order_ID, Create_User, out  mResultType, out  mResultMessage);
        }
        /// <summary>
        /// 更新订单流程
        /// </summary>
        /// <param name="Order_ID"></param>
        /// <param name="Order_Status"></param>
        /// <param name="Create_User"></param>
        /// <param name="mResultType"></param>
        /// <param name="mResultMessage"></param>
        public void UpdateOrderFlow(string Order_ID, string Order_Status, string Create_User
            ,List<OrderFileOR> _lsitFiles ,string Longitude, string Latitude, string LocationCity, string remark, out int mResultType, out string mResultMessage)
        {
            new YWTOrderDA().UpdateOrderFlow(Order_ID, Order_Status, Create_User, _lsitFiles
                , Longitude, Latitude, LocationCity, remark, out   mResultType, out   mResultMessage);
        }

        /// <summary>
        /// 订单评价
        /// </summary>
        /// <param name="orderAssess"></param>
        /// <param name="mResultType"></param>
        /// <param name="mResultMessage"></param>
        public void OrderAssess(OrderAssessOR orderAssess, out int mResultType, out string mResultMessage)
        {
            new YWTOrderDA().OrderAssess(orderAssess, out  mResultType, out  mResultMessage);
        }

        
        #endregion

       
    }
}
