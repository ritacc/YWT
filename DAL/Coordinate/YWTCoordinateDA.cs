﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YWT.Model.Coordinate;
using System.Data.SqlClient;
using System.Data;
using CBSCS.DBUtility;
using YWT.Model.User;

namespace YWT.DAL.Coordinate
{
    public class YWTCoordinateDA
    {

        
        /// <summary>
        /// 插入
        /// </summary>
        public void Insert(YWTCoordinateOR sNRCoordinate, out int mResultType, out string mResultMessage)
        {
            //            string sql = @"insert into SNR_Coordinate (ID, longitude, latitude, CreateDateTime, CarID, UserID, IMEI, OS, manufacturer, gaodeLongitude, gaodeLatitude)
            //values (NEWID(), @longitude, @latitude, GETDATE(), @CarID, @UserID, @IMEI, @OS, @manufacturer, @gaodeLongitude, @gaodeLatitude)";
            SqlParameter[] parameters = new SqlParameter[]
			{
                //new SqlParameter("@ID", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "ID", DataRowVersion.Default, sNRCoordinate.ID),
                new SqlParameter("@longitude", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "longitude", DataRowVersion.Default, sNRCoordinate.longitude),
                new SqlParameter("@latitude", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "latitude", DataRowVersion.Default, sNRCoordinate.latitude),
                new SqlParameter("@CarID", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "CarID", DataRowVersion.Default, sNRCoordinate.CarID),
                new SqlParameter("@UserID", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "UserID", DataRowVersion.Default, sNRCoordinate.UserID),
                new SqlParameter("@IMEI", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "IMEI", DataRowVersion.Default, sNRCoordinate.IMEI),
                new SqlParameter("@OS", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "OS", DataRowVersion.Default, sNRCoordinate.OS),
                new SqlParameter("@manufacturer", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "manufacturer", DataRowVersion.Default, sNRCoordinate.manufacturer),
                //new SqlParameter("@gaodeLongitude", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "gaodeLongitude", DataRowVersion.Default, sNRCoordinate.gaodeLongitude),
                //new SqlParameter("@gaodeLatitude", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "gaodeLatitude", DataRowVersion.Default, sNRCoordinate.gaodeLatitude)
			};
            DbHelperSQL.ExecuteProcedureNonQuery("SP_YWTCoordinate_Save", parameters, out   mResultType, out   mResultMessage);
            //
        }

        /// <summary>
        /// 查询运维商下面所有运维人员
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="mResultType"></param>
        /// <param name="mResultMessage"></param>
        /// <returns></returns>
        public List<YWTUserPostionInfoOR> GetSupplierAllUserPostionInfo(string UserID, out int mResultType, out string mResultMessage)
        {
            SqlParameter[] parameters = new SqlParameter[]
			{
                new SqlParameter("@UserID", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "UserID", DataRowVersion.Default, UserID),
                new SqlParameter("@SearchType", SqlDbType.Int, 8, ParameterDirection.Input, false, 0, 0, "SearchType", DataRowVersion.Default, 1)
			};
            DataSet ds = DbHelperSQL.ExecuteProcedure("sp_YWTUser_GetPostionInfo", parameters, out   mResultType, out   mResultMessage);
            if (mResultType == 0)
            {
                List<YWTUserPostionInfoOR> _lis = new List<YWTUserPostionInfoOR>();

                if (ds != null)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        _lis.Add(new YWTUserPostionInfoOR(row));
                    }
                }
                return _lis;
            }
            return null;
        }

    }
}
