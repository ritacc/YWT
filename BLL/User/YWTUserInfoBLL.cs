using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using YWT.Model.User;
using YWT.DAL.User;


namespace YWT.BLL.User
{
    /// <summary>
    /// 
    /// </summary>
    public class YWTUserInfoBLL
    {
        #region 查询

        
        public YWTUserInfoOR SelectARowDate(string m_id)
        {
            return new YWTUserInfoDA().SelectARowDate(m_id);
        }
        #endregion
        #region 插入
        /// <summary>
        /// 插入
        /// </summary>
        public void InsertUpdate(YWTUserInfoOR userInfo, out int mResultType, out string mResultMessage)
        {
              new YWTUserInfoDA().InsertUpdate(userInfo, out   mResultType, out   mResultMessage);
        }
        #endregion
         
        

    }
}

