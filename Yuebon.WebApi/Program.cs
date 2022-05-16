using AutoMapper;
using log4net;
using log4net.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Quartz;
using Quartz.Impl;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using Yitter.IdGenerator;
using Yuebon.AspNetCore.Common;
using Yuebon.AspNetCore.Mvc.Filter;
using Yuebon.Commons.Core.App;
using Yuebon.Commons.Core.UnitOfWork;
using Yuebon.Commons.Extensions;
using Yuebon.Commons.Filters;
using Yuebon.Commons.Helpers;
using Yuebon.Commons.Log;
using Yuebon.Commons.Module;
using Yuebon.Commons.SeedInitData;
using Yuebon.Quartz.Jobs;
using static Yuebon.Commons.Extensions.SwaggerVersions;

var builder = WebApplication.CreateBuilder(args);

#region 1、配置host与容器
builder.Host
.ConfigureLogging((hostingContext, builder) =>
{
    builder.AddFilter("System", LogLevel.Error);
    builder.AddFilter("Microsoft", LogLevel.Error);
    builder.SetMinimumLevel(LogLevel.Error);
    builder.AddLog4Net(Path.Combine(Directory.GetCurrentDirectory(), "Log4net.config"));
})
.ConfigureAppConfiguration((hostingContext, config) =>
{
    config.Sources.Clear();
    config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: false);
});


ILoggerRepository loggerRepository = LogManager.CreateRepository("NETCoreRepository");
Log4NetHelper.SetConfig(loggerRepository, "log4net.config");
#endregion

#region 2、配置服务

builder.Services.AddSingleton(new Appsettings(builder.Configuration));
//builder.Services.AddSingleton(new LogLog(builder.Environment.ContentRootPath));
builder.Services.AddUiFilesZipSetup(builder.Environment);
//HttpContext 相关服务
builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddHttpContextAccessor();

builder.Services.AddRedisCacheSetup();

#region MiniProfiler
builder.Services.AddMiniProfilerSetup();
#endregion

builder.Services.AddSqlsugarSetup();


// Api多版本版本配置
builder.Services.AddApiVersioning(o =>
{
    o.ReportApiVersions = true;//是否在请求头中返回受支持的版本信息。
    o.AssumeDefaultVersionWhenUnspecified = true;//请求没有指明版本的情况下是否使用默认的版本。
    o.DefaultApiVersion = new ApiVersion(1, 0);//默认的版本号。
    o.ApiVersionReader = ApiVersionReader.Combine(new HeaderApiVersionReader("api-version"));////版本信息放到header ,不写在不配置路由的情况下，版本信息放到response url 中
}).AddVersionedApiExplorer();


builder.Services.AddSwaggerSetup();
builder.Services.AddAuthorizationSetup();

////如果部署在linux系统上，需要加上下面的配置：
//builder.Services.Configure<KestrelServerOptions>(options => options.AllowSynchronousIO = true);
////如果部署在IIS上，需要加上下面的配置：
//builder.Services.AddOptions();
//builder.Services.Configure<IISServerOptions>(options => options.AllowSynchronousIO = true);
builder.Services.Configure<KestrelServerOptions>(x => x.AllowSynchronousIO = true)
        .Configure<IISServerOptions>(x => x.AllowSynchronousIO = true);

#region 全局设置跨域访问
//允许所有跨域访问，测试用
builder.Services.AddCors(options => options.AddPolicy("yuebonCors",
    policy => policy.WithOrigins("*").AllowAnyHeader().AllowAnyMethod()));
// 跨域设置 建议正式环境
//services.AddCors(options => options.AddPolicy("yuebonCors",
//    policy => policy.WithOrigins(Configuration.GetSection("AppSetting:AllowOrigins").Value.Split(',', StringSplitOptions.RemoveEmptyEntries)).AllowAnyHeader().AllowAnyMethod()));
#endregion

#region 健康检查
builder.Services.AddHealthChecks();
#endregion

