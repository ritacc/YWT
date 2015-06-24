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
            new UPFileDA().UPFile_Save(action, ElementID, Creator, ImagePath, out   mResultType, out   mResultMessage);
        }
    }
}
