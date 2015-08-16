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
        public List<OnlineApprovalOR> SearchList(string Create_User, int StartIndex, int EndIndex, out int mResultType, out string mResultMessage)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Create_User", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "Create_User", DataRowVersion.Default,Create_User),
                new SqlParameter("@StartIndex", SqlDbType.Int,8, ParameterDirection.Input, false, 0, 0, "StartIndex", DataRowVersion.Default, StartIndex),
                new SqlParameter("@EndIndex", SqlDbType.Int,8, ParameterDirection.Input, false, 0, 0, "EndIndex", DataRowVersion.Default, EndIndex),
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
        /// <summary>
        /// 运维商查询需要审批的列表
        /// </summary>
        /// <param name="Create_User"></param>
        /// <param name="StartIndex"></param>
        /// <param name="EndIndex"></param>
        /// <param name="mResultType"></param>
        /// <param name="mResultMessage"></param>
        /// <returns></returns>
        public List<OnlineApproval_ForCompanyListOR> SearchListForComapny(string Create_User, string searchType, int StartIndex, int EndIndex, out int mResultType, out string mResultMessage)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Create_User", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "Create_User", DataRowVersion.Default,Create_User),
                new SqlParameter("@SearchType", SqlDbType.Int,8, ParameterDirection.Input, false, 0, 0, "SearchType", DataRowVersion.Default, searchType),
                new SqlParameter("@StartIndex", SqlDbType.Int,8, ParameterDirection.Input, false, 0, 0, "StartIndex", DataRowVersion.Default, StartIndex),
                new SqlParameter("@EndIndex", SqlDbType.Int,8, ParameterDirection.Input, false, 0, 0, "EndIndex", DataRowVersion.Default, EndIndex),
            };
            

            DataSet ds = DbHelperSQL.ExecuteProcedure("SP_YWTOnlineApproval_SearchForCompany", parameters, out    mResultType, out   mResultMessage);
            if (ds.Tables.Count == 1)
            {
                List<OnlineApproval_ForCompanyListOR> _lis = new List<OnlineApproval_ForCompanyListOR>();
                foreach (DataRow _row in ds.Tables[0].Rows)
                {
                    _lis.Add(new OnlineApproval_ForCompanyListOR(_row));
                }
                return _lis;
            }
            return null;
        }
        public OnlineApprovalOR SearchItem(string   OnlineApproval_ID, out int mResultType, out string mResultMessage)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@OnlineApproval_ID", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "OnlineApproval_ID", DataRowVersion.Default,OnlineApproval_ID),
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
                //new SqlParameter("@OnlineApproval_ID", SqlDbType.BigInt, 8, ParameterDirection.Input, false, 0, 0, "OnlineApproval_ID", DataRowVersion.Default, onlineApproval.OnlineApproval_ID),
                //new SqlParameter("@ApplyNo", SqlDbType.VarChar, 12, ParameterDirection.Input, false, 0, 0, "ApplyNo", DataRowVersion.Default, onlineApproval.ApplyNo),
                new SqlParameter("@ApplyType", SqlDbType.VarChar, 30, ParameterDirection.Input, false, 0, 0, "ApplyType", DataRowVersion.Default, onlineApproval.ApplyType),
                new SqlParameter("@ApplyContent", SqlDbType.VarChar, 600, ParameterDirection.Input, false, 0, 0, "ApplyContent", DataRowVersion.Default, onlineApproval.ApplyContent),
                new SqlParameter("@ApplyUserID", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "ApplyUserID", DataRowVersion.Default, onlineApproval.ApplyUserID),
                //new SqlParameter("@ApplyDate", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "ApplyDate", DataRowVersion.Default, onlineApproval.ApplyDate),
                //new SqlParameter("@ApprovalUserID", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "ApprovalUserID", DataRowVersion.Default, onlineApproval.ApprovalUserID),
                //new SqlParameter("@ApprovalStatus", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "ApprovalStatus", DataRowVersion.Default, onlineApproval.ApprovalStatus),
                //new SqlParameter("@ApprovalStatusName", SqlDbType.VarChar, 30, ParameterDirection.Input, false, 0, 0, "ApprovalStatusName", DataRowVersion.Default, onlineApproval.ApprovalStatusName),
                //new SqlParameter("@ApprovalResult", SqlDbType.VarChar, 30, ParameterDirection.Input, false, 0, 0, "ApprovalResult", DataRowVersion.Default, onlineApproval.ApprovalResult),
                //new SqlParameter("@ApprovalTime", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "ApprovalTime", DataRowVersion.Default, onlineApproval.ApprovalTime)
			};
            DbHelperSQL.ExecuteProcedureNonQuery(sql, parameters, out   mResultType, out   mResultMessage);
		}

        public void Approval(string OnlineApproval_ID, string ApprovalUserID, string ApprovalStatus, string ApprovalResult, out int mResultType, out string mResultMessage)
        {
            string sql = "SP_YWTOnlineApproval_Approval";
            SqlParameter[] parameters = new SqlParameter[]
			{
                new SqlParameter("@OnlineApproval_ID", SqlDbType.BigInt, 8, ParameterDirection.Input, false, 0, 0, "OnlineApproval_ID", DataRowVersion.Default, OnlineApproval_ID),
                new SqlParameter("@ApprovalUserID", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "ApprovalUserID", DataRowVersion.Default, ApprovalUserID),
                new SqlParameter("@ApprovalStatus", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "ApprovalStatus", DataRowVersion.Default, ApprovalStatus),
                new SqlParameter("@ApprovalResult", SqlDbType.VarChar, 30, ParameterDirection.Input, false, 0, 0, "ApprovalResult", DataRowVersion.Default, ApprovalResult)
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

