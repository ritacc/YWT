using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CBSCS.DBUtility;
using YWT.Model.Log;
using YWT.Model.Other;


namespace YWT.DAL.Other
{
    /// <summary>
    /// 
    /// </summary>
    public class OnlineApprovalDA
    {
        #region 生成代码
        #region 查询
        public DataTable SelectAllByWhere(string strWhere, int startIndex, int endIndex, out int RecordCount)
        {
            RecordCount = 0;
            string sql = string.Format(@"
SELECT COUNT(1) FROM YWT_OnlineApproval WHERE 1=1 {0}
SELECT
    ITEM.*
FROM
(
    SELECT
        YWT_OnlineApproval.*
        ,ROW_NUMBER() over(order by  OnlineApproval_ID desc) rowid 
    FROM 
        YWT_OnlineApproval
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
        public OnlineApprovalOR selectARowDate(string m_id)
        {
            string sql = string.Format("select * from YWT_OnlineApproval where  OnlineApproval_ID='{0}'",m_id); 
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
            OnlineApprovalOR m_Onli=new OnlineApprovalOR(dr); 
            return m_Onli;

        }
        #endregion
        #region 插入
        /// <summary>
        /// 插入
        /// </summary>
        public virtual bool Insert(OnlineApprovalOR onlineApproval)
        {
        string sql = @"insert into YWT_OnlineApproval (OnlineApproval_ID, ApplyType, ApplyContent, ApplyUserID, ApplyDate, Approval_UserID, Approval_Status, Approval_Time)
values (@OnlineApproval_ID, @ApplyType, @ApplyContent, @ApplyUserID, @ApplyDate, @Approval_UserID, @Approval_Status, @Approval_Time)";
            SqlParameter [] parameters = new SqlParameter[]
			{
                new SqlParameter("@OnlineApproval_ID", SqlDbType.BigInt, 8, ParameterDirection.Input, false, 0, 0, "OnlineApproval_ID", DataRowVersion.Default, onlineApproval.OnlineApproval_ID),
                new SqlParameter("@ApplyType", SqlDbType.VarChar, 30, ParameterDirection.Input, false, 0, 0, "ApplyType", DataRowVersion.Default, onlineApproval.ApplyType),
                new SqlParameter("@ApplyContent", SqlDbType.VarChar, 600, ParameterDirection.Input, false, 0, 0, "ApplyContent", DataRowVersion.Default, onlineApproval.ApplyContent),
                new SqlParameter("@ApplyUserID", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "ApplyUserID", DataRowVersion.Default, onlineApproval.ApplyUserID),
                new SqlParameter("@ApplyDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "ApplyDate", DataRowVersion.Default, onlineApproval.ApplyDate),
                new SqlParameter("@Approval_UserID", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "Approval_UserID", DataRowVersion.Default, onlineApproval.Approval_UserID),
                new SqlParameter("@Approval_Status", SqlDbType.VarChar, 30, ParameterDirection.Input, false, 0, 0, "Approval_Status", DataRowVersion.Default, onlineApproval.Approval_Status),
                new SqlParameter("@Approval_Time", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "Approval_Time", DataRowVersion.Default, onlineApproval.Approval_Time)
			};
			return DbHelperSQL.ExecuteSql(sql, parameters) > -1;
		}
		#endregion
        #region 更新
        /// <summary>
        /// 更新
        /// </summary>
        public virtual bool Update(OnlineApprovalOR onlineApproval)
        {
			string sql = @"update YWT_OnlineApproval set ApplyType=@ApplyType,ApplyContent=@ApplyContent,ApplyUserID=@ApplyUserID,ApplyDate=@ApplyDate,Approval_UserID=@Approval_UserID,Approval_Status=@Approval_Status,Approval_Time=@Approval_Time where  OnlineApproval_ID = @OnlineApproval_ID";
            SqlParameter [] parameters = new SqlParameter[]
			{
                new SqlParameter("@OnlineApproval_ID", SqlDbType.BigInt, 8, ParameterDirection.Input, false, 0, 0, "OnlineApproval_ID", DataRowVersion.Default, onlineApproval.OnlineApproval_ID),
                new SqlParameter("@ApplyType", SqlDbType.VarChar, 30, ParameterDirection.Input, false, 0, 0, "ApplyType", DataRowVersion.Default, onlineApproval.ApplyType),
                new SqlParameter("@ApplyContent", SqlDbType.VarChar, 600, ParameterDirection.Input, false, 0, 0, "ApplyContent", DataRowVersion.Default, onlineApproval.ApplyContent),
                new SqlParameter("@ApplyUserID", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "ApplyUserID", DataRowVersion.Default, onlineApproval.ApplyUserID),
                new SqlParameter("@ApplyDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "ApplyDate", DataRowVersion.Default, onlineApproval.ApplyDate),
                new SqlParameter("@Approval_UserID", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "Approval_UserID", DataRowVersion.Default, onlineApproval.Approval_UserID),
                new SqlParameter("@Approval_Status", SqlDbType.VarChar, 30, ParameterDirection.Input, false, 0, 0, "Approval_Status", DataRowVersion.Default, onlineApproval.Approval_Status),
                new SqlParameter("@Approval_Time", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "Approval_Time", DataRowVersion.Default, onlineApproval.Approval_Time)
			};
			return DbHelperSQL.ExecuteSql(sql, parameters) > -1;
		}
		#endregion
        #region 删除
        /// <summary>
        /// 删除
        /// </summary>
        public virtual bool Delete(string strOnlineApproval_ID)
        {
			string sql = @"delete from YWT_OnlineApproval where  OnlineApproval_ID = @OnlineApproval_ID";
			SqlParameter parameter = new SqlParameter("@OnlineApproval_ID", strOnlineApproval_ID);
			return DbHelperSQL.ExecuteSql(sql, parameter) > -1;
		}
		#endregion
		#endregion
		#region 调整代码
		#endregion

    }
}

