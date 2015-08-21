using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YWT.Model.Common;
using System.IO;
using YWT.Common;
using YWT.BLL.File;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace YWT.API
{
    /// <summary>
    /// YWT_UPUserFile 的摘要说明
    /// </summary>
    public class YWT_UPUserFile : IHttpHandler
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
                string action = context.Request["action"];  //getcertifyfile中所定义、  userimg 用户头像
                string userid = context.Request["q0"].TrimDangerousCharacter(); //用户ID
                string Creator = context.Request["q1"].TrimDangerousCharacter();//操作人ID。

                if (context.Request.Files.Count > 0)
                {
                    _result = UpFile(action);
                    if (_result.Status)
                    {
                        if (!string.IsNullOrEmpty(action))
                        {
                            int mResultType = 0;
                            string mResultMessage = "";
                            new UPFileBLL().UPFile_Save(userid, action.ToLower(), _result.ReturnMsg, Creator, out mResultType, out mResultMessage);
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


        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="_action"></param>
        /// <returns></returns>
        private AjaxContentOR UpFile(string _action)
        {
            string folder = "UserCertify";
            if (_action == "userimg")
            {
                folder = "UserImg";
            }
            AjaxContentOR _result = new AjaxContentOR();
            string savePath = "";
            try
            {
                string path = _context.Server.MapPath("~/");

                path += string.Format("/Upload/" + folder + "/{0}/{1}", DateTime.Now.ToString("yyyy"), DateTime.Now.ToString("yyyy-MM"));
                savePath = string.Format("/Upload/" + folder + "/{0}/{1}", DateTime.Now.ToString("yyyy"), DateTime.Now.ToString("yyyy-MM"));
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
                //Bitmap b=new Bitmap(
                _result.Status = true;
                _result.ReturnMsg = savePath + "/" + newPath + end;
            }
            catch (Exception ex)
            {
                _result.Status = false;
                _result.ReturnMsg = ex.Message;
            }
            return _result;
        }

        public static Bitmap ResizeImage(Bitmap bmp, int newW, int newH)
        {
            try
            {
                Bitmap b = new Bitmap(newW, newH);
                Graphics g = Graphics.FromImage(b);
                // 插值算法的质量    
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(bmp, new Rectangle(0, 0, newW, newH), new Rectangle(0, 0, bmp.Width, bmp.Height), GraphicsUnit.Pixel);
                g.Dispose();
                return b;
            }
            catch
            {
                return null;
            }
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