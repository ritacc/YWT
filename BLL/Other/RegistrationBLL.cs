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
    public class RegistrationBLL
    {
	/// <summary>
        /// 
        /// </summary>
        /// <param name="warehouse"></param>
        /// <returns></returns>
        public void Insert(RegistrationOR obj, out int mResultType, out string mResultMessage)
        {
            new RegistrationDA().InsertuUpdate(obj, "ADD", out   mResultType, out   mResultMessage);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="warehouse"></param>
        /// <returns></returns>
        public void Update(RegistrationOR obj, out int mResultType, out string mResultMessage)
        {
            new RegistrationDA().InsertuUpdate(obj, "EDIT", out   mResultType, out   mResultMessage);
        }
        
        public RegistrationOR SearchItem(string keyid, out int mResultType, out string mResultMessage)
        {
            return new RegistrationDA().SearchItem(keyid, out   mResultType, out   mResultMessage);
 
        }

        public List<RegistrationOR> SearchList(string Create_User, long MinID, out int mResultType, out string mResultMessage)
        {
            return new RegistrationDA().SearchList(Create_User, MinID, out   mResultType, out   mResultMessage);
        }
    }
}

