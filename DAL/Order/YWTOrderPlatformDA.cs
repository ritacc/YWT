using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YWT.Model.Order;
using System.Data;
using System.Data.SqlClient;
using CBSCS.DBUtility;
using YWT.Model.OrderPlatform;

namespace YWT.DAL.Order
{
    /// <summary>
    ///  /// <summary>
    /// 处理运维通平台运维单相关逻辑
    /// 查询平台运维单 查看一条运维单信息   申请接运维单  运维商选定运维人员   执行流程 评价
    /// </summary>
    /// </summary>
   public class YWTOrderPlatformDA
    {
       
        /// <summary>
        /// 查询平台多条运维单
        /// </summary>
        /// <param name="StartIndex"></param>
        /// <param name="endIndex"></param>
        /// <param name="mResultType"></param>
        /// <param name="mResultMessage"></param>
        /// <returns></returns>
       public List<YWTOrderPlatform_ForListOR> PlatformOrderListSearch_ForAll(int StartIndex, int endIndex, out int mResultType, out string mResultMessage)
        {
            string sql = @"SP_YWTOrder_Platform_Search";
            SqlParameter[] parameters = new SqlParameter[]
			{
                new SqlParameter("@StartIndex", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "StartIndex", DataRowVersion.Default, StartIndex),
                new SqlParameter("@endIndex", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "ContactMobile", DataRowVersion.Default, endIndex),
                new SqlParameter("@SearchType", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "SearchType", DataRowVersion.Default, "all")               
			};
            DataSet ds = DbHelperSQL.ExecuteProcedure(sql, parameters, out   mResultType, out   mResultMessage);
            if (ds != null && ds.Tables.Count > 0)
            {
                List<YWTOrderPlatform_ForListOR> _list = new List<YWTOrderPlatform_ForListOR>();
                foreach (DataRow _row in ds.Tables[0].Rows)
                {
                    _list.Add(new YWTOrderPlatform_ForListOR(_row));
                }
                return _list;
            }
            return null;
        }

       /// <summary>
       /// 查询平台多条运维单
       /// </summary>
       /// <param name="StartIndex"></param>
       /// <param name="endIndex"></param>
       /// <param name="mResultType"></param>
       /// <param name="mResultMessage"></param>
       /// <returns></returns>
       public List<YWTOrderPlatform_ForListOR> PlatformOrderListSearch_ForSupplier(string Create_User, int StartIndex, int endIndex, out int mResultType, out string mResultMessage)
       {
           string sql = @"SP_YWTOrder_Platform_Search";
           SqlParameter[] parameters = new SqlParameter[]
			{
                new SqlParameter("@StartIndex", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "StartIndex", DataRowVersion.Default, StartIndex),
                new SqlParameter("@endIndex", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "ContactMobile", DataRowVersion.Default, endIndex),
                new SqlParameter("@Create_User", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "Create_User", DataRowVersion.Default, Create_User),
                new SqlParameter("@SearchType", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 0, 0, "SearchType", DataRowVersion.Default, "sup")
			};
           DataSet ds = DbHelperSQL.ExecuteProcedure(sql, parameters, out   mResultType, out   mResultMessage);
           if (ds != null && ds.Tables.Count > 0)
           {
               List<YWTOrderPlatform_ForListOR> _list = new List<YWTOrderPlatform_ForListOR>();
               foreach (DataRow _row in ds.Tables[0].Rows)
               {
                   _list.Add(new YWTOrderPlatform_ForListOR(_row));
               }
               return _list;
           }
           return null;
       }

