using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YWT.Model.Order.ImgView;
using YWT.DAL.Order;

namespace YWT.BLL.Order
{
    public class YWTOrderImgViewBLL
    {
        /// <summary>
        /// 现场拍照
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="PageIndex"></param>
        /// <param name="mResultType"></param>
        /// <param name="mResultMessage"></param>
        /// <returns></returns>
        public List<OrderImgViewOR> ImgViewStart(string UserID, int PageIndex, out  int mResultType, out string mResultMessage)
        {
            return new YWTOrderImgViewDA().ImgViewStart(UserID, PageIndex, out  mResultType, out mResultMessage);
        }

        /// <summary>
        /// 效果查询，过程还原
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="PageIndex"></param>
        /// <param name="mResultType"></param>
        /// <param name="mResultMessage"></param>
        /// <returns></returns>
        public List<OrderImgViewOR> ImgViewEnd(string UserID, int PageIndex, out  int mResultType, out string mResultMessage)
        {
            return new YWTOrderImgViewDA().ImgViewEnd(UserID, PageIndex, out  mResultType, out mResultMessage);
        }

        /// <summary>
        /// 查询图片
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="OrderID"></param>
        /// <param name="mResultType"></param>
        /// <param name="mResultMessage"></param>
        /// <returns></returns>
        public OrderImgViewItemOR ImgViewStartItem(string UserID,   string OrderID, out  int mResultType, out string mResultMessage)
        {
            return new YWTOrderImgViewDA().ImgViewLoad(UserID, "30", OrderID, out mResultType, out mResultMessage);
        }

        /// <summary>
        /// 查询图片
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="OrderID"></param>
        /// <param name="mResultType"></param>
        /// <param name="mResultMessage"></param>
        /// <returns></returns>
        public OrderImgViewItemOR ImgViewEndItem(string UserID,  string OrderID, out  int mResultType, out string mResultMessage)
        {
            return new YWTOrderImgViewDA().ImgViewLoad(UserID, "90", OrderID, out    mResultType, out   mResultMessage);
        }
    }
}
