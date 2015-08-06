using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YWT.DAL.User;
using YWT.Model.User;

namespace YWT.BLL.User
{
    public class YWTUserFileBLL
    {
        /// <summary>
        /// 提交身份认证
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="CertifyType"></param>
        /// <param name="CertifyRealName">姓名</param>
        /// <param name="CertifyIDCard">身份证号</param>
        /// <param name="CertifyCompanyName">公司名称</param>
        /// <param name="mResultType"></param>
        /// <param name="mResultMessage"></param>
        public void YWTUserFileCertify(string UserID, string CertifyType, string CertifyRealName, string CertifyIDCard, string CertifyCompanyName
            
            , out int mResultType, out string mResultMessage)
        {
            new YWTUserFileDA().YWTUserFileCertify(UserID, CertifyType, CertifyRealName, CertifyIDCard, CertifyCompanyName
                , out   mResultType, out   mResultMessage);
        }

        public List<YWTUserFileOR> GetUserFiles(string UserID, out int mResultType, out string mResultMessage)
        {
            return new YWTUserFileDA().GetUserFiles(UserID, out   mResultType, out   mResultMessage);
        }
       

    }
}
