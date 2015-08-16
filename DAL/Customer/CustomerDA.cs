using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CBSCS.DBUtility;
using YWT.Model.Customer;


namespace YWT.DAL.Customer
{
    /// <summary>
    /// 
    /// </summary>
    public class CustomerDA
    {
        
        public List<CustomerOR> SearchList(string Create_User,int StartIndex,int EndIndex, out int mResultType, out string mResultMessage)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Create_User", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "Create_User", DataRowVersion.Default,Create_User),
                new SqlParameter("@StartIndex", SqlDbType.Int,8, ParameterDirection.Input, false, 0, 0, "StartIndex", DataRowVersion.Default, StartIndex),
                new SqlParameter("@EndIndex", SqlDbType.Int,8, ParameterDirection.Input, false, 0, 0, "EndIndex", DataRowVersion.Default, EndIndex),
            };
             
            DataSet ds = DbHelperSQL.ExecuteProcedure("SP_YWTCustomer_Search", parameters, out    mResultType, out   mResultMessage);
            if (ds.Tables.Count == 1)
            {
                List<CustomerOR> _lis = new List<CustomerOR>();
                foreach (DataRow _row in ds.Tables[0].Rows)
                {
                    _lis.Add(new CustomerOR(_row));
                }
                return _lis;
            }
            return null;
        }
        public CustomerOR SearchItem(string   CustomerID, out int mResultType, out string mResultMessage)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@CustomerID", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "CustomerID", DataRowVersion.Default,CustomerID),
            }; 
            DataSet ds = DbHelperSQL.ExecuteProcedure("SP_YWTCustomer_Load", parameters, out    mResultType, out   mResultMessage);
            if (ds.Tables.Count == 1)
            {
                foreach (DataRow _row in ds.Tables[0].Rows)
                {
                    return new CustomerOR(_row);
                }
            }
            return null;
        }
        public void InsertuUpdate(CustomerOR customer, string RecordStatus, out int mResultType, out string mResultMessage)        {
            string sql = "SP_YWTCustomer_Save";
            SqlParameter[] parameters = new SqlParameter[]
			{ 
                 new SqlParameter("@CustomerID", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "CustomerID", DataRowVersion.Default,customer.CustomerID),
                new SqlParameter("@CusShort", SqlDbType.VarChar, 30, ParameterDirection.Input, false, 0, 0, "CusShort", DataRowVersion.Default, customer.CusShort),
                new SqlParameter("@CusFullName", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "CusFullName", DataRowVersion.Default, customer.CusFullName),
                new SqlParameter("@ContactMan", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "ContactMan", DataRowVersion.Default, customer.ContactMan),
                new SqlParameter("@ContactMobile", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "ContactMobile", DataRowVersion.Default, customer.ContactMobile),
                new SqlParameter("@ContactAddress", SqlDbType.VarChar, 200, ParameterDirection.Input, false, 0, 0, "ContactAddress", DataRowVersion.Default, customer.ContactAddress),
                new SqlParameter("@Create_User", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "Create_User", DataRowVersion.Default, customer.Create_User),
                 new SqlParameter("@RecordStatus", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "RecordStatus", DataRowVersion.Default,RecordStatus)

			};
            DbHelperSQL.ExecuteProcedureNonQuery(sql, parameters, out   mResultType, out   mResultMessage);
		}
        public void Delete(string CustomerID,out int mResultType, out string mResultMessage)
        {
            SqlParameter[] parameters = new SqlParameter[]
			{
                new SqlParameter("@CustomerID", CustomerID)
			};
            DbHelperSQL.ExecuteProcedureNonQuery( "SP_YWTCustomer_Delete", parameters, out   mResultType, out   mResultMessage);
		}

    }
}

