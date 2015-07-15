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
       public List<YWTOrderPlatform_ForListOR> PlatformOrderListSearch(int StartIndex, int endIndex, out int mResultType, out string mResultMessage)
        {
            string sql = @"SP_YWTOrder_Platform_Search";
            SqlParameter[] parameters = new SqlParameter[]
			{
                new SqlParameter("@StartIndex", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "StartIndex", DataRowVersion.Default, StartIndex),               
                new SqlParameter("@endIndex", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "ContactMobile", DataRowVersion.Default, endIndex)
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
        /// </summary>
        /// <param name="mResultType"></param>
        /// <param name="mResultMessage"></param>
        /// <returns></returns>
       public YWTOrderPlatform_ForItemOR PlatformOrderItemSearch(string Order_ID, string Create_User, int endIndex, out int mResultType, out string mResultMessage)
        {
            string sql = @"SP_YWTOrder_Platform_Item_Search";
            SqlParameter[] parameters = new SqlParameter[]
			{
                new SqlParameter("@Order_ID", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "Order_ID", DataRowVersion.Default, Order_ID),
                new SqlParameter("@Create_User", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "Create_User", DataRowVersion.Default, Create_User)
			};
            DataSet ds = DbHelperSQL.ExecuteProcedure(sql, parameters, out   mResultType, out   mResultMessage);
            if (ds != null && ds.Tables.Count > 0)
            {
                YWTOrderPlatform_ForItemOR result = null;
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow _row = ds.Tables[0].Rows[0];
                    result = new YWTOrderPlatform_ForItemOR(_row);


                    List<YWTOrderPlatformApplyUserOR> _list = new List<YWTOrderPlatformApplyUserOR>();
                    foreach (DataRow _rowuser in ds.Tables[0].Rows)
                    {
                        _list.Add(new YWTOrderPlatformApplyUserOR(_rowuser));
                    }
                    result.ApplyUsers = _list;
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

        

        //选定运给人员

        //评价



        

    }
}
