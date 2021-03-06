﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace YWT.Common
{
    /// <summary>
    /// DES加密/解密类
    /// </summary>
    public class DES
    {
        #region [Encrypt]加密

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="Text">源串</param>
        /// <returns>加密后的字符串</returns>
        public static string Encrypt(string Text)
        {
            return Encrypt(Text, "YWTABCabc123");
        }

        /// <summary> 
        /// 加密数据 
        /// </summary> 
        /// <param name="Text">源串</param> 
        /// <param name="sKey">密钥</param> 
        /// <returns>加密后的字符串</returns> 
        public static string Encrypt(string Text, string sKey)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] inputByteArray;
            inputByteArray = Encoding.Default.GetBytes(Text);
            des.Key = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
            des.IV = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            StringBuilder ret = new StringBuilder();
            foreach (byte b in ms.ToArray())
            {
                ret.AppendFormat("{0:X2}", b);
            }
            return ret.ToString();
        }

        #endregion

        #region [Decrypt]解密

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="Text">源串</param>
        /// <returns>解密后的字符串</returns>
        public static string Decrypt(string Text)
        {
            return Decrypt(Text, "YWTABCabc123");
        }

        /// <summary> 
        /// 解密数据 
        /// </summary> 
        /// <param name="Text">源串</param> 
        /// <param name="sKey"></param> 
        /// <returns>解密后的字符串</returns> 
        public static string Decrypt(string Text, string sKey)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            int len;
            len = Text.Length / 2;
            byte[] inputByteArray = new byte[len];
            int x, i;
            for (x = 0; x < len; x++)
            {
                i = Convert.ToInt32(Text.Substring(x * 2, 2), 16);
                inputByteArray[x] = (byte)i;
            }
            des.Key = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
            des.IV = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            return Encoding.Default.GetString(ms.ToArray());
        }

        #endregion
    }
}
