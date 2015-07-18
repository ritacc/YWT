using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using CBSCS.DBUtility;


namespace YWT.DAL.Pub
{
    public class YWTSetupBLL
    {

        public void Setup(string IMEI, string OS, string Manufacturer, out int mResultType, out string mResultMessage)
        {
            SqlParameter[] parameters = new SqlParameter[]
			{
                new SqlParameter("@OS", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "OS", DataRowVersion.Default,OS ),
                new SqlParameter("@IMEI", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "IMEI", DataRowVersion.Default,IMEI),
                new SqlParameter("@Manufacturer", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "Manufacturer", DataRowVersion.Default, Manufacturer)
			};
            DbHelperSQL.ExecuteProcedureNonQuery("SP_SNRSetup_Save", parameters, out   mResultType, out   mResultMessage);
        }
       
    }
}
