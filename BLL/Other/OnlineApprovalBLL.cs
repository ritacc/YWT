using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using YWT.Model.Other;
using YWT.DAL.Other;


namespace YWT.BLL.Other
{
    /// <summary>
    /// 
    /// </summary>
    public class OnlineApprovalBLL
    {
	/// <summary>
        /// 
        /// </summary>
        /// <param name="warehouse"></param>
        /// <returns></returns>
        public void Insert(OnlineApprovalOR obj, out int mResultType, out string mResultMessage)
        {
            new OnlineApprovalDA().InsertuUpdate(obj, "ADD", out   mResultType, out   mResultMessage);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="warehouse"></param>
        /// <returns></returns>
        public void Update(OnlineApprovalOR obj, out int mResultType, out string mResultMessage)
        {
            new OnlineApprovalDA().InsertuUpdate(obj, "EDIT", out   mResultType, out   mResultMessage);
        }
        
        public OnlineApprovalOR SearchItem(string keyid, out int mResultType, out string mResultMessage)
        {
            return new OnlineApprovalDA().SearchItem(keyid, out   mResultType, out   mResultMessage);
 
        }

        public List<OnlineApprovalOR> SearchList(string Create_User, long MinID, out int mResultType, out string mResultMessage)
        {
            return new OnlineApprovalDA().SearchList(Create_User, MinID, out   mResultType, out   mResultMessage);
        }
    }
}

