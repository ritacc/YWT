using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using YWT.BLL;
using YWT.Model.Interface;

namespace YWT.Interface
{
    public partial class Interface : System.Web.UI.Page
    {
        protected StringBuilder sb = new StringBuilder();
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadMenus();
        }

        List<InterfaceActionOR> ListAction = new List<InterfaceActionOR>();
        List<InterfaceParaOR> ListPara = new List<InterfaceParaOR>();
        protected void LoadMenus()
        {
            InterfaceBLL bll = new InterfaceBLL();
            ListAction = bll.SelectAction();
            ListPara = bll.SelectPara();
            if (ListAction != null)
            {

                string oldTitle = string.Empty;
                foreach (InterfaceActionOR _action in ListAction)
                {
                    if (oldTitle != _action.IFile)
                    {
                        oldTitle = _action.IFile;
                        sb.AppendFormat("<tr><td  colspan='2' style='border-top: 2px solid #00BFFF;font-weight:bold; font-size:14px;'>{0}</td><tr>", _action.IFile);
                    }
                    sb.AppendFormat("<tr><td  style=' width:40%;'>{0}?action={1}{2}</td><td>{3}</td><tr>", _action.IFile, _action.IACTION, getdPara(_action.Inerface_ID), _action.IDescription);
                    AddPara(_action.Inerface_ID);
                }
                
            }            
        }

        public void AddPara(Int64 _id)
        {
            string strContent = string.Empty;
            sb.Append("<tr><td colspan='2'><table style='width:60%;border-collapse:collapse;'>");
            foreach (InterfaceParaOR _para in ListPara)
            {
                if (_para.Inerface_ID == _id)
                {
                    strContent = string.Format("<tr><td  style=' width:60px;'>{0}</td><td>{1}</td></tr>", _para.PNAME, _para.PDescription);
                    sb.Append(strContent);
                }
            }
            sb.Append("</table></td></tr>");
        }

        public string getdPara(Int64 _id)
        {
            string _result = string.Empty;
             
            foreach (InterfaceParaOR _para in ListPara)
            {
                if (_para.Inerface_ID == _id)
                {
                    _result += string.Format("&{0}=", _para.PNAME);
                   
                }
            }
            
            return _result;
        }
    }
}