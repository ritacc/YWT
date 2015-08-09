using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CBSCS.DBUtility;
using YWT.Model.Other;
using YWT.Model.Warehouse;


namespace YWT.DAL.Other
{
    /// <summary>
    /// 
    /// </summary>
    public class WarehouseDA
    {
        public List<WarehouseOR> SearchList(string Create_User,long MinID, out int mResultType, out string mResultMessage)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Create_User", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "Create_User", DataRowVersion.Default,Create_User),
                new SqlParameter("@MinID", SqlDbType.BigInt,10, ParameterDirection.Input, false, 0, 0, "MinID", DataRowVersion.Default, MinID),
            };


            DataSet ds = DbHelperSQL.ExecuteProcedure("SP_YWTWarehouse_Search", parameters, out    mResultType, out   mResultMessage);
            if (ds.Tables.Count == 1)
            {
                List<WarehouseOR> _lis = new List<WarehouseOR>();
                foreach (DataRow _row in ds.Tables[0].Rows)
                {
                    _lis.Add(new WarehouseOR(_row));
                }
                return _lis;
            }
            return null;
        }
        //public List<WarehouseOR> SearchList(string Create_User,int StartIndex,int EndIndex, out int mResultType, out string mResultMessage)
        //{
        //    SqlParameter[] parameters = new SqlParameter[]
        //    {
        //        new SqlParameter("@Create_User", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "Create_User", DataRowVersion.Default,Create_User),
        //        new SqlParameter("@StartIndex", SqlDbType.Int,8, ParameterDirection.Input, false, 0, 0, "StartIndex", DataRowVersion.Default, StartIndex),
        //        new SqlParameter("@EndIndex", SqlDbType.Int,8, ParameterDirection.Input, false, 0, 0, "EndIndex", DataRowVersion.Default, EndIndex),
        //    };

        //    DataSet ds = DbHelperSQL.ExecuteProcedure("SP_YWTWarehouse_Search", parameters, out    mResultType, out   mResultMessage);
        //    if (ds.Tables.Count == 1)
        //    {
        //        List<WarehouseOR> _lis = new List<WarehouseOR>();
        //        foreach (DataRow _row in ds.Tables[0].Rows)
        //        {
        //            _lis.Add(new WarehouseOR(_row));
        //        }
        //        return _lis;
        //    }
        //    return null;
        //}
        public WarehouseOR SearchItem(string   Warehouse_ID, out int mResultType, out string mResultMessage)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Warehouse_ID", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "Warehouse_ID", DataRowVersion.Default,Warehouse_ID),
            };


            DataSet ds = DbHelperSQL.ExecuteProcedure("SP_YWTWarehouse_Load", parameters, out    mResultType, out   mResultMessage);
            if (ds.Tables.Count == 1)
            {
                foreach (DataRow _row in ds.Tables[0].Rows)
                {
                    return new WarehouseOR(_row);
                }
            }
            return null;
        }
        public void InsertuUpdate(WarehouseOR warehouse, string RecordStatus, out int mResultType, out string mResultMessage)        
        {
            string sql = "SP_YWTWarehouse_Save";
            SqlParameter[] parameters = new SqlParameter[]
			{
                new SqlParameter("@Warehouse_ID", SqlDbType.BigInt, 8, ParameterDirection.Input, false, 0, 0, "Warehouse_ID", DataRowVersion.Default, warehouse.Warehouse_ID),
                new SqlParameter("@Prodeuct_Img", SqlDbType.VarChar, 200, ParameterDirection.Input, false, 0, 0, "Prodeuct_Img", DataRowVersion.Default, warehouse.Prodeuct_Img),
                new SqlParameter("@Prodeuct_Name", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "Prodeuct_Name", DataRowVersion.Default, warehouse.Prodeuct_Name),
                new SqlParameter("@Product_Brand", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "Product_Brand", DataRowVersion.Default, warehouse.Product_Brand),
                new SqlParameter("@Prodeuct_Model", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "Prodeuct_Model", DataRowVersion.Default, warehouse.Prodeuct_Model),
                new SqlParameter("@Number", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 0, 0, "Number", DataRowVersion.Default, warehouse.Number),
                new SqlParameter("@Unit", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "Unit", DataRowVersion.Default, warehouse.Unit),
                new SqlParameter("@Create_User", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "Create_User", DataRowVersion.Default, warehouse.Create_User),
                new SqlParameter("@RecordStatus", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "RecordStatus", DataRowVersion.Default,RecordStatus)

			};
            DbHelperSQL.ExecuteProcedureNonQuery(sql, parameters, out   mResultType, out   mResultMessage);
		}
        public void Delete(string Warehouse_ID,out int mResultType, out string mResultMessage)
        {
            SqlParameter[] parameters = new SqlParameter[]
			{
                new SqlParameter("@Warehouse_ID", Warehouse_ID)
			};
            DbHelperSQL.ExecuteProcedureNonQuery( "SP_YWTWarehouse_Delete", parameters, out   mResultType, out   mResultMessage);
		}

    }
}

