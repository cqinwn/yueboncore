# 必要配置

## 数据库连接配置

支持多类型、多个数据库访问。数据库连接配置在ConnectionStrings中，前面属性名称要包含数据库类型名称，系统会根据这个名称区分数据库类型。具体类型如下：

| 数据库类型  | 属性必含字符 | 举例        |
| ----------- | ------------ | ----------- |
| Mssqlserver | MSSQL        | MsSqlServer |
| MySql       | MySql        | MySqlCrm    |
| ORACLE      | ORACLE       | ORACLEERP   |
| SQLITE      | SQLITE       | SQLITETest  |

数据库连接名称规则：

1、总原则：业务_数据库类型_读(read)/写(write),如果不区分读写分离可以不需要后面读写部分。

2、例子：base_MsSqlServer_read,base_MsSqlServer_write,

```json
"ConnectionStrings": {
    "MySql": "server=localhost;port=3306;database=jcrm;user=root;CharSet=utf8;password=root;",
    "MsSqlServer": "Server=192.168.1.105;Database=YuebonFW;User id=sa; password=Yuebon!23;MultipleActiveResultSets=True;",
    "MsSqlServerCode": "Server=192.168.1.105;Database=YuebonFW;User id=sa; password=Yuebon!23;MultipleActiveResultSets=True;"
  },
  "AppSetting": {
    "SoftName": "YueBonCore Framework",
    "CertificatedCompany": "Yuebon",
    "ConStringEncrypt": "false",
    "DefaultDataBase": "MsSqlServer",
  },
```
其中：

1、ConStringEncrypt配置数据库连接字符串是否加密，加密设置为true，否则设置false。数据库连接字符加密请用系统集成工具，在“开发者-数据库连接”模块操作

2、DefaultDataBase设置默认数据库连接

3、注入上下文

注意修改`Startup.cs`中`InitIoC()`方法中的与之匹配数据库上下文注入，在`310`行左右,如下

``` cs
 services.AddTransient<IDbContextCore, MySqlDbContext>(); //注入EF mysql上下文
```

##  服务器缓存设置

系统采用Redis和net自带的MemoryCache。

可以根据自己需要，扩展Redis等缓存。需要引用Microsoft.Extensions.Caching.Redis和StackExchange.Redis两个Redis包。

在appsettings.json添加配置
```json
"CacheProvider": {
    "UseRedis": true,
    "Redis_ConnectionString": "127.0.0.1:6379,allowAdmin=true,password=123456,defaultdatabase=0",
    "Redis_InstanceName": "yuebon_redis_"
  }
```
我们写一个类，来获取配置几个配置，CacheProvider说明：

1）、UseRedis：是否使用Redis缓存，不使用设置false即可；

2）、Redis_ConnectionString：Redis连接，按示例参数进行配置，allowadmin、password、defaultdatabase都需要，其他配置参数请查阅相关文档；

3）、Redis_InstanceName：Redis实例名称

## 跨域设置

跨域访问在appsettings.json中设置AllowOrigins值，用英文逗号“,”隔开，不要以斜杆“/”结束
```
"AllowOrigins": "http://localhost,http://192.168.1.106,http://netvue.ts.yuebon.com",
```
前后端分离时前台调用后台系统时就是跨域访问，此处配置允许前台访问的请求地址。第三方网站调用本系统 webapi 也要配置，否则一样不能跨域访问。


Startup.cs代码

目前源码中默认为测试环境配置，允许所有跨域访问,配置如下：
```cs
//允许所有跨域访问，测试用
services.AddCors(options => options.AddPolicy("yuebonCors",
     policy => policy.WithOrigins("*").AllowAnyHeader().AllowAnyMethod()));
```

正式环境建议如下配置：

```cs
//全局设置跨域访问
services.AddCors(options => options.AddPolicy("yuebonCors",
policy => policy.WithOrigins(Configuration.GetSection("AppSetting:AllowOrigins").Value.Split(',', StringSplitOptions.RemoveEmptyEntries))
.AllowAnyHeader()
.AllowAnyMethod()));
```


* IIS部署中部分会出现method为delete时跨域问题？

请在web.config做如下配置：

``` cs
<modules>
   <remove name="WebDAVModule" />
</modules>
<handlers>
   <remove name="WebDAV" />
</handlers>
```


如遇到问题到[Issues](https://gitee.com/yuebon/YuebonNetCore/issues)反馈