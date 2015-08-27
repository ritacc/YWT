using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CBSCS.DBUtility;
using YWT.Model.Order;
using YWT.Model.Order.View;


namespace YWT.DAL.Order
{
    /// <summary>
    /// 
    /// </summary>
    public class YWTOrderDA
    {

        #region 基础操作
        /// <summary>
        /// 插入
        /// </summary>
        public void Insert(YWTOrderAdminOR orderAdmin, out int mResultType, out string mResultMessage)
        {
            string sqlOrdermain = @"sp_YWTOrder_Save";
            YWTOrderOR order = orderAdmin.OrderMain;
            if (string.IsNullOrEmpty(order.Order_ID))
            {
                order.Order_ID = Guid.NewGuid().ToString();
            }
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
                new SqlParameter("@Creator", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "Creator", DataRowVersion.Default, order.Creator),
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
                foreach (OrderFileOR _OrderFile in OrderFile)
                {
                    if (!string.IsNullOrEmpty(_OrderFile.FileName) && _OrderFile.FileName.Length > 40)
                    {
                        string sqlOrderFile = @"SP_YWTOrder_File_Save";
                        SqlParameter[] parametersOrderFile = new SqlParameter[]
                        {
                            new SqlParameter("@Order_ID", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "Order_ID", DataRowVersion.Default, order.Order_ID),
                            new SqlParameter("@OrderFileType", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "OrderFileType", DataRowVersion.Default, _OrderFile.FileType),
                            new SqlParameter("@ImagePath", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "ImagePath", DataRowVersion.Default, _OrderFile.FileName),
                            new SqlParameter("@FileIcon", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "FileIcon", DataRowVersion.Default, _OrderFile.FileIcon),
                            new SqlParameter("@Creator", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "Creator", DataRowVersion.Default, order.Creator)
                        };
                        _cmds.Add(new CommandInfo(sqlOrderFile, parametersOrderFile));
                    }
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
        public YWTOrderDetaill_FroItemOR GetOrderItem(string Order_ID, string Create_User, out  int mResultType, out string mResultMessage)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@StatusType", SqlDbType.Int, 8, ParameterDirection.Input, false, 0, 0, "StatusType", DataRowVersion.Default, 100),
                new SqlParameter("@Order_ID", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "Order_ID", DataRowVersion.Default,Order_ID),
                new SqlParameter("@Create_User", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "Create_User", DataRowVersion.Default,Create_User)
            };

            DataSet ds = DbHelperSQL.ExecuteProcedure("SP_YWTOrder_Search", parameters, out    mResultType, out   mResultMessage);
            if (ds.Tables.Count == 4 && ds.Tables[0].Rows.Count > 0)
            {
                //主表信息
                YWTOrderDetaill_FroItemOR _OrderDetaill = new YWTOrderDetaill_FroItemOR(ds.Tables[0].Rows[0]);
                //分配人员
                List<OrderTaskUserSimpleOR> _lisUser = new List<OrderTaskUserSimpleOR>();
                foreach (DataRow _row in ds.Tables[1].Rows)
                {
                    _lisUser.Add(new OrderTaskUserSimpleOR(_row));
                }
                _OrderDetaill.OrderUsers = _lisUser;
                //流程
                List<OrderFlowSimpleOR> _lisFlow = new List<OrderFlowSimpleOR>();
                foreach (DataRow _row in ds.Tables[2].Rows)
                {
                    _lisFlow.Add(new OrderFlowSimpleOR(_row));
                }
                _OrderDetaill.OrderFlows = _lisFlow;
                //文件
                List<OrderFileSimpleOR> _listFile = new List<OrderFileSimpleOR>();
                foreach (DataRow _row in ds.Tables[3].Rows)
                {
                    _listFile.Add(new OrderFileSimpleOR(_row));
                }
                _OrderDetaill.OrderFiles = _listFile;
                _OrderDetaill.SetNexStatus();
                return _OrderDetaill;
            }
            return null;
        }
        #endregion

        #region 流程操作 
        /// <summary>
        /// 指派运维人员
        /// </summary>
        /// <param name="_lsitOrder"></param>
        /// <param name="Order_ID"></param>
        /// <param name="Create_User"></param>
        /// <param name="mResultType"></param>
        /// <param name="mResultMessage"></param>
        public void DesignateUser(List<OrderTaskUserOR> _lsitOrder, string Order_ID, string Create_User, out  int mResultType, out string mResultMessage)
        {
            string sqlOrdermain = @"sp_YWTOrder_TaskUser_Save";
            List<CommandInfo> _cmds = new List<CommandInfo>();
            foreach (OrderTaskUserOR _item in _lsitOrder)
            {  
                SqlParameter[] parameters = new SqlParameter[]
			    {
                    new SqlParameter("@Order_ID", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "Order_ID", DataRowVersion.Default, Order_ID),
                    new SqlParameter("@UserID", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "UserID", DataRowVersion.Default, _item.UserID),
                    new SqlParameter("@Create_User", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "Create_User", DataRowVersion.Default, Create_User)
			    };               
                _cmds.Add(new CommandInfo(sqlOrdermain, parameters));
            }
            //保存流程状态
            SqlParameter[] parametersFlow = new SqlParameter[]
			{
                new SqlParameter("@Order_ID", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "Order_ID", DataRowVersion.Default, Order_ID),
                new SqlParameter("@Order_Status", SqlDbType.Int, 30, ParameterDirection.Input, false, 0, 0, "Order_Status", DataRowVersion.Default, 20),
                new SqlParameter("@Create_User", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "Create_User", DataRowVersion.Default,Create_User),
                new SqlParameter("@Longitude", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "Longitude", DataRowVersion.Default,""),
                new SqlParameter("@Latitude", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "Latitude", DataRowVersion.Default,""),
                new SqlParameter("@LocationCity", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "LocationCity", DataRowVersion.Default,""),
                new SqlParameter("@FlowRemark", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "FlowRemark", DataRowVersion.Default,"")
                
			};
            _cmds.Add(new CommandInfo("SP_YWTOrder_Flow_Save", parametersFlow));            
            DbHelperSQL.ExecuteProcedures(_cmds, out   mResultType, out   mResultMessage);
        }

        /// <summary>
        /// 保存订单流程
        /// </summary>
        /// <param name="Order_ID"></param>
        /// <param name="Order_Status"></param>
        /// <param name="Create_User"></param>
        /// <param name="Longitude"></param>
        /// <param name="Latitude"></param>
        /// <param name="LocationCity"></param>
        /// <param name="remark"></param>
        /// <param name="mResultType"></param>
        /// <param name="mResultMessage"></param>
        public void UpdateOrderFlow(string Order_ID, string Order_Status, string Create_User
           , List<OrderFileOR> _lsitFiles, string Longitude, string Latitude, string LocationCity, string remark, out int mResultType, out string mResultMessage)
        {
           
            List<CommandInfo> _cmds = new List<CommandInfo>();
            //并以上传多张图片
            if (_lsitFiles != null && _lsitFiles.Count > 0)
            {                 
                foreach (var item in _lsitFiles)
                {
                    if (!string.IsNullOrEmpty(item.FileName) && item.FileName.Length > 40)
                    {
                        SqlParameter[] parameterFiles = new SqlParameter[]
			            {
                            new SqlParameter("@Order_ID", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "Order_ID", DataRowVersion.Default, Order_ID),
                            new SqlParameter("@OrderFileType", SqlDbType.Int, 50, ParameterDirection.Input, false, 0, 0, "OrderFileType", DataRowVersion.Default, Order_Status),
                            new SqlParameter("@ImagePath", SqlDbType.VarChar, 200, ParameterDirection.Input, false, 0, 0, "ImagePath", DataRowVersion.Default,item.FileName),
                            new SqlParameter("@FileIcon", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "FileIcon", DataRowVersion.Default, item.FileIcon),
                            new SqlParameter("@Creator", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "Creator", DataRowVersion.Default,Create_User)
			            };
                        _cmds.Add(new CommandInfo() { CommandText = "SP_YWTOrder_File_Save", Parameters = parameterFiles });
                    }
                }
            }
           
            SqlParameter[] _parameters = new SqlParameter[]
			{
                new SqlParameter("@Order_ID", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "Order_ID", DataRowVersion.Default, Order_ID),
                new SqlParameter("@Order_Status", SqlDbType.Int, 30, ParameterDirection.Input, false, 0, 0, "Order_Status", DataRowVersion.Default, Order_Status),
                new SqlParameter("@Create_User", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "Create_User", DataRowVersion.Default,Create_User),
                new SqlParameter("@Longitude", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "Longitude", DataRowVersion.Default,Longitude),
                new SqlParameter("@Latitude", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "Latitude", DataRowVersion.Default,Latitude),
                new SqlParameter("@LocationCity", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "LocationCity", DataRowVersion.Default,LocationCity),
                new SqlParameter("@FlowRemark", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "FlowRemark", DataRowVersion.Default,remark)
                
			};
            _cmds.Add(new CommandInfo() { CommandText = "SP_YWTOrder_Flow_Save", Parameters = _parameters });
            DbHelperSQL.ExecuteProcedures(_cmds, out   mResultType, out   mResultMessage);
        }

