using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YWT.BLL.SysDB;
using System.Data;

namespace YWT
{
    public partial class D : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                InitPage(); 
            }

        }

        private void InitPage()
        {
            DataTable dt = new AccessSqlserverBLL().GetAllTable();
            dbdtable.DataSource = dt;
            dbdtable.DataTextField = "table_name";
            dbdtable.DataValueField = "id";
            dbdtable.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new AccessSqlserverBLL().GetAllDate(dbdtable.SelectedItem.Text);
            gdcolumns.DataSource = dt;
            gdcolumns.DataBind();
        }
    }
}