        /// <summary>
        /// 查询一条平台运维单 
        /// 运单主体\申请人员列表
        /// </summary>
        /// <param name="mResultType"></param>
        /// <param name="mResultMessage"></param>
        /// <returns></returns>
       public YWTOrderPlatform_ForItemOR PlatformOrderItemSearch(string Order_ID, string Create_User,   out int mResultType, out string mResultMessage)
        {
            string sql = @"SP_YWTOrder_Platform_Item_Search";
            SqlParameter[] parameters = new SqlParameter[]
			{
                new SqlParameter("@Order_ID", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "Order_ID", DataRowVersion.Default, Order_ID),
                new SqlParameter("@Create_User", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "Create_User", DataRowVersion.Default, Create_User)
			};
            DataSet ds = DbHelperSQL.ExecuteProcedure(sql, parameters, out   mResultType, out   mResultMessage);
            if (ds != null && ds.Tables.Count > 0)
            {
                YWTOrderPlatform_ForItemOR result = null;
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow _row = ds.Tables[0].Rows[0];
                    result = new YWTOrderPlatform_ForItemOR(_row);
                    
                    //List<YWTOrderPlatformApplyUserOR> _list = new List<YWTOrderPlatformApplyUserOR>();
                    //foreach (DataRow _rowuser in ds.Tables[0].Rows)
                    //{
                    //    _list.Add(new YWTOrderPlatformApplyUserOR(_rowuser));
                    //}
                    //result.ApplyUsers = _list;
                }
                return result;
            }
            return null;
        }

      

