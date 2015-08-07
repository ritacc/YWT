using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

namespace SystemModle
{
    public class BuildHelper
    {
        public static void Save(string path, string fileName, string text)
        {
            fileName = Regex.Replace(fileName, "[^A-Za-z0-9_.]", "_");
            //FileStream stream = null;
            //StreamWriter writer = null;
            try
            {
                //若没有存在指定的目录,则创建之.
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                //若文件已存在,则删除之.
                if (File.Exists(path + @"\" + fileName))
                {
                    File.Delete(path + @"\" + fileName);
                }

                File.AppendAllText(path + @"\" + fileName, text + "\n", Encoding.UTF8);

                //创建文件并得到文件流对象.
                //stream = new FileStream(path + @"\" + fileName, FileMode.Create);
                //writer = new StreamWriter(stream, Encoding.UTF8);
                //writer.Write(text);
                //writer.WriteLine("");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                //if (null != writer)
                //{
                //    writer.Flush();
                //    writer.Close();
                //    writer.Dispose();
                //}
            }            
        }
    }
}
