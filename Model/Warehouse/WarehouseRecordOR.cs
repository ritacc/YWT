using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace YWT.Model.Warehouse
{
    /// <summary>
    /// 
    /// </summary>
    public class WarehouseRecordOR
    {
       
		/// <summary>
		/// 
		/// </summary>
		public long Warehouse_Record_ID { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public long Warehouse_ID { get; set; }
		/// <summary>
		/// 操作类型
		/// </summary>
		public string Record_Type { get; set; }
		/// <summary>
		/// 数量
		/// </summary>
		public decimal Number { get; set; }
		/// <summary>
		/// 描述
		/// </summary>
		public string Remark { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string Create_User { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public DateTime Create_Date { get; set; }
		/// <summary>
		/// WarehouseRecord构造函数
		/// </summary>
		public WarehouseRecordOR()
		{

		}

		/// <summary>
		/// WarehouseRecord构造函数
		/// </summary>
		public WarehouseRecordOR(DataRow row)
		{
			// 
			if(row["Warehouse_Record_ID"]!= DBNull.Value)
                Warehouse_Record_ID=Convert.ToInt64(row["Warehouse_Record_ID"].ToString());
			// 
			if(row["Warehouse_ID"]!= DBNull.Value)
                Warehouse_ID=Convert.ToInt64(row["Warehouse_ID"].ToString());
			// 操作类型
			Record_Type=row["Record_Type"].ToString().Trim();
			// 数量
			if(row["Number"]!= DBNull.Value)
                Number=Convert.ToDecimal(row["Number"]);
			// 描述
			Remark=row["Remark"].ToString().Trim();
			// 
			Create_User=row["Create_User"].ToString().Trim();
			// 
			if(row["Create_Date"]!= DBNull.Value)
                Create_Date=Convert.ToDateTime(row["Create_Date"]);
		}
    }
}

