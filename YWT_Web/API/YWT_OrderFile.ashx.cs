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
    /// YWT_OrderFile 的摘要说明
    /// </summary>
    public class YWT_OrderFile : IHttpHandler
    {

        HttpContext _context;
        public void ProcessRequest(HttpContext context)
        {
            _context = context;
            AjaxContentFileOR _result = new AjaxContentFileOR();
            context.Response.ContentType = "text/plain";
            try
            { 
                if (context.Request.Files.Count > 0)
                {
                    _result = UpFile();
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
                Utils.WriteLog("YWT_OrderFile.ashx/ProcessRequest", ex.ToString());
            }
            context.Response.ContentType = "text/plain";
            context.Response.Write(_result.ToJSON2());
        }


        private AjaxContentFileOR UpFile()
        {
            AjaxContentFileOR _result = new AjaxContentFileOR();
            string saveDBPath = "";
            try
            {
                string path = _context.Server.MapPath("~/");
                DateTime _Current = DateTime.Now;
                path += string.Format("Upload\\Order\\{0}\\{1}\\{2}", _Current.ToString("yyyy"), _Current.ToString("MM"), _Current.ToString("dd"));
                saveDBPath = string.Format("Upload/Order/{0}/{1}/{2}", _Current.ToString("yyyy"), _Current.ToString("MM"), _Current.ToString("dd"));
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                string fileName = Path.GetFileName(_context.Request.Files[0].FileName);
                string end = fileName.Substring(fileName.Length - 4).ToLower();

                string newName = Guid.NewGuid().ToString() ;
                //saveDBPath = saveDBPath + "/" + newPath + end;
                
               
                //ICON
                string ReturnMsgIcon_DBPath = saveDBPath + "/" + newName + "icon" + end;//多加ICON
                string ReturnMsgIcon_SavePath = path + "\\" + newName + "icon" + end;//多加ICON
                
                //保存到文件夹
                string SavePath = path + "\\" + newName + end;
                if (_context.Request.Files["filename"] != null)
                {
                    _context.Request.Files["filename"].SaveAs(SavePath);
                }
                else if (_context.Request.Files.Count > 0)
                {
                    _context.Request.Files[0].SaveAs(SavePath);
                }

                _result.ReturnMsg = saveDBPath + "/" + newName + end;
                _result.ReturnMsgIcon = ReturnMsgIcon_DBPath;
                //保存小图标
                ResizeImage(SavePath, ReturnMsgIcon_SavePath);
                _result.Status = true;
            }
            catch (Exception ex)
            {
                Utils.WriteLog("", ex.Message + "************"+ _result.ReturnMsg);
                _result.Status = false;
                _result.ReturnMsg = ex.Message;
            }
            return _result;
        }
        public void ResizeImage( string SourcePath,string newPath)
        {
            Bitmap bmp = new Bitmap(SourcePath);

            if (bmp.Width > 100)
            {

                double rate = 100.00d / bmp.Width;

                int newW = 100;
                double newH = bmp.Height * rate;
                try
                {
                    using (Bitmap b = new Bitmap(newW, Convert.ToInt32(newH)))
                    {
                        Graphics g = Graphics.FromImage(b);
                        // 插值算法的质量    
                        g.InterpolationMode = InterpolationMode.Low;
                        g.DrawImage(bmp, new Rectangle(0, 0, Convert.ToInt32(newW), Convert.ToInt32(newH)), new Rectangle(0, 0, bmp.Width, bmp.Height), GraphicsUnit.Pixel);
                        g.Dispose();
                        b.Save(newPath);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                bmp.Save(newPath);
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