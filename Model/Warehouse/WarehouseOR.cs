using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace YWT.Model.Warehouse
{
    /// <summary>
    /// 
    /// </summary>
    public class WarehouseOR
    {
       
		/// <summary>
		/// 
		/// </summary>
		public long Warehouse_ID { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string SupplierID { get; set; }
		/// <summary>
		/// 产品图片
		/// </summary>
		public string Prodeuct_Img { get; set; }
		/// <summary>
		/// 产品名称
		/// </summary>
		public string Prodeuct_Name { get; set; }
		/// <summary>
		/// 品牌
		/// </summary>
		public string Product_Brand { get; set; }
		/// <summary>
		/// 型号
		/// </summary>
		public string Prodeuct_Model { get; set; }
		/// <summary>
		/// 数量
		/// </summary>
		public decimal Number { get; set; }
		/// <summary>
		/// 单位
		/// </summary>
		public string Unit { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string Create_User { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public DateTime Create_Date { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string Last_Modify_User { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public DateTime Last_Modify_Date { get; set; }
		/// <summary>
		/// Warehouse构造函数
		/// </summary>
		public WarehouseOR()
		{

		}

		/// <summary>
		/// Warehouse构造函数
		/// </summary>
		public WarehouseOR(DataRow row)
		{
			// 
			if(row["Warehouse_ID"]!= DBNull.Value)
                Warehouse_ID=Convert.ToInt64(row["Warehouse_ID"].ToString());
			// 
			SupplierID=row["SupplierID"].ToString().Trim();
			// 产品图片
			Prodeuct_Img=row["Prodeuct_Img"].ToString().Trim();
			// 产品名称
			Prodeuct_Name=row["Prodeuct_Name"].ToString().Trim();
			// 品牌
			Product_Brand=row["Product_Brand"].ToString().Trim();
			// 型号
			Prodeuct_Model=row["Prodeuct_Model"].ToString().Trim();
			// 数量
			if(row["Number"]!= DBNull.Value)
                Number=Convert.ToDecimal(row["Number"]);
			// 单位
			Unit=row["Unit"].ToString().Trim();
			// 
			Create_User=row["Create_User"].ToString().Trim();
			// 
			if(row["Create_Date"]!= DBNull.Value)
                Create_Date=Convert.ToDateTime(row["Create_Date"]);
			// 
			Last_Modify_User=row["Last_Modify_User"].ToString().Trim();
			// 
			if(row["Last_Modify_Date"]!= DBNull.Value)
                Last_Modify_Date=Convert.ToDateTime(row["Last_Modify_Date"]);
		}
    }
}

