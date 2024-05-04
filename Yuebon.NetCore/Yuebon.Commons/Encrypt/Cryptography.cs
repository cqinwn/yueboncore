/*******************************************************************************
 * Copyright © 2017-2020 Yuebon.Framework 版权所有
 * Author: Yuebon
 * Description: Yuebon快速开发平台
 * Website：http://www.yuebon.com
*********************************************************************************/
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;

namespace Yuebon.Commons
{
    /// <summary>
    /// 用于webapi 生成票据使用，公开
    /// </summary>
    public sealed class Cryptography
    {
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="tmpStr">字符串</param>
        /// <param name="encodingAESKey">密钥</param>
        /// <returns></returns>
        public static string AESEncrypt(string tmpStr, string encodingAESKey)
        {
            string str = tmpStr + GetSHA512(encodingAESKey);
            return GetSHA512(GetSHA512(str)) + GetSHA512(tmpStr);
        }
        

        /// <summary>
        /// 获得SHA512加密
        /// </summary>
        public static string GetSHA512(string input)
        {
            byte[] data = SHA512.HashData(Encoding.Default.GetBytes(input));
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sb.Append(data[i].ToString("x2"));
            }
            return sb.ToString();
        }

    }
}
