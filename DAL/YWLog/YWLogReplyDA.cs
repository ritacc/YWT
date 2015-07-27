using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CBSCS.DBUtility;
using YWT.Model.YWLog;


namespace YWT.DAL.YWLog
{
    /// <summary>
    /// 
    /// </summary>
    public class YWLogReplyDA
    {
        #region 生成代码
        #region 查询
        public DataTable SelectAllByWhere(string strWhere, int startIndex, int endIndex, out int RecordCount)
        {
            RecordCount = 0;
            string sql = string.Format(@"
SELECT COUNT(1) FROM YWT_YWLog_Reply WHERE 1=1 {0}
SELECT
    ITEM.*
FROM
(
    SELECT
        YWT_YWLog_Reply.*
        ,ROW_NUMBER() over(order by  ReplyID desc) rowid 
    FROM 
        YWT_YWLog_Reply
    WHERE
        1=1 {0}
) AS ITEM
WHERE ITEM.rowid BETWEEN {1} AND {2}
 ",strWhere, startIndex, endIndex);
            DataSet ds = DbHelperSQL.Query(sql);
            if (ds.Tables.Count == 2)
            {
                RecordCount = (int)ds.Tables[0].Rows[0][0];
                return ds.Tables[1];
            }
            else
            {
                return null;
            }
        }
        public YWLogReplyOR selectARowDate(string m_id)
        {
            string sql = string.Format("select * from YWT_YWLog_Reply where  ReplyID='{0}'",m_id); 
            DataTable dt = null;
            try
            {
                dt = DbHelperSQL.QueryTable(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            if (dt == null)
                return null;
            if (dt.Rows.Count == 0)
                return null;

            DataRow dr = dt.Rows[0];
            YWLogReplyOR m_YWLo=new YWLogReplyOR(dr); 
            return m_YWLo;

        }
        #endregion
        #region 插入
        /// <summary>
        /// 插入
        /// </summary>
        public virtual bool Insert(YWLogReplyOR yWLogReply)
        {
        string sql = @"insert into YWT_YWLog_Reply (ReplyID, LogID, Reply_UserID, ReplyContent, Create_Date)
values (@ReplyID, @LogID, @Reply_UserID, @ReplyContent, getdate())";
            SqlParameter [] parameters = new SqlParameter[]
			{
                new SqlParameter("@ReplyID", SqlDbType.BigInt, 8, ParameterDirection.Input, false, 0, 0, "ReplyID", DataRowVersion.Default, yWLogReply.ReplyID),
                new SqlParameter("@LogID", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "LogID", DataRowVersion.Default, yWLogReply.LogID),
                new SqlParameter("@Reply_UserID", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "Reply_UserID", DataRowVersion.Default, yWLogReply.Reply_UserID),
                new SqlParameter("@ReplyContent", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "ReplyContent", DataRowVersion.Default, yWLogReply.ReplyContent),

			};
			return DbHelperSQL.ExecuteSql(sql, parameters) > -1;
		}
		#endregion
        #region 更新
        /// <summary>
        /// 更新
        /// </summary>
        public virtual bool Update(YWLogReplyOR yWLogReply)
        {
			string sql = @"update YWT_YWLog_Reply set LogID=@LogID,Reply_UserID=@Reply_UserID,ReplyContent=@ReplyContent, where  ReplyID = @ReplyID";
            SqlParameter [] parameters = new SqlParameter[]
			{
                new SqlParameter("@ReplyID", SqlDbType.BigInt, 8, ParameterDirection.Input, false, 0, 0, "ReplyID", DataRowVersion.Default, yWLogReply.ReplyID),
                new SqlParameter("@LogID", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "LogID", DataRowVersion.Default, yWLogReply.LogID),
                new SqlParameter("@Reply_UserID", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "Reply_UserID", DataRowVersion.Default, yWLogReply.Reply_UserID),
                new SqlParameter("@ReplyContent", SqlDbType.NVarChar, 2000, ParameterDirection.Input, false, 0, 0, "ReplyContent", DataRowVersion.Default, yWLogReply.ReplyContent),

			};
			return DbHelperSQL.ExecuteSql(sql, parameters) > -1;
		}
		#endregion
        #region 删除
        /// <summary>
        /// 删除
        /// </summary>
        public virtual bool Delete(string strReplyID)
        {
			string sql = @"delete from YWT_YWLog_Reply where  ReplyID = @ReplyID";
			SqlParameter parameter = new SqlParameter("@ReplyID", strReplyID);
			return DbHelperSQL.ExecuteSql(sql, parameter) > -1;
		}
		#endregion
		#endregion
		#region 调整代码
		#endregion

    }
}

