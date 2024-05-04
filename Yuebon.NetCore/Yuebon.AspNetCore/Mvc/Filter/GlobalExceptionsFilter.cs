using UAParser;
using Yuebon.Security.IServices;
using Yuebon.Security.Models;

namespace Yuebon.AspNetCore.Mvc.Filter;

/// <summary>
/// 表示一个特性，该特性用于全局捕获程序运行异常信息。
/// </summary>
public class GlobalExceptionsFilter : IExceptionFilter
{

    private readonly ILogService _service;
    /// <summary>
    /// 
    /// </summary>
    /// <param name="service"></param>
    public GlobalExceptionsFilter(ILogService service)
    {
        _service = service;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="context"></param>
    public  void OnException(ExceptionContext context)
    {
        var exception = context.Exception;

        var httpContext = context.HttpContext;
        var httpRequest = httpContext.Request;
        var type = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType;
        CommonResult result = new CommonResult();
        if (exception is MyApiException myApiex)
        {
            context.HttpContext.Response.StatusCode = 200;
            context.ExceptionHandled = true;
            result.ErrMsg = myApiex.Msg;
            result.ErrCode = myApiex.ErrCode;
        }
        else
        {
            result.ErrMsg = "程序异常,服务端出现异常![异常消息]" + exception.Message;
            result.ErrCode = "500";
        }
        Log4NetHelper.Error(type, "全局捕获程序运行异常信息\n\r" , context.Exception);
        JsonSerializerOptions options = new JsonSerializerOptions()
        {
            WriteIndented = true,                                   //格式化json字符串
            AllowTrailingCommas = true,                             //可以结尾有逗号
            //IgnoreNullValues = true,                              //可以有空值,转换json去除空值属性
            IgnoreReadOnlyProperties = true,                        //忽略只读属性
            PropertyNameCaseInsensitive = true,                     //忽略大小写
                                                                    //PropertyNamingPolicy = JsonNamingPolicy.CamelCase     //命名方式是默认还是CamelCase
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
        };
        options.Converters.Add(new DateTimeJsonConverter("yyyy-MM-dd HH:mm:ss"));
        context.Result = new JsonResult(result, options);
        var headers = httpRequest.Headers;
        var clientInfo = headers.ContainsKey("User-Agent") ? Parser.GetDefault().Parse(headers["User-Agent"]) : null;
        var actionDescriptor = context.ActionDescriptor as ControllerActionDescriptor;
        var ip = httpContext.GetClientUserIp();
        Log logEntity = new Log()
        {
            Date = DateTime.Now,
            Account = Appsettings.UserClaims?.FindFirstValue(YuebonClaimConst.UserName),
            RealName = Appsettings.UserClaims?.FindFirstValue(YuebonClaimConst.RealName),
            IPAddress = ip,
            RequestUrl = httpRequest.Path,
            OS = clientInfo.OS.Family + clientInfo.OS.Major,
            Browser = clientInfo.UA.Family + clientInfo.UA.Major,
            MethodName = actionDescriptor?.ActionName,
            RequestMethod = httpRequest.Method,
            ExceptionType = exception.GetType().Name,
            Description = $"异常信息：{exception.Message} \r\n【堆栈调用】：\r\n{exception.StackTrace}"
        };

        _service.Insert(logEntity);
    }
}
