# 快速了解

## 项目简介

YuebonCore是一套基于.Net5.0 开发出来的框架，源代码完全开源！目前发布了Vue单页面版和mvc版两个版本，开发者可以根据自己的喜好选择。

使用 MIT 协议，采用主流框架，容易上手，简单易学，学习成本低。可完全实现二次开发、基本满足80%项目需求。

代码生成器可以帮助解决.NET项目70%的重复工作，让开发更多关注业务逻辑。既能快速提高开发效率，帮助公司节省人力成本，同时又不失灵活性。

操作权限控制精密细致，对所有管理链接都进行权限验证，可控制到导航菜单、功能按钮。

数据权限（精细化数据权限控制，可以设置角色可以访问的数据范围，部门、工作组、公司数据）

常用类封装，日志、缓存、验证、字典、文件、邮件、,Excel。等等，目前兼容浏览器（IE11+、Chrome、Firefox、360浏览器等）

适用范围：可以开发OA、ERP、BPM、CRM、WMS、TMS、MIS、BI、电商平台后台、物流管理系统、快递管理系统、教务管理系统等各类管理软件。

## 技术介绍

前端目前采用Vue独立前端和asp.net core MVC模式，使用的技术栈有些区别，后期将侧重于Vue端的优化运维。

### 前端技术 

1、asp.net MVC版详见：[asp.netcore MVC前端技术栈](https://gitee.com/yuebon/YuebonNetCore/wikis/asp.netcore%20MVC%E5%89%8D%E7%AB%AF%E6%8A%80%E6%9C%AF%E6%A0%88?sort_id=2142838)

2、Vue版前端技术栈 ：基于 vue、vuex、vue-router 、vue-cli 、axios 和 element-ui，，前端采用vscode工具开发

3、传送门

element-ui 官网[点击进入](https://element.eleme.cn/#/zh-CN)

vue-element-admin [点击进入](https://panjiachen.gitee.io/vue-element-admin-site/zh/guide/)

### 后端技术

核心框架：.Net5.0 + EF + Dapper + autofac + AutoMapper + Web API + swagger

定时计划任务：Quartz.Net组件

安全支持：过滤器、Sql注入、请求伪造

服务端验证：实体模型验证、自己封装Validator

缓存框架：微软自带Cache、Redis

日志管理：Log4net、登录日志、操作日志

工具类：NPOI、MiniProfiler性能分析、验证码、丰富公共功能

## 项目结构

Yuebon.NetCore解决方案包含：

Yuebon.Commons[基础类库]：包框架的核心组件，包含一系列快速开发中经常用到的Utility辅助工具功能，框架各个组件的核心接口定义，部分核心功能的实现；

Yuebon.Security.Core[权限管理类库]：以Security为基础实现以角色-功能、用户-功能的功能权限实现，以角色-数据，用户-数据的数据权限的封装

Yuebon.AspNetCore[AspNetCore类库]，提供AspNetCore的服务端功能的封装，支持webapi和webmvc模式，同时支持插件式开发；

Yuebon.WebApp[管理后台]：基于aspnet core mvc实现了权限管理和CMS部分管理后台，在MVC分支已暂停新的升级计划。

Yuebon.Cms.Core[CMS基础类库]，包含文章管理、广告管理等内容，以此做案例给大家开发参考

Yuebon.WebApi[webapi接口]：为Vue版或其他三方系统提供接口服务。

DataBase是最新数据库备份文件，目前支持MS SQL Server和MySql。


## 内置功能

1、系统设置：对系统动态配置常用参数。

2、用户管理：用户是系统操作者，该功能主要完成系统用户配置。

3、组织机构：配置系统组织机构（公司、部门、小组），树结构展现支持数据权限。

4、角色管理：角色菜单权限分配、设置角色按机构进行数据范围权限划分。

5、字典管理：对系统中经常使用的一些较为固定的数据进行维护。

6、功能模块：配置系统菜单，操作权限，按钮权限标识等。

7、定时任务：在线（添加、修改、删除)任务调度包含执行结果日志。

8、代码生成：前后端代码的生成（.cs、.vue、.js）代码。

9、日志管理：系统正常操作日志、登录日志记录和查询；系统异常信息日志记录和查询。

10、多应用管理：支持应用调用api授权控制。

11、多系统管理：实现各子系统的统一管理和授权。

13、业务单据编码规则：可以按常量、日期、计数、时间等自定义业务单据编码规则。

14、短信和邮件：集成腾讯云短信通知和EMail发送通知

15、支持租户模式



如遇到问题到[Issues](https://gitee.com/yuebon/YuebonNetCore/issues)反馈
