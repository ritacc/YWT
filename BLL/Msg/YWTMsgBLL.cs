using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YWT.DAL.Msg;
using YWT.Model.Msg;

namespace YWT.BLL.Msg
{
   public class YWTMsgBLL
    {
       public List<YWTMsgOR> GetMsg(string UserID, out int mResultType, out string mResultMessage)
       {
           return new YWTMsgDA().GetMsg(UserID, out   mResultType, out   mResultMessage);
       }
    }
}
