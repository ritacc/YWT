using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YWT.Model.Common;
using System.IO;
using YWT.Common;
using YWT.BLL.File;

namespace YWT.API
{
    /*
    GO
    --YWT_UPFile 运维商信息

    DECLARE @Inerface_ID	BIGINT		
            ,@IFile			VARCHAR(50)='YWT_UPFile'
    INSERT INTO YWT_Inerface (IFile,IACTION,IDescription) VALUES(@IFile,'userimg','上传用户头像文件。')
    SET @Inerface_ID=@@IDENTITY 
    INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q0',N'用户ID')
    INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'q1',N'userID:操作人ID')
    INSERT INTO YWT_Inerface_PARA (Inerface_ID,PNAME,PDescription) VALUES(@Inerface_ID,N'from',N'来源：IOS')
    
 
    */
    /// <summary>
    /// YWT_UPFile 的摘要说明
    /// </summary>
    public class YWT_UPFile : IHttpHandler
    {
        HttpContext _context;
        public void ProcessRequest(HttpContext context)
        {
            _context = context;
            AjaxContentOR _result = new AjaxContentOR();
            context.Response.ContentType = "text/plain";
            try
            {
                string from = context.Request.QueryString["from"];
                string action = context.Request["action"];  //运单下单时，不传此参数。 签收单 uporderqsd   ，费用单时使用 uporderfyd  userimg 用户头像
                string q0 = context.Request["q0"].TrimDangerousCharacter(); //用户ID
                string Creator = context.Request["q1"].TrimDangerousCharacter();//操作人ID。

                if (context.Request.Files.Count > 0)
                {
                    _result = UpFile();
                    if (_result.Status)
                    {
                        if (!string.IsNullOrEmpty(action))
                        {
                            int mResultType = 0;
                            string mResultMessage = "";
                            new UPFileBLL().UPFile_Save(action.ToLower(), q0, Creator, _result.ReturnMsg, out mResultType, out mResultMessage);
                            _result.Status = true;
                            if (mResultType != 0)
                            {
                                _result.Status = false;
                                _result.ReturnMsg = mResultMessage;
                            }
                        }
                    }
                }
                else
                {
                    _result.Status = false;
                    _result.ReturnMsg = "没有选择文件。";
                }
            }
            catch (Exception ex)
            {
                _result.ReturnMsg = ex.Message.ToString();
                Utils.WriteLog("HDL_UPFile.ashx/UpdateSupplier", ex.ToString());
            }

            context.Response.ContentType = "text/plain";
            context.Response.Write(_result.ToJSON2());

        }


        private AjaxContentOR UpFile()
        {
            AjaxContentOR _result = new AjaxContentOR();
            string savePath = "";
            string path = _context.Server.MapPath("~/");

            path += string.Format("/Upload/Order/{0}/{1}/{2}", DateTime.Now.ToString("yyyy"), DateTime.Now.ToString("yyyy-MM"), DateTime.Now.ToString("yyyy-MM-dd"));
            savePath = string.Format("/Upload/Order/{0}/{1}/{2}", DateTime.Now.ToString("yyyy"), DateTime.Now.ToString("yyyy-MM"), DateTime.Now.ToString("yyyy-MM-dd"));
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);


            string fileName = Path.GetFileName(_context.Request.Files[0].FileName);
            string end = fileName.Substring(fileName.Length - 4).ToLower();

            string newPath = Guid.NewGuid().ToString();
            if (_context.Request.Files["filename"] != null)
            {
                _context.Request.Files["filename"].SaveAs(path + "\\" + newPath + end);
            }
            else if (_context.Request.Files.Count > 0)
            {
                _context.Request.Files[0].SaveAs(path + "\\" + newPath + end);
            }
            _result.Status = true;
            _result.ReturnMsg = savePath + "/" + newPath + end;

            return _result;
        }



        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}