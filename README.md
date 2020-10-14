


### 如果对您有帮助，您可以点右上角 "Star" 支持一下，这样我们才有继续免费下去的动力，谢谢！

### 更新日志

##### 近期更新
1、新增业务单据编码规则，实现单据编码自定义规则

2、优化批量处理方法

3、升级到最新SDK 3.1.402,ASP.NET Core Runtime 3.1.8

4、实现定时任务模块，支持本地任务和远程接口任务，详情参考[定时任务帮助](https://gitee.com/yuebon/YuebonNetCore/wikis/%E5%AE%9A%E6%97%B6%E4%BB%BB%E5%8A%A1?sort_id=2926976)

5、实现邮件发送功能

6、修复角色新增必填字段验证

7、修复组织机构新增必填字段验证

8、优化登录返回页面到主页，不在返回登录前页面

9、json序列化和反序列化采用system.text.json，Newtonsoft.Json。

10、定时任务可以设置任务开始和结束时间，通知节点。

11、支持自定义主键，详见[主键设置](https://gitee.com/yuebon/YuebonNetCore/wikis/%E4%B8%BB%E9%94%AE%E8%AE%BE%E7%BD%AE?sort_id=2990249)。

更多更新日志 [点击查看](https://gitee.com/yuebon/YuebonNetCore/commits/master)

##### 新计划
1、完善软件注册授权模块

2、完善mysql的支持

3、11月份发布支持.net5.0版本，同时更新名称为YBNF（YueBon Net Framework）

有任何疑问可以在文尾添加作者微信咨询。

### 概述
YuebonCore FW是基于.NetCore3.1开发的权限管理及快速开发框架，整合应用最新技术包括Asp.NetCore MVC、Dapper、AutoFac、WebAPI、Swagger、IdentityServer4、Vue等，核心模块包括：组织机构、角色用户、权限授权、多系统、多应用管理、定时任务、业务单据编码规则、代码生成器等。它的架构易于扩展，是中小企业的优选。

YuebonCore FW其核心设计目标是开发迅速、代码量少、学习简单、功能强大、轻量级、易扩展，让Web开发更快速、简单，解决70%重复工作。轻松开发，专注您的业务，从YuebonCore FW开始！

### 项目简介

YuebonCore是一套基于NetCore3.1 开发出来的框架，源代码完全开源！目前发布了Vue单页面版和mvc版两个版本，开发者可以根据自己的喜好选择。

使用 MIT 协议，采用主流框架，容易上手，简单易学，学习成本低。可完全实现二次开发、基本满足80%项目需求。

代码生成器可以帮助解决.NET项目70%的重复工作，让开发更多关注业务逻辑。既能快速提高开发效率，帮助公司节省人力成本，同时又不失灵活性。

操作权限控制精密细致，对所有管理链接都进行权限验证，可控制到导航菜单、功能按钮。

数据权限（精细化数据权限控制，控制到行级，列表级，表单字段级，实现不同人看不同数据，不同人对同一个页面操作不同字段
提高开发效率及质量。常用类封装，日志、缓存、验证、字典、文件、邮件、,Excel。等等，目前兼容浏览器（IE11+、Chrome、Firefox、360浏览器等）

适用范围：可以开发OA、ERP、BPM、CRM、WMS、TMS、MIS、BI、电商平台后台、物流管理系统、快递管理系统、教务管理系统等各类管理软件。

### 在线体验

Vue版本体验地址：[http://netvue.ts.yuebon.com/](http://netvue.ts.yuebon.com)（用户名：test，密码：test123）

测试账号未分配删除和重置密码操作，最近总有那么个别人闲得慌登陆上来修改密码和删除关键数据。

WebApi接口地址：[http://netcoreapi.ts.yuebon.com](http://netcoreapi.ts.yuebon.com)


### 技术介绍

前端目前采用Vue独立前端和asp.net core MVC模式，使用的技术栈有些区别，后期将侧重于Vue端的优化运维。

####  前端技术 
1、asp.net MVC版详见：[asp.netcore MVC前端技术栈](https://gitee.com/yuebon/YuebonNetCore/wikis/asp.netcore%20MVC%E5%89%8D%E7%AB%AF%E6%8A%80%E6%9C%AF%E6%A0%88?sort_id=2142838)

2、Vue版前端技术栈 ：基于 ES2015+、vue、vuex、vue-router 、vue-cli 、axios 和 element-ui，，前端采用vscode工具开发

#### 后端技术

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

DataBase是最新数据库备份文件，目前支持MS SQL Server和MySql。

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

9、定时任务

![列表](https://images.gitee.com/uploads/images/2020/0930/145634_ed46d73b_1017224.png "屏幕截图.png")

本地任务
![输入图片说明](https://images.gitee.com/uploads/images/2020/0930/150300_e99d86f7_1017224.png "屏幕截图.png")

10、代码生成器
支持一键生成服务端代码和前端代码，复制粘贴简单快速高效实现功能
![输入图片说明](https://images.gitee.com/uploads/images/2020/0423/213202_8621bf65_1017224.png "代码生成器.png")

11、WebApi 集成Swagger
![输入图片说明](https://images.gitee.com/uploads/images/2018/0719/120718_772240d6_1017224.png "9 webapi.png")
![输入图片说明](https://images.gitee.com/uploads/images/2018/0719/120732_0776845c_1017224.png "9-1 webapi.png")


### 如何用起来
1、系统基于Netcore SDK 3.1.402开发、Runtime 3.1.8版本，请务必安装sdk版本3.1.402 及以上；

2、安装Redis并启动，下载地址：https://github.com/MicrosoftArchive/redis/releases；
如果不用redis缓存可以将UseRedis设置为false。

3、创建数据YuebonFW，然后按顺序分别执行mssql表结构.sql、mssql权限初始化数据.sql;地区数据可以根据自己的实际情况执行mssql地区数据.sql；

4、修改数据库连接MsSqlServer，根据自己的数据库服务填写。

5、打开解决方案，如果使用aspnet core mvc版本启动项目Yuebon.WebApp即可。初始化用户名为admin，密码为admin888

### vue版如何用起来，[请点击进入专题](https://gitee.com/yuebon/YuebonNetCore/wikis/%E5%85%B3%E4%BA%8EVue%E7%89%88%E6%9C%AC%E7%9A%84%E4%BD%BF%E7%94%A8?sort_id=2148244)


### 部分应用案例
1、做个车吧

2、展途汽车

3、视奇光学仓库发货系统

4、金宝龙学校数据分析系统

5、汇聚自动化设备

6、天逸电器订单系统

### 开发者信息

系统名称：YuebonCore快速开发平台

系统作者：YuebonCore团队

作者微信：13524377688

发布日期：2018年07月1日

版权所有：YuebonCore开发团队出品

开源协议：Mit协议

欢迎你加入我们一起共商、共建、共享技术成果！开源让我们进步，开源让我们开阔视野！

有任何疑问可加微信咨询，微信二维码如下，添加时请备注 “gitee”

![微信二维码](https://images.gitee.com/uploads/images/2020/0915/120702_f1c8e303_1017224.jpeg "微信图片_20200915120640.jpg")

### 帮助[请查看](https://gitee.com/yuebon/YuebonNetCore/wikis/%E9%A1%B9%E7%9B%AE%E7%AE%80%E4%BB%8B)




### 鸣谢

1、感谢@cuijianhao_admin[催催啊](https://gitee.com/cuijianhao_admin)提供mysql测试环境


### 如果对您有帮助，您可以点右上角 "Star" 支持一下，这样我们才有继续免费下去的动力，谢谢！


### 捐赠
如果这个项目对您有所帮助，请扫下方二维码打赏一杯咖啡。
![输入图片说明](https://images.gitee.com/uploads/images/2020/0515/105002_d82f8d8e_1017224.jpeg "收款码.jpg")