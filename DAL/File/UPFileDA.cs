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
        public void UPFile_Save(string User_ID, string FileType, string FileName, string Creator, out int mResultType, out string mResultMessage)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@User_ID", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "ACTION", DataRowVersion.Default,User_ID),
                new SqlParameter("@FileType", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "FileType", DataRowVersion.Default, FileType),
                new SqlParameter("@FileName", SqlDbType.VarChar, 200, ParameterDirection.Input, false, 0, 0, "FileName", DataRowVersion.Default, FileName),
                new SqlParameter("@Creator", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "Creator", DataRowVersion.Default, Creator),
                //new SqlParameter("@CertifyType", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "CertifyType", DataRowVersion.Default, CertifyType)
            };
            DbHelperSQL.ExecuteProcedureNonQuery("sp_YWTUser_File_Save", parameters, out   mResultType, out   mResultMessage);
        }
    }
}
