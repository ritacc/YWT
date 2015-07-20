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
                new SqlParameter("@RealNameChar", SqlDbType.VarChar, 1, ParameterDirection.Input, false, 0, 0, "RealNameChar", DataRowVersion.Default, YWTUser.GetRealNameChar),

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

        #region 供应商用户管理
        /// <summary>
        /// 管理供应商用户
        /// </summary>
        /// <param name="_user"></param>
        /// <param name="RecordStatus">用户管理 ADD EDIT</param>
        /// <param name="mResultType"></param>
        /// <param name="mResultMessage"></param>
        /// <returns></returns>
        public bool SuplierAddUser(YWTUserDetailOR _user, string RecordStatus, out int mResultType, out string mResultMessage)
        {
            YWTUserOR YWTUser = _user.User;
            YWTUser.ID = string.IsNullOrEmpty(YWTUser.ID) ? Guid.NewGuid().ToString() : YWTUser.ID;
            SqlParameter[] parameters = new SqlParameter[]
			{
                new SqlParameter("@ID", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "ID", DataRowVersion.Default, YWTUser.ID),
                new SqlParameter("@UserName", SqlDbType.VarChar, 32, ParameterDirection.Input, false, 0, 0, "UserName", DataRowVersion.Default, YWTUser.UserName),
                new SqlParameter("@PassWord", SqlDbType.VarChar, 32, ParameterDirection.Input, false, 0, 0, "PassWord", DataRowVersion.Default, YWTUser.PassWord),
                new SqlParameter("@Mobile", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "Mobile", DataRowVersion.Default, YWTUser.Mobile),
                new SqlParameter("@RealName", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "RealName", DataRowVersion.Default, YWTUser.RealName),
                new SqlParameter("@RealNameChar", SqlDbType.VarChar, 1, ParameterDirection.Input, false, 0, 0, "RealNameChar", DataRowVersion.Default, YWTUser.GetRealNameChar),

                new SqlParameter("@Active", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "Active", DataRowVersion.Default, YWTUser.Active),
                new SqlParameter("@UserType", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "UserType", DataRowVersion.Default, YWTUser.UserType),
               
                new SqlParameter("@RecordStatus", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "RecordStatus", DataRowVersion.Default, RecordStatus),                
                
                new SqlParameter("@SupplierID", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "SupplierID", DataRowVersion.Default, YWTUser.SupplierID)
			};
            List<CommandInfo> _cmds = new List<CommandInfo>();
            _cmds.Add(new CommandInfo("sp_YWTUser_Save_ForSupplier", parameters));

            YWTUserInfoOR userInfo = _user.UserInfo;
            //userInfo.YWTUser_ID = string.IsNullOrEmpty(userInfo.YWTUser_ID) ? Guid.NewGuid().ToString() : userInfo.YWTUser_ID;
            userInfo.YWTUser_ID = YWTUser.ID;
            SqlParameter[] parametersInfo = new SqlParameter[]
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
            _cmds.Add(new CommandInfo("SP_YWTUserInfo_Save_ForSupplier", parametersInfo));

            return DbHelperSQL.ExecuteProcedures(_cmds, out   mResultType, out   mResultMessage) > -1;
        }
        public bool EditSelfInfo(YWTUserInfoOR userInfo, out int mResultType, out string mResultMessage)
        {   
            List<CommandInfo> _cmds = new List<CommandInfo>();
            SqlParameter[] parametersInfo = new SqlParameter[]
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
            _cmds.Add(new CommandInfo("SP_YWTUserInfo_Save_ForSupplier", parametersInfo));

            return DbHelperSQL.ExecuteProcedures(_cmds, out   mResultType, out   mResultMessage) > -1;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="Create_User"></param>
        /// <param name="mResultType"></param>
        /// <param name="mResultMessage"></param>
        /// <returns></returns>
        public YWTUserDetailOR GetADetail(string UserID, string Create_User, out int mResultType, out string mResultMessage)
        {
            SqlParameter[] parameters = new SqlParameter[]
			{
                new SqlParameter("@UserID", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "UserID", DataRowVersion.Default, UserID),
                new SqlParameter("@Create_User", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "Create_User", DataRowVersion.Default, Create_User)
			};
            DataSet ds = DbHelperSQL.ExecuteProcedure("SP_YWTUser_GetADetail", parameters, out   mResultType, out   mResultMessage);
            if (mResultType == 0)
            {
                if (ds != null && ds.Tables.Count == 2)
                {
                    YWTUserOR _User = new YWTUserOR(ds.Tables[0].Rows[0]);
                    YWTUserInfoOR _UserInfo = null;
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        _UserInfo = new YWTUserInfoOR(ds.Tables[1].Rows[0]);// 详细信息
                    }
                    return new YWTUserDetailOR() { User=_User, UserInfo=_UserInfo };
                }
            }
            return null;
        }

        public List<YWTSupplierUserOR> GetSupplierUser(int startNum, int EndNum, string Create_User, out int mResultType, out string mResultMessage)
        {
            SqlParameter[] parameters = new SqlParameter[]
			{
                new SqlParameter("@StartNum", SqlDbType.Int, 8, ParameterDirection.Input, false, 0, 0, "StartNum", DataRowVersion.Default, startNum),
                new SqlParameter("@EndNum", SqlDbType.Int, 8, ParameterDirection.Input, false, 0, 0, "EndNum", DataRowVersion.Default, EndNum),
                //new SqlParameter("@UserID", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "UserID", DataRowVersion.Default, UserID),
                new SqlParameter("@Create_User", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "Create_User", DataRowVersion.Default, Create_User)
			};
            DataSet ds = DbHelperSQL.ExecuteProcedure("SP_YWTUser_GetSupplierUser", parameters, out   mResultType, out   mResultMessage);
            if (mResultType == 0)
            {
                if (ds != null && ds.Tables.Count == 1)
                {
                    List<YWTSupplierUserOR> _list = new List<YWTSupplierUserOR>();
                    foreach (DataRow _row in ds.Tables[0].Rows)
                    {
                        _list.Add(new YWTSupplierUserOR(_row));// 详细信息                         
                    }
                    return _list;
                }
            }
            return null;
        }
        #endregion

        #region 认证
        /// <summary>
        /// 查询认证文件
        /// </summary>
        /// <param name="Create_User"></param>
        /// <param name="CertifyType"></param>
        /// <param name="mResultType"></param>
        /// <param name="mResultMessage"></param>
        /// <returns></returns>
        public List<UserCertifyTypeOR> GetCertifyFile(string Create_User, string CertifyType, out int mResultType, out string mResultMessage)
        {
            SqlParameter[] parameters = new SqlParameter[]
			{
                new SqlParameter("@Create_User", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "Create_User", DataRowVersion.Default, Create_User),
                new SqlParameter("@CertifyType", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "CertifyType", DataRowVersion.Default, CertifyType)
			};

            DataSet ds = DbHelperSQL.ExecuteProcedure("SP_YWTUser_GetCertifyFile", parameters, out   mResultType, out   mResultMessage);
            if (mResultType == 0)
            {
                if (ds != null && ds.Tables.Count == 1)
                {
                    List<UserCertifyTypeOR> _list = new List<UserCertifyTypeOR>();
                    foreach (DataRow _row in ds.Tables[0].Rows)
                    {
                        _list.Add(new UserCertifyTypeOR(_row));// 详细信息                         
                    }
                    return _list;
                }
            }
            return null;
        }

        #endregion
    }
}
