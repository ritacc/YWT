using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace YWT.Model.Log
{
    /// <summary>
    /// 
    /// </summary>
    public class YWLogOR
    {
       
		/// <summary>
		/// 
		/// </summary>
		public string LogID { get; set; }
        public long AutoID { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string UserID { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string Title { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string Content { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public int LogStatus { get; set; }
        public string LogStatusName
        {
            get
            {
                if (LogStatus == 0)
                {
                    return "未发布";
                }
                else
                {
                    return string.Format("评论({0})", ReplyNumber);
                }
            }
        }
		/// <summary>
		/// 
		/// </summary>
		public long ReplyNumber { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public DateTime Create_Date { get; set; }
		/// <summary>
		/// YWLog构造函数
		/// </summary>
		public YWLogOR()
		{

		}

		/// <summary>
		/// YWLog构造函数
		/// </summary>
		public YWLogOR(DataRow row)
		{
			// 
			LogID=row["LogID"].ToString().Trim();
			// 
			UserID=row["UserID"].ToString().Trim();
			// 
			Title=row["Title"].ToString().Trim();
			// 
			Content=row["Content"].ToString().Trim();
			// 
			if(row["LogStatus"]!= DBNull.Value)
                LogStatus=Convert.ToInt32(row["LogStatus"]);
            if (row["AutoID"] != DBNull.Value)
                AutoID = Convert.ToInt32(row["AutoID"]);
            

			if(row["ReplyNumber"]!= DBNull.Value)
                ReplyNumber=Convert.ToInt64(row["ReplyNumber"].ToString());
			// 
			if(row["Create_Date"]!= DBNull.Value)
                Create_Date=Convert.ToDateTime(row["Create_Date"]);
		}
    }
}

