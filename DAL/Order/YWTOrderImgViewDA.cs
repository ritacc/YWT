using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CBSCS.DBUtility;
using YWT.Model.Order;
using YWT.Model.Order.View;
using YWT.Model.Order.ImgView;

namespace YWT.DAL.Order
{
   public class YWTOrderImgViewDA
    {
       /// <summary>
       /// 现场拍照
       /// </summary>
       /// <param name="UserID"></param>
       /// <param name="PageIndex"></param>
       /// <param name="mResultType"></param>
       /// <param name="mResultMessage"></param>
       /// <returns></returns>
       public List<OrderImgViewOR> ImgViewStart(string UserID, int PageIndex, out  int mResultType, out string mResultMessage)
       {
           SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@UserID", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "UserID", DataRowVersion.Default, UserID),
                new SqlParameter("@PageIndex", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "PageIndex", DataRowVersion.Default,PageIndex)
            };

           DataSet ds = DbHelperSQL.ExecuteProcedure("SP_YWTOrder_ImgViewStart", parameters, out    mResultType, out   mResultMessage);
           if (ds.Tables.Count == 2)
           {
               List<OrderImgViewOR> _list = new List<OrderImgViewOR>();

               //详细文件
               List<OrderFileOR> _Files = new List<OrderFileOR>();
               foreach (DataRow _row in ds.Tables[1].Rows)
               {
                   _Files.Add(new OrderFileOR(_row));
               }

               foreach (DataRow _row in ds.Tables[0].Rows)
               {
                   OrderImgViewOR item = new OrderImgViewOR(_row, 30);
                   item.InitFiles(_Files);
                   _list.Add(item);
               }
               return _list;
           }
           return null;
       }

       /// <summary>
       /// 效果查询，过程还原
       /// </summary>
       /// <param name="UserID"></param>
       /// <param name="PageIndex"></param>
       /// <param name="mResultType"></param>
       /// <param name="mResultMessage"></param>
       /// <returns></returns>
       public List<OrderImgViewOR> ImgViewEnd(string UserID, int PageIndex, out  int mResultType, out string mResultMessage)
       {
           SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@UserID", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "UserID", DataRowVersion.Default, UserID),
                new SqlParameter("@PageIndex", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "PageIndex", DataRowVersion.Default,PageIndex)
            };

           DataSet ds = DbHelperSQL.ExecuteProcedure("SP_YWTOrder_ImgViewEnd", parameters, out    mResultType, out   mResultMessage);
           if (ds.Tables.Count == 2)
           {
               List<OrderImgViewOR> _list = new List<OrderImgViewOR>();

               //详细文件
               List<OrderFileOR> _Files = new List<OrderFileOR>();
               foreach (DataRow _row in ds.Tables[1].Rows)
               {
                   _Files.Add(new OrderFileOR(_row));
               }

               foreach (DataRow _row in ds.Tables[0].Rows)
               {
                   OrderImgViewOR item = new OrderImgViewOR(_row, 90);
                   item.InitFiles(_Files);
                   _list.Add(item);
               }
               return _list;
           }
           return null;
       }

       /// <summary>
       /// 查询图片
       /// </summary>
       /// <param name="UserID"></param>
       /// <param name="FileType"></param>
       /// <param name="OrderID"></param>
       /// <param name="mResultType"></param>
       /// <param name="mResultMessage"></param>
       /// <returns></returns>
       public OrderImgViewItemOR ImgViewLoad(string UserID, string FileType, string OrderID, out  int mResultType, out string mResultMessage)
       {
           SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@UserID", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "UserID", DataRowVersion.Default, UserID),
                new SqlParameter("@OrderID", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "OrderID", DataRowVersion.Default, OrderID),
                new SqlParameter("@FileType", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "FileType", DataRowVersion.Default,FileType)
            };

           DataSet ds = DbHelperSQL.ExecuteProcedure("SP_YWTOrder_ImgViewLoad", parameters, out    mResultType, out   mResultMessage);
           if (ds.Tables.Count == 2)
           {   
               //详细文件
               OrderImgViewItemOR _Result = new OrderImgViewItemOR(ds.Tables[0].Rows[0], Convert.ToInt32(FileType));

               List<string> _Filse = new List<string>();
               foreach (DataRow _row in ds.Tables[1].Rows)
               {
                   _Filse.Add(_row["FileName"].ToString());
               }
               _Result.Files = _Filse;
               return _Result;
           }
           return null;
       }
    }
}
