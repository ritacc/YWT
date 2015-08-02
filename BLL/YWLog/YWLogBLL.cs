using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using YWT.Model.Log;
using YWT.DAL.Log;
using YWT.Model.YWLog;


namespace YWT.BLL.Log
{
    /// <summary>
    /// 
    /// </summary>
    public class YWLogBLL
    {


        /// <summary>
        /// 添加日志
        /// </summary>
        /// <param name="yWLog"></param>
        /// <param name="_lsitFiles"></param>
        /// <param name="mResultType"></param>
        /// <param name="mResultMessage"></param>
        public void InsertUpdate(YWLogOR yWLog, List<YWLogFileOR> _lsitFiles, out int mResultType, out string mResultMessage)
        {
            new YWLogDA().InsertUpdate(yWLog, _lsitFiles, out  mResultType, out  mResultMessage);
        }

        /// <summary>
        /// 评论
        /// </summary>
        /// <param name="LogID"></param>
        /// <param name="Reply_UserID"></param>
        /// <param name="ReplyContent"></param>
        /// <param name="mResultType"></param>
        /// <param name="mResultMessage"></param>
        public void LogReply(string LogID, string Reply_UserID, string ReplyContent, out int mResultType, out string mResultMessage)
        {
            new YWLogDA().LogReply(LogID, Reply_UserID, ReplyContent, out  mResultType, out  mResultMessage);
        }
        /// <summary>
        /// 公司内部查询其它人员日志
        /// </summary>
        /// <param name="Creator"></param>
        /// <param name="MinID"></param>
        /// <param name="mResultType"></param>
        /// <param name="mResultMessage"></param>
        /// <returns></returns>
        public List<YWLog_ForListOR> LogSearchForCompany(string Creator, long MinID, out int mResultType, out string mResultMessage)
        {
            string SearchType = "company";
            string LogID = "";
            DataSet ds = new YWLogDA().LogSearch(Creator, SearchType, MinID, LogID, out   mResultType, out   mResultMessage);
            if (mResultType == 0 && ds != null)
            {
                List<YWLog_ForListOR> _list = new List<YWLog_ForListOR>();
                foreach (DataRow _row in ds.Tables[0].Rows)
                {
                    _list.Add(new YWLog_ForListOR(_row));
                }
                return _list;
            }
            return null;
        }
        /// <summary>
        ///  查询自己的日志
        /// </summary>
        /// <param name="Creator"></param>
        /// <param name="MinID"></param>
        /// <param name="mResultType"></param>
        /// <param name="mResultMessage"></param>
        /// <returns></returns>
        public List<YWLog_ForSelfListOR> LogSearchForSelf(string Creator, long MinID, out int mResultType, out string mResultMessage)
        {
            string SearchType = "self";
            string LogID = "";
            DataSet ds = new YWLogDA().LogSearch(Creator, SearchType, MinID, LogID, out   mResultType, out   mResultMessage);
            if (mResultType == 0 && ds != null)
            {
                List<YWLog_ForSelfListOR> _list = new List<YWLog_ForSelfListOR>();
                foreach (DataRow _row in ds.Tables[0].Rows)
                {
                    _list.Add(new YWLog_ForSelfListOR(_row));
                }
                return _list;
            }
            return null;
        }

        /// <summary>
        ///  查询日志明细 + 最新评论
        /// </summary>
        /// <param name="Creator"></param>
        /// <param name="LogID"></param>
        /// <param name="mResultType"></param>
        /// <param name="mResultMessage"></param>
        /// <returns></returns>
        public YWLogDetailOR GetLogItem(string Creator, string LogID, out int mResultType, out string mResultMessage)
        {
            string SearchType = "item";

            DataSet ds = new YWLogDA().LogSearch(Creator, SearchType, 0, LogID, out   mResultType, out   mResultMessage);
            if (mResultType > 0 && ds != null)
            {
                YWLogDetailOR logItem = new YWLogDetailOR(ds.Tables[0].Rows[0]);
                //日志文件
                List<YWLogFileOR> _listFile = new List<YWLogFileOR>();
                foreach (DataRow _row in ds.Tables[1].Rows)
                {
                    _listFile.Add(new YWLogFileOR(_row));
                }
                logItem.LogFiles = _listFile;
                //回复
                List<YWLogReplyDetailOR> _list = new List<YWLogReplyDetailOR>();
                foreach (DataRow _row in ds.Tables[2].Rows)
                {
                    _list.Add(new YWLogReplyDetailOR(_row));
                }
                logItem.Replys = _list;
                return logItem;
            }
            return null;
        }

        /// <summary>
        ///  查询运维日志评论
        /// </summary>
        /// <param name="Creator"></param>
        /// <param name="MinID"></param>
        /// <param name="mResultType"></param>
        /// <param name="mResultMessage"></param>
        /// <returns></returns>
        public List<YWLogReplyDetailOR> LogReplySearch(string Creator, string LogID, long MinID, out int mResultType, out string mResultMessage)
        {
            string SearchType = "replylist";
            
            DataSet ds = new YWLogDA().LogSearch(Creator, SearchType, MinID, LogID, out   mResultType, out   mResultMessage);
            if (mResultType > 0 && ds != null)
            {
                List<YWLogReplyDetailOR> _list = new List<YWLogReplyDetailOR>();
                foreach (DataRow _row in ds.Tables[1].Rows)
                {
                    _list.Add(new YWLogReplyDetailOR(_row));
                }
                return _list;
            }
            return null;
        }


    }
}

