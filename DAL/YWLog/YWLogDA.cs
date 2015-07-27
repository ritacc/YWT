using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CBSCS.DBUtility;
using YWT.Model.Log;
using YWT.Model.YWLog;


namespace YWT.DAL.Log
{
    /// <summary>
    /// 
    /// </summary>
    public class YWLogDA
    {

        /// <summary>
        /// 插入
        /// </summary>
        public void InsertUpdate(YWLogOR yWLog, List<YWLogFileOR> _lsitFiles, out int mResultType, out string mResultMessage)
        {
            yWLog.LogID = string.IsNullOrEmpty(yWLog.LogID) ? Guid.NewGuid().ToString() : yWLog.LogID;
            List<CommandInfo> _cmds = new List<CommandInfo>();
            SqlParameter[] _parameters = new SqlParameter[]
			{
                new SqlParameter("@LogID", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "LogID", DataRowVersion.Default, yWLog.LogID),
                new SqlParameter("@UserID", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "UserID", DataRowVersion.Default, yWLog.UserID),
                new SqlParameter("@Title", SqlDbType.VarChar, 30, ParameterDirection.Input, false, 0, 0, "Title", DataRowVersion.Default, yWLog.Title),
                new SqlParameter("@Content", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "Content", DataRowVersion.Default, yWLog.Content),
                new SqlParameter("@LogStatus", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "LogStatus", DataRowVersion.Default, yWLog.LogStatus)
			};
            _cmds.Add(new CommandInfo() { CommandText = "sp_YWTYWLog_Save", Parameters = _parameters });

            //并以上传多张图片            
            if (_lsitFiles != null && _lsitFiles.Count > 0)
            {
                foreach (var item in _lsitFiles)
                {
                    SqlParameter[] parameterFiles = new SqlParameter[]
			        {
                        new SqlParameter("@LogID", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "LogID", DataRowVersion.Default, yWLog.LogID),
                        new SqlParameter("@FileName", SqlDbType.VarChar, 200, ParameterDirection.Input, false, 0, 0, "FileName", DataRowVersion.Default, item.FileName),
			        };
                    _cmds.Add(new CommandInfo() { CommandText = "sp_YWTYWLog_File_Save", Parameters = parameterFiles });
                }
            }
            DbHelperSQL.ExecuteProcedures(_cmds, out   mResultType, out   mResultMessage);
        }


        public void LogReply(string LogID, string Reply_UserID, string ReplyContent, out int mResultType, out string mResultMessage)
        {
            string sql = @"sp_YWTYWLog_Reply_Save";
            SqlParameter[] parameters = new SqlParameter[]
			{
                new SqlParameter("@LogID", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "LogID", DataRowVersion.Default, LogID),
                new SqlParameter("@Reply_UserID", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "Reply_UserID", DataRowVersion.Default, Reply_UserID),
                new SqlParameter("@ReplyContent", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "ReplyContent", DataRowVersion.Default, ReplyContent)
			};
            DbHelperSQL.ExecuteProcedure(sql, parameters, out   mResultType, out   mResultMessage);
        }
       /// <summary>
       /// 
       /// </summary>
       /// <param name="Creator"></param>
        /// <param name="SearchType">company	self  item  replylist</param>
       /// <param name="MinID"></param>
       /// <param name="LogID"></param>
       /// <param name="mResultType"></param>
       /// <param name="mResultMessage"></param>
       /// <returns></returns>
        public DataSet LogSearch(string Creator, string SearchType, long MinID, string LogID, out int mResultType, out string mResultMessage)
        {
            string sql = @"sp_YWTYWLog_Search";
            SqlParameter[] parameters = new SqlParameter[]
			{
                new SqlParameter("@Creator", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "Creator", DataRowVersion.Default, LogID),
                new SqlParameter("@SearchType", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "SearchType", DataRowVersion.Default, SearchType),
                new SqlParameter("@MinID", SqlDbType.BigInt, 20, ParameterDirection.Input, false, 0, 0, "MinID", DataRowVersion.Default, MinID),
                new SqlParameter("@LogID", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "LogID", DataRowVersion.Default, LogID)
			};
            return DbHelperSQL.ExecuteProcedure(sql, parameters, out   mResultType, out   mResultMessage);
        }

    }
}

