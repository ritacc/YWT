using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using YWT.Model.User;
using System.Data.SqlClient;
using CBSCS.DBUtility;

namespace YWT.DAL.User
{
    public class YWTSupplierDA
    {
        #region 生成代码
        #region 查询
       
        public YWTSupplierOR selectARowDate(string m_id)
        {
            string sql = string.Format("select * from YWT_Supplier where  ID='{0}'", m_id);
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
            YWTSupplierOR m_YWTS = new YWTSupplierOR(dr);
            return m_YWTS;

        }

        #endregion
        
        /// <summary>
        /// 插入
        /// </summary>
        public virtual void InsertUpdate(YWTSupplierOR YWTSupplier, string UserID, out int mResultType, out string mResultMessage)
        {
            SqlParameter[] parameters = new SqlParameter[]
			{
                new SqlParameter("@ID", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "ID", DataRowVersion.Default,string.IsNullOrEmpty( YWTSupplier.ID) ? Guid.NewGuid().ToString() :  YWTSupplier.ID.ToString()),
                new SqlParameter("@Company", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "Company", DataRowVersion.Default, YWTSupplier.Company),
                new SqlParameter("@ContactMan", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "ContactMan", DataRowVersion.Default, YWTSupplier.ContactMan),
                new SqlParameter("@Address", SqlDbType.NVarChar, 160, ParameterDirection.Input, false, 0, 0, "Address", DataRowVersion.Default, YWTSupplier.Address),
                new SqlParameter("@Tel", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "Tel", DataRowVersion.Default, YWTSupplier.Tel),
                new SqlParameter("@Mobile", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "Mobile", DataRowVersion.Default, YWTSupplier.Mobile),
                new SqlParameter("@Fax", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "Fax", DataRowVersion.Default, YWTSupplier.Fax),
                new SqlParameter("@Email", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "Email", DataRowVersion.Default, YWTSupplier.Email),
                new SqlParameter("@UserID", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "UserID", DataRowVersion.Default, UserID),
			};
            DbHelperSQL.ExecuteProcedureNonQuery("SP_YWTSupplier_Save", parameters, out   mResultType, out   mResultMessage);
        }
       

      
        #endregion

       
    }
}
