using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Yuebon.Commons.Helpers
{
    /// <summary>
    /// HttpContext注入类
    /// </summary>
    public static class HttpContextHelper
    {
        private static IHttpContextAccessor httpContextAccessor;
        public static void Configure(IHttpContextAccessor _httpContextAccessor)
        {
            httpContextAccessor = _httpContextAccessor;
        }

        public static HttpContext HttpContext => httpContextAccessor.HttpContext;

    }
}
