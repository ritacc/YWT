using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CBSCS.DBUtility;
using System.Data.SqlClient;
using System.Data;
using YWT.Model.User;

namespace YWT.DAL.User
{
    public class YWTUserFileDA
    {
        /// <summary>
        /// 提交身份认证
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="CertifyType"></param>
        /// <param name="CertifyRealName">姓名</param>
        /// <param name="CertifyIDCard">身份证号</param>
        /// <param name="CertifyCompanyName">公司名称</param>
        /// <param name="mResultType"></param>
        /// <param name="mResultMessage"></param>
        public void YWTUserFileCertify(string UserID, string CertifyType, string CertifyRealName, string CertifyIDCard, string CertifyCompanyName            
            , out int mResultType, out string mResultMessage)
        {
            SqlParameter[] parameters = new SqlParameter[]
			{
                new SqlParameter("@UserID", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "UserID", DataRowVersion.Default, UserID),
                new SqlParameter("@CertifyType", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "CertifyType", DataRowVersion.Default, CertifyType),               
                new SqlParameter("@CertifyRealName", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "CertifyRealName", DataRowVersion.Default, CertifyRealName),
                new SqlParameter("@CertifyCompanyName", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "CertifyCompanyName", DataRowVersion.Default, CertifyCompanyName),
                new SqlParameter("@CertifyIDCard", SqlDbType.VarChar, 18, ParameterDirection.Input, false, 0, 0, "CertifyIDCard", DataRowVersion.Default, CertifyIDCard)
			};
            DbHelperSQL.ExecuteProcedureNonQuery("sp_User_File_Certify", parameters, out   mResultType, out   mResultMessage);
        }

        public List<YWTUserFileOR> GetUserFiles(string UserID, out int mResultType, out string mResultMessage)
        {
            SqlParameter[] parameters = new SqlParameter[]
			{
                new SqlParameter("@UserID", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "ID", DataRowVersion.Default, UserID)
			};
            DataSet ds = DbHelperSQL.ExecuteProcedure("SP_YWTUser_File_Search", parameters, out   mResultType, out   mResultMessage);
            if (mResultType == 0)
            {
                if (ds != null && ds.Tables.Count > 0)
                {
                    List<YWTUserFileOR> _list = new List<YWTUserFileOR>();
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        _list.Add(new YWTUserFileOR(row));
                    }
                    return _list;
                }
            }
            return null;
        }
    }
}
