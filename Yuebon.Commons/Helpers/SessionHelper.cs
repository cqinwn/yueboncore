﻿using Microsoft.AspNetCore.Http;
using System.Text;
using Yuebon.Commons.Extensions;

namespace Yuebon.Commons.Helpers
{
    /// <summary>
    /// Session帮助类，可在非controler中读取或保存session
    /// </summary>
    public static class SessionHelper
    {
        /// <summary>
        /// 
        /// </summary>
        public static HttpContext HttpHelper => HttpContextHelper.HttpContext;
        /// <summary>
        /// 设置 Session
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void SetSession(string key, object value)
        {
            HttpHelper.Session.Set(key, value);
        }

        /// <summary>
        /// 获取 Session
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T GetSession<T>(string key)
        {
            return HttpHelper.Session.Get<T>(key);
        }

        /// <summary>
        /// 获取 Session
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetString(string key)
        {
            return HttpHelper.Session.GetString(key);
        }
    }
}