#region 控制器
builder.Services.AddControllers(c =>
{
    c.Filters.Add(new ExceptionHandlingAttribute());
    c.Conventions.Add(new GlobalRoutePrefixFilter(new RouteAttribute("")));
}).AddJsonOptions(options =>
{
    options.JsonSerializerOptions.WriteIndented = true;
    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    //设置时间格式
    options.JsonSerializerOptions.Converters.Add(new DateTimeJsonConverter());
    options.JsonSerializerOptions.Converters.Add(new DateTimeNullableConverter());
    //设置bool获取格式
    options.JsonSerializerOptions.Converters.Add(new BooleanJsonConverter());
    //设置Decimal获取格式
    options.JsonSerializerOptions.Converters.Add(new DecimalJsonConverter());
    //设置数字
    options.JsonSerializerOptions.Converters.Add(new IntJsonConverter());
    options.JsonSerializerOptions.Converters.Add(new LongJsonConverter());
    options.JsonSerializerOptions.PropertyNamingPolicy = new UpperFirstCaseNamingPolicy();
    options.JsonSerializerOptions.Encoder = JavaScriptEncoder.Create(UnicodeRanges.All);
});


builder.Services.AddMvcCore().AddApiExplorer();
builder.Services.AddEndpointsApiExplorer();

#endregion

builder.Services.AddAutoScanInjection();//自动化注入仓储和服务


#region automapper
List<Assembly> myAssembly = RuntimeHelper.GetAllYuebonAssemblies().ToList();
builder.Services.AddAutoMapper(myAssembly);
builder.Services.AddTransient<IMapper, Mapper>();
#endregion

#region 定时任务
builder.Services.AddTransient<HttpResultfulJob>();
builder.Services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();
////设置定时启动的任务
//builder.Services.AddHostedService<QuartzService>();
#endregion

builder.Services.AddSingleton<IUnitOfWork, UnitOfWork>();
Appsettings.Services = builder.Services;
//雪花算法配置
YitIdHelper.SetIdGenerator(new IdGeneratorOptions()
{
    WorkerId = 1,
    WorkerIdBitLength = 10,
    SeqBitLength = 6,
    DataCenterIdBitLength = 1,
    TopOverCostCount = 2000,
    //TimestampType = 1,
    // MinSeqNumber = 1,
    // MaxSeqNumber = 200,
    // BaseTime = DateTime.Now.AddYears(-10),
});


#endregion

#region 3、配置中间件
var app = builder.Build();

AutoMapperService.UsePack(app.Services);
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    //app.UseHsts();
}
//开启性能分析
app.UseMiniProfiler();
app.UseApiVersioning();
#region 启用swaggerUI
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.DocumentTitle = Appsettings.Configuration.GetSection("SwaggerDoc:Title").Value;
    typeof(ApiVersions).GetEnumNames().OrderByDescending(e => e).ToList().ForEach(version =>
    {
        options.SwaggerEndpoint($"/swagger/{version}/swagger.json", $"{Appsettings.Configuration.GetSection("SwaggerDoc:Title").Value + version.ToUpperInvariant()}");
        options.RoutePrefix = string.Empty;//这里主要是不需要再输入swagger这个默认前缀
    });
    options.HeadContent = "<script async id=\"mini-profiler\" src=\"/mini-profiler-resources/includes.min.js?v=4.2.22+b27bea37e9\" data-version=\"4.2.22+b27bea37e9\" data-path=\"/mini-profiler-resources/\" data-current-id=\"144b1192-acd3-4fe2-bbc5-6f1e1c6d53df\" data-ids=\"87a1341b-995d-4d1d-aaba-8f2bfcfc9ca9,144b1192-acd3-4fe2-bbc5-6f1e1c6d53df\" data-position=\"Left\" data-scheme=\"Light\" data-authorized=\"true\" data-max-traces=\"15\" data-toggle-shortcut=\"Alt+P\" data-trivial-milliseconds=\"2.0\" data-ignored-duplicate-execute-types=\"Open,OpenAsync,Close,CloseAsync\"></script>";
});
#endregion
app.UseHealthChecks("/Health");
app.UseStaticHttpContextAccessor();

app.Use((context, next) =>
{
    context.Request.EnableBuffering();
    return next();
});
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
//跨域
app.UseMiddleware<CorsMiddleware>();
app.UseCors("yuebonCors");

app.UseStatusCodePages();

app.MapControllers();
#endregion

#region 初始化
if (Appsettings.GetValue("AppSetting:SeedDBEnabled").ObjToBool() || Appsettings.GetValue("AppSetting:SeedDBDataEnabled").ObjToBool())
{
    DBSeedService.SeedAsync(new List<string> { "Yuebon.Security.Core.dll", "Yuebon.CMS.Core.dll", "Yuebon.Tenants.Core.dll", "Yuebon.Quartz.Jobs.dll" }).Wait();
}
#endregion

//new DefaultInitial().CacheAppList();
// 4、运行
app.Run();
