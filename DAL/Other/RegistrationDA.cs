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
    public class RegistrationDA
    {
        #region 生成代码
        #region 查询
        public DataTable SelectAllByWhere(string strWhere, int startIndex, int endIndex, out int RecordCount)
        {
            RecordCount = 0;
            string sql = string.Format(@"
SELECT COUNT(1) FROM YWT_Registration WHERE 1=1 {0}
SELECT
    ITEM.*
FROM
(
    SELECT
        YWT_Registration.*
        ,ROW_NUMBER() over(order by  Registration_ID desc) rowid 
    FROM 
        YWT_Registration
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
        public RegistrationOR selectARowDate(string m_id)
        {
            string sql = string.Format("select * from YWT_Registration where  Registration_ID='{0}'",m_id); 
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
            RegistrationOR m_Regi=new RegistrationOR(dr); 
            return m_Regi;

        }
        #endregion
        #region 插入
        /// <summary>
        /// 插入
        /// </summary>
        public virtual bool Insert(RegistrationOR registration)
        {
        string sql = @"insert into YWT_Registration (Registration_ID, UserID, latitude, longitude, Position, IMEI, Create_Date)
values (@Registration_ID, @UserID, @latitude, @longitude, @Position, @IMEI, getdate())";
            SqlParameter [] parameters = new SqlParameter[]
			{
                new SqlParameter("@Registration_ID", SqlDbType.BigInt, 8, ParameterDirection.Input, false, 0, 0, "Registration_ID", DataRowVersion.Default, registration.Registration_ID),
                new SqlParameter("@UserID", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "UserID", DataRowVersion.Default, registration.UserID),
                new SqlParameter("@latitude", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "latitude", DataRowVersion.Default, registration.latitude),
                new SqlParameter("@longitude", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "longitude", DataRowVersion.Default, registration.longitude),
                new SqlParameter("@Position", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "Position", DataRowVersion.Default, registration.Position),
                new SqlParameter("@IMEI", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "IMEI", DataRowVersion.Default, registration.IMEI),

			};
			return DbHelperSQL.ExecuteSql(sql, parameters) > -1;
		}
		#endregion
        #region 更新
        /// <summary>
        /// 更新
        /// </summary>
        public virtual bool Update(RegistrationOR registration)
        {
			string sql = @"update YWT_Registration set UserID=@UserID,latitude=@latitude,longitude=@longitude,Position=@Position,IMEI=@IMEI, where  Registration_ID = @Registration_ID";
            SqlParameter [] parameters = new SqlParameter[]
			{
                new SqlParameter("@Registration_ID", SqlDbType.BigInt, 8, ParameterDirection.Input, false, 0, 0, "Registration_ID", DataRowVersion.Default, registration.Registration_ID),
                new SqlParameter("@UserID", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "UserID", DataRowVersion.Default, registration.UserID),
                new SqlParameter("@latitude", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "latitude", DataRowVersion.Default, registration.latitude),
                new SqlParameter("@longitude", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "longitude", DataRowVersion.Default, registration.longitude),
                new SqlParameter("@Position", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "Position", DataRowVersion.Default, registration.Position),
                new SqlParameter("@IMEI", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "IMEI", DataRowVersion.Default, registration.IMEI),

			};
			return DbHelperSQL.ExecuteSql(sql, parameters) > -1;
		}
		#endregion
        #region 删除
        /// <summary>
        /// 删除
        /// </summary>
        public virtual bool Delete(string strRegistration_ID)
        {
			string sql = @"delete from YWT_Registration where  Registration_ID = @Registration_ID";
			SqlParameter parameter = new SqlParameter("@Registration_ID", strRegistration_ID);
			return DbHelperSQL.ExecuteSql(sql, parameter) > -1;
		}
		#endregion
		#endregion
		 

    }
}

