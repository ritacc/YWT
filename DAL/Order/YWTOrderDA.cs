using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CBSCS.DBUtility;
using YWT.Model.Order;


namespace YWT.DAL.Order
{
    /// <summary>
    /// 
    /// </summary>
    public class YWTOrderDA
    {


        /// <summary>
        /// 插入
        /// </summary>
        public void Insert(YWTOrderAdminOR orderAdmin, out int mResultType, out string mResultMessage)
        {
            string sqlOrdermain = @"sp_SNROrder_Save";
            YWTOrderOR order = orderAdmin.OrderMain;
            SqlParameter[] parameters = new SqlParameter[]
			{
                new SqlParameter("@Order_ID", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "Order_ID", DataRowVersion.Default, order.Order_ID),                
                new SqlParameter("@OrderTitle", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 0, 0, "OrderTitle", DataRowVersion.Default, order.OrderTitle),
                new SqlParameter("@OrderType", SqlDbType.VarChar, 30, ParameterDirection.Input, false, 0, 0, "OrderType", DataRowVersion.Default, order.OrderType),
                new SqlParameter("@OrderTask", SqlDbType.NVarChar, 1000, ParameterDirection.Input, false, 0, 0, "OrderTask", DataRowVersion.Default, order.OrderTask),
                new SqlParameter("@TaskTimeLen", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 0, 0, "TaskTimeLen", DataRowVersion.Default, order.TaskTimeLen),
                
                new SqlParameter("@Task_Province", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "Task_Province", DataRowVersion.Default, order.Task_Province),
                new SqlParameter("@Task_City", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "Task_City", DataRowVersion.Default, order.Task_City),
                new SqlParameter("@Task_County", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "Task_County", DataRowVersion.Default, order.Task_County),
                new SqlParameter("@Task_Town", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "Task_Town", DataRowVersion.Default, order.Task_Town),
                new SqlParameter("@Task_Address", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "Task_Address", DataRowVersion.Default, order.Task_Address),
                
                //new SqlParameter("@Status", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "Status", DataRowVersion.Default, order.Status),
                new SqlParameter("@Remark", SqlDbType.NVarChar, 400, ParameterDirection.Input, false, 0, 0, "Remark", DataRowVersion.Default, order.Remark),
                //new SqlParameter("@SupplierID", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "SupplierID", DataRowVersion.Default, order.SupplierID),
                new SqlParameter("@Creator", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "Creator", DataRowVersion.Default, order.Creator),
                //new SqlParameter("@CreateDateTime", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "CreateDateTime", DataRowVersion.Default, order.CreateDateTime),
                new SqlParameter("@CustomerShort", SqlDbType.VarChar, 30, ParameterDirection.Input, false, 0, 0, "CustomerShort", DataRowVersion.Default, order.CustomerShort),
                new SqlParameter("@ContactMan", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "ContactMan", DataRowVersion.Default, order.ContactMan),
                new SqlParameter("@ContactMobile", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "ContactMobile", DataRowVersion.Default, order.ContactMobile),
                new SqlParameter("@IsPublishToPlat", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "IsPublishToPlat", DataRowVersion.Default, order.IsPublishToPlat),
                
                new SqlParameter("@Freight", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 0, 0, "Freight", DataRowVersion.Default, order.Freight),
                new SqlParameter("@PersonNum", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "PersonNum", DataRowVersion.Default, order.PersonNum),
                new SqlParameter("@AbilityRequest", SqlDbType.NVarChar, 400, ParameterDirection.Input, false, 0, 0, "AbilityRequest", DataRowVersion.Default, order.AbilityRequest),

                new SqlParameter("@RecordStatus", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "RecordStatus", DataRowVersion.Default, "ADD")
			};
            List<CommandInfo> _cmds = new List<CommandInfo>();
            _cmds.Add(new CommandInfo(sqlOrdermain, parameters));
            if (orderAdmin.OrderFile != null)
            {
                List<OrderFileOR> OrderFile = orderAdmin.OrderFile;
                foreach (OrderFileOR sNROrderFile in OrderFile)
                {
                    string sqlOrderFile = @"SP_YWTOrder_File_Save";
                    SqlParameter[] parametersOrderFile = new SqlParameter[]
                    {
                        new SqlParameter("@ID", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "ID", DataRowVersion.Default,string.IsNullOrEmpty( sNROrderFile.Order_File_ID)? Guid.NewGuid().ToString(): sNROrderFile.Order_File_ID),
                        new SqlParameter("@OrderID", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "OrderID", DataRowVersion.Default, order.Order_ID),
                        new SqlParameter("@FileType", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "FileType", DataRowVersion.Default, sNROrderFile.FileType),
                        new SqlParameter("@FileName", SqlDbType.VarChar, 200, ParameterDirection.Input, false, 0, 0, "FileName", DataRowVersion.Default, sNROrderFile.FileName),
                        new SqlParameter("@Creator", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "Creator", DataRowVersion.Default, sNROrderFile.Creator)
                    };
                    _cmds.Add(new CommandInfo(sqlOrderFile, parametersOrderFile));
                }
            }
            DbHelperSQL.ExecuteProcedures(_cmds, out   mResultType, out   mResultMessage);
        }

