using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YWT.Model.Coordinate;
using System.Data.SqlClient;
using System.Data;
using CBSCS.DBUtility;
using YWT.Model.User;

namespace YWT.DAL.User
{
    public class YWTUserDA
    {
        #region 注册 登录 修改密码
        public YWTUserOR InsertUpdate(YWTUserOR YWTUser, string RecordStatus, out int mResultType, out string mResultMessage)
        {
            SqlParameter[] parameters = new SqlParameter[]
			{
                new SqlParameter("@ID", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "ID", DataRowVersion.Default, YWTUser.ID),
                new SqlParameter("@UserName", SqlDbType.VarChar, 32, ParameterDirection.Input, false, 0, 0, "UserName", DataRowVersion.Default, YWTUser.UserName),
                new SqlParameter("@PassWord", SqlDbType.VarChar, 32, ParameterDirection.Input, false, 0, 0, "PassWord", DataRowVersion.Default, YWTUser.PassWord),
                new SqlParameter("@Mobile", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "Mobile", DataRowVersion.Default, YWTUser.Mobile),
                new SqlParameter("@RealName", SqlDbType.VarChar, 16, ParameterDirection.Input, false, 0, 0, "RealName", DataRowVersion.Default, YWTUser.RealName),
                
                new SqlParameter("@Active", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "Active", DataRowVersion.Default, YWTUser.Active),
                new SqlParameter("@UserType", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "UserType", DataRowVersion.Default, YWTUser.UserType),
                new SqlParameter("@IMEI", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "IMEI", DataRowVersion.Default, YWTUser.IMEI),
                new SqlParameter("@OS", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "OS", DataRowVersion.Default, YWTUser.OS),
                new SqlParameter("@manufacturer", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "manufacturer", DataRowVersion.Default, YWTUser.manufacturer),
                new SqlParameter("@RecordStatus", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "RecordStatus", DataRowVersion.Default, RecordStatus),                
                
                new SqlParameter("@SupplierID", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "SupplierID", DataRowVersion.Default, YWTUser.SupplierID)
			};
            DataSet ds = DbHelperSQL.ExecuteProcedure("sp_YWTUser_Save", parameters, out   mResultType, out   mResultMessage);
            if (mResultType == 0)
            {
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    return new YWTUserOR(ds.Tables[0].Rows[0]);
            }
            return null;
        }

        public YWTUserSupplierNameOR LoginCheck(string UserNameOrMobile, string password, string IMEI, string OS, string Manufacturer, int LoginType, out int mResultType, out string mResultMessage)
        {

            SqlParameter[] parameters = new SqlParameter[]
			{
                new SqlParameter("@UserNameOrMobile", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "UserNameOrMobile", DataRowVersion.Default, UserNameOrMobile),
                new SqlParameter("@password", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "password", DataRowVersion.Default, password),
                new SqlParameter("@IMEI", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "IMEI", DataRowVersion.Default, IMEI),
                new SqlParameter("@OS", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "OS", DataRowVersion.Default, OS),
                new SqlParameter("@Manufacturer", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "Manufacturer", DataRowVersion.Default, Manufacturer),
                new SqlParameter("@LoginType", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "LoginType", DataRowVersion.Default, LoginType) 
			};
            DataSet ds = DbHelperSQL.ExecuteProcedure("SP_YWTUser_Login", parameters, out   mResultType, out   mResultMessage);
            if (mResultType == 0)
            {
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    return new YWTUserSupplierNameOR(ds.Tables[0].Rows[0]);
            }
            return null;
        }

        /// <summary>
        /// 登录验证
        /// </summary>
        public void AlertPwd(string userid, string oldpwd, string newpwd, string pwdType, out int mResultType, out string mResultMessage)
        {

            SqlParameter[] parameters = new SqlParameter[]
			{
                new SqlParameter("@userid", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "userid", DataRowVersion.Default, userid),
                new SqlParameter("@oldpwd", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "oldpwd", DataRowVersion.Default, oldpwd),
                new SqlParameter("@newpwd", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "newpwd", DataRowVersion.Default, newpwd),
                new SqlParameter("@pwdType", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "pwdType", DataRowVersion.Default, pwdType)
			};
            DbHelperSQL.ExecuteProcedureNonQuery("SP_YWTUser_AlertPwd", parameters, out   mResultType, out   mResultMessage);
        }
        #endregion

        

    }
}
