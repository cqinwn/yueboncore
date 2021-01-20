# 业务设计

## 概述

本系列教程中，我们将一步一步实现一个业务编码规则的业务模块，并对使用YuebonCore框架进行业务实现的过程涉及的框架知识进行全面的讲解。 通过学习本系列教程，你将对YuebonCore框架的业务实现有个较全面的了解，你将学习到框架的如下知识点：

* 1、框架推荐的项目文件组织方式
* 2、实体类设计，并将实体类加载到数据上下文
* 3、模块化的业务层服务设计
* 4、基于WebAPI的角色**功能权限**控制
* 5、基于 **角色-实体** 的**数据权限**控制
* 6、Vue前端**菜单/按钮权限**控制

## 业务需求分析

根据规则生成单据编号

* 业务编号：一般前几位为客户自己定义的常量，中间几位为当前年月日，最后四位为当天的流水号，这些都可以在业务编号规则中设置，稍候在配置规则中再说。
* 实现可以按天、月、年重置编码序号
* 定义编码规则分隔符
* 可以对业务编码规则进行**新增、更新、删除、禁用、启用**操作
* 开启 **逻辑删除** 功能，保留历史数据

## 业务模块包含什么

一个完整的业务模块，要实现一系列相关联的业务功能，需要一个完整的 **数据层 - 服务层 - WebAPI层 - 前端UI层** 的代码链的支持，各个层次各司其职，共同来完成当前模块的业务处理。

### 业务模块文件夹结构布局

``YuebonCore``框架有一套推荐的模块文件夹布局方案，根据该方案，业务单据编码模块的 后端文件夹 结构推荐如下：

```
src                                              # 源代码文件夹
├─Yuebon.Security.Core                           # 项目核心工程
│  ├─Dtos                                        # 模块DTO文件夹
│  │   ├─SequenceInputDto.cs                     # 业务单据类型输入DTO
│  │   ├─SequenceOutputDto.cs                    # 业务单据规则输出DTO
│  │   ├─SequenceRuleInputDto.cs                 # 业务单据类型输入DTO
│  │   └─SequenceRuleOutputDto.cs                # 业务单据规则输出DTO
│  ├─IRepositories                               # 仓储接口文件夹
│  │   ├─ISequenceRepository.cs                  # 业务单据类型仓储接口
│  │   └─ISequenceRuleRepository.cs              # 业务单据规则仓储接口
│  ├─IServices                                   # 服务接口文件夹
│  │   ├─ISequenceService.cs                     # 业务单据类型服务接口
│  │   └─ISequenceRuleService.cs                 # 业务单据规则服务接口
│  ├─Models                                      # 数据实体文件夹
│  │   ├─Sequence.cs                             # 业务单据类型实体
│  │   └─SequenceRule.cs                         # 业务单据规则实体
│  ├─Repositories                                # 仓储实现文件夹
│  │   ├─SequenceRepository.cs                   # 业务单据类型仓储实现
│  │   └─SequenceRuleRepository.cs               # 业务单据规则仓储实现
│  └─Services                                    # 服务实现文件夹
│      ├─SequenceService.cs                      # 业务单据类型服务实现
│      └─SequenceRuleService.cs                  # 业务单据规则服务实现
└─Yuebon.WebApi                                  # webapi接口项目
   ├─Areas
   │   └─Security                                # 权限模块文件夹
   │       └─Controllers                         # 控制器文件夹
   │          ├─SequenceController.cs            # 业务单据类型控制器
   │          └─SequenceRuleController.cs        # 业务单据规则控制器
   ├─appsettings.json
   ├─Program.cs
   └─Startup.cs
```

单据编码规则模块相应的 **Vue** 前端文件夹 结构推荐如下：

```
VueUI
├─src                                         # 前端源文件夹
│   ├─api                                     # api接口文件夹
│   │    └─security                           # 权限模块文件夹
│   │       ├─sequence.js                     # 业务单据类型
│   │       └─sequencerule.js                 # 业务单据规则
│   ├─assets
│   ├─components                              
│   ├─icons                      
│   ├─layout                      
│   ├─router                      
│   ├─store                      
│   ├─styles                      
│   ├─utils                      
│   ├─views                                   # 页面视图文件夹
│   │    └─sequence                           # 单据编码规则文件夹
│   │       ├─index.vue                       # 业务单据类型页面
│   │       └─rule.vue                        # 业务单据规则页面
│   ├─App.vue                      
│   ├─main.js                      
│   ├─permission.js                      
│   └─settings.js                      
├─public
├─dist
├─build
├─appsettings.json
├─Program.cs
└─vue.config.js
```

### 数据层

``YuebonCore``的数据层，主要是 **数据实体** 的定义，只要数据实体定义好，并做好 **数据实体映射**，再配合框架中已定义好的数据仓储 IRepository<TEntity, TKey>，即可轻松完成数据的数据库存取操作。 根据设计需要有 **单据类型、单据编码规则** 两个数据实体。

### 服务层

服务层负责实现模块的业务处理，是整个系统的最核心部分，一个系统有什么功能，能对外提供什么样的服务，都是在服务层实现的。

|    实体  |   业务操作   |
| -------- | ------------ |
| 业务单据类型      | 新增、更新、删除、启用/禁用、软删除 |
| 单据编码规则      | 新增、更新、删除、启用/禁用、软删除 |

### WebAPI层

WebAPI层负责对外提供数据操作API，并对API进行授权约束。

* 业务单据类型

|    操作  |   访问类型    |   操作角色   |
| -------- | ------------ | ----------- |
| 读取      | 角色访问        | 系统配置 |
| 新增      | 角色访问        | 系统配置    |
| 修改      | 角色访问       | 系统配置   |
| 启用/禁用 | 角色访问        | 系统配置  |
| 删除      | 角色访问        | 超级管理员  |
| 软删除    | 角色访问        | 系统配置  |


* 单据编码规则

|    操作  |   访问类型    |   操作角色   |
| -------- | ------------ | ----------- |
| 读取      | 角色访问        | 系统配置 |
| 新增      | 角色访问        | 系统配置    |
| 修改      | 角色访问       | 系统配置   |
| 启用/禁用 | 角色访问        | 系统配置  |
| 删除      | 角色访问        | 超级管理员  |
| 软删除    | 角色访问        | 系统配置  |

### 前端UI层

前端UI层是整个系统的对外操作界面，是直面最终用户的终端，整个系统最终表现形式全靠前端展现出现。 业务单据编码规则模块UI设计如下：

* 统一使用后台管理界面来提供 **业务单据类型、单据编码规则** 的管理
* 业务单据类型列表
*    可以新增、修改、删除业务单据类型
* 单据编码规则列表
*    可以新增、修改、删除业务单据类型

至此，业务单据编码规则模块的详细设计设计完毕，后面我们将一步一步来实现这个业务需求。


如遇到问题到[Issues](https://gitee.com/yuebon/YuebonNetCore/issues)反馈