        /// <summary>
        /// 查询运维单
        /// </summary>
        /// <param name="StatusType"></param>
        /// <param name="Create_User"></param>
        /// <param name="StartIndex"></param>
        /// <param name="endIndex"></param>
        /// <param name="mResultType"></param>
        /// <param name="mResultMessage"></param>
        /// <returns></returns>
        public List<YWTOrderForListOR> GetOrderList(string StatusType, string Create_User, int StartIndex, int endIndex, out  int mResultType, out string mResultMessage)
        {
            SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@StatusType", SqlDbType.Int, 8, ParameterDirection.Input, false, 0, 0, "StatusType", DataRowVersion.Default, StatusType),
                    new SqlParameter("@Create_User", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "Create_User", DataRowVersion.Default,Create_User),
                    new SqlParameter("@StartIndex", SqlDbType.Int,8, ParameterDirection.Input, false, 0, 0, "StartIndex", DataRowVersion.Default, StartIndex),
                    new SqlParameter("@EndIndex", SqlDbType.Int, 8, ParameterDirection.Input, false, 0, 0, "EndIndex", DataRowVersion.Default, endIndex)
                };

            DataSet ds = DbHelperSQL.ExecuteProcedure("SP_YWTOrder_Search", parameters, out    mResultType, out   mResultMessage);
            if (ds.Tables.Count == 1)
            {
                List<YWTOrderForListOR> _lis = new List<YWTOrderForListOR>();
                foreach (DataRow _row in ds.Tables[0].Rows)
                {
                    _lis.Add(new YWTOrderForListOR(_row));
                }
                return _lis;
            }
            return null;

        }

        /// <summary>
        /// 查询一个运维单详细
        /// </summary>
        /// <param name="Order_ID"></param>
        /// <param name="Create_User"></param>
        /// <param name="mResultType"></param>
        /// <param name="mResultMessage"></param>
        /// <returns></returns>
        public YWTOrderDetaillOR GetOrderItem(string Order_ID, string Create_User, out  int mResultType, out string mResultMessage)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@StatusType", SqlDbType.Int, 8, ParameterDirection.Input, false, 0, 0, "StatusType", DataRowVersion.Default, 100),
                new SqlParameter("@Order_ID", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "Order_ID", DataRowVersion.Default,Order_ID),
                new SqlParameter("@Create_User", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "Create_User", DataRowVersion.Default,Create_User)
            };

            DataSet ds = DbHelperSQL.ExecuteProcedure("SP_YWTOrder_Search", parameters, out    mResultType, out   mResultMessage);
            if (ds.Tables.Count == 3 && ds.Tables[0].Rows.Count > 0)
            {
                //主表信息
                YWTOrderDetaillOR _OrderDetaill = new YWTOrderDetaillOR(ds.Tables[0].Rows[0]);
                //分配人员
                List<OrderTaskUserOR> _lisUser = new List<OrderTaskUserOR>();
                foreach (DataRow _row in ds.Tables[1].Rows)
                {
                    _lisUser.Add(new OrderTaskUserOR(_row));
                }
                //流程
                List<OrderFlowOR> _lisFlow = new List<OrderFlowOR>();
                foreach (DataRow _row in ds.Tables[2].Rows)
                {
                    _lisFlow.Add(new OrderFlowOR(_row));
                }
                return _OrderDetaill;
            }
            return null;
        }


    }
}

