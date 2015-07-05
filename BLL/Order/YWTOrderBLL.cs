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
        public YWTOrderDetaillOR GetOrderItem(string Order_ID, string Create_User, out  int mResultType, out string mResultMessage)
        {
            return new YWTOrderDA().GetOrderItem(Order_ID, Create_User, out   mResultType, out  mResultMessage);
        }
    }
}
