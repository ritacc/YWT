using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace YWT.Model.Order
{
    /// <summary>
    /// 
    /// </summary>
    public class OrderFileSimpleOR
    { 
		/// <summary>
		/// 文件类型 到场照片、完成照片文件等
		/// </summary>
		public string FileType { get; set; }
		/// <summary>
		/// 文件名及存储路径
		/// </summary>
		public string FileName { get; set; }
		 
		/// <summary>
		/// OrderFile构造函数
		/// </summary>
		public OrderFileSimpleOR()
		{

		}

		/// <summary>
		/// OrderFile构造函数
		/// </summary>
        public OrderFileSimpleOR(DataRow row)
		{
			// 文件类型 到场照片、完成照片文件等
			FileType=row["FileType"].ToString().Trim();
			// 文件名
			FileName=row["FileName"].ToString().Trim();
		}
    }
}

