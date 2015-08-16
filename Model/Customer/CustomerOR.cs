using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace YWT.Model.Customer
{
    /// <summary>
    /// 
    /// </summary>
    public class CustomerOR
    {
       
		/// <summary>
		/// 
		/// </summary>
		public long CustomerID { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string SupplierID { get; set; }
		/// <summary>
		/// 简称
		/// </summary>
		public string CusShort { get; set; }
		/// <summary>
		/// 名称
		/// </summary>
		public string CusFullName { get; set; }
		/// <summary>
		/// 联系人
		/// </summary>
		public string ContactMan { get; set; }
		/// <summary>
		/// 联系电话
		/// </summary>
		public string ContactMobile { get; set; }
		/// <summary>
		/// 地址
		/// </summary>
		public string ContactAddress { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string Create_User { get; set; }
		 
		/// <summary>
		/// Customer构造函数
		/// </summary>
		public CustomerOR()
		{

		}

		/// <summary>
		/// Customer构造函数
		/// </summary>
		public CustomerOR(DataRow row)
		{
			// 
			if(row["CustomerID"]!= DBNull.Value)
                CustomerID=Convert.ToInt64(row["CustomerID"].ToString());
			// 
			SupplierID=row["SupplierID"].ToString().Trim();
			// 简称
			CusShort=row["CusShort"].ToString().Trim();
			// 名称
			CusFullName=row["CusFullName"].ToString().Trim();
			// 联系人
			ContactMan=row["ContactMan"].ToString().Trim();
			// 联系电话
			ContactMobile=row["ContactMobile"].ToString().Trim();
			// 地址
			ContactAddress=row["ContactAddress"].ToString().Trim();
			// 
			Create_User=row["Create_User"].ToString().Trim();
			 
		}
    }
}

