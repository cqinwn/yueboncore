


### 如果对您有帮助，您可以点右上角 "Star" 支持一下，这样我们才有继续免费下去的动力，谢谢！

### 更新日志

##### 2020/4/23

1、已经完全实现前后端分离，前端采用Vue+element实现。

2、本次更新是大版本更新，传统的asp.net core MVC有部分bug还未修复。

3、近期将发布相关文档，请到QQ群下载

更多更新日志 [点击查看](https://gitee.com/yuebon/YuebonNetCore/wikis/%E6%9B%B4%E6%96%B0%E6%97%A5%E5%BF%97?sort_id=1983111)

### 概述
YuebonCore FW是基于.NetCore3.1开发的权限管理及快速开发框架，整合应用最新技术包括Asp.NetCore MVC、Dapper、AutoFac、WebAPI、Swagger、Json.Net、IdentityServer4等，核心模块包括：组织机构、角色用户、权限授权、多系统、多应用管理等。它的架构易于扩展，是中小企业的优选。

YuebonCore FW其核心设计目标是开发迅速、代码量少、学习简单、功能强大、轻量级、易扩展，让Web开发更快速、简单，解决70%重复工作。轻松开发，专注您的业务，从YuebonCore FW开始！

### 项目简介

使用时请务必保留来源，请勿用于违反我国法律的web平台、如诈骗等非法平台网站。版权最终解释权归《YuebonCore团队》所有。

YuebonCore是一套基于NetCore3.1+Dapper+Vue开发出来的框架，源代码完全开源，可以帮助你解决C#.NET项目70%的重复工作，让开发人员远离加班！

使用 Apache License 2.0 协议，采用主流框架，容易上手，简单易学，学习成本低。可完全实现二次开发、基本满足80%项目需求。

可以帮助解决.NET项目70%的重复工作，让开发更多关注业务逻辑。既能快速提高开发效率，帮助公司节省人力成本，同时又不失灵活性。

操作权限控制精密细致，对所有管理链接都进行权限验证，可控制到导航菜单、功能按钮。

数据权限（精细化数据权限控制，控制到行级，列表级，表单字段级，实现不同人看不同数据，不同人对同一个页面操作不同字段
提高开发效率及质量。常用类封装，日志、缓存、验证、字典、文件、邮件、,Excel。等等，目前兼容浏览器（IE11+、Chrome、Firefox、360浏览器等）

适用范围：可以开发OA、ERP、BPM、CRM、WMS、TMS、MIS、BI、电商平台后台、物流管理系统、快递管理系统、教务管理系统等各类管理软件。

### 在线体验

Vue版本体验地址：[http://netvue.ts.yuebon.com/](http://netvue.ts.yuebon.com)（用户名：admin，密码：admin888）

Asp.net core mvc 版本体验地址：[http://netcore.ts.yuebon.com](http://netcore.ts.yuebon.com)（用户名：admin，密码：admin888）

WebApi接口地址：[http://netcoreapi.ts.yuebon.com](http://netcoreapi.ts.yuebon.com)


#### 技术介绍

前端目前采用Vue独立前端和asp.net core MVC模式，使用的技术栈有些区别，后期将侧重于Vue端的优化运维。

#####  前端技术 
1、asp.net MVC版详见：[asp.netcore MVC前端技术栈](https://gitee.com/yuebon/YuebonNetCore/wikis/asp.netcore%20MVC%E5%89%8D%E7%AB%AF%E6%8A%80%E6%9C%AF%E6%A0%88?sort_id=2142838)

2、Vue版前端技术栈 ：Vue+elementUI+Vue Router+aoxis+Vuex，前端采用vscode工具开发

##### 后端技术

核心框架：.NetCore3.1 + Web API + Dapper + autofac + AutoMapper+swagger

定时计划任务：Quartz.Net组件

安全支持：过滤器、Sql注入、请求伪造

服务端验证：实体模型验证、自己封装Validator

缓存框架：微软自带Cache、Redis

日志管理：Log4net、登录日志、操作日志

工具类：NPOI、Newtonsoft.Json、验证码、丰富公共功能

### 项目结构
Yuebon.NetCore解决方案包含：

Yuebon.Commons[基础类库]：包框架的核心组件，包含一系列快速开发中经常用到的Utility辅助工具功能，框架各个组件的核心接口定义，部分核心功能的实现；

Yuebon.Security.Core[权限管理类库]：以Security为基础实现以角色-功能、用户-功能的功能权限实现，以角色-数据，用户-数据的数据权限的封装

Yuebon.AspNetCore[AspNetCore类库]，提供AspNetCore的服务端功能的封装，支持webapi和webmvc模式，同时支持插件式开发；

Yuebon.Manager[管理后台]：基于aspnet core mvc实现了权限管理和CMS部分管理后台；

Yuebon.Cms.Core[CMS基础类库]，包含文章管理、广告管理等内容，以此做案例给大家开发参考

Yuebon.WebApi[webapi接口]：为Vue版或其他三方系统提供接口服务。

DataBase是最新数据库备份文件，目前仅支持MS SQL Server。

### 部分界面展示

1、登录
![输入图片说明](https://images.gitee.com/uploads/images/2018/0719/120412_ba01c3fc_1017224.jpeg "1、登录.jpg")

2、系统模块和功能管理
![输入图片说明](https://images.gitee.com/uploads/images/2020/0423/211620_9471c41b_1017224.png "4.png")

3、用户管理多角色
![输入图片说明](https://images.gitee.com/uploads/images/2020/0423/211818_f13ba83a_1017224.png "用户管理多角色.png")

4、角色管理
![输入图片说明](https://images.gitee.com/uploads/images/2020/0423/211842_be7657c3_1017224.png "2.png")

5、应用管理
支持多个应用分别设置appId和密钥，适用于多个应用访问接口，每个应用采用jwt标准化token验证访问接口。
![输入图片说明](https://images.gitee.com/uploads/images/2020/0423/211927_40dbbbf1_1017224.png "应用管理.png")

6、数据字典
![输入图片说明](https://images.gitee.com/uploads/images/2020/0423/212216_0a8dc479_1017224.png "3.png")

7、多系统
![输入图片说明](https://images.gitee.com/uploads/images/2020/0423/212234_a23c3a34_1017224.png "多子系统管理.png")

8、日志管理
![输入图片说明](https://images.gitee.com/uploads/images/2020/0423/212256_8a482274_1017224.png "日志管理.png")

9、代码生成器
支持一键生成服务端代码和前端代码，复制粘贴简单快速高效实现功能
![输入图片说明](https://images.gitee.com/uploads/images/2020/0423/213202_8621bf65_1017224.png "代码生成器.png")

10、WebApi 集成Swagger
![输入图片说明](https://images.gitee.com/uploads/images/2018/0719/120718_772240d6_1017224.png "9 webapi.png")
![输入图片说明](https://images.gitee.com/uploads/images/2018/0719/120732_0776845c_1017224.png "9-1 webapi.png")


### 如何用起来
1、系统基于Netcore SDK 3.1.102开发、Runtime 3.1.2版本，请务必安装sdk版本3.1.102 及以上；

2、安装Redis并启动，下载地址：https://github.com/MicrosoftArchive/redis/releases；
如果不用redis缓存可以将UseRedis设置为false。

3、创建数据YuebonFW，然后按顺序分别执行mssql表结构.sql、mssql权限初始化数据.sql;地区数据可以根据自己的实际情况执行mssql地区数据.sql；

4、修改数据库连接MsSqlServer，根据自己的数据库服务填写。

5、打开解决方案，如果使用aspnet core mvc版本启动项目Yuebon.WebApp即可。初始化用户名为admin，密码为admin888

6、使用vue版请按如下操作：

1）打开解决方案，启动Yuebon.Webapi项目

2）进入项目目录vueUI

cd vueUI

3）安装依赖

npm install

4）# 本地开发 启动项目

npm run dev


注意：启动后需要修接口访问地址，在vueUI -> src目录下settings.js的文件中修改


7、如果使用有任何疑问，可以联系作者QQ：381450948（微信同号）


### 部分应用案例
1、做个车吧(http://img.qichetester.com)

2、展途汽车(http://www.zhantucar.com)

3、视奇光学仓库发货系统

4、金宝龙学校数据分析系统

5、汇聚自动化设备

### 未来计划
1、微信开放平台对接、小程序对接、公众号对接

2、实现权限的数据控制（已实现）

3、实现图片可以自管理

4、实现阿里云OSS、腾讯云OSS云存储

5、实现微服务



### 开发者信息

系统名称：YuebonCore快速开发平台

系统作者：YuebonCore团队

作者QQ：381450948(微信同号)

发布日期：2018年07月1日

版权所有：YuebonCore开发团队出品

开源协议：Apache License 2.0

欢迎你加入我们一起共商、共建、共享技术成果！开源让我们进步，开源让我们开阔视野！

交流QQ群：90311523，直接扫码加入

![QQ群](https://images.gitee.com/uploads/images/2020/0417/183047_30037ea3_1017224.jpeg "微信图片_20200417183028.jpg")

### 如果对您有帮助，您可以点右上角 "Star" 支持一下，这样我们才有继续免费下去的动力，谢谢！
