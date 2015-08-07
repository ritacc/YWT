using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
<#usingNamespace>

namespace <#ClaseNameSpace>
{
    public partial class <#ClassName>List : PageBase
    {
        private <#ClassName>DA m_Rose = new <#ClassName>DA();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.pg.OnPageChanged += new EventHandler(PageChanged);
            if (!IsPostBack)
            {
                InitPage();
                BindGraid();
            }
        }

        private void InitPage()
        {
            //btnAdd.Visible = base.HasPermission("Admin");
            aBtnAdd.Visible = gv<#ClassName>.Columns[1].Visible = base.HasPermission("Edit");
            gv<#ClassName>.Columns[2].Visible = base.HasPermission("Delete");
        }

        protected void PageChanged(object sender, EventArgs e)
        {
            BindGraid();/*加查询条件string.Empty*/
        }

        private void BindGraid()
        {
            int PageCount = 0;
            this.gv<#ClassName>.DataSource = new <#ClassName>DA().selectAllDateByWhere(this.pg.PageIndex, this.pg.PageSize, out PageCount, string.Empty); ;

            this.gv<#ClassName>.DataBind();
            this.pg.RecordCount = PageCount;
        }

        protected void GView_LinkButton_Click(object sender, CommandEventArgs e)
        {
            string id = e.CommandArgument.ToString();
            if (e.CommandName == "delete")
            {
                if (!m_Rose.Delete(id))
                {
                    base.Alert("删除失败!");
                }
               
                BindGraid();
            }
        }
    }

}