using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace YWT.Model.User
{
    /// <summary>
    /// 
    /// </summary>
    public class UserCertifyTypeOR
    {
       
		/// <summary>
		/// 
		/// </summary>
		public long CertifyType_ID { get; set; }
		/// <summary>
		/// P个人，E企业
		/// </summary>
		public string PE { get; set; }
		/// <summary>
		/// 认证类型code 如：身份证 录入为：sfz
		/// </summary>
		public string CertifyTypeCode { get; set; }
		/// <summary>
		/// 认证类型名称 如：身份证
		/// </summary>
		public string CertifyTypeName { get; set; }
		/// <summary>
		/// 是否必须
		/// </summary>
		public bool IsMust { get; set; }

        /// <summary>
        /// 文件名称
        /// </summary>
        public string FileName { get; set; }
		/// <summary>
		/// UserCertifyType构造函数
		/// </summary>
		public UserCertifyTypeOR()
		{

		}

		/// <summary>
		/// UserCertifyType构造函数
		/// </summary>
		public UserCertifyTypeOR(DataRow row)
		{
			// 
			if(row["CertifyType_ID"]!= DBNull.Value)
                CertifyType_ID=Convert.ToInt64(row["CertifyType_ID"].ToString());
			// P个人，E企业
			PE=row["PE"].ToString().Trim();
			// 认证类型code 如：身份证 录入为：sfz
			CertifyTypeCode=row["CertifyTypeCode"].ToString().Trim();
			// 认证类型名称 如：身份证
			CertifyTypeName=row["CertifyTypeName"].ToString().Trim();
			// 是否必须
			if(row["IsMust"]!= DBNull.Value)
                IsMust=Convert.ToBoolean(row["IsMust"]);

            FileName = row["FileName"].ToString().Trim();
		}
    }
}

