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
    public partial class <#ClassName>Edit : CBSCS.BLL.UI.BasePageNoPermission
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request["id"] != null)
		{
                    LoadData();
                    btnDelete.Visible = true;
		}	
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
                Alert(e.Message);
            }
        }

        private <#ClassName>OR SetValue()
        {
            <#editSetValue>
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            <#ClassName>OR sg = SetValue();            

            try
            {
                if (Request["id"] == null)
                {
			        new <#ClassName>BLL().Insert(sg);
                }
                else
                {
			        new <#ClassName>BLL().Update(sg);
                }
                base.Close();
            }
            catch (Exception ex)
            {
                base.Alert(ex.Message);
            }
        }

        //protected void btnLock_Click(object sender, EventArgs e)
        // {
        //    try
        //    {
        //        new <#ClassName>BLL().Lock("1", Request["id"]);
        //        base.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        base.Alert(ex.Message);
        //    }
        //}

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                new <#ClassName>BLL().Delete(Request["id"]);
                base.Close();
            }
            catch (Exception ex)
            {
                base.Alert(ex.Message);
            }
        }


    }
}