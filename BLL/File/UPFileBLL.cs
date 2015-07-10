using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YWT.DAL.File;

namespace YWT.BLL.File
{
    public class UPFileBLL
    {

        /// <summary>
        /// 更新用户头像、用户资质认证。
        /// </summary>
        /// <param name="User_ID"></param>
        /// <param name="FileType"></param>
        /// <param name="FileName"></param>
        /// <param name="CertifyType"></param>
        /// <param name="Creator"></param>
        /// <param name="mResultType"></param>
        /// <param name="mResultMessage"></param>
        public void UPFile_Save(string User_ID, string FileType, string FileName , string Creator, out int mResultType, out string mResultMessage)
        {
            new UPFileDA().UPFile_Save(User_ID, FileType, FileName, Creator, out   mResultType, out   mResultMessage);
        }
    }
}
