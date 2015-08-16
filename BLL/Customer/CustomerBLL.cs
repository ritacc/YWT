using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using YWT.Model.Customer;
using YWT.DAL.Customer;


namespace YWT.BLL.Customer
{
    /// <summary>
    /// 
    /// </summary>
    public class CustomerBLL
    {
	/// <summary>
        /// 
        /// </summary>
        /// <param name="warehouse"></param>
        /// <returns></returns>
        public void Insert(CustomerOR obj, out int mResultType, out string mResultMessage)
        {
            new CustomerDA().InsertuUpdate(obj, "ADD", out   mResultType, out   mResultMessage);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="warehouse"></param>
        /// <returns></returns>
        public void Update(CustomerOR obj, out int mResultType, out string mResultMessage)
        {
            new CustomerDA().InsertuUpdate(obj, "EDIT", out   mResultType, out   mResultMessage);
        }
        
        public CustomerOR SearchItem(string keyid, out int mResultType, out string mResultMessage)
        {
            return new CustomerDA().SearchItem(keyid, out   mResultType, out   mResultMessage); 
        }

        public List<CustomerOR> SearchList(string Create_User, int StartIndex, int EndIndex, out int mResultType, out string mResultMessage)
        {
            return new CustomerDA().SearchList(Create_User, StartIndex, EndIndex, out   mResultType, out   mResultMessage);
        }
    }
}

