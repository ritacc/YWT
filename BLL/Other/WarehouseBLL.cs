using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using YWT.Model.Other;
using YWT.DAL.Other;
using YWT.Model.Warehouse;


namespace YWT.BLL.Other
{
    /// <summary>
    /// 
    /// </summary>
    public class WarehouseBLL
    {
	/// <summary>
        /// 
        /// </summary>
        /// <param name="warehouse"></param>
        /// <returns></returns>
        public void Insert(WarehouseOR obj, out int mResultType, out string mResultMessage)
        {
            new WarehouseDA().InsertuUpdate(obj, "ADD", out   mResultType, out   mResultMessage);
        }

        public void Update(WarehouseOR obj, out int mResultType, out string mResultMessage)
        {
            new WarehouseDA().InsertuUpdate(obj, "EDIT", out   mResultType, out   mResultMessage);
        }
        
        public WarehouseOR SearchItem(string keyid, out int mResultType, out string mResultMessage)
        {
            return new WarehouseDA().SearchItem(keyid, out   mResultType, out   mResultMessage);
        }

        public List<WarehouseOR> SearchList(string Create_User, long MinID, out int mResultType, out string mResultMessage)
        {
            return new WarehouseDA().SearchList(Create_User, MinID, out   mResultType, out   mResultMessage);
        }
    }
}

