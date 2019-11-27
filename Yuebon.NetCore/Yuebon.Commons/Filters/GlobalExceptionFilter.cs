using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.Filters;
using Yuebon.Commons.Log;

namespace Yuebon.Commons.Filters
{
    /// <summary>
    /// 异常过滤器，将异常写入日志
    /// </summary>
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            var type = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType;
            Log4NetHelper.WriteWarn(type, filterContext.Exception);
        }
    }
}
