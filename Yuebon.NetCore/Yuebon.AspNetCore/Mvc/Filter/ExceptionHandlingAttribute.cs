using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yuebon.AspNetCore.Common;
using Yuebon.AspNetCore.Models;
using Yuebon.Commons.Log;
using Yuebon.Commons.Models;

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
            Log4NetHelper.Error(type, "全局捕获程序运行异常信息", context.Exception);
            if (exception is MyApiException myApiex)
            {
                context.HttpContext.Response.StatusCode = 200;
                context.ExceptionHandled = true;
                context.Result = new JsonResult(new CommonResult(myApiex.Msg, myApiex.ErrCode));
            }
            else
            {
                context.Result = new JsonResult(new CommonResult("程序异常,服务端出现异常![异常消息]"+exception.Message, ErrCode.err40110));
            }
        }
    }
}
