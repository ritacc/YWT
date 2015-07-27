using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace YWT.Model.YWLog
{
    /// <summary>
    /// 
    /// </summary>
    public class YWLogReplyOR
    {
       
		/// <summary>
		/// 
		/// </summary>
		public long ReplyID { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string LogID { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string Reply_UserID { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string ReplyContent { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public DateTime Create_Date { get; set; }
		/// <summary>
		/// YWLogReply构造函数
		/// </summary>
		public YWLogReplyOR()
		{

		}

		/// <summary>
		/// YWLogReply构造函数
		/// </summary>
		public YWLogReplyOR(DataRow row)
		{
			// 
			if(row["ReplyID"]!= DBNull.Value)
                ReplyID=Convert.ToInt64(row["ReplyID"].ToString());
			// 
			LogID=row["LogID"].ToString().Trim();
			// 
			Reply_UserID=row["Reply_UserID"].ToString().Trim();
			// 
			ReplyContent=row["ReplyContent"].ToString().Trim();
			// 
			if(row["Create_Date"]!= DBNull.Value)
                Create_Date=Convert.ToDateTime(row["Create_Date"]);
		}
    }
}

