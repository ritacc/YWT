using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using YWT.Common;
using YWT.Model.User;
using YWT.Model.Order;
using YWT.BLL.SysDB;
using System.Data;
using YWT.Model.Other;

namespace YWT
{
    public partial class T : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                InitPage();

                string result = GetStringSpell.getSpell("不想加");
                List<OrderTaskUserOR> _list = new List<OrderTaskUserOR>();
                _list.Add(new OrderTaskUserOR() { UserID = "afafafeee" });
                _list.Add(new OrderTaskUserOR() { UserID = "gggggg" });

                OnlineApprovalOR obj = new  OnlineApprovalOR();
                this.txt.Text = obj.ToJSON2();// _list.ToJSON2();
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
            DataTable dt = new AccessSqlserverBLL().SelectColumn(dbdtable.SelectedItem.Text);
            gdcolumns.DataSource = dt;
            gdcolumns.DataBind();
        }


    }
}