using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace YWT.Model.Order
{
    /// <summary>
    /// 
    /// </summary>
    public class OrderFileOR
    {
       
		/// <summary>
		/// 
		/// </summary>
		public string Order_File_ID { get; set; }
		/// <summary>
		/// 对应单证编号
		/// </summary>
		public string OrderID { get; set; }
		/// <summary>
		/// 文件类型 到场照片、完成照片文件等
		/// </summary>
		public string FileType { get; set; }
		/// <summary>
		/// 文件名及存储路径
		/// </summary>
		public string FileName { get; set; }

        /// <summary>
        /// 运维单上传文件，缩略图路径。
        /// </summary>
        public string FileIcon { get; set; }
		/// <summary>
		/// 创建人
		/// </summary>
		public string Creator { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public DateTime CreateDateTime { get; set; }
		/// <summary>
		/// OrderFile构造函数
		/// </summary>
		public OrderFileOR()
		{

		}

		/// <summary>
		/// OrderFile构造函数
		/// </summary>
		public OrderFileOR(DataRow row)
		{
			// 
			Order_File_ID=row["Order_File_ID"].ToString().Trim();
			// 对应单证编号
            OrderID = row["Order_ID"].ToString().Trim();
			// 文件类型 到场照片、完成照片文件等
			FileType=row["FileType"].ToString().Trim();
			// 文件名
			FileName=row["FileName"].ToString().Trim();

            FileIcon = row["FileIcon"].ToString().Trim();
            
			// 创建人
			Creator=row["Creator"].ToString().Trim();
			// 
			if(row["CreateDateTime"]!= DBNull.Value)
                CreateDateTime=Convert.ToDateTime(row["CreateDateTime"]);
		}
    }
}

