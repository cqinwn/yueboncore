# 快速使用

## 准备工作

### 安装sdk

下载安装微软官方SDK 5.0最新版，代码地址：https://dotnet.microsoft.com/download

本地须安装 node 和 git，可在如下地址获得 NodeJS 的安装包：https://nodejs.org/en/ ，二者也可以到qq群90311523获取下载，

如果需用Redis，请安装Redis并启动，下载地址：https://github.com/MicrosoftArchive/redis/releases； 如果不用redis缓存可以将UseRedis设置为false。

::: tip 提示
前端安装完node后，最好设置下淘宝的镜像源，不建议使用cnpm（可能会出现奇怪的问题）

npm config set registry https://registry.npm.taobao.org
:::

### 下载代码

使用git工具下载代码，代码地址：https://gitee.com/yuebon/YuebonNetCore.git

### 初始化数据库

目前支持数据库有：
* Microsift SqlServer 2012+
* MySql 8.0+

使用数据库脚本`mssql vue版本`或`mssql mvc版本`或`mysql初始化脚本` 文件夹里面的结构脚本和数据脚本初始化数据库。

::: tip 提示
各数据库表结构一样，初始化数据存在差异，vue版和mvc版主要是功能菜单模块数据差异。

mysql版本需要开启数据库表名称不区分大小写规则。
需要修改mysql的配置文件my.cnf，在[mysqld]加入一行： lower_case_table_names=1
:::

## 后台运行

使用Visual Studio 2019或Rider打开 `YuebonNetCore.sln`

### 修改连接字符串

* 修改Yuebon.WebApp/appsettings.json连接字符串，如下：
```json
 "ConnectionStrings": {
    "MySql": "server=localhost;port=3306;database=jcrm;user=root;CharSet=utf8;password=root;",
    "MsSqlServer": "Server=192.168.1.105;Database=YuebonFW;User id=sa; password=Yuebon!23;MultipleActiveResultSets=True;",
    "MsSqlServerCode": "Server=192.168.1.105;Database=YuebonFW;User id=sa; password=Yuebon!23;MultipleActiveResultSets=True;"
  },
  "AppSetting": {
    "SoftName": "YueBonCore Framework",
    "CertificatedCompany": "Yuebon",
    "ConStringEncrypt": "false",//连接字符串是否加密
    "DefaultDataBase": "MsSqlServer",//默认数据库连接
  },
```

* 修改Yuebon.WebApi/appsettings.json连接字符串,如下：
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

* 其中：

1、ConStringEncrypt配置数据库连接字符串是否加密，加密设置为true，否则设置false

2、DefaultDataBase设置默认数据库连接

3、注入上下文

注意修改`Startup.cs`中`InitIoC()`方法中的与之匹配数据库上下文注入，在`310`行左右,如下

``` cs
 services.AddTransient<IDbContextCore, MySqlDbContext>(); //注入EF mysql上下文
```

### 编译运行

使用visualstudio生成解决方案。
`注：首次启动时，visual studio会启动nuget还原第三方依赖包，请保持网络通畅，并等待一段时间`

启动Yuebon.WebApi项目。


## 前端运行

项目采用vue家族技术作为前端，在项目目录VueUI中。

### 修改接口访问地址

在目录中VueUI\src修改setting.js文件中接口访问地址，将地址改为webapi项目启动访问地址。
**注意你的接口采用https还是http方式，很多小伙伴有时候没有注意。**

```js

 apiHostUrl: 'http://localhost:54678/api/', // 基础接口
 apiSecurityUrl: 'http://localhost:54678/api/Security/', // 权限管理系统接口
 fileUrl: 'http://localhost:54678/', // 文件访问路径
 fileUploadUrl: 'http://localhost:54678/api/Files/Upload'// 文件上传路径

```

### 编译运行

```sh

#进入目录
 cd VueUI

# 安装依赖
npm install

# 强烈建议不要用直接使用 cnpm 安装，会有各种诡异的 bug，可以通过重新指定 registry 来解决 npm 安装速度慢的问题。
npm install --registry=https://registry.npm.taobao.org

# 本地开发 启动项目
npm run dev
```
打开浏览器，输入：http://localhost:8085 （默认账户 admin/admin888）
若能正确展示登录页面，并能成功登录，菜单及页面展示正常，则表明环境搭建成功


::: tip 提示
因为本项目是前后端分离的，所以需要前后端都编译启动好，才能进行访问。

我们在接口访问采用类似于腾讯微信开放平台、阿里云开放平台等大厂的接口访问安全机制，接口访问需要通过应用`AppId`和应用密钥`AppSecret`获取凭据`token`与正确授权请求url才能调用接口访问数据。

本权限系统默认应用AppId为`openauth`，对应授权可以访问的url地址需要在数据库表`sys_app`中修改。但是`localhost`本地测试将不限制。
:::

## 常见问题

1、前后都启动好了，出现500错误，请检查[跨域访问设置](/guide/peizhi.html#跨域设置)

2、node-sass安装失败

Windows 用户若安装不成功，很大概率是node-sass安装失败。解决node-sass安装不成功的问题

```sh
npm i node-sass --sass_binary_site=https://npm.taobao.org/mirrors/node-sass
```

3、启动后出现如错误：Module build failed (from ./node_modules/babel-loader/lib/index.js):

解决方法：进入当前项目目录 npm install @babel/core @babel/preset-env 命令


如遇到问题到[Issues](https://gitee.com/yuebon/YuebonNetCore/issues)反馈