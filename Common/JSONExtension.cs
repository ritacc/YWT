using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using System.Text.RegularExpressions;
using System.IO;
using System.Runtime.Serialization.Json;

namespace YWT.Common
{
    public static class JSONExtension
    {
        /// <summary>
        /// 去除危险字符
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string TrimDangerousCharacter(this object obj)
        {
            if (obj == null)
                return "";
            string retStr = obj.ToString();
            string SqlStr = "'|exec|insert|select|delete|update|master|truncate|declare";
            string[] anySqlStr = SqlStr.Split('|');
            foreach (string ss in anySqlStr)
            {
                if (retStr.IndexOf(ss) >= 0)
                {
                    retStr = retStr.Replace(ss, "");
                }
            }
            return retStr;
        }

        public static string ToJSON2(this object obj)
        {
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            return (javaScriptSerializer.Serialize(obj));
        }

        

        public static T ParseJSON<T>(this string str)
        {
            //在将json字符串反序列化的过程中， 毫秒形式的时间转日期会因为utc与本地时间不同而有8小时的差异。
            //所以会有下面的这个Regex.Replace
            str = Regex.Replace(str, @"/Date\((\d+)\)/", match =>
            {
                DateTime dt = new DateTime(1970, 1, 1);
                dt = dt.AddMilliseconds(long.Parse(match.Groups[1].Value));
                dt = dt.ToLocalTime(); //将UTC时间转换为本地时间
                return string.Format(@"/Date({0})/", dt.Subtract(DateTime.Parse("1970-1-1")).TotalMilliseconds.ToString());
            });

            T obj = Activator.CreateInstance<T>();
            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(str)))
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
                return (T)serializer.ReadObject(ms);
            }
        }

    }
}