        /// <summary>
        /// 评价运维单
        /// </summary>
        /// <param name="orderAssess"></param>
        /// <param name="mResultType"></param>
        /// <param name="mResultMessage"></param>
        public void OrderAssess(OrderAssessOR orderAssess, out int mResultType, out string mResultMessage)
        {
            string sql = @"SP_YWTOrder_Assess_Save";
            SqlParameter[] parameters = new SqlParameter[]
			{   
                new SqlParameter("@Order_ID", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "Order_ID", DataRowVersion.Default, orderAssess.Order_ID),
                new SqlParameter("@YW_Result", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "YW_Result", DataRowVersion.Default, orderAssess.YW_Result),
                new SqlParameter("@Score", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "Score", DataRowVersion.Default, orderAssess.Score),
                new SqlParameter("@AssessContent", SqlDbType.NVarChar, 1000, ParameterDirection.Input, false, 0, 0, "AssessContent", DataRowVersion.Default, orderAssess.AssessContent),                
               // new SqlParameter("@IsAddIntegral", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "IsAddIntegral", DataRowVersion.Default, orderAssess.IsAddIntegral),
                new SqlParameter("@Creator", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "Creator", DataRowVersion.Default, orderAssess.Creator)
			};
            DbHelperSQL.ExecuteProcedure(sql, parameters, out   mResultType, out   mResultMessage);
        }
        #endregion

        #region 统计

        public MonthViewAadminResultOR MonthViewAadmin(string UserID, string mType, out  int mResultType, out string mResultMessage)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@UserID", SqlDbType.Int, 8, ParameterDirection.Input, false, 0, 0, "UserID", DataRowVersion.Default, UserID),
                new SqlParameter("@Type", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "Type", DataRowVersion.Default,mType)
            };

            DataSet ds = DbHelperSQL.ExecuteProcedure("SP_YWTOrder_IntegralScore_MonthViewAadmin", parameters, out    mResultType, out   mResultMessage);
            if (ds.Tables.Count == 2)
            {
                MonthViewAadminResultOR _result = new MonthViewAadminResultOR();
                _result.Item = new MonthViewAadminOR(ds.Tables[0].Rows[0]);

                List<MonthViewAadminOR> _list = new List<MonthViewAadminOR>();
                foreach (DataRow _row in ds.Tables[1].Rows)
                {
                    _list.Add(new MonthViewAadminOR(_row));
                }
                _result.Items = _list;
                return _result;
            }
            return null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="mResultType"></param>
        /// <param name="mResultMessage"></param>
        /// <returns></returns>
        public MonthViewResultOR MonthView(string UserID,out  int mResultType, out string mResultMessage)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@UserID", SqlDbType.Int, 8, ParameterDirection.Input, false, 0, 0, "UserID", DataRowVersion.Default, UserID)
            };

            DataSet ds = DbHelperSQL.ExecuteProcedure("SP_YWTOrder_IntegralScore_MonthView", parameters, out    mResultType, out   mResultMessage);
            if (ds.Tables.Count == 2)
            {
                MonthViewResultOR _result = new MonthViewResultOR();
                _result.Item = new MonthViewOR(ds.Tables[0].Rows[0]);

                List<MonthViewOR> _list = new List<MonthViewOR>();
                foreach (DataRow _row in ds.Tables[1].Rows)
                {
                    _list.Add(new MonthViewOR(_row));
                }
                _result.Items = _list;
                return _result;
            }
            return null;
        }
        #endregion
    }
}

