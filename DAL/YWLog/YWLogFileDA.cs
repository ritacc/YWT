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
    public class YWLogFileDA
    {
        #region 生成代码
        #region 查询
        public DataTable SelectAllByWhere(string strWhere, int startIndex, int endIndex, out int RecordCount)
        {
            RecordCount = 0;
            string sql = string.Format(@"
SELECT COUNT(1) FROM YWT_YWLog_File WHERE 1=1 {0}
SELECT
    ITEM.*
FROM
(
    SELECT
        YWT_YWLog_File.*
        ,ROW_NUMBER() over(order by  YWLogFileID desc) rowid 
    FROM 
        YWT_YWLog_File
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
        public YWLogFileOR selectARowDate(string m_id)
        {
            string sql = string.Format("select * from YWT_YWLog_File where  YWLogFileID='{0}'",m_id); 
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
            YWLogFileOR m_YWLo=new YWLogFileOR(dr); 
            return m_YWLo;

        }
        #endregion
        #region 插入
        /// <summary>
        /// 插入
        /// </summary>
        public virtual bool Insert(YWLogFileOR yWLogFile)
        {
        string sql = @"insert into YWT_YWLog_File (YWLogFileID, LogID, FileName, Create_Date)
values (@YWLogFileID, @LogID, @FileName, getdate())";
            SqlParameter [] parameters = new SqlParameter[]
			{
                new SqlParameter("@YWLogFileID", SqlDbType.BigInt, 8, ParameterDirection.Input, false, 0, 0, "YWLogFileID", DataRowVersion.Default, yWLogFile.YWLogFileID),
                new SqlParameter("@LogID", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "LogID", DataRowVersion.Default, yWLogFile.LogID),
                new SqlParameter("@FileName", SqlDbType.VarChar, 200, ParameterDirection.Input, false, 0, 0, "FileName", DataRowVersion.Default, yWLogFile.FileName),

			};
			return DbHelperSQL.ExecuteSql(sql, parameters) > -1;
		}
		#endregion
        #region 更新
        /// <summary>
        /// 更新
        /// </summary>
        public virtual bool Update(YWLogFileOR yWLogFile)
        {
			string sql = @"update YWT_YWLog_File set LogID=@LogID,FileName=@FileName, where  YWLogFileID = @YWLogFileID";
            SqlParameter [] parameters = new SqlParameter[]
			{
                new SqlParameter("@YWLogFileID", SqlDbType.BigInt, 8, ParameterDirection.Input, false, 0, 0, "YWLogFileID", DataRowVersion.Default, yWLogFile.YWLogFileID),
                new SqlParameter("@LogID", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "LogID", DataRowVersion.Default, yWLogFile.LogID),
                new SqlParameter("@FileName", SqlDbType.VarChar, 200, ParameterDirection.Input, false, 0, 0, "FileName", DataRowVersion.Default, yWLogFile.FileName),

			};
			return DbHelperSQL.ExecuteSql(sql, parameters) > -1;
		}
		#endregion
        #region 删除
        /// <summary>
        /// 删除
        /// </summary>
        public virtual bool Delete(string strYWLogFileID)
        {
			string sql = @"delete from YWT_YWLog_File where  YWLogFileID = @YWLogFileID";
			SqlParameter parameter = new SqlParameter("@YWLogFileID", strYWLogFileID);
			return DbHelperSQL.ExecuteSql(sql, parameter) > -1;
		}
		#endregion
		#endregion
		#region 调整代码
		#endregion

    }
}

