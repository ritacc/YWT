using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
 
using YWT.Common;
using YWT.Model.User;
 
namespace YWT
{
    public partial class T : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            YWTSupplierOR obj = new YWT.Model.User.YWTSupplierOR();
            this.txt.Text = obj.ToJSON2();
        }
    }
}