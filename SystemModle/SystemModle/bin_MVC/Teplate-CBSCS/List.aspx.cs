using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
<#usingNamespace>

namespace <#ClaseNameSpace>
{
    public partial class <#ClassName>List : CBSCS.BLL.UI.BasePageNoPermission
    {
		public DataTable dt = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtStart.Text = DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd");
                txtEnd.Text = DateTime.Now.ToString("yyyy-MM-dd");
                base.InitParams(pager);
                
                InitPage();
                BindGrid();
            }
        }
        protected void InitPage()
        {

        }
        
		protected void BindGrid()
        {
            if (Request["pagec1"] != null && Request["pagec1"] != "")
            {
                pager.PageSize = Convert.ToInt16(Request["pagec1"]);
            }
            if (pager.PageSize == 0)
            {
                pager.PageSize = 200;
            }

            string strWhere = string.Empty;
            //strWhere = string.Format(" and create_date BETWEEN '{0}' and '{1} 23:59:59'", txtStart.Text, txtEnd.Text);
            

            int StartIndex = (this.pager.CurrentPageIndex - 1) * (this.pager.PageSize) + 1;
            int EndIndex = this.pager.CurrentPageIndex * this.pager.PageSize;


            int RecordCount = 0;
            dt = new <#ClassName>BLL().SelectAllByWhere(strWhere, StartIndex, EndIndex, out RecordCount);

            pager.RecordCount = Convert.ToInt32(RecordCount);

            pager.CustomInfoText = "总数 <font color=\"blue\"><b>" + pager.RecordCount.ToString() + "</b></font>，";
            pager.CustomInfoText += "页数 <font color=\"blue\"><b>" + pager.PageCount.ToString() + "</b></font>，";
            pager.CustomInfoText += "当前为第 <font color=\"red\"><b>" + pager.CurrentPageIndex.ToString() + " </b></font>页，";
            pager.CustomInfoText += "每页显示<input id='pagec' type='text' name='pagec1' runat='server' style='WIDTH: 30px' value='" + pager.PageSize + "' onblur='document.getElementById(\"btnSearch\").click();'>";

            base.SaveParams(pager);
        }
        
        protected void pager_PageChanged(object src, Wuqi.Webdiyer.PageChangedEventArgs e)
        {
            pager.CurrentPageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            pager.CurrentPageIndex = 1;
            BindGrid();
        }
    }

}