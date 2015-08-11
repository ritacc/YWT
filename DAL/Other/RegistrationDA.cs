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
    public class RegistrationDA
    {
        public List<RegistrationOR> SearchList(string Create_User,long MinID, out int mResultType, out string mResultMessage)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Create_User", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "Create_User", DataRowVersion.Default,Create_User),
                new SqlParameter("@MinID", SqlDbType.BigInt,10, ParameterDirection.Input, false, 0, 0, "MinID", DataRowVersion.Default, MinID),
            };
            DataSet ds = DbHelperSQL.ExecuteProcedure("SP_YWTRegistration_Search", parameters, out    mResultType, out   mResultMessage);
            if (ds.Tables.Count == 1)
            {
                List<RegistrationOR> _lis = new List<RegistrationOR>();
                foreach (DataRow _row in ds.Tables[0].Rows)
                {
                    _lis.Add(new RegistrationOR(_row));
                }
                return _lis;
            }
            return null;
        }

        public List<RegistrationForCommpanyOR> SearchCompanyList(string Create_User, string UserID, DateTime StartTime, DateTime EndTime
            , string MinID, out int mResultType, out string mResultMessage)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Create_User", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "Create_User", DataRowVersion.Default,Create_User),
                new SqlParameter("@UserID", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "UserID", DataRowVersion.Default,UserID),
                new SqlParameter("@StartTime", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "StartTime", DataRowVersion.Default,StartTime),
                new SqlParameter("@EndTime", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "EndTime", DataRowVersion.Default,EndTime),
                new SqlParameter("@MinID", SqlDbType.BigInt,10, ParameterDirection.Input, false, 0, 0, "MinID", DataRowVersion.Default, MinID)
            };
            DataSet ds = DbHelperSQL.ExecuteProcedure("SP_YWTRegistration_SearchForComapny", parameters, out    mResultType, out   mResultMessage);
            if (ds.Tables.Count == 1)
            {
                List<RegistrationForCommpanyOR> _lis = new List<RegistrationForCommpanyOR>();
                foreach (DataRow _row in ds.Tables[0].Rows)
                {
                    _lis.Add(new RegistrationForCommpanyOR(_row));
                }
                return _lis;
            }
            return null;
        }
        

        //public RegistrationOR SearchItem(string Registration_ID, out int mResultType, out string mResultMessage)
        //{
        //    SqlParameter[] parameters = new SqlParameter[]
        //    {
        //        new SqlParameter("@Registration_ID", SqlDbType.BigInt, 36, ParameterDirection.Input, false, 0, 0, "Registration_ID", DataRowVersion.Default,Registration_ID),
        //    }; 
        //    DataSet ds = DbHelperSQL.ExecuteProcedure("SP_YWTRegistration_Load", parameters, out    mResultType, out   mResultMessage);
        //    if (ds.Tables.Count == 1)
        //    {
        //        foreach (DataRow _row in ds.Tables[0].Rows)
        //        {
        //            return new RegistrationOR(_row);
        //        }
        //    }
        //    return null;
        //}
        public void InsertuUpdate(RegistrationOR registration, string RecordStatus, out int mResultType, out string mResultMessage)        
        {
            string sql = "SP_YWTRegistration_Save";
            SqlParameter[] parameters = new SqlParameter[]
			{
                new SqlParameter("@Registration_ID", SqlDbType.BigInt, 8, ParameterDirection.Input, false, 0, 0, "Registration_ID", DataRowVersion.Default, registration.Registration_ID),
                new SqlParameter("@UserID", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "UserID", DataRowVersion.Default, registration.UserID),
                new SqlParameter("@latitude", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "latitude", DataRowVersion.Default, registration.latitude),
                new SqlParameter("@longitude", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "longitude", DataRowVersion.Default, registration.longitude),
                new SqlParameter("@Position", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "Position", DataRowVersion.Default, registration.Position),
                new SqlParameter("@IMEI", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "IMEI", DataRowVersion.Default, registration.IMEI),
               // new SqlParameter("@RecordStatus", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "RecordStatus", DataRowVersion.Default,RecordStatus)

			};
            DbHelperSQL.ExecuteProcedureNonQuery(sql, parameters, out   mResultType, out   mResultMessage);
		}
        //public void Delete(string Registration_ID,out int mResultType, out string mResultMessage)
        //{
        //    SqlParameter[] parameters = new SqlParameter[]
        //    {
        //        new SqlParameter("@Registration_ID", Registration_ID)
        //    };
        //    DbHelperSQL.ExecuteProcedureNonQuery( "SP_YWTRegistration_Delete", parameters, out   mResultType, out   mResultMessage);
        //}
    }
}

