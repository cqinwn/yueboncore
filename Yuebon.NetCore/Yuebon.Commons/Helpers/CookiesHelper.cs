using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Yuebon.Commons.Helpers
{
    /// <summary>
    /// Cookie操作类
    /// </summary>
    public static class CookiesHelper
    {
        /// <summary>
        /// 
        /// </summary>
        public static HttpContext HttpHelper => HttpContextHelper.HttpContext;
        /// <summary>
        /// Cookie名称
        /// </summary>
        public static string CookieName { get; set; } = "yuebon_";

        /// <summary>
        /// 设置Cookie键
        /// </summary>
        /// <param name="cookieName">键</param>
        /// <returns></returns>
        private static string CookieKey(string cookieName)
        {
            return CookieName+ cookieName;
        }
        /// <summary>
        /// 删除Cookie
        /// </summary>
        /// <param name="context"></param>
        /// <param name="cookieName">Coookie名称</param>
        public static void DeleteCookie(HttpContext context, string cookieName)
        {
            string key = CookieKey(cookieName);
            context.Response.Cookies.Delete(key);
        }
        /// <summary>
        /// 写/保存Cookie
        /// </summary>
        /// <param name="context"></param>
        /// <param name="cookieName">Coookie名称</param>
        /// <param name="value">Coookie值</param>
        /// <param name="months">有效月数</param>
        public static void WriteCookie(HttpContext context, string cookieName, string value, int months)
        {
            WriteCookie(context, cookieName, value, months, 0);
        }

        /// <summary>
        /// 写/保存Cookie
        /// </summary>
        /// <param name="cookieName">Coookie名称</param>
        /// <param name="value">Coookie值</param>
        /// <param name="months">有效月数</param>
        public static void WriteCookie(string cookieName, string value, int months)
        {
            WriteCookie(HttpHelper, cookieName, value, months, 0);
        }
        /// <summary>
        /// 写/保存Cookie
        /// </summary>
        /// <param name="context"></param>
        /// <param name="cookieName">Coookie名称</param>
        /// <param name="value">Coookie值</param>
        /// <param name="months">有效月数</param>
        /// <param name="days">有效天数</param>
        public static void WriteCookie(HttpContext context, string cookieName, string value, int months, int days)
        {
            string key = CookieKey(cookieName);
            if (!context.Request.Cookies.ContainsKey(key))
            {
                DateTime expires = DateTime.Today.AddDays(30 * months + days);
                DateTimeOffset dateAndOffset = new DateTimeOffset(expires,
                                            TimeZoneInfo.Local.GetUtcOffset(expires));

                context.Response.Cookies.Append(key, value,
                    new CookieOptions
                    {
                        Expires = expires
                    });
            }
        }
        /// <summary>
        /// 获取Cookie值
        /// </summary>
        /// <param name="context"></param>
        /// <param name="cookieName">Coookie名称</param>
        /// <returns></returns>
        public static string ReadCookie(HttpContext context, string cookieName)
        {
            string key = CookieKey(cookieName);

            try
            {
                return System.Net.WebUtility.UrlDecode(context.Request.Cookies[key]);
            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        /// 获取Cookie值
        /// </summary>
        /// <param name="cookieName">Coookie名称</param>
        /// <returns></returns>
        public static string ReadCookie(string cookieName)
        {
            string key = CookieKey(cookieName);

            try
            {
                return System.Net.WebUtility.UrlDecode(HttpHelper.Request.Cookies[key]);
            }
            catch
            {
                return "";
            }
        }
    }
}
