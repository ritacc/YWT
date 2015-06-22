using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.IO;
using System.Text.RegularExpressions;

namespace YWT.Common
{
    /// <summary>
    /// 常用对象类型转换工具类
    /// </summary>
    public class Utils
    {
        public static string ObjToString(object o)
        {
            if (o == null)
                return "";
            return o.ToString();
        }

        #region int处理
        public static int StrToInt(string str, int defaultValue)
        {
            if (!string.IsNullOrEmpty(str))
            {
                if (PageValidate.IsNumber(str))
                {
                    return int.Parse(str);
                }
            }
            return defaultValue;
        }
        public static int StrToInt(string str)
        {
            return StrToInt(str, 0);
        }
        public static int StrToInt(object o)
        {
            if (o == null)
                return 0;
            return StrToInt(o.ToString(), 0);
        }
        #endregion


        #region DateTime处理
        /// <summary>
        /// 将对象转换为可插入数据库的日期格式参数, 可为空
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static DateTime ObjToDateTime(object o)
        {
            try
            {
                return Convert.ToDateTime(o);
            }
            catch
            {
                return DateTime.MinValue;
            }
        }
        /// <summary>
        /// 将对象转换为可插入数据库的日期格式参数, 可为空
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static DateTime? ObjToDateTimeParam(object o)
        {
            if (o == DBNull.Value || o == null)
            {
                return null;
            }
            if (o.ToString() == "")
                return null;
            try
            {
                return Convert.ToDateTime(o);
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// 日期格式，无时间
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static string ObjToDateStr(object o)
        {
            return ObjToDateFmtStr(o, "yyyy-MM-dd");
        }
        /// <summary>
        /// 日期时间格式
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static string ObjToDateTimeStr(object o)
        {
            return ObjToDateFmtStr(o, "yyyy-MM-dd HH:mm:ss");
        }
        /// <summary>
        /// 日期时间格式，有时分，无秒
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static string ObjToDateTimeStr2(object o)
        {
            return ObjToDateFmtStr(o, "yyyy-MM-dd HH:mm");
        }
        public static string ObjToDateFmtStr(object o, string format)
        {
            if (o == DBNull.Value || o == null)
            {
                return "";
            }
            DateTime dt = new DateTime();
            try
            {
                dt = Convert.ToDateTime(o);
            }
            catch
            {
                return "";
            }
            return dt.ToString(format);
        }
        #endregion


        #region float处理
        /// <summary>
        /// 转换为Decimal对象
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static decimal ObjToDecimal(object o)
        {
            return ObjToFloat(o, 0M);
        }
        /// <summary>
        /// 转换为Decimal对象
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static double ObjToDouble(object o)
        {
            return ObjToFloat(o, 0D);
        }
        /// <summary>
        /// 转换为Decimal对象
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static float ObjToFloat(object o)
        {
            return ObjToFloat(o, 0f);
        }
        /// <summary>
        /// 转换为Float对象
        /// </summary>
        /// <param name="o"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static T ObjToFloat<T>(object o, T defaultValue)
        {
            if (o == null)
                return defaultValue;
            if (!PageValidate.IsDecimalSign(o.ToString()))
                return defaultValue;
            try
            {
                T result = (T)Convert.ChangeType(o, typeof(T));
                return result;
            }
            catch
            {
                return defaultValue;
            }
        }
        /// <summary>
        /// 转换为Decimal对象
        /// </summary>
        /// <param name="o"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static decimal ObjToDecimal(object o, decimal defaultValue)
        {
            if (o == null)
                return defaultValue;
            if (!PageValidate.IsDecimalSign(o.ToString()))
                return defaultValue;
            try
            {
                return Convert.ToDecimal(o);
            }
            catch
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// 转换为double字符串（去掉小数点后多余的0，去掉千分符,）
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static string ObjToDoubleStr(object o)
        {
            if (o != null)
            {
                if (PageValidate.IsDecimalSign(o.ToString()))
                {
                    return Convert.ToDouble(o).ToString();
                }
            }
            return "0";
        }

        /// <summary>
        /// 转换为标准货币字符串（两位小数）
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static string ParseDecimal(object o)
        {
            if (o != null)
            {
                if (PageValidate.IsDecimalSign(o.ToString()))
                {
                    return string.Format("{0:n2}", o);
                }
            }
            return "0";
        }
        /// <summary>
        /// 转换为标准货币字符串, len位小数
        /// </summary>
        /// <param name="o"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static string ParseDecimal(object o, int len)
        {
            if (o != null)
            {
                if (PageValidate.IsDecimalSign(o.ToString()))
                {
                    if (len >= 1)
                    {
                        return string.Format("{0:n" + len + "}", o);
                    }
                    else
                    {
                        return Convert.ToDecimal(o).ToString("0");
                    }
                }
            }
            return len >= 1 ? string.Format("{0:n" + len + "}", 0) : "0";
        }
        #endregion






        /// <summary>
        /// 截取指定字节长度的字符串
        /// </summary>
        /// <param name="str">原字符串</param>
        /// <param name="len">截取字节长度</param>
        /// <returns></returns>
        public static string CutByteString(string str, int len)
        {
            string result = string.Empty;// 最终返回的结果
            if (string.IsNullOrEmpty(str)) { return result; }
            int byteLen = System.Text.Encoding.Default.GetByteCount(str);// 单字节字符长度
            int charLen = str.Length;// 把字符平等对待时的字符串长度
            int byteCount = 0;// 记录读取进度
            int pos = 0;// 记录截取位置
            if (byteLen > len)
            {
                for (int i = 0; i < charLen; i++)
                {
                    if (Convert.ToInt32(str.ToCharArray()[i]) > 255)// 按中文字符计算加2
                    { byteCount += 2; }
                    else// 按英文字符计算加1
                    { byteCount += 1; }
                    if (byteCount > len)// 超出时只记下上一个有效位置
                    {
                        pos = i;
                        break;
                    }
                    else if (byteCount == len)// 记下当前位置
                    {
                        pos = i + 1;
                        break;
                    }
                }
                if (pos >= 0)
                { result = str.Substring(0, pos); }
            }
            else
            { result = str; }
            return result;
        }

        /// <summary>
        /// 截取指定字节长度的字符串
        /// </summary>
        /// <param name="str">原字符串</param>
        /// <param name="startIndex">起始位置</param>
        /// <param name="len">截取字节长度</param>
        /// <returns></returns>
        public static string CutByteString(string str, int startIndex, int len)
        {
            string result = string.Empty;// 最终返回的结果
            if (string.IsNullOrEmpty(str)) { return result; }

            int byteLen = System.Text.Encoding.Default.GetByteCount(str);// 单字节字符长度
            int charLen = str.Length;// 把字符平等对待时的字符串长度

            if (startIndex == 0)
            { return CutByteString(str, len); }
            else if (startIndex >= byteLen)
            { return result; }
            else //startIndex < byteLen
            {
                int AllLen = startIndex + len;
                int byteCountStart = 0;// 记录读取进度
                int byteCountEnd = 0;// 记录读取进度
                int startpos = 0;// 记录截取位置                
                int endpos = 0;// 记录截取位置
                for (int i = 0; i < charLen; i++)
                {
                    if (Convert.ToInt32(str.ToCharArray()[i]) > 255)// 按中文字符计算加2
                    { byteCountStart += 2; }
                    else// 按英文字符计算加1
                    { byteCountStart += 1; }
                    if (byteCountStart > startIndex)// 超出时只记下上一个有效位置
                    {
                        startpos = i;
                        AllLen = startIndex + len - 1;
                        break;
                    }
                    else if (byteCountStart == startIndex)// 记下当前位置
                    {
                        startpos = i + 1;
                        break;
                    }
                }

                if (startIndex + len <= byteLen)//截取字符在总长以内
                {
                    for (int i = 0; i < charLen; i++)
                    {
                        if (Convert.ToInt32(str.ToCharArray()[i]) > 255)// 按中文字符计算加2
                        { byteCountEnd += 2; }
                        else// 按英文字符计算加1
                        { byteCountEnd += 1; }
                        if (byteCountEnd > AllLen)// 超出时只记下上一个有效位置
                        {
                            endpos = i;
                            break;
                        }
                        else if (byteCountEnd == AllLen)// 记下当前位置
                        {
                            endpos = i + 1;
                            break;
                        }
                    }
                    endpos = endpos - startpos;
                }
                else if (startIndex + len > byteLen)//截取字符超出总长
                {
                    endpos = charLen - startpos;
                }
                if (endpos >= 0)
                { result = str.Substring(startpos, endpos); }
            }
            return result;
        }



        /// <summary>
        /// 获得当前绝对路径
        /// </summary>
        /// <param name="strPath">指定的路径</param>
        /// <returns>绝对路径</returns>
        public static string GetMapPath(string strPath)
        {
            if (HttpContext.Current != null)
            {
                return HttpContext.Current.Server.MapPath(strPath);
            }
            else //非web程序引用
            {
                strPath = strPath.Replace("/", "\\");
                if (strPath.StartsWith("\\"))
                {
                    strPath = strPath.Substring(strPath.IndexOf('\\', 1)).TrimStart('\\');
                }
                return System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, strPath);
            }
        }



        /// <summary>
        /// 记录文件日志
        /// </summary>
        /// <param name="Source">产生日志的方法/语句</param>
        /// <param name="Err">日志内容</param>
        public static void WriteLog(string Source, string Err)
        {
            DateTime dt = DateTime.Now;
            //获取文件名
            string fileName = dt.ToString("dd");
            //获取文件路径
            string folderPath = Utils.GetMapPath("\\eventslog\\" + dt.ToString("yyyy-MM") + "\\");
            string path = folderPath + fileName + ".txt";

            try
            {
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                if (!File.Exists(path))
                {
                    using (StreamWriter sw = File.CreateText(path))
                    {
                        sw.WriteLine("---------------New Log---------------");
                        sw.WriteLine("-----时间: " + DateTime.Now);
                        sw.WriteLine("-----来源: " + Source);
                        sw.WriteLine("------URL: " + (HttpContext.Current != null ? HttpContext.Current.Request.Url.ToString() : ""));
                        sw.WriteLine("-----内容: " + Err);
                        sw.WriteLine("-----IP: " + Utils.GetClientIP());
                        sw.WriteLine("");
                    }
                }
                else
                {
                    using (StreamWriter sw = File.AppendText(path))
                    {
                        sw.WriteLine("---------------New Log---------------");
                        sw.WriteLine("-----时间: " + DateTime.Now);
                        sw.WriteLine("-----来源: " + Source);
                        sw.WriteLine("------URL: " + (HttpContext.Current != null ? HttpContext.Current.Request.Url.ToString() : ""));
                        sw.WriteLine("-----内容: " + Err);
                        sw.WriteLine("-----IP: " + Utils.GetClientIP());
                        sw.WriteLine("");
                    }
                }
            }
            catch
            { }
        }
        /// <summary>
        /// 记录文件日志
        /// </summary>
        /// <param name="Source">产生日志的方法/语句</param>
        /// <param name="Err">日志内容</param>
        public static void WriteLog(string Source, string Err, string user)
        {
            DateTime dt = DateTime.Now;
            //获取文件名
            string fileName = dt.ToString("dd");
            //获取文件路径
            string folderPath = Utils.GetMapPath("\\eventslog\\" + dt.ToString("yyyy-MM") + "\\");
            string path = folderPath + fileName + ".txt";

            try
            {
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                if (!File.Exists(path))
                {
                    using (StreamWriter sw = File.CreateText(path))
                    {
                        sw.WriteLine("---------------New Log---------------");
                        sw.WriteLine("-----时间: " + DateTime.Now);
                        sw.WriteLine("-----来源: " + Source);
                        sw.WriteLine("------URL: " + (HttpContext.Current != null ? HttpContext.Current.Request.Url.ToString() : ""));
                        sw.WriteLine("-----内容: " + Err);
                        sw.WriteLine("-----User: " + user);
                        sw.WriteLine("-----IP: " + Utils.GetClientIP());
                        sw.WriteLine("");
                    }
                }
                else
                {
                    using (StreamWriter sw = File.AppendText(path))
                    {
                        sw.WriteLine("---------------New Log---------------");
                        sw.WriteLine("-----时间: " + DateTime.Now);
                        sw.WriteLine("-----来源: " + Source);
                        sw.WriteLine("------URL: " + (HttpContext.Current != null ? HttpContext.Current.Request.Url.ToString() : ""));
                        sw.WriteLine("-----内容: " + Err);
                        sw.WriteLine("-----User: " + user);
                        sw.WriteLine("-----IP: " + Utils.GetClientIP());
                        sw.WriteLine("");
                    }
                }
            }
            catch
            { }
        }

        /// <summary>
        /// 任意数组转换为字符串
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="norepeat">是否去除重复</param>
        /// <returns></returns>
        public static string ArrToString<T>(T[] obj, bool norepeat)
        {
            string ret = ",";
            foreach (T t in obj)
            {
                if (!ret.Contains("," + t.ToString() + ","))
                {
                    ret += t.ToString() + ",";
                }
            }
            return ret.TrimStart(',').TrimEnd(',');
        }


        public static string GetRootUrl(System.Uri uri)
        {
            return uri.Scheme + "://" + uri.Authority + "";
        }





        /// <summary>  
        /// 提取汉字首字母  
        /// </summary>  
        /// <param name="strText">需要转换的字</param>  
        /// <returns>转换结果</returns>  
        public static string GetChineseSpell(string strText)
        {
            int len = strText.Length;
            string myStr = "";
            for (int i = 0; i < len; i++)
            {
                myStr += getSpell(strText.Substring(i, 1));
            }
            return myStr;
        }
        /// <summary>  
        /// 把提取的字母变成大写  
        /// </summary>  
        /// <param name="strText">需要转换的字符串</param>  
        /// <returns>转换结果</returns>  
        public static string GetLowerChineseSpell(string strText)
        {
            return GetChineseSpell(strText).ToLower();
        }
        /// <summary>  
        /// 把提取的字母变成大写  
        /// </summary>  
        /// <param name="myChar">需要转换的字符串</param>  
        /// <returns>转换结果</returns>  
        public static string GetUpperChineseSpell(string strText)
        {
            return GetChineseSpell(strText).ToUpper();
        }
        /// <summary>  
        /// 获取单个汉字的首拼音  
        /// </summary>  
        /// <param name="myChar">需要转换的字符</param>  
        /// <returns>转换结果</returns>  
        public static string getSpell(string myChar)
        {
            byte[] arrCN = System.Text.Encoding.Default.GetBytes(myChar);
            if (arrCN.Length > 1)
            {
                int area = (short)arrCN[0];
                int pos = (short)arrCN[1];
                int code = (area << 8) + pos;
                int[] areacode = { 45217, 45253, 45761, 46318, 46826, 47010, 47297, 47614, 48119, 48119, 49062, 49324, 49896, 50371, 50614, 50622, 50906, 51387, 51446, 52218, 52698, 52698, 52698, 52980, 53689, 54481 };
                for (int i = 0; i < 26; i++)
                {
                    int max = 55290;
                    if (i != 25) max = areacode[i + 1];
                    if (areacode[i] <= code && code < max)
                    {
                        return System.Text.Encoding.Default.GetString(new byte[] { (byte)(65 + i) });
                    }
                }
                return "_";
            }
            else return myChar;
        }

        public static HttpCookie CreateCookie(string name, DateTime dt)
        {
            HttpCookie cookie = new HttpCookie(name);//初使化并设置Cookie的名称
            cookie.Expires = dt;//设置过期时间
            return cookie;
        }


        /// <summary>
        /// 获取客户端IP地址
        /// </summary>
        /// <returns></returns>
        public static string GetClientIP()
        {
            string result = String.Empty;

            result = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(result))
            {
                result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }
            if (string.IsNullOrEmpty(result))
            {
                result = HttpContext.Current.Request.UserHostAddress;
            }
            if (string.IsNullOrEmpty(result))
            {
                return "127.0.0.1";
            }
            return result;
        }



        /// <summary>
        /// 检测是否有Sql危险字符
        /// </summary>
        /// <param name="str">要判断字符串</param>
        /// <returns>判断结果</returns>
        public static bool IsSafeSqlString(string str)
        {
            return !Regex.IsMatch(str, @"[-|;|,|\/|\(|\)|\[|\]|\}|\{|%|@|\*|!|\']");
        }
    }
}
