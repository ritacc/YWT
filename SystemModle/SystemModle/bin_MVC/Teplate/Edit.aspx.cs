using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Text;
<#usingNamespace>

namespace <#ClaseNameSpace>
{
    public partial class <#ClassName>Edit : PageBase
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                    LoadData();
            }
        }

        private void LoadData()
        {
            try
            {
               <#editLoadData>
            }
            catch (Exception e)
            {
                Alert(e);
            }
        }

        private <#ClassName>OR SetValue()
        {
            <#editSetValue>
        }

        protected void lbtSave_Click(object sender, EventArgs e)
        {
            <#ClassName>OR sg = SetValue();            

            try
            {
                if (Request.QueryString["id"] == null)
                {
			new <#ClassName>DA().Insert(sg);
		}
		else
		{
			new <#ClassName>DA().Update(sg);
		}
		base.Close("tr");
            }
            catch (Exception ex)
            {
                base.Alert(ex.Message);
            }
        }
    }
}