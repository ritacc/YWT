using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using CBSCS.DBUtility;

namespace YWT.DAL.File
{
    public class UPFileDA
    {
        /// <summary>
        /// 保存图片，更新用户头像、运维单等。
        /// </summary>
        /// <param name="action"></param>
        /// <param name="ElementID"></param>
        /// <param name="Creator"></param>
        /// <param name="ImagePath"></param>
        /// <param name="mResultType"></param>
        /// <param name="mResultMessage"></param>
        public void UPFile_Save(string action, string ElementID, string Creator, string ImagePath, out int mResultType, out string mResultMessage)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ACTION", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "ACTION", DataRowVersion.Default,action),
                new SqlParameter("@ElementID", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "ElementID", DataRowVersion.Default, ElementID),
                new SqlParameter("@Creator", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "Creator", DataRowVersion.Default, Creator),
                new SqlParameter("@ImagePath", SqlDbType.VarChar, 200, ParameterDirection.Input, false, 0, 0, "ImagePath", DataRowVersion.Default, ImagePath),
            };
            DbHelperSQL.ExecuteProcedureNonQuery("sp_UPFile_Save", parameters, out   mResultType, out   mResultMessage);
        }
    }
}
