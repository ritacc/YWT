using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YWT.DAL.Pub;

namespace YWT.BLL.Pub
{
    public class YWTSetupBLL
    {
        public void Setup(string IMEI, string OS, string Manufacturer, out int mResultType, out string mResultMessage)
        {
            new YWTSetupBLL().Setup(IMEI, OS, Manufacturer, out mResultType, out mResultMessage);
        }
    }
}
