using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YWT.Model.Order;
using YWT.DAL.Order;
using YWT.Model.OrderPlatform;

namespace YWT.BLL.Order
{
    /// <summary>
    /// 处理运维通平台运维单相关逻辑
    /// </summary>
    public class YWTOrderPlatformBLL
    {
         
        /// <summary>
        /// 查询平台运维单 所有人列表
        /// </summary>
        /// <param name="StartIndex"></param>
        /// <param name="endIndex"></param>
        /// <param name="mResultType"></param>
        /// <param name="mResultMessage"></param>
        /// <returns></returns>
        public List<YWTOrderPlatform_ForListOR> PlatformOrderListSearch_ForAll(int StartIndex, int endIndex, out int mResultType, out string mResultMessage)
        {
            return new YWTOrderPlatformDA().PlatformOrderListSearch_ForAll(StartIndex, endIndex, out   mResultType, out   mResultMessage);
        }

        /// <summary>
        /// 下单人
        /// </summary>
        /// <param name="Create_User"></param>
        /// <param name="StartIndex"></param>
        /// <param name="endIndex"></param>
        /// <param name="mResultType"></param>
        /// <param name="mResultMessage"></param>
        /// <returns></returns>
        public List<YWTOrderPlatform_ForListOR> PlatformOrderListSearch_ForSupplier(string Create_User, int StartIndex, int endIndex, out int mResultType, out string mResultMessage)
        {
            return new YWTOrderPlatformDA().PlatformOrderListSearch_ForSupplier(Create_User, StartIndex, endIndex, out   mResultType, out   mResultMessage);
        }

        /// <summary>
        /// 查询一条平台运维单 
        /// 运单主体\申请人员列表
        /// </summary>
        /// <param name="mResultType"></param>
        /// <param name="mResultMessage"></param>
        /// <returns></returns>
        public YWTOrderPlatform_ForItemOR PlatformOrderItemSearch(string Order_ID, string Create_User, out int mResultType, out string mResultMessage)
        {
            return new YWTOrderPlatformDA().PlatformOrderItemSearch(Order_ID, Create_User, out mResultType, out mResultMessage);
        }

        /// <summary>
        /// 第三方人员 申请运维单
        /// </summary>
        /// <param name="orderPlatformApply"></param>
        /// <param name="mResultType"></param>
        /// <param name="mResultMessage"></param>
        public void OrderPlatformApply(YWTOrderPlatformApplyOR orderPlatformApply, out int mResultType, out string mResultMessage)
        {
          new YWTOrderPlatformDA().OrderPlatformApply(  orderPlatformApply, out   mResultType, out   mResultMessage);
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
        public void OrderPlatform_ComfirmApplyUser(string orderID, string Platform_Apply_ID, string Create_User, out int mResultType, out string mResultMessage)
        {
            new YWTOrderPlatformDA().OrderPlatform_ComfirmApplyUser(orderID, Platform_Apply_ID, Create_User, out   mResultType, out   mResultMessage);
        }


        /// <summary>
        /// 第三方人员申请成功运维单
        /// </summary>
        /// <param name="StartIndex"></param>
        /// <param name="endIndex"></param>
        /// <param name="Create_User"></param>
        /// <param name="mResultType"></param>
        /// <param name="mResultMessage"></param>
        /// <returns></returns>
        public List<YWTOrderPlatform_ForListOR> PlatformOrderList_ApplySuccess_Search(int StartIndex, int endIndex, string Create_User, out int mResultType, out string mResultMessage)
        {
            return new YWTOrderPlatformDA().PlatformOrderList_ApplySuccess_Search(StartIndex, endIndex, Create_User, out   mResultType, out   mResultMessage);
        }
        /// <summary>
        /// 第三方人员申请运维单记录查询
        /// </summary>
        /// <param name="StartIndex"></param>
        /// <param name="endIndex"></param>
        /// <param name="Create_User"></param>
        /// <param name="mResultType"></param>
        /// <param name="mResultMessage"></param>
        /// <returns></returns>
        public List<YWTOrderPlatform_ForListOR> PlatformOrderList_Apply_Search(int StartIndex, int endIndex, string Create_User, out int mResultType, out string mResultMessage)
        {
            return new YWTOrderPlatformDA().PlatformOrderList_Apply_Search(StartIndex, endIndex, Create_User, out mResultType, out mResultMessage);
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
        /// <param name="mResultType"></param>
        /// <param name="mResultMessage"></param>
        public void PlatformOrder_Assess_Save(string Order_ID, string Assess_Type, string YW_Result,
            int Score, string AssessContent, string Create_User, out int mResultType, out string mResultMessage)
        {
            new YWTOrderPlatformDA().PlatformOrder_Assess_Save(Order_ID, Assess_Type, YW_Result, Score, AssessContent, Create_User, out  mResultType, out  mResultMessage);
        }

        #region 申请人数据查询
        public List<YWTOrderPlatformApplyUser_ForListOR> GetListApplyUsers(string Order_ID, long MinID, out int mResultType, out string mResultMessage)
        {
         return   new YWTOrderPlatformDA().GetListApplyUsers(Order_ID,  MinID, out  mResultType, out  mResultMessage);
        }

        public YWTOrderPlatformApplyUserOR GetItemApplyUsers(string Platform_Apply_ID, out int mResultType, out string mResultMessage)
        {
           return new YWTOrderPlatformDA().GetItemApplyUsers( Platform_Apply_ID, out  mResultType, out  mResultMessage);
        }
        #endregion
    }
}
