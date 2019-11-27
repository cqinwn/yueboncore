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
        public static string CookieName { get; set; } = "";
        public static string LoginCookieName { get; set; } = "ll";

        private static string CookieKey(string cookieName)
        {
            return cookieName + CookieName;
        }

        public static void DeleteCookie(HttpContext context, string cookieName)
        {
            string key = CookieKey(cookieName);

            context.Response.Cookies.Delete(key);
        }

        public static void WriteCookie(HttpContext context, string cookieName, string value, int months)
        {
            WriteCookie(context, cookieName, value, months, 0);
        }

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
    }
}
