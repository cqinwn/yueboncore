# 接口与版本控制

目前框架支持webapi多版本，采用swagger针对不同的版本可进行交互。多版本控制基于`Microsoft.AspNetCore.Mvc.Versioning.ApiExplorer` 和`Swashbuckle.AspNetCore`包

## 安装包

通过nuget导入如下三个包：

1、`Microsoft.AspNetCore.Mvc.Versioning.ApiExplorer` 

2、`Microsoft.AspNetCore.Mvc.Versioning`

3、`Swashbuckle.AspNetCore`

## 添加服务及配置

### 1、让项目支持版本控制
，ConfigServices中添加如下代码

``` cs
// Api多版本版本配置
services.AddApiVersioning(o =>
{
    o.ReportApiVersions = true;//是否在请求头中返回受支持的版本信息。
    o.ApiVersionReader = new HeaderApiVersionReader("api-version");////版本信息放到header ,不写在不配置路由的情况下，版本信息放到response url 中
    o.AssumeDefaultVersionWhenUnspecified = true;//请求没有指明版本的情况下是否使用默认的版本。
    o.DefaultApiVersion = new ApiVersion(1, 0);//默认的版本号。
}).AddVersionedApiExplorer(option =>
{    // 版本名的格式：v+版本号
    option.GroupNameFormat = "'v'V";
    option.AssumeDefaultVersionWhenUnspecified = true;
});
//获取webapi版本信息，用于swagger多版本支持 
apiVersionProvider = services.BuildServiceProvider().GetRequiredService<IApiVersionDescriptionProvider>();
```

apiVersionProvider需在全局定义

```cs
private IApiVersionDescriptionProvider apiVersionProvider;//版本控制
```

支持通过url?api-version=2和header两种方式进行传递,如果不指定版本路由那么定义ApiVersionReader，则通过header传递。【推荐】系统默认支持通过header传递。要通过url传参支持请删除` o.ApiVersionReader = new HeaderApiVersionReader("api-version")`即可。

header传递如下：
![说明](/assets/img/webapidemo.png "说明")

当然，如果为默认版本号也可以不传。

### 2、让swagger支持多版本控制

a、ConfigServices中添加如下代码

``` cs
services.AddSwaggerGen(options =>
{
    string contactName = Configuration.GetSection("SwaggerDoc:ContactName").Value;
    string contactNameEmail = Configuration.GetSection("SwaggerDoc:ContactEmail").Value;
    string contactUrl = Configuration.GetSection("SwaggerDoc:ContactUrl").Value;

    foreach (var description in apiVersionProvider.ApiVersionDescriptions)
    {
        options.SwaggerDoc(description.GroupName,
                new OpenApiInfo()
                {
                    Title = $"{Configuration.GetSection("SwaggerDoc:Title").Value}v{description.ApiVersion}",
                    Version = description.ApiVersion.ToString(),
                    Description = Configuration.GetSection("SwaggerDoc:Description").Value,
                    Contact = new OpenApiContact { Name = contactName, Email = contactNameEmail, Url = new Uri(contactUrl) },
                    License = new OpenApiLicense { Name = contactName, Url = new Uri(contactUrl) }
                }
        );
    }
    Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.xml").ToList().ForEach(file =>
    {
        options.IncludeXmlComments(file, true);
    });
    options.DocumentFilter<HiddenApiFilter>(); // 在接口类、方法标记属性 [HiddenApi]，可以阻止【Swagger文档】生成
    //给api添加token令牌证书
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT授权(数据将在请求头中进行传输) 直接在下框中输入Bearer {token}（注意两者之间是一个空格）\"",
        Name = "Authorization",//jwt默认的参数名称
        In = ParameterLocation.Header,//jwt默认存放Authorization信息的位置(请求头中)
        Type = SecuritySchemeType.ApiKey,
        BearerFormat="JWT",
        Scheme= "Bearer"
    });
    //添加安全请求
    options.AddSecurityRequirement(
        new OpenApiSecurityRequirement {
            { 
                new OpenApiSecurityScheme
                {
                    Reference=new OpenApiReference{
                        Type=ReferenceType.SecurityScheme,
                        Id= "Bearer"//必须和AddSecurityDefinition中名称一致
                    }
                }
                ,new string[] { }
            }
        });
    //开启加权锁
    options.OperationFilter<AddResponseHeadersFilter>();
    options.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();
    options.OperationFilter<SecurityRequirementsOperationFilter>();
});
```

b、Configure中添加如下代码

```cs
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    foreach (var description in apiVersionProvider.ApiVersionDescriptions)
    {
        options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", $"{Configuration.GetSection("SwaggerDoc:Title").Value+description.GroupName.ToUpperInvariant()}");
        options.RoutePrefix = string.Empty;//这里主要是不需要再输入swagger这个默认前缀
    }
});
```
## 使用

### 1、控制器定义版本

例子：
``` cs
/// <summary>
/// 验证码接口
/// </summary>
[Route("api/[controller]")]
[ApiController]
[ApiVersion("1.0")]
public class CaptchaController : ApiController
{
}
```

### 2、方法中定义版本

```cs
/// <summary>
/// 用户登录，无验证码，主要用于app登录
/// </summary>
/// <param name="username">用户名</param>
/// <param name="password">密码</param>
/// <param name="appId">AppId</param>
/// <param name="systemCode">系统编码</param>
/// <returns>返回用户User对象</returns>
[HttpGet("UserLogin")]
[ApiVersion("2.0")]
[NoPermissionRequired]
[AllowAnonymous]
public async Task<IActionResult> UserLogin(string username, string password,  string appId, string systemCode)
{

    CommonResult result = new CommonResult();
    RemoteIpParser remoteIpParser = new RemoteIpParser();
    string strIp = remoteIpParser.GetClientIp(HttpContext).MapToIPv4().ToString();
    YuebonCacheHelper yuebonCacheHelper = new YuebonCacheHelper();
    Log logEntity = new Log();
    bool blIp = _filterIPService.ValidateIP(strIp);
    if (blIp)
    {
        result.ErrMsg = strIp + "该IP已被管理员禁止登录！";
    }
    else
    {
        ....
    }
    return ToJsonContent(result, true);
}

```

### 3、swagger效果
运行程序看效果，可以在右上角实现版本切换
![说明](/assets/img/swaggerdemo.png "说明")

## 常见问题

### 同一控制器多版本
例子：
``` cs
/// <summary>
/// 验证码接口
/// </summary>
[Route("api/[controller]")]
[ApiController]
[ApiVersion("1.0")]
[ApiVersion("2.0")]
public class CaptchaController : ApiController
{
}
```

但是两个相同的版本中Controller不能有相同的方法。比如v1文件夹和v2文件的UserController都指向v2版本,是不能同时拥有GetList()的，但是如果我们想要v2中的GetList重写v1的GetList方法，其他的方法都继承过来怎么处理呢？

方法：将v2版本中的GetList（）方法 MapToApiVersion到v1即可
```cs
/// <summary>
/// 获取用户列表
/// </summary>
/// <returns></returns>
[HttpGet,MapToApiVersion("1.0")]
public NetResponse<List<User>> GetList()
{}
```
这样以来v1与v2中的GetList 就互不影响了。

### 版本弃用
设置`Deprecated`  这个属性设置 `True` ：标识是否弃用API。
```cs
[ApiVersion("1.0", Deprecated = True)]
```


如遇到问题到[Issues](https://gitee.com/yuebon/YuebonNetCore/issues)反馈