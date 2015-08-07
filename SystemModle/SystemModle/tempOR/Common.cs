using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SystemModle.tempOR
{
    public class Common
    {
        public static string NameFormat(string name)
        {
            //if (name.IndexOf("_") > -1)
            //{
            //    name = Regex.Replace(name.ToLower(), "^t_", "");
            //    Regex reg = new Regex("^[A-Za-z]|[_][A-Za-z]", RegexOptions.IgnoreCase);
            //    MatchCollection matchs = reg.Matches(name);
            //    int len = matchs.Count;
            //    foreach (Match match in matchs)
            //    {
            //        name = name.Remove(match.Index, match.Length);
            //        name = name.Insert(match.Index, match.Value.ToUpper());
            //    }
            //    return name.Replace("_", "");
            //}
            //return name.Substring(0, 1).ToUpper() + name.Substring(1).ToLower();
            return name;
        }

		public static string getSC(string ClassName)
        {
            if (ClassName.Length > 4)
            {
                return string.Format("m_{0}", ClassName.Substring(0, 4));
            }
            else
            {
                return string.Format("m_{0}", ClassName);
            }
        }

        
    }
}
