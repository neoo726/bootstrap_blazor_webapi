using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataView_UMS.Utlis
{
    public sealed class EncryptHelper
    {
        /// <summary>
        /// MD5加密（UTF-8编码）
        /// </summary>
        /// <param name="str">明文密码</param>
        /// <returns></returns>
        public static string GetMd5(string str)
        {
            if (string.IsNullOrEmpty(str)) return null;
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] hashedDataBytes = md5.ComputeHash(Encoding.GetEncoding("gb2312").GetBytes(str));
            StringBuilder tmp = new StringBuilder();
            foreach (var i in hashedDataBytes)
            {
                tmp.Append(i.ToString("x2"));
            }
            return tmp.ToString();
        }
    }
    /// <summary>
    /// 实现Base64加密解密
    /// </summary>
    public sealed class Base64
    {
        /// <summary>
        /// Base64加密
        /// </summary>
        /// <param name="encode">加密采用的编码方式</param>
        /// <param name="source">待加密的明文</param>
        /// <returns></returns>
        public static string EncodeBase64(Encoding encode, string source)
        {
            byte[] bytes = encode.GetBytes(source);
            string strEncode = string.Empty;
            try
            {
                strEncode = Convert.ToBase64String(bytes);
            }
            catch
            {
                strEncode = source;
            }
            return strEncode;
        }

        /// <summary>
        /// Base64加密，采用utf8编码方式加密
        /// </summary>
        /// <param name="source">待加密的明文</param>
        /// <returns>加密后的字符串</returns>
        public static string EncodeBase64(string source)
        {
            return EncodeBase64(Encoding.UTF8, source);
        }

        /// <summary>
        /// Base64解密
        /// </summary>
        /// <param name="encode">解密采用的编码方式，注意和加密时采用的方式一致</param>
        /// <param name="result">待解密的密文</param>
        /// <returns>解密后的字符串</returns>
        public static string DecodeBase64(Encoding encode, string result)
        {
            string decode = "";
            byte[] bytes = Convert.FromBase64String(result);
            try
            {
                decode = encode.GetString(bytes);
            }
            catch
            {
                decode = result;
            }
            return decode;
        }

        /// <summary>
        /// Base64解密，采用utf8编码方式解密
        /// </summary>
        /// <param name="result">待解密的密文</param>
        /// <returns>解密后的字符串</returns>
        public static string DecodeBase64(string result)
        {
            return DecodeBase64(Encoding.UTF8, result);
        }
    }
}
