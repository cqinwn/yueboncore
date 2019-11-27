using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yuebon.Commons.Log;

namespace Yuebon.AspNetCore.Mvc.Filter
{
    /// <summary>
    /// 表示一个特性，该特性用于全局捕获程序运行异常信息。
    /// </summary>
    public class ExceptionHandlingAttribute : ExceptionFilterAttribute
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public override void OnException(ExceptionContext context)
        {
            var exception = context.Exception;

            string requestHost = context.HttpContext.Request.Host.ToString();
            string requestPath = context.HttpContext.Request.Path.ToString();
            string queryString = context.HttpContext.Request.QueryString.ToString();
            var type = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType;
            Log4NetHelper.WriteWarn(type, context.Exception);
           // _logger.LogWarning(new EventId(exception.HResult), exception, exception.Message);
            context.ExceptionHandled = true;
        }
    }
}
