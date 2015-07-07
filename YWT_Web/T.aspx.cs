using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
 
using YWT.Common;
using YWT.Model.User;
using YWT.Model.Order;
 
namespace YWT
{
    public partial class T : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<OrderTaskUserOR> _list = new List<OrderTaskUserOR>();
            _list.Add(new OrderTaskUserOR() { UserID="afafafeee" });
            _list.Add(new OrderTaskUserOR() { UserID = "gggggg" });

            YWTSupplierOR obj = new YWT.Model.User.YWTSupplierOR();
            this.txt.Text = _list.ToJSON2();
        }
    }
}