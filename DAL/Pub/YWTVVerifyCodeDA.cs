using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using CBSCS.DBUtility;

namespace YWT.DAL.Pub
{
  public  class YWTVVerifyCodeDA
    {
        /// <summary>
        /// 保存验证码
        /// </summary>
        public void VerifyCode_Save(string Phone, string IMEI, string VerifyCode, out int mResultType, out string mResultMessage)
        {
            SqlParameter[] parameters = new SqlParameter[]
			{
                new SqlParameter("@Phone", SqlDbType.VarChar, 15, ParameterDirection.Input, false, 0, 0, "Phone", DataRowVersion.Default, Phone),
                new SqlParameter("@IMEI", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "IMEI", DataRowVersion.Default,IMEI),
                new SqlParameter("@VerifyCode", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "VerifyCode", DataRowVersion.Default, VerifyCode)
			};
            DbHelperSQL.ExecuteProcedureNonQuery("sp_YWTVerifyCode_Save", parameters, out   mResultType, out   mResultMessage);
        }

        public void VerifyCode_Check(string Phone, string IMEI, string VerifyCode, out int mResultType, out string mResultMessage)
        {
            SqlParameter[] parameters = new SqlParameter[]
			{
                new SqlParameter("@Phone", SqlDbType.VarChar, 15, ParameterDirection.Input, false, 0, 0, "Phone", DataRowVersion.Default, Phone),
                new SqlParameter("@IMEI", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "IMEI", DataRowVersion.Default,IMEI),
                new SqlParameter("@VerifyCode", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "VerifyCode", DataRowVersion.Default, VerifyCode)
			};
            DbHelperSQL.ExecuteProcedureNonQuery("sp_YWTVerifyCode_Check", parameters, out   mResultType, out   mResultMessage);
        }
    }
}
