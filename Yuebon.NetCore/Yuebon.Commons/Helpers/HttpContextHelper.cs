using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Yuebon.Commons.Helpers
{
    /// <summary>
    /// HttpContext帮助类
    /// </summary>
    public static class HttpContextHelper
    {
        /// <summary>
        /// 
        /// </summary>
        private static IHttpContextAccessor httpContextAccessor;
        /// <summary>
        /// 注入
        /// </summary>
        /// <param name="_httpContextAccessor"></param>
        public static void Configure(IHttpContextAccessor _httpContextAccessor)
        {
            httpContextAccessor = _httpContextAccessor;
        }
        /// <summary>
        /// 
        /// </summary>
        public static HttpContext HttpContext => httpContextAccessor.HttpContext;

    }
}
