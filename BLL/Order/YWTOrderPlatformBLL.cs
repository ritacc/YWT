using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YWT.Model.Order;
using YWT.DAL.Order;

namespace YWT.BLL.Order
{
    /// <summary>
    /// 处理运维通平台运维单相关逻辑
    /// </summary>
    public class YWTOrderPlatformBLL
    {
        /// <summary>
        /// 第三方人员  申请运维单
        /// </summary>
        /// <param name="orderPlatformApply"></param>
        /// <param name="mResultType"></param>
        /// <param name="mResultMessage"></param>
        public void OrderPlatformApply(YWTOrderPlatformApplyOR orderPlatformApply, out int mResultType, out string mResultMessage)
        {
            new YWTOrderPlatformDA().OrderPlatformApply(orderPlatformApply, out  mResultType, out  mResultMessage);
        }
    }
}
