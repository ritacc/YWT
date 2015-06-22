using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YWT.Model.User;
using YWT.DAL.User;

namespace YWT.BLL.User
{
    public class YWTSupplierBLL
    {
        #region 查询        
        public YWTSupplierOR selectARowDate(string m_id)
        {
            return new YWTSupplierDA().selectARowDate(m_id);
        }
        #endregion
        #region 插入
        /// <summary>
        /// 插入
        /// </summary>
        public void InsertUpdate(YWTSupplierOR YWTSupplier, string UserID, out int mResultType, out string mResultMessage)
        {
            new YWTSupplierDA().InsertUpdate(YWTSupplier, UserID, out   mResultType, out   mResultMessage);
        }
        #endregion
       
    }
}
