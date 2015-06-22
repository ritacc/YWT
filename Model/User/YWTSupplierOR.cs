using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace YWT.Model.User
{
  public class YWTSupplierOR
    {
      /// <summary>
		/// 
		/// </summary>
        public string ID { get; set; }
		/// <summary>
		/// 公司名称
		/// </summary>
		public string Company { get; set; }
		/// <summary>
		/// 联系人
		/// </summary>
		public string ContactMan { get; set; }
		/// <summary>
		/// 公司地址
		/// </summary>
		public string Address { get; set; }
		/// <summary>
		/// 联系电话
		/// </summary>
		public string Tel { get; set; }
		/// <summary>
		/// 手机号码
		/// </summary>
		public string Mobile { get; set; }
		/// <summary>
		/// 传真
		/// </summary>
		public string Fax { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string Email { get; set; }
		/// <summary>
		/// 供应商状态是否可用
		/// </summary>
		public bool Status { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public DateTime CreateDateTime { get; set; }
		/// <summary>
		/// SNRSupplier构造函数
		/// </summary>
		public YWTSupplierOR()
		{
            ID = Guid.NewGuid().ToString();
            CreateDateTime = DateTime.Now;
		}

		/// <summary>
		/// SNRSupplier构造函数
		/// </summary>
        public YWTSupplierOR(DataRow row)
		{
			// 
            ID = row["ID"].ToString();
			// 公司名称
			Company=row["Company"].ToString().Trim();
			// 联系人
			ContactMan=row["ContactMan"].ToString().Trim();
			// 公司地址
			Address=row["Address"].ToString().Trim();
			// 联系电话
			Tel=row["Tel"].ToString().Trim();
			// 手机号码
			Mobile=row["Mobile"].ToString().Trim();
			// 传真
			Fax=row["Fax"].ToString().Trim();
			// 
			Email=row["Email"].ToString().Trim();
			// 供应商状态是否可用
			if(row["Status"]!= DBNull.Value)
                Status=Convert.ToBoolean(row["Status"]);
			// 
			if(row["CreateDateTime"]!= DBNull.Value)
                CreateDateTime=Convert.ToDateTime(row["CreateDateTime"]);
		}
    }
}
