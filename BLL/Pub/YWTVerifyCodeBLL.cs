using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YWT.DAL.Pub;

namespace YWT.BLL.pub
{
    public class YWTVerifyCodeBLL
    {
        /// <summary>
        /// 生成验证码
        /// </summary>
        /// <param name="Phone"></param>
        /// <param name="IMEI"></param>
        /// <param name="VerifyCode"></param>
        /// <param name="mResultType"></param>
        /// <param name="mResultMessage"></param>
        public void VerifyCode_Save(string Phone, string IMEI, string VerifyCode, out int mResultType, out string mResultMessage)
        {
            new YWTVVerifyCodeDA().VerifyCode_Save(Phone, IMEI, VerifyCode, out  mResultType, out  mResultMessage);
        }

        /// <summary>
        /// 验证
        /// </summary>
        /// <param name="Phone"></param>
        /// <param name="IMEI"></param>
        /// <param name="VerifyCode"></param>
        /// <param name="mResultType"></param>
        /// <param name="mResultMessage"></param>
        public void VerifyCode_Check(string Phone, string IMEI, string VerifyCode, out int mResultType, out string mResultMessage)
        {
            new YWTVVerifyCodeDA().VerifyCode_Check(Phone, IMEI, VerifyCode, out  mResultType, out  mResultMessage);
        }
    }
}