       public YWTOrderPlatform_ForItemOR PlatformOrderItemSearch(string Order_ID, long Platform_Apply_ID,long MinID,   out int mResultType, out string mResultMessage)
        {
            string sql = @"SP_YWTOrder_Platform_ApplyUsers_Search";
            SqlParameter[] parameters = new SqlParameter[]
			{
                new SqlParameter("@Order_ID", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "Order_ID", DataRowVersion.Default, Order_ID),
                new SqlParameter("@Platform_Apply_ID", SqlDbType.BigInt, 10, ParameterDirection.Input, false, 0, 0, "Platform_Apply_ID", DataRowVersion.Default, Platform_Apply_ID),
                new SqlParameter("@MinID", SqlDbType.BigInt, 10, ParameterDirection.Input, false, 0, 0, "MinID", DataRowVersion.Default, MinID),
			};
            DataSet ds = DbHelperSQL.ExecuteProcedure(sql, parameters, out   mResultType, out   mResultMessage);
            if (ds != null && ds.Tables.Count > 0)
            {
                YWTOrderPlatform_ForItemOR result = null;
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow _row = ds.Tables[0].Rows[0];
                    result = new YWTOrderPlatform_ForItemOR(_row);
                    
                    //List<YWTOrderPlatformApplyUserOR> _list = new List<YWTOrderPlatformApplyUserOR>();
                    //foreach (DataRow _rowuser in ds.Tables[0].Rows)
                    //{
                    //    _list.Add(new YWTOrderPlatformApplyUserOR(_rowuser));
                    //}
                    //result.ApplyUsers = _list;
                }
                return result;
            }
            return null;
        }
       

        /// <summary>
        /// 第三方人员 申请运维单
        /// </summary>
        /// <param name="orderPlatformApply"></param>
        /// <param name="mResultType"></param>
        /// <param name="mResultMessage"></param>
        public void OrderPlatformApply(YWTOrderPlatformApplyOR orderPlatformApply, out int mResultType, out string mResultMessage)
        {
            string sql = @"SP_YWTOrder_Platform_Apply";
            SqlParameter[] parameters = new SqlParameter[]
			{
                new SqlParameter("@Order_ID", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "Order_ID", DataRowVersion.Default, orderPlatformApply.Order_ID),
                new SqlParameter("@Apply_UserID", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "Apply_UserID", DataRowVersion.Default, orderPlatformApply.Apply_UserID),                
                new SqlParameter("@Apply_Content", SqlDbType.NVarChar, 600, ParameterDirection.Input, false, 0, 0, "Apply_Content", DataRowVersion.Default, orderPlatformApply.Apply_Content),
                new SqlParameter("@ContactMan", SqlDbType.VarChar, 30, ParameterDirection.Input, false, 0, 0, "ContactMan", DataRowVersion.Default, orderPlatformApply.ContactMan),
                new SqlParameter("@ContactMobile", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "ContactMobile", DataRowVersion.Default, orderPlatformApply.ContactMobile)
			};
            DbHelperSQL.ExecuteProcedure(sql, parameters, out   mResultType, out   mResultMessage);
        }

        
       /// <summary>
        /// 选定运给人员 
        /// 第三方人员申请后，运维商选定人员
       /// </summary>
       /// <param name="orderID"></param>
       /// <param name="Platform_Apply_ID"></param>
       /// <param name="Create_User"></param>
       /// <param name="mResultType"></param>
       /// <param name="mResultMessage"></param>
        public void OrderPlatform_ComfirmApplyUser(string orderID, string Platform_Apply_ID, string Create_User, out int mResultType, out string mResultMessage)
       {
           string sql = @"SP_YWTOrder_Platform_ComfirmApplyUser";
           SqlParameter[] parameters = new SqlParameter[]
			{
                new SqlParameter("@Order_ID", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "Order_ID", DataRowVersion.Default, orderID),
                new SqlParameter("@Platform_Apply_ID", SqlDbType.BigInt, 10, ParameterDirection.Input, false, 0, 0, "Platform_Apply_ID", DataRowVersion.Default, Platform_Apply_ID),
                new SqlParameter("@Create_User", SqlDbType.VarChar, 30, ParameterDirection.Input, false, 0, 0, "Create_User", DataRowVersion.Default, Create_User)
			};
           DbHelperSQL.ExecuteProcedure(sql, parameters, out   mResultType, out   mResultMessage);
       }


       /// <summary>
       /// 第三方人员申请成功运维单
       /// </summary>
       /// <param name="StartIndex"></param>
       /// <param name="endIndex"></param>
       /// <param name="Create_User"></param>
       /// <param name="mResultType"></param>
       /// <param name="mResultMessage"></param>
       /// <returns></returns>
        public List<YWTOrderPlatform_ForListOR> PlatformOrderList_ApplySuccess_Search(int StartIndex, int endIndex, string Create_User, out int mResultType, out string mResultMessage)
        {
            string sql = @"SP_YWTOrder_Platform_ApplySuccess_Search";
            SqlParameter[] parameters = new SqlParameter[]
			{
                new SqlParameter("@StartIndex", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "StartIndex", DataRowVersion.Default, StartIndex),               
                new SqlParameter("@endIndex", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "ContactMobile", DataRowVersion.Default, endIndex),
                new SqlParameter("@Create_User", SqlDbType.VarChar, 30, ParameterDirection.Input, false, 0, 0, "Create_User", DataRowVersion.Default, Create_User)                
			};
            DataSet ds = DbHelperSQL.ExecuteProcedure(sql, parameters, out   mResultType, out   mResultMessage);
            if (ds != null && ds.Tables.Count > 0)
            {
                List<YWTOrderPlatform_ForListOR> _list = new List<YWTOrderPlatform_ForListOR>();
                foreach (DataRow _row in ds.Tables[0].Rows)
                {
                    _list.Add(new YWTOrderPlatform_ForListOR(_row));
                }
                return _list;
            }
            return null;
        }

        /// <summary>
        /// 第三方人员申请运维单记录查询
        /// </summary>
        /// <param name="StartIndex"></param>
        /// <param name="endIndex"></param>
        /// <param name="Create_User"></param>
        /// <param name="mResultType"></param>
        /// <param name="mResultMessage"></param>
        /// <returns></returns>
        public List<YWTOrderPlatform_ForListOR> PlatformOrderList_Apply_Search(int StartIndex, int endIndex, string Create_User, out int mResultType, out string mResultMessage)
        {
            string sql = @"SP_YWTOrder_Platform_Apply_Search";
            SqlParameter[] parameters = new SqlParameter[]
			{
                new SqlParameter("@StartIndex", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "StartIndex", DataRowVersion.Default, StartIndex),               
                new SqlParameter("@endIndex", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "ContactMobile", DataRowVersion.Default, endIndex),
                new SqlParameter("@Create_User", SqlDbType.VarChar, 30, ParameterDirection.Input, false, 0, 0, "Create_User", DataRowVersion.Default, Create_User)                
			};
            DataSet ds = DbHelperSQL.ExecuteProcedure(sql, parameters, out   mResultType, out   mResultMessage);
            if (ds != null && ds.Tables.Count > 0)
            {
                List<YWTOrderPlatform_ForListOR> _list = new List<YWTOrderPlatform_ForListOR>();
                foreach (DataRow _row in ds.Tables[0].Rows)
                {
                    _list.Add(new YWTOrderPlatform_ForListOR(_row));
                }
                return _list;
            }
            return null;
        }

     

       /// <summary>
        /// 运维人员评价
        /// 运维商评价
       /// </summary>
       /// <param name="Order_ID"></param>
       /// <param name="Assess_Type">评价类型: 91 第三方运维人员 92 运维商</param>
        /// <param name="YW_Result">运维结果: 完成 未完成</param>
       /// <param name="Score">评分</param>
       /// <param name="AssessContent">评价内容</param>
       /// <param name="Create_User">操作人</param>
       /// <param name="mResultType"></param>
       /// <param name="mResultMessage"></param>
        public void PlatformOrder_Assess_Save(string Order_ID, string Assess_Type, string YW_Result,
            int Score, string AssessContent, string Create_User, out int mResultType, out string mResultMessage)
        {
            string sql = @"SP_YWTOrder_Platform_Assess_Save";
            SqlParameter[] parameters = new SqlParameter[]
			{
                new SqlParameter("@Order_ID", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "StartIndex", DataRowVersion.Default, Order_ID),               
                new SqlParameter("@Assess_Type", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "Assess_Type", DataRowVersion.Default, Assess_Type),
                new SqlParameter("@YW_Result", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "YW_Result", DataRowVersion.Default, YW_Result),

                new SqlParameter("@Score", SqlDbType.Int, 8, ParameterDirection.Input, false, 0, 0, "Score", DataRowVersion.Default, Score),               
                new SqlParameter("@AssessContent", SqlDbType.NVarChar, 500, ParameterDirection.Input, false, 0, 0, "AssessContent", DataRowVersion.Default, AssessContent),               
                new SqlParameter("@Creator", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "Creator", DataRowVersion.Default, Create_User)            

			};
            DbHelperSQL.ExecuteProcedureNonQuery(sql, parameters, out   mResultType, out   mResultMessage);
        }

        #region 申请人数据查询

        public List<YWTOrderPlatformApplyUser_ForListOR> GetListApplyUsers(string Order_ID, long MinID, out int mResultType, out string mResultMessage)
        {
            string sql = @"SP_YWTOrder_Platform_ApplyUsers_Search";
            SqlParameter[] parameters = new SqlParameter[]
			{
                new SqlParameter("@Order_ID", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "Order_ID", DataRowVersion.Default, Order_ID),
                new SqlParameter("@MinID", SqlDbType.BigInt, 10, ParameterDirection.Input, false, 0, 0, "MinID", DataRowVersion.Default, MinID)

			};
            DataSet ds = DbHelperSQL.ExecuteProcedure(sql, parameters, out   mResultType, out   mResultMessage);
            if (ds != null && ds.Tables.Count > 0)
            {
                List<YWTOrderPlatformApplyUser_ForListOR> _list = new List<YWTOrderPlatformApplyUser_ForListOR>();
                foreach (DataRow _row in ds.Tables[0].Rows)
                {
                    _list.Add(new YWTOrderPlatformApplyUser_ForListOR(_row));
                }
                return _list;
            }
            return null;
        }
            
        public YWTOrderPlatformApplyUserOR GetItemApplyUsers(string Platform_Apply_ID, out int mResultType, out string mResultMessage)
        {
            string sql = @"SP_YWTOrder_Platform_ApplyUsers_Search";
            SqlParameter[] parameters = new SqlParameter[]
			{
                new SqlParameter("@Platform_Apply_ID", SqlDbType.BigInt, 10, ParameterDirection.Input, false, 0, 0, "Platform_Apply_ID", DataRowVersion.Default, Platform_Apply_ID)
			};
            DataSet ds = DbHelperSQL.ExecuteProcedure(sql, parameters, out   mResultType, out   mResultMessage);
            if (ds != null && ds.Tables.Count > 0)
            {
                
                foreach (DataRow _row in ds.Tables[0].Rows)
                {
                   return  new YWTOrderPlatformApplyUserOR(_row);
                }                 
            }
            return null;
        }

        #endregion
    }
}
