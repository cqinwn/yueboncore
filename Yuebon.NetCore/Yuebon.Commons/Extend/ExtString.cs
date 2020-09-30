using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;

namespace Yuebon.Commons.Extend
{
    /// <summary>
    /// 字符串处理
    /// </summary>
    public static class ExtString
    {
        /// <summary>
        /// 过滤html格式
        /// </summary>
        /// <param name="Htmlstring"></param>
        /// <returns></returns>
        public static string NoHTML(this string Htmlstring)
        {
            Htmlstring = Regex.Replace(Htmlstring, @"<script[\s\S]*?</script>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<noscript[\s\S]*?</noscript>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<style[\s\S]*?</style>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<.*?>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", " ", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", " ", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"-->", " ", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", " ", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", " ", RegexOptions.IgnoreCase);
            return Htmlstring;
        }
        /// <summary>
        /// 用于微信小程序编辑页面，将json字符串解析成html格式
        /// </summary>
        /// <param name="Jsonstring"></param>
        /// <returns></returns>
        public static string YuebonEditorJsonToHtml(this string Jsonstring)
        {
            JArray jArray = JArray.Parse(Jsonstring);
            Jsonstring = string.Empty;
            foreach (var item in jArray)
            {
                JObject jdata = (JObject)item;
                string type = jdata["type"].ToString();
                switch (type)
                {
                    case "txt":
                        Jsonstring += string.Format("<p>{0}</p>", jdata["content"].ToString());
                        break;
                    case "img":
                        Jsonstring += string.Format("<img src=\"{0}\"/>", jdata["content"].ToString());
                        break;
                    case "center":
                        Jsonstring += string.Format("<p style=\"text-align:center; \">{0}</p>", jdata["content"].ToString());
                        break;
                    case "strong":
                        Jsonstring += string.Format("<strong style=\"background:none; font-weight:600; width:100%; border:none; font-size:32upx; line-height:36upx; padding:5px 0; \">{0}</strong>", jdata["content"].ToString());
                        break;
                    default:
                        Jsonstring += string.Format("<p>{0}</p>", jdata["content"].ToString());
                        break;
                }
            }
            return Jsonstring;
        }
        /// <summary>
        /// 用于微信小程序编辑页面，将html符串解析成json字格式
        /// </summary>
        /// <param name="htmlstring"></param>
        /// <returns></returns>
        public static string YuebonHtmlToEditorJson(this string htmlstring)
        {
            JArray jArray = JArray.Parse(htmlstring);
            string descStr = string.Empty;
            foreach (var item in jArray)
            {
                JObject jdata = (JObject)item;
                string type = jdata["type"].ToString();
                switch (type)
                {
                    case "txt":
                        descStr += string.Format("<p>{0}</p>", jdata["content"].ToString());
                        break;
                    case "img":
                        descStr += string.Format("<img src=\"{0}\"/>", jdata["content"].ToString());
                        break;
                    case "center":
                        descStr += string.Format("<p style=\"text-align:center; \">{0}</p>", jdata["content"].ToString());
                        break;
                    case "strong":
                        descStr += string.Format("<p style=\"background:none; font-weight:600; width:100%; border:none; font-size:32upx; line-height:36upx; padding:5px 0; \">{0}</p>", jdata["content"].ToString());
                        break;
                    default:
                        descStr += string.Format("<p>{0}</p>", jdata["content"].ToString());
                        break;
                }
            }
            return htmlstring;
        }

        /// <summary>
        /// 转换为字节流
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte[] ToByte(this string value)
        {
            return System.Text.Encoding.UTF8.GetBytes(value);
        }

        /// <summary>
        /// 转换为HtmlDecode
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string HtmlDecode(this string value)
        {
            return System.Net.WebUtility.HtmlDecode(value);
        }
        /// <summary>
        /// 转换为HtmlEncode
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string HtmlEncode(this string value)
        {
            return System.Net.WebUtility.HtmlEncode(value);
        }
        /// <summary>
        /// 转换为UrlEncode
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string UrlEncode(this string value)
        {
            StringBuilder sb = new StringBuilder();
            byte[] byStr = System.Text.Encoding.UTF8.GetBytes(value);
            for (int i = 0; i < byStr.Length; i++)
            {
                sb.Append(@"%" + Convert.ToString(byStr[i], 16));
            }
            return (sb.ToString());
        }

        /// <summary>
        /// 转换为ToUnicode
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToUnicode(this string value)
        {
            if (string.IsNullOrEmpty(value)) return value;
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < value.Length; i++)
            {
                builder.Append("\\u" + ((int)value[i]).ToString("x"));
            }
            return builder.ToString();
        }
        /// <summary>
        /// email正则验证
        /// </summary>
        private static readonly Regex emailExpression = new Regex(@"^([0-9a-zA-Z]+[-._+&])*[0-9a-zA-Z]+@([-0-9a-zA-Z]+[.])+[a-zA-Z]{2,6}$", RegexOptions.Singleline | RegexOptions.CultureInvariant | RegexOptions.Compiled);
        /// <summary>
        /// url正则验证
        /// </summary>
        private static readonly Regex webUrlExpression = new Regex(@"(http|https)://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?", RegexOptions.Singleline | RegexOptions.CultureInvariant | RegexOptions.Compiled);
        /// <summary>
        /// 
        /// </summary>
        private static readonly Regex stripHTMLExpression = new Regex("<\\S[^><]*>", RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Multiline | RegexOptions.CultureInvariant | RegexOptions.Compiled);

