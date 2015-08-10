//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using YWT.Model.Warehouse;
//using YWT.DAL.Warehouse;

//namespace YWT.BLL.Warehouse
//{
//    public class WarehouseBLL
//    {
//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="warehouse"></param>
//        /// <returns></returns>
//        public void Insert(WarehouseOR warehouse, out int mResultType, out string mResultMessage)
//        {
//            new WarehouseDA().InsertuUpdate(warehouse, "ADD", out   mResultType, out   mResultMessage);
//        }
//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="warehouse"></param>
//        /// <returns></returns>
//        public void Update(WarehouseOR warehouse, out int mResultType, out string mResultMessage)
//        {
//            new WarehouseDA().InsertuUpdate(warehouse, "EDIT", out   mResultType, out   mResultMessage);
//        }
        
//        public WarehouseOR SearchItem(long Warehouse_ID, out int mResultType, out string mResultMessage)
//        {
//            var Item = new WarehouseDA().Search(Warehouse_ID, "", -1, "item", out   mResultType, out   mResultMessage);
//            if (Item != null && Item.Count > 0)
//                return Item[0];
//            return null;

//        }

//        public List<WarehouseOR> SearchList(string Create_User, long MinID, out int mResultType, out string mResultMessage)
//        {
//            return new WarehouseDA().Search(-1, Create_User, MinID, "list", out   mResultType, out   mResultMessage);
//        }
//    }
//}
