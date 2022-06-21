using Microsoft.AspNetCore.Builder;
using Yuebon.Commons.Log;
using Yuebon.Quartz.Jobs;
using Yuebon.Security.IServices;

namespace Yuebon.Extensions.Middlewares;

/// <summary>
/// Quartz 启动服务
/// </summary>
public static class QuartzJobMiddleware
{
    public static async void UseQuartzJobMiddleware(this IApplicationBuilder app, ITaskManagerService tasksQzServices, ISchedulerCenter schedulerCenter)
    {
        if (app == null) throw new ArgumentNullException(nameof(app));

        try
        {
            if (Appsettings.app("Middleware", "QuartzNetJob", "Enabled").ObjToBool())
            {
                CancellationToken cancellationToken = CancellationToken.None;
              await new QuartzService(schedulerCenter, tasksQzServices).StartAsync(cancellationToken);

            }
        }
        catch (Exception e)
        {
            Log4NetHelper.Error($"An error was reported when starting the job service.\n{e.Message}");
            throw;
        }
    }
}