        /// <summary>
        /// 格式化
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static string FormatWith(this string instance, params object[] args)
        {
            return string.Format(instance, args);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static T ToEnum<T>(this string instance, T defaultValue) where T : struct, IComparable, IFormattable
        {
            T convertedValue = defaultValue;

            if (!string.IsNullOrWhiteSpace(instance) && !Enum.TryParse(instance.Trim(), true, out convertedValue))
            {
                convertedValue = defaultValue;
            }

            return convertedValue;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static T ToEnum<T>(this int instance, T defaultValue) where T : struct, IComparable, IFormattable
        {
            T convertedValue;

            if (!Enum.TryParse(instance.ToString(), true, out convertedValue))
            {
                convertedValue = defaultValue;
            }

            return convertedValue;
        }
        /// <summary>
        /// 删除html内容
        /// </summary>
        /// <param name="instance"></param>
        /// <returns></returns>
        public static string StripHtml(this string instance)
        {
            return stripHTMLExpression.Replace(instance, string.Empty);
        }
        /// <summary>
        /// 是否是email地址
        /// </summary>
        /// <param name="instance"></param>
        /// <returns></returns>
        public static bool IsEmail(this string instance)
        {
            return !string.IsNullOrWhiteSpace(instance) && emailExpression.IsMatch(instance);
        }
        /// <summary>
        /// 是否是url
        /// </summary>
        /// <param name="instance"></param>
        /// <returns></returns>
        public static bool IsWebUrl(this string instance)
        {
            return !string.IsNullOrWhiteSpace(instance) && webUrlExpression.IsMatch(instance);
        }

        /// <summary>
        /// 转换为bool
        /// </summary>
        /// <param name="instance"></param>
        /// <returns></returns>
        public static bool AsBool(this string instance)
        {
            bool result = false;
            bool.TryParse(instance, out result);
            return result;
        }
        /// <summary>
        /// 转换为日期时间型
        /// </summary>
        /// <param name="instance"></param>
        /// <returns></returns>
        public static DateTime AsDateTime(this string instance)
        {
            DateTime result = DateTime.MinValue;
            DateTime.TryParse(instance, out result);
            return result;
        }
        /// <summary>
        /// 转换为Decima
        /// </summary>
        /// <param name="instance"></param>
        /// <returns></returns>
        public static Decimal AsDecimal(this string instance)
        {
            var result = (decimal)0.0;
            Decimal.TryParse(instance, out result);
            return result;
        }
        /// <summary>
        /// 转换为整型
        /// </summary>
        /// <param name="instance"></param>
        /// <returns></returns>
        public static int AsInt(this string instance)
        {
            var result = (int)0;
            int.TryParse(instance, out result);
            return result;
        }
        /// <summary>
        /// 是否是Int整型
        /// </summary>
        /// <param name="instance"></param>
        /// <returns></returns>
        public static bool IsInt(this string instance)
        {
            int result;
            return int.TryParse(instance, out result);
        }
        /// <summary>
        /// 是否是DateTime日期时间型
        /// </summary>
        /// <param name="instance"></param>
        /// <returns></returns>
        public static bool IsDateTime(this string instance)
        {
            DateTime result;
            return DateTime.TryParse(instance, out result);
        }
        /// <summary>
        /// 是否是Float浮点型
        /// </summary>
        /// <param name="instance"></param>
        /// <returns></returns>
        public static bool IsFloat(this string instance)
        {
            float result;
            return float.TryParse(instance, out result);
        }
        /// <summary>
        /// 是否为空或空白
        /// </summary>
        /// <param name="instance"></param>
        /// <returns></returns>
        public static bool IsNullOrWhiteSpace(this string instance)
        {
            return string.IsNullOrWhiteSpace(instance);
        }
        /// <summary>
        /// 是否为不空或空白
        /// </summary>
        /// <param name="instance"></param>
        /// <returns></returns>
        public static bool IsNotNullAndWhiteSpace(this string instance)
        {
            return !string.IsNullOrWhiteSpace(instance);
        }

        /// <summary>
        /// 是否为空
        /// </summary>
        /// <param name="theString"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string theString)
        {
            return string.IsNullOrEmpty(theString);
        }
        /// <summary>
        /// 字符串第一个字符大写
        /// </summary>
        /// <param name="instance"></param>
        /// <returns></returns>
        public static string FirstCharToLowerCase(this string instance)
        {
            if (instance.IsNotNullAndWhiteSpace() && instance.Length > 2 && char.IsUpper(instance[0]))
            {
                return char.ToLower(instance[0]) + instance.Substring(1);
            }
            if (instance.Length == 2)
            {
                return instance.ToLower();
            }
            return instance;
        }
        /// <summary>
        /// 文件路径
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string ToFilePath(this string path)
        {
            return string.Join(Path.DirectorySeparatorChar.ToString(), path.Split(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar));
        }

        #region 文件路径转换
        /// <summary>
        /// 文件路径转换
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <returns></returns>
        public static string ReplacePath(this string path)
        {
            bool _windows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
            if (string.IsNullOrEmpty(path))
                return "";
            if (_windows)
                return path.Replace("/", "\\");
            return path.Replace("\\", "/");

        }
        #endregion
        /// <summary>
        /// 文件路径拼接
        /// </summary>
        /// <param name="p">原有文件路径</param>
        /// <param name="path">新文件路径</param>
        /// <returns></returns>
        public static string CombinePath(this string p,string path)
        {
            return p + Path.DirectorySeparatorChar + path;
        }

        /// <summary>
        /// 将JSON字符串还原为对象
        /// </summary>
        /// <typeparam name="T">要转换的目标类型</typeparam>
        /// <param name="json">JSON字符串 </param>
        /// <returns></returns>
        public static T FromJsonString<T>(this string json)
        {
            
            return JsonConvert.DeserializeObject<T>(json);
        }

        /// <summary>
        /// 将JSON字符串还原为对象
        /// </summary>
        /// <param name="json">JSON字符串 </param>
        /// <param name="type">数据类型</param>
        public static object FromJsonString(this string json, Type type)
        {
            return JsonConvert.DeserializeObject(json, type);
        }


        #region Base64加密解密
        /// <summary>
        /// Base64加密，采用指定字符编码方式加密。
        /// </summary>
        /// <param name="input">待加密的明文</param>
        /// <param name="encode">字符编码</param>
        /// <returns></returns>
        public static string Base64Encrypt(this string input, Encoding encode)
        {
            return Convert.ToBase64String(encode.GetBytes(input));
        }

        /// <summary>
        /// Base64加密，采用UTF8编码方式加密。
        /// </summary>
        /// <param name="input">待加密的明文</param>
        /// <returns></returns>
        public static string Base64Encrypt(this string input)
        {
            return Base64Encrypt(input, new UTF8Encoding());
        }

        /// <summary>
        /// Base64解密，采用UTF8编码方式解密。
        /// </summary>
        /// <param name="input">待解密的秘文</param>
        /// <returns></returns>
        public static string Base64Decrypt(this string input)
        {
            return Base64Decrypt(input, new UTF8Encoding());
        }

        /// <summary>
        /// Base64解密，采用指定字符编码方式解密。
        /// </summary>
        /// <param name="input">待解密的秘文</param>
        /// <param name="encode">字符的编码</param>
        /// <returns></returns>
        public static string Base64Decrypt(this string input, Encoding encode)
        {
            return encode.GetString(Convert.FromBase64String(input));
        }
        #endregion
    }
}
