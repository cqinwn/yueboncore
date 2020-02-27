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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filterContext"></param>
        public void OnException(ExceptionContext filterContext)
        {
            Log4NetHelper.Error("全局过滤器异常",filterContext.Exception);
        }
    }
}
