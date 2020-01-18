# YuebonNetCore

#### 概述
YuebonCore FW是基于.NetCore3.1开发的权限管理及快速开发框架，整合应用最新技术包括Asp.NetCore MVC、Dapper、AutoFac、WebAPI、Swagger、Json.Net、IdentityServer4等，核心模块包括：组织机构、角色用户、权限授权、多系统、多应用管理等。它的架构易于扩展，是中小企业的优选。

YuebonCore FW其核心设计目标是开发迅速、代码量少、学习简单、功能强大、轻量级、易扩展，让Web开发更快速、简单，解决70%重复工作。轻松开发，专注您的业务，从YuebonCore FW开始！

#### 项目简介

使用时请务必保留来源，请勿用于违反我国法律的web平台、如诈骗等非法平台网站。版权最终解释权归《YuebonCore团队》所有。

YuebonCore是一套基于NetCore3.1+Dapper+Bootstrap开发出来的框架，源代码完全开源，可以帮助你解决C#.NET项目70%的重复工作，让开发人员远离加班！

使用 Apache License 2.0 协议，采用主流框架，容易上手，简单易学，学习成本低。可完全实现二次开发、基本满足80%项目需求。

可以帮助解决.NET项目70%的重复工作，让开发更多关注业务逻辑。既能快速提高开发效率，帮助公司节省人力成本，同时又不失灵活性。

支持SQLServer、MySQL、Oracle、SQLite、Access 等多数据库类型。模块化设计，层次结构清晰。内置一系列企业信息管理的基础功能。

操作权限控制精密细致，对所有管理链接都进行权限验证，可控制到导航菜单、功能按钮。

数据权限（精细化数据权限控制，控制到行级，列表级，表单字段级，实现不同人看不同数据，不同人对同一个页面操作不同字段
提高开发效率及质量。常用类封装，日志、缓存、验证、字典、文件、邮件、,Excel。等等，目前兼容浏览器（IE8+、Chrome、Firefox、360浏览器等）
适用范围：可以开发OA、ERP、BPM、CRM、WMS、TMS、MIS、BI、电商平台后台、物流管理系统、快递管理系统、教务管理系统等各类管理软件。

在线体验地址：[http://netcore.ts.yuebon.com](http://netcore.ts.yuebon.com)（用户名：admin，密码：admin888）

#### 开发者信息

系统名称：YuebonCore快速开发平台

系统作者：YuebonCore团队

作者Q Q：381450948（微信同号）

QQ交流群：90311523

发布日期：2018年07月1日

版权所有：YuebonCore开发团队出品

开源协议：Apache License 2.0

欢迎你加入我们共商、共建、共享技术成果！开源让我们进步，开源让我们开阔视野！

#### 技术介绍

######  前端技术

JS框架：jquery-v3.3.1、Bootstrap.js、JQuery UI

CSS框架：Bootstrap v4.3.1（UI方面根据需求自己升级改造吧）。

客户端验证：Query Validation Plugin v1.17.0。

在线编辑器：ckeditor

上传文件：Uploadify v3.2.1

数据表格：bootstrap-table、bootstrap-treeview、jquery-treegrid

对话框：toastr、sweetalert

下拉选择框：jQuery Select2

复选框：jQuery iCheck

树结构控件：jQuery zTree、jQuery wdtree

页面布局：AdminLTE-3.0.0

图表插件：echarts、highcharts

日期控件： My97DatePicker

###### 后端技术

核心框架：asp.net mvc + Web API + Dapper + autofac + AutoMapper+swagger

定时计划任务：Quartz.Net组件

安全支持：过滤器、Sql注入、请求伪造

服务端验证：实体模型验证、自己封装Validator

缓存框架：微软自带Cache、Redis

日志管理：Log4net、登录日志、操作日志

工具类：NPOI、Newtonsoft.Json、验证码、丰富公共功能

#### 项目结构
Yuebon.NetCore解决方案包含：

Yuebon.Commons[基础类库]：包框架的核心组件，包含一系列快速开发中经常用到的Utility辅助工具功能，框架各个组件的核心接口定义，部分核心功能的实现；

Yuebon.Security.Core[权限管理类库]：以Security为基础实现以角色-功能、用户-功能的功能权限实现，以角色-数据，用户-数据的数据权限的封装

Yuebon.AspNetCore[AspNetCore类库]，提供AspNetCore的服务端功能的封装，支持webapi和webmvc模式，同时支持插件式开发；

Yuebon.Manager[管理后台]：实现了权限管理和CMS部分管理后台；

Yuebon.Cms.Core[CMS基础类库]，包含文章管理、广告管理等内容，以此做案例给大家开发参考

DataBase是最新数据库备份文件，支持MS SQL Server 2012。

#### 部分界面展示

1、登录
![输入图片说明](https://images.gitee.com/uploads/images/2018/0719/120412_ba01c3fc_1017224.jpeg "1、登录.jpg")

2、系统菜单
![输入图片说明](https://images.gitee.com/uploads/images/2018/0719/120429_f75f0974_1017224.png "2、系统菜单.png")

3、用户管理多色
![输入图片说明](https://images.gitee.com/uploads/images/2018/0719/120503_3bdaf7ef_1017224.png "3、用户管理多色.png")

4、角色管理
![输入图片说明](https://images.gitee.com/uploads/images/2018/0719/120525_2cebd34a_1017224.png "4-1角色管理.png")

5、角色管理
![输入图片说明](https://images.gitee.com/uploads/images/2018/0719/120545_80d53d21_1017224.png "4角色管理.png")

6、应用管理
![输入图片说明](https://images.gitee.com/uploads/images/2018/0719/120603_9ea0faf4_1017224.png "5应用管理.png")

7、数据字典
![输入图片说明](https://images.gitee.com/uploads/images/2018/0719/120622_42aa9820_1017224.png "6、数据字典.png")

8、多系统
![输入图片说明](https://images.gitee.com/uploads/images/2018/0719/120643_6bc390ad_1017224.png "7多系统.png")

9、日志管理
![输入图片说明](https://images.gitee.com/uploads/images/2018/0719/120702_5e692a88_1017224.png "8、日志管理.png")

10、WebApi 集成Swagger
![输入图片说明](https://images.gitee.com/uploads/images/2018/0719/120718_772240d6_1017224.png "9 webapi.png")
![输入图片说明](https://images.gitee.com/uploads/images/2018/0719/120732_0776845c_1017224.png "9-1 webapi.png")

#### 部分应用案例
1、做个车吧(http://img.qichetester.com)

2、展途汽车(http://www.zhantucar.com)

3、视奇光学仓库发货系统

4、金宝龙学校数据分析系统

5、汇聚自动化设备