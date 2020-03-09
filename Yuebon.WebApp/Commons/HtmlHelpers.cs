using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yuebon.WebApp.Commons
{
    /// <summary>
    /// HTML辅助类方法是通过扩展静态方法进行实现
    /// </summary>
    public static class HtmlHelpers
    {
        public static bool HasFunction(this IHtmlHelper helper, string functionId)
        {
            return new Permission().HasFunction(functionId);
        }

        public static bool IsAdmin()
        {
            return new Permission().IsAdmin();
        }
    }
}
