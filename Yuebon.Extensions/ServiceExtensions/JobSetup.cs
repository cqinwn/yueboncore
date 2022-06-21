﻿using Microsoft.Extensions.DependencyInjection;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;
using Yuebon.Quartz.Jobs;

namespace Yuebon.Extensions.ServiceExtensions;

/// <summary>
/// 任务调度 启动服务
/// </summary>
public static class JobSetup
{
    public static void AddJobSetup(this IServiceCollection services)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));
        services.AddSingleton<IJobFactory, JobFactory>();
        services.AddSingleton<ISchedulerCenter, SchedulerCenter>();
        //任务注入
        var baseType = typeof(IJob);
        var path = AppDomain.CurrentDomain.RelativeSearchPath ?? AppDomain.CurrentDomain.BaseDirectory;
        var referencedAssemblies = System.IO.Directory.GetFiles(path, "Yuebon.Quartz.Jobs.dll").Select(Assembly.LoadFrom).ToArray();
        var types = referencedAssemblies
            .SelectMany(a => a.DefinedTypes)
            .Select(type => type.AsType())
            .Where(x => x != baseType && baseType.IsAssignableFrom(x)).ToArray();
        var implementTypes = types.Where(x => x.IsClass).ToArray();
        foreach (var implementType in implementTypes)
        {
            services.AddSingleton(implementType);
        }
    }
}
