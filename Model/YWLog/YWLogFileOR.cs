using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace YWT.Model.YWLog
{
    /// <summary>
    /// 
    /// </summary>
    public class YWLogFileOR
    {
       
		/// <summary>
		/// 
		/// </summary>
		public long YWLogFileID { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string LogID { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string FileName { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public DateTime Create_Date { get; set; }
		/// <summary>
		/// YWLogFile构造函数
		/// </summary>
		public YWLogFileOR()
		{

		}

		/// <summary>
		/// YWLogFile构造函数
		/// </summary>
		public YWLogFileOR(DataRow row)
		{
			// 
			if(row["YWLogFileID"]!= DBNull.Value)
                YWLogFileID=Convert.ToInt64(row["YWLogFileID"].ToString());
			// 
			LogID=row["LogID"].ToString().Trim();
			// 
			FileName=row["FileName"].ToString().Trim();
			// 
			if(row["Create_Date"]!= DBNull.Value)
                Create_Date=Convert.ToDateTime(row["Create_Date"]);
		}
    }
}

