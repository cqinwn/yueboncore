### 重要说明

saas分支为saas版本，支持共享数据库使用tenantId字段分离租户，也支持一个租户一个独立数据库。相比master分支版本将接口和实现进行分离项目实现解耦，新增了事件订阅等一系列功能。


master分支适合单体应用开发，架构较为简单，没有实现接口和实现的解耦。



### 概述
YuebonCore是基于.Net6.0开发的权限管理及快速开发框架，整合应用最新技术包括Asp.NetCore MVC、SqlSugar ORM、WebAPI、Swagger、Vue3等，核心模块包括：组织机构、角色用户、权限授权、多系统、多应用管理、定时任务、业务单据编码规则、代码生成器等。它的架构易于扩展，规范了一套业务实现的代码结构与操作流程，使YuebonCore框架更易于应用到实际项目开发中。

YuebonCore FW其核心设计目标是开发迅速、代码量少、学习简单、功能强大、轻量级、易扩展，让Web开发更快速、简单，解决70%重复工作。轻松开发，专注您的业务，从YuebonCore FW开始！

### 在线体验

1、管理平台体验地址：[http://default.ts.yuebon.com](http://default.ts.yuebon.com) 有租户管理模块

2、测试租户体验地址:[http://tenant1.ts.yuebon.com](http://tenant1.ts.yuebon.com)，无租户管理模块

体验账号密码均为：admin/admin888

WebApi 接口地址：[http://netcoreapi.ts.yuebon.com](http://netcoreapi.ts.yuebon.com)

官方文档：[http://docs.v.yuebon.com/](http://docs.v.yuebon.com/)

视频教程：[点击观看](https://space.bilibili.com/1615836206)或QQ群下载观看

交流QQ群: [90311523](https://jq.qq.com/?_wv=1027&k=p6IUTzDF)


### 更新日志

更新日志 [点击查看](https://gitee.com/yuebon/YuebonNetCore/commits/master)

### 核心看点

使用 MIT 协议，完整开源。采用主流框架，容易上手，简单易学，学习成本低。可完全实现二次开发、基本满足80%项目需求。

代码生成器可以帮助解决.NET项目70%的重复工作，让开发更多关注业务逻辑。既能快速提高开发效率，帮助公司节省人力成本，同时又不失灵活性。

操作权限控制精密细致，对所有管理链接都进行权限验证，可控制到导航菜单、功能按钮。

数据权限（精细化数据权限控制，可以设置角色可以访问的数据范围，部门、工作组、公司数据）

常用类封装，日志、缓存、验证、字典、文件、邮件、,Excel。等等，目前兼容浏览器（IE11+、Chrome、Firefox、360浏览器等）

适用范围：可以开发OA、ERP、BPM、CRM、WMS、TMS、MIS、BI、电商平台后台、物流管理系统、快递管理系统、教务管理系统等各类管理软件。


### 技术介绍

前端目前采用Vue家族前端技术。

####  前端技术 

Vue版前端技术栈 ：基于vue3、Vite、vuex、vue-router 、vue-cli 、axios 和 element-plus，，前端采用vscode工具开发

#### 后端技术

核心框架：.Net6.0 + Web API +SqlSugar + AutoMapper + swagger

定时计划任务：Quartz.Net组件

安全支持：过滤器、Sql注入、请求伪造

服务端验证：实体模型验证、自己封装Validator

缓存框架：微软自带Cache、Redis

日志管理：Log4net、登录日志、操作日志

工具类：NPOI、验证码、丰富公共功能

性能分析：MiniProfiler组件


### 内置功能

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

16、支持用户定义主题风格

17、支持一主多从数据库读写分离



### 部分界面展示

1、登录
![输入图片说明](https://images.gitee.com/uploads/images/2021/0124/092120_64eb54dc_1017224.png "1、登录.jpg")

2、系统模块和功能管理
![输入图片说明](https://images.gitee.com/uploads/images/2021/0124/092135_56b7d10b_1017224.png "4.png")

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

![本地任务](https://images.gitee.com/uploads/images/2021/0124/092152_d941062d_1017224.png "屏幕截图.png")

10、代码生成器
支持一键生成服务端代码和前端代码，复制粘贴简单快速高效实现功能
![输入图片说明](https://images.gitee.com/uploads/images/2021/0124/092205_a7c39eae_1017224.png "代码生成器.png")

11、WebApi 集成Swagger
![输入图片说明](https://images.gitee.com/uploads/images/2018/0719/120718_772240d6_1017224.png "9 webapi.png")
![输入图片说明](https://images.gitee.com/uploads/images/2018/0719/120732_0776845c_1017224.png "9-1 webapi.png")

### 开发者信息

系统名称：YuebonCore快速开发平台

系统作者：YuebonCore团队

版权所有：YuebonCore开发团队出品

开源协议：Mit协议


### 各分支说明

|  分支      |     说明         
|-----------|---------------
| master    | 正式发布的主分支，通常这个分支比较稳定，可以用于生产环境。
| dev | 1、开发分支，此分支通常为 Beta 版本，新版本都会先在此分支中进行开发，最后推送稳定版到 master 分支，如果想对新功能先睹为快，可以使用此分支。<br> 2、建议 Pull Request 的代码都到这个分支下，而不是 master
| saas   | saas分支为saas版本，支支持共享数据库使用tenantId字段分离租户，也支持一个租户一个独立数据库。
| 其他分支   | 其他分支请忽略。


### 社区


欢迎你加入我们一起共商、共建、共享技术成果！开源让我们进步，开源让我们开阔视野！

有任何疑问加微信cqinwn或加入[QQ群 90311523](https://jq.qq.com/?_wv=1027&k=p6IUTzDF)，点击链接加入群聊[【YuebonCore交流群】](https://jq.qq.com/?_wv=1027&k=p6IUTzDF)

如果对您有帮助，您可以点 "Star" 支持一下，这样我们才有继续免费下去的动力，谢谢！