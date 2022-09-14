using MediatR;
using StackExchange.Profiling;
using System.Diagnostics;
using UAParser;
using Yuebon.Security.Models;
using Yuebon.Security.Services.CommandHandlers;

namespace Yuebon.AspNetCore.Mvc.Filter;

/// <summary>
/// 请求拦截操作
/// </summary>
public class RequestActionFilter : IAsyncActionFilter
{
    private readonly IMediator _mediator;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="mediator"></param>
    public RequestActionFilter(IMediator mediator)
    {
        _mediator = mediator;
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="context"></param>
    /// <param name="next"></param>
    /// <returns></returns>
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var sw = new Stopwatch();
        var profiler = MiniProfiler.StartNew("StartNew");
        sw.Start();
        var actionContext = await next();
        sw.Stop();
        profiler.Stop();
        var httpContext = context.HttpContext;
        var httpRequest = httpContext.Request;

        var isRequestSucceed = actionContext.Exception == null; // 判断是否请求成功（没有异常就是成功）
        var headers = httpRequest.Headers;
        var clientInfo = headers.ContainsKey("User-Agent") ? Parser.GetDefault().Parse(headers["User-Agent"]) : null;
        var actionDescriptor = context.ActionDescriptor as ControllerActionDescriptor;
        var ip = httpContext.GetClientUserIp();
        VisitLog visitLog= new VisitLog()
        {
            Date = DateTime.Now.AddMilliseconds(-sw.ElapsedMilliseconds),
            Account = Appsettings.UserClaims?.FindFirstValue(YuebonClaimConst.UserName),
            RealName = Appsettings.UserClaims?.FindFirstValue(YuebonClaimConst.RealName),
            IPAddress = ip,
            RequestUrl = httpRequest.Path,
            OS = clientInfo.OS.Family + clientInfo.OS.Major,
            Browser = clientInfo.UA.Family + clientInfo.UA.Major,
            ModuleName = context.Controller.ToString(),
            MethodName = actionDescriptor?.ActionName,
            RequestMethod = httpRequest.Method,
            ElapsedTime = sw.ElapsedMilliseconds,
            RequestParameter = context.ActionArguments.Count < 1 ? string.Empty : JsonSerializer.Serialize(context.ActionArguments),
            Result = isRequestSucceed,
            Id = IdGeneratorHelper.IdSnowflake()
        };
        VisitLogCommand visitLogCommand = new VisitLogCommand()
        {
            VisitLogInput = visitLog
        };
        await _mediator.Send(visitLogCommand);
        //_eventBus.Publish(new VisitLogIntegrationEvent()
        //{
        //    Date = DateTime.Now.AddMilliseconds(-sw.ElapsedMilliseconds),
        //    Account = Appsettings.UserClaims?.FindFirstValue(YuebonClaimConst.UserName),
        //    RealName = Appsettings.UserClaims?.FindFirstValue(YuebonClaimConst.RealName),
        //    IPAddress = ip,
        //    RequestUrl = httpRequest.Path,
        //    OS = clientInfo.OS.Family + clientInfo.OS.Major,
        //    Browser = clientInfo.UA.Family + clientInfo.UA.Major,
        //    ModuleName = context.Controller.ToString(),
        //    MethodName = actionDescriptor?.ActionName,
        //    RequestMethod = httpRequest.Method,
        //    ElapsedTime = sw.ElapsedMilliseconds,
        //    RequestParameter = context.ActionArguments.Count < 1 ? string.Empty : JsonSerializer.Serialize(context.ActionArguments),
        //    //Description = (actionContext.Result?.GetType() == typeof(ContentResult)) ? actionContext.Result.ToJson() : string.Empty,
        //    Result = isRequestSucceed,
        //    PreId = IdGeneratorHelper.IdSnowflake()
        //});
        WriteLog(profiler);
    }

    /// <summary>
    /// sql跟踪
    /// 下载：MiniProfiler.AspNetCore
    /// </summary>
    /// <param name="profiler"></param>
    private void WriteLog(MiniProfiler profiler)
    {
        if (profiler?.Root != null)
        {
            var root = profiler.Root;
            if (root.HasChildren)
            {
                GetSqlLog(root.Children);
            }
        }
    }
    /// <summary>
    /// 递归获取MiniProfiler内容
    /// </summary>
    /// <param name="chil"></param>
    private void GetSqlLog(List<Timing> chil)
    {
        chil.ForEach(chill =>
        {
            if (chill.CustomTimings?.Count > 0)
            {
                List<SqlLog> logList = new List<SqlLog>();
                foreach (var customTiming in chill.CustomTimings)
                {
                    int i = 1;
                    customTiming.Value?.ForEach(value =>
                    {
                        if (value.ExecuteType != "OpenAsync" && !value.CommandString.Contains("Connection"))
                        {
                            logList.Add(new SqlLog()
                            {
                                CreatorTime = DateTime.Now,
                                Account = Appsettings.UserClaims?.FindFirstValue(YuebonClaimConst.UserName),
                                Result=value.Errored?false:true,
                                ElapsedTime=value.DurationMilliseconds,
                                Description = $"【{customTiming.Key}{i++}】{value.CommandString}",
                            });
                        }
                    });
                }

                SqlLogCommand sqlLogCommand = new SqlLogCommand()
                {
                    SqlLogInputs = logList
                };
                _mediator.Send(sqlLogCommand);
            }
            else
            {
                if (chill.Children!=null)
                {
                    GetSqlLog(chill.Children);
                }
            }
        });
    }
}
