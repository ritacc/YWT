using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace YWT.Model.Msg
{
    public class MsgOR
    {
        public string Title { get; set; }
        public String Content { get; set; }
        public int MsgType { get; set; }
        public string MsgType_Name { get; set; }
    }

    public class YWTMsgOR
    {

        /// <summary>
        /// 
        /// </summary>
        public long Msg_ID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string To_UserID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Msg_Content { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int MsgType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string MsgType_Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime CreateDateTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool ReadStatus { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime ReadDateTime { get; set; }
        /// <summary>
        /// SNRMsg构造函数
        /// </summary>
        public YWTMsgOR()
        {

        }

        /// <summary>
        /// SNRMsg构造函数
        /// </summary>
        public YWTMsgOR(DataRow row)
        {
            // 
            if (row["Msg_ID"] != DBNull.Value)
                Msg_ID = Convert.ToInt64(row["Msg_ID"]);
            // 
            To_UserID = row["To_UserID"].ToString().Trim();
            // 
            Title = row["Title"].ToString().Trim();
            // 
            Msg_Content = row["Msg_Content"].ToString().Trim();
            // 
            if (row["MsgType"] != DBNull.Value)
                MsgType = Convert.ToInt32(row["MsgType"]);
            // 
            MsgType_Name = row["MsgType_Name"].ToString().Trim();
            // 
            if (row["CreateDateTime"] != DBNull.Value)
                CreateDateTime = Convert.ToDateTime(row["CreateDateTime"]);
            // 
            if (row["ReadStatus"] != DBNull.Value)
                ReadStatus = Convert.ToBoolean(row["ReadStatus"]);
            // 
            if (row["ReadDateTime"] != DBNull.Value)
                ReadDateTime = Convert.ToDateTime(row["ReadDateTime"]);
        }
    }
}
