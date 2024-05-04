using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Runtime.InteropServices;
using Yuebon.Commons.Filters;
using Yuebon.Commons.Log;
using static Yuebon.Extensions.ServiceExtensions.SwaggerVersions;
using Asp.Versioning;

namespace Yuebon.Extensions.ServiceExtensions;

/// <summary>
/// Swagger 启动服务
/// </summary>
public static class SwaggerSetup
{

    private static readonly ILog log =LogManager.GetLogger(typeof(SwaggerSetup));
    /// <summary>
    /// 
    /// </summary>
    /// <param name="services"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public static void AddSwaggerSetup(this IServiceCollection services)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));
        // Api多版本版本配置
        services.AddApiVersioning(o =>
        {
            o.ReportApiVersions = true;//是否在请求头中返回受支持的版本信息。
            o.AssumeDefaultVersionWhenUnspecified = true;//请求没有指明版本的情况下是否使用默认的版本。
            o.DefaultApiVersion = new ApiVersion(1, 0);//默认的版本号。
            o.ApiVersionReader = ApiVersionReader.Combine(new HeaderApiVersionReader("api-version"));////版本信息放到header ,不写在不配置路由的情况下，版本信息放到response url 中
        }).AddApiExplorer();

        services.AddSwaggerGen(options =>
        {
            string contactName = Appsettings.Configuration.GetSection("SwaggerDoc:ContactName").Value;
            string contactNameEmail = Appsettings.Configuration.GetSection("SwaggerDoc:ContactEmail").Value;
            string contactUrl = Appsettings.Configuration.GetSection("SwaggerDoc:ContactUrl").Value;
            string termsOfService= Appsettings.Configuration.GetSection("SwaggerDoc:TermsOfService").Value;

            //遍历出全部的版本，做文档信息展示
            typeof(ApiVersions).GetEnumNames().ToList().ForEach(version =>
            {
                options.SwaggerDoc(version,
                     new OpenApiInfo()
                     {
                         Title = $"{Appsettings.Configuration.GetSection("SwaggerDoc:Title").Value}-{RuntimeInformation.FrameworkDescription}",
                         Version = $"{ version}",
                         TermsOfService = new Uri(termsOfService),
                         Description = Appsettings.Configuration.GetSection("SwaggerDoc:Description").Value,
                         Contact = new OpenApiContact { Name = contactName, Email = contactNameEmail, Url = new Uri(contactUrl) },
                         License = new OpenApiLicense { Name = "Apache 2.0", Url = new Uri("https://www.apache.org/licenses/LICENSE-2.0") }
                     }
                ); ;
            });
            //options.IgnoreObsoleteActions();//忽略掉废弃接接口，即不展示
            //options.IgnoreObsoleteProperties();//废弃接接口
            options.UseInlineDefinitionsForEnums();
            try
            {
                Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.xml").ToList().ForEach(file =>
                {
                    options.IncludeXmlComments(file, true);
                });
            }
            catch (Exception ex)
            {
                Log4NetHelper.Error("请检查并拷贝。\n" + ex.Message);
            }
            //给api添加token令牌证书
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "JWT授权(数据将在请求头中进行传输) 直接在下框中输入Bearer {token}（注意两者之间是一个空格）\"",
                Name = "Authorization",//jwt默认的参数名称
                In = ParameterLocation.Header,//jwt默认存放Authorization信息的位置(请求头中)
                Type = SecuritySchemeType.ApiKey,
                BearerFormat = "JWT",
                Scheme = "Bearer"
            });

            //添加安全请求
            options.AddSecurityRequirement(
                new OpenApiSecurityRequirement {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference=new OpenApiReference{
                                Type=ReferenceType.SecurityScheme,
                                Id= "Bearer"
                            }
                        }
                        ,new string[] { }
                    }
                }
             );

            options.DocumentFilter<CustomDocumentFilter>();
            options.OrderActionsBy((apidesc) => apidesc.RelativePath);
            options.OperationFilter<AddRequiredHeaderParameter>();
            //开启加权锁
            options.OperationFilter<AddResponseHeadersFilter>();
            options.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();
            // 在header中添加token，传递到后台
            options.OperationFilter<SecurityRequirementsOperationFilter>();
            //options.OrderActionsBy((apiDesc) => $"{apiDesc.ActionDescriptor.RouteValues["controller"]}");
            //options.g(apiDesc=> {
            //    System.Diagnostics.Debug.WriteLine(apiDesc.ID);
            //    var attribute = apiDesc.GetControllerAndActionAttributes<SwaggerControllerViewAttribute>();
            //    if (attribute.Any())
            //        return attribute.First().ControllerName + " " + attribute.First().Version;
            //    else
            //        return apiDesc.ActionDescriptor.ControllerDescriptor.ControllerName;
            //});
        });

    }
}


/// <summary>
/// swagger配置项版本控制
/// </summary>
public class SwaggerVersions
{
    /// <summary>
    ///  swagger版本选项
    /// </summary>
    public enum ApiVersions
    {
        /// <summary>
        /// V1 版本
        /// </summary>
        V1 = 1,
        /// <summary>
        /// V2 版本
        /// </summary>
        V2 = 2,
        /// <summary>
        /// V3 版本
        /// </summary>
        V3 = 3,
        /// <summary>
        /// V4 版本
        /// </summary>
        V4 = 4
    }
}
