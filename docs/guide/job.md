# 定时任务

在实际项目开发中Web应用有一类不可缺少的，那就是定时任务。 定时任务的场景可以说非常广泛，比如某些视频网站，购买会员后，每天会给会员送成长值，每月会给会员送一些电影券； 比如在保证最终一致性的场景中，往往利用定时任务调度进行一些比对工作；比如一些定时需要生成的报表、邮件；比如一些需要定时清理数据的任务等。 所以我们提供方便友好的web界面，实现动态管理任务，可以达到动态控制定时任务启动、暂停、重启、删除、添加、修改等操作，极大地方便了开发过程。

::: tip 提示
定时任务基于Quartz.Net开发
:::

## 功能简述

定时任务模块支持本地任务和外部接口任务

本地任务全部放在`Yuebon.Quartz.Jobs`项目中，其中`HttpResultfulJob`是执行远程接口任务的实现，不要删除。自定义实现其他任务可以参考的TestJob写法。每个任务都要实现IJob这个接口。

支持Cron表达式和json格式参数，cron表达式参考cron表达式生成器

支持任务执行Email通知，方便运维及时知道任务执行情况，可以设置不通知、异常通知（出异常时才通知）、所有通知（任务执行成功或失败都会通知）

## 编写任务代码

在Yuebon.Quartz.Jobs中编写定时任务的执行代码。比如`TestJob`

```csharp
namespace Yuebon.Quartz.Jobs
{
    /// <summary>
    /// 测试demo
    /// 必须实现IJob接口中的Execute()方法
    /// </summary>
    public class TestJob : IJob
    {
        ITaskManagerService iService = IoCContainer.Resolve<ITaskManagerService>();

        public Task Execute(IJobExecutionContext context)
        { 
            DateTime dateTime = DateTime.Now;
            YuebonCacheHelper yuebonCacheHelper = new YuebonCacheHelper();
            SysSetting sysSetting = JsonSerializer.Deserialize<SysSetting>(yuebonCacheHelper.Get("SysSetting").ToJson());
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            AbstractTrigger trigger = (context as JobExecutionContextImpl).Trigger as AbstractTrigger;
            string sqlWhere = string.Format("Id='{0}' and GroupName='{1}'", trigger.Name, trigger.Group);
            TaskManager taskManager = iService.GetWhere(sqlWhere);
            if (taskManager == null)
            {
                FileQuartz.WriteErrorLog($"任务不存在");
                return Task.Delay(1);
            }
            try
            {
                string msg = $"开始时间:{dateTime.ToString("yyyy-MM-dd HH:mm:ss ffff")}";
                //记录任务执行记录
                iService.RecordRun(taskManager.Id, JobAction.开始,true, msg);
                //初始化任务日志
                FileQuartz.InitTaskJobLogPath(taskManager.Id);
                var jobId = context.MergedJobDataMap.GetString("OpenJob");
                //todo:这里可以加入自己的自动任务逻辑
                Log4NetHelper.Info(DateTime.Now.ToString() + "执行任务");


                stopwatch.Stop();
                string content = $"结束时间:{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ffff")} 共耗时{stopwatch.ElapsedMilliseconds} 毫秒\r\n";
                iService.RecordRun(taskManager.Id, JobAction.结束, true, content);
                if (taskManager.SendMail == MsgTypeOption.All.ToInt())
                {
                    string emailAddress = sysSetting.Email;
                    if (!string.IsNullOrEmpty(taskManager.EmailAddress))
                    {
                        emailAddress = taskManager.EmailAddress;
                    }

                    List<string> recipients = new List<string>();
                    recipients = emailAddress.Split(",").ToList();
                    var mailBodyEntity = new MailBodyEntity()
                    {
                        Body = msg + content + ",请勿回复本邮件",
                        Recipients = recipients,
                        Subject = taskManager.TaskName
                    };
                    SendMailHelper.SendMail(mailBodyEntity);

                }
            }
            catch (Exception ex)
            {
                stopwatch.Stop();
                string content = $"结束时间:{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ffff")} 共耗时{stopwatch.ElapsedMilliseconds} 毫秒\r\n";
                iService.RecordRun(taskManager.Id, JobAction.结束, false, content + ex.Message);
                FileQuartz.WriteErrorLog(ex.Message);
                if (taskManager.SendMail == MsgTypeOption.Error.ToInt() || taskManager.SendMail == MsgTypeOption.All.ToInt())
                {
                    string emailAddress = sysSetting.Email;
                    if (!string.IsNullOrEmpty(taskManager.EmailAddress))
                    {
                        emailAddress = taskManager.EmailAddress;
                    }

                    List<string> recipients = new List<string>();
                    recipients = emailAddress.Split(",").ToList();
                    var mailBodyEntity = new MailBodyEntity()
                    {
                        Body = "处理失败," + ex.Message + ",请勿回复本邮件",
                        Recipients = recipients,
                        Subject = taskManager.TaskName
                    };
                    SendMailHelper.SendMail(mailBodyEntity);
                }
            }

            return Task.Delay(1);
        }
    }
}

```

## 添加任务

编写完任务的执行代码后即可运行系统，在界面【定时任务】-【任务列表】中添加任务的执行规则，如图：

![](/job1.png)

添加任务规则后，在界面直接点击`启用`即可

![](/job2.png)

::: tip 提示
支持提供[CRON规则](https://cron.qqe2.com/)
:::

## 任务日志

在任务列表页面可以查看最近40条处理日志记录

![](/job3.png)

查看所有任务的日志在【定时任务】-【任务日志】中查看

![](/job4.png)

## 任务启动

QuartzService实现系统启动时定时任务的启动与执行操作，在Startup中注入服务即可。

``` cs
services.AddHostedService<QuartzService>();
```


如遇到问题到[Issues](https://gitee.com/yuebon/YuebonNetCore/issues)反馈