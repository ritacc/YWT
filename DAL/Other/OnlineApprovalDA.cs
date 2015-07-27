using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CBSCS.DBUtility;
using YWT.Model.Other;


namespace YWT.DAL.Other
{
    /// <summary>
    /// 
    /// </summary>
    public class OnlineApprovalDA
    {
        public List<OnlineApprovalOR> SearchList(string Create_User,long MinID, out int mResultType, out string mResultMessage)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Create_User", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "Create_User", DataRowVersion.Default,Create_User),
                new SqlParameter("@MinID", SqlDbType.BigInt,10, ParameterDirection.Input, false, 0, 0, "MinID", DataRowVersion.Default, MinID),
            };


            DataSet ds = DbHelperSQL.ExecuteProcedure("SP_YWTOnlineApproval_Search", parameters, out    mResultType, out   mResultMessage);
            if (ds.Tables.Count == 1)
            {
                List<OnlineApprovalOR> _lis = new List<OnlineApprovalOR>();
                foreach (DataRow _row in ds.Tables[0].Rows)
                {
                    _lis.Add(new OnlineApprovalOR(_row));
                }
                return _lis;
            }
            return null;
        }
        public OnlineApprovalOR SearchItem(string OnlineApproval_ID, out int mResultType, out string mResultMessage)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@OnlineApproval_ID", SqlDbType.BigInt, 36, ParameterDirection.Input, false, 0, 0, "OnlineApproval_ID", DataRowVersion.Default,OnlineApproval_ID),
            };


            DataSet ds = DbHelperSQL.ExecuteProcedure("SP_YWTOnlineApproval_Load", parameters, out    mResultType, out   mResultMessage);
            if (ds.Tables.Count == 1)
            {
                foreach (DataRow _row in ds.Tables[0].Rows)
                {
                    return new OnlineApprovalOR(_row);
                }
            }
            return null;
        }
        public void InsertuUpdate(OnlineApprovalOR onlineApproval, string RecordStatus, out int mResultType, out string mResultMessage)        {
            string sql = "SP_YWTOnlineApproval_Save";
            SqlParameter[] parameters = new SqlParameter[]
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
            DbHelperSQL.ExecuteProcedureNonQuery(sql, parameters, out   mResultType, out   mResultMessage);
		}
        public void Delete(string OnlineApproval_ID,out int mResultType, out string mResultMessage)
        {
            SqlParameter[] parameters = new SqlParameter[]
			{
                new SqlParameter("@OnlineApproval_ID", OnlineApproval_ID)
			};
            DbHelperSQL.ExecuteProcedureNonQuery( "SP_YWTOnlineApproval_Delete", parameters, out   mResultType, out   mResultMessage);
		}

    }
}

