using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CBSCS.DBUtility;
using YWT.Model.Msg;
using System.Data.SqlClient;
using System.Data;

namespace YWT.DAL.Msg
{
    public class YWTMsgDA
    {
        public List<YWTMsgOR> GetMsg(string UserID, out int mResultType, out string mResultMessage)
        {
            SqlParameter[] parameters = new SqlParameter[]
			{   
                new SqlParameter("@Create_User", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "Create_User", DataRowVersion.Default, UserID) 
			};
            DataSet ds = DbHelperSQL.ExecuteProcedure("sp_SNRMsg_Search", parameters, out   mResultType, out   mResultMessage);
            if (mResultType != 0)
                return null;

            /// 订单信息
            List<YWTMsgOR> _list = new List<YWTMsgOR>();
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow _row in ds.Tables[0].Rows)
                {
                    _list.Add(new YWTMsgOR(_row));
                }
            }
            return _list;
        }
    }
}
