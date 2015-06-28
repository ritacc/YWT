using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CBSCS.DBUtility;
using YWT.Model.User;


namespace YWT.DAL.User
{
    /// <summary>
    /// 
    /// </summary>
    public class YWTUserInfoDA
    {
        
        #region 查询
       
        public YWTUserInfoOR SelectARowDate(string m_id)
        {
            string sql = string.Format("select * from YWT_User_Info where  YWTUser_ID='{0}'",m_id); 
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
            YWTUserInfoOR m_User=new YWTUserInfoOR(dr); 
            return m_User;
        }
        #endregion
        #region 插入
        /// <summary>
        /// 插入
        /// </summary>
        public void InsertUpdate(YWTUserInfoOR userInfo, out int mResultType, out string mResultMessage)
        {
            string sql = @"SP_YWTUserInfo_Save";
            SqlParameter [] parameters = new SqlParameter[]
			{
                new SqlParameter("@YWTUser_ID", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "YWTUser_ID", DataRowVersion.Default, userInfo.YWTUser_ID),
                new SqlParameter("@RealName", SqlDbType.VarChar, 30, ParameterDirection.Input, false, 0, 0, "RealName", DataRowVersion.Default, userInfo.RealName),
                new SqlParameter("@User_Sex", SqlDbType.VarChar, 2, ParameterDirection.Input, false, 0, 0, "User_Sex", DataRowVersion.Default, userInfo.User_Sex),
                new SqlParameter("@Location_Province", SqlDbType.VarChar, 30, ParameterDirection.Input, false, 0, 0, "Location_Province", DataRowVersion.Default, userInfo.Location_Province),
                new SqlParameter("@Location_City", SqlDbType.VarChar, 30, ParameterDirection.Input, false, 0, 0, "Location_City", DataRowVersion.Default, userInfo.Location_City),
                new SqlParameter("@Location_County", SqlDbType.VarChar, 30, ParameterDirection.Input, false, 0, 0, "Location_County", DataRowVersion.Default, userInfo.Location_County),
                new SqlParameter("@Birthday", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "Birthday", DataRowVersion.Default, userInfo.Birthday),
                new SqlParameter("@User_Address", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 0, 0, "User_Address", DataRowVersion.Default, userInfo.User_Address),
                new SqlParameter("@Email", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "Email", DataRowVersion.Default, userInfo.Email),
                new SqlParameter("@HighestEducation", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "HighestEducation", DataRowVersion.Default, userInfo.HighestEducation),
                new SqlParameter("@Finish_School", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "Finish_School", DataRowVersion.Default, userInfo.Finish_School),
                new SqlParameter("@SpecialtyName", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "SpecialtyName", DataRowVersion.Default, userInfo.SpecialtyName),
                new SqlParameter("@GraduationData", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "GraduationData", DataRowVersion.Default, userInfo.GraduationData),
                new SqlParameter("@SkillDescription", SqlDbType.NVarChar, 1000, ParameterDirection.Input, false, 0, 0, "SkillDescription", DataRowVersion.Default, userInfo.SkillDescription),
                new SqlParameter("@Specialty", SqlDbType.NVarChar, 1000, ParameterDirection.Input, false, 0, 0, "Specialty", DataRowVersion.Default, userInfo.Specialty),
                
                new SqlParameter("@Create_User", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "Create_User", DataRowVersion.Default, userInfo.Create_User)
			};
            DbHelperSQL.ExecuteProcedureNonQuery(sql, parameters, out   mResultType, out   mResultMessage);
		}
		#endregion
        
        
		 
	 
    }
}

