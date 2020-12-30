using Microsoft.AspNetCore.Mvc.Filters;
using StackExchange.Profiling;
using StackExchange.Profiling.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yuebon.Commons.IoC;
using Yuebon.Commons.Log;
using Yuebon.Security.IRepositories;
using Yuebon.Security.IServices;
using Yuebon.Security.Models;
using Yuebon.Security.Repositories;

namespace Yuebon.AspNetCore.Mvc.Filter
{
    /// <summary>
    /// 
    /// </summary>
    public class ActionFilter : IAsyncActionFilter
    {

         ILogService _logService = IoCContainer.Resolve<ILogService>();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var profiler = MiniProfiler.StartNew("StartNew");
            using (profiler.Step("Level1"))
            {
                //执行Action
                await next();
            }
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
                    dg(root.Children);
                }
            }
        }

        private void dg(List<Timing> chil)
        {
            chil.ForEach(chill =>
            {
                if (chill.CustomTimings?.Count > 0)
                {
                    StringBuilder logSql = new StringBuilder();
                    foreach (var customTiming in chill.CustomTimings)
                    {
                        var all_sql = new List<string>();
                        var err_sql = new List<string>();
                        var all_log = new List<string>();
                        int i = 1;
                        customTiming.Value?.ForEach(value =>
                        {
                            if (value.ExecuteType != "OpenAsync"&& !value.CommandString.Contains("Connection"))
                            {
                                logSql.Append($"【{customTiming.Key}{i++}】{value.CommandString} 耗时 :{value.DurationMilliseconds} ms,状态 :{(value.Errored?"失败":"成功")}");
                               
                            }
                        });
                    }
                    Log logEntity = new Log();
                    logEntity.Date = logEntity.CreatorTime = DateTime.Now;
                    logEntity.Type = "SQL";
                    logEntity.Result = true;
                    logEntity.Description = logSql.ToString();
                    _logService.Insert(logEntity);
                    //Log4NetHelper.Info(log.ToString());
                }
                else
                {
                    if (chill.Children!=null)
                    {
                        dg(chill.Children);
                    }
                }
            });
        }
    }
}
