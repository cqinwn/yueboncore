using MediatR;
using Yuebon.Email.CommandHandler;

namespace Yuebon.Quartz.Jobs;

/// <summary>
/// 定时删除操作日志和任务日志
/// 
/// </summary>
public class SysLogJob : IJob
{
    private readonly ITaskManagerService iService;
    private readonly ITaskJobsLogService iJobLogService;
    private readonly ILogService iLogService;
    private IMediator _mediatR;

    public SysLogJob(ITaskManagerService iService, ITaskJobsLogService iJobLogService, ILogService iLogService, IMediator mediatR)
    {
        this.iService = iService;
        this.iJobLogService = iJobLogService;
        this.iLogService = iLogService;
        _mediatR = mediatR;
    }

    public async Task Execute(IJobExecutionContext context)
    {
        DateTime dateTime = DateTime.Now; 
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        AbstractTrigger trigger = (context as JobExecutionContextImpl).Trigger as AbstractTrigger;
        string sqlWhere = string.Format("Id='{0}' and GroupName='{1}'", trigger.Name, trigger.Group);
        TaskManager taskManager = iService.GetWhere(sqlWhere);
        if (taskManager == null)
        {
            FileQuartz.WriteErrorLog($"任务不存在");
        }
        try
        {
            string msg = $"开始时间:{dateTime.ToString("yyyy-MM-dd HH:mm:ss ffff")}";
            //记录任务执行记录
            iService.RecordRun(taskManager.Id, JobAction.开始, true, msg);
            //初始化任务日志
            FileQuartz.InitTaskJobLogPath(taskManager.Id);

            var jobId = context.MergedJobDataMap.GetString("OpenJob");
            iJobLogService.ClearLog();
            string where = "CreatorTime<'"+ DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd") + "'";
            await iLogService.DeleteBatchWhereAsync(where);

            stopwatch.Stop();
            string resume = $"结束时间:{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ffff")} 共耗时{stopwatch.ElapsedMilliseconds} 毫秒\r\n";
            iService.RecordRun(taskManager.Id, JobAction.结束, true, resume);
            if ((MsgType)taskManager.SendMail == MsgType.All)
            {
                if (!string.IsNullOrEmpty(taskManager.EmailAddress))
                {
                    List<string> recipients = new List<string>();
                    recipients = taskManager.EmailAddress.Split(",").ToList();
                    var mailBodyEntity = new MailBodyEntity()
                    {
                        Body = resume + ",请勿回复本邮件",
                        Recipients = recipients,
                        Subject = taskManager.TaskName
                    };

                    SendMailCommand sendMailCommand = new SendMailCommand(mailBodyEntity);
                    await _mediatR.Send(sendMailCommand);
                }
            }
        }
        catch (Exception ex)
        {
            stopwatch.Stop();
            string resume = $"结束时间:{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ffff")} 共耗时{stopwatch.ElapsedMilliseconds} 毫秒\r\n";
            iService.RecordRun(taskManager.Id, JobAction.结束, true, resume, ex.Message);
            FileQuartz.WriteErrorLog(ex.Message);
            if ((MsgType)taskManager.SendMail == MsgType.Error || (MsgType)taskManager.SendMail == MsgType.All)
            {
                if (!string.IsNullOrEmpty(taskManager.EmailAddress))
                {
                    List<string> recipients = new List<string>();
                    recipients = taskManager.EmailAddress.Split(",").ToList();
                    var mailBodyEntity = new MailBodyEntity()
                    {
                        Body = "处理失败," + ex.Message + ",请勿回复本邮件",
                        Recipients = recipients,
                        Subject = taskManager.TaskName
                    };
                    await SendMailHelper.SendMail(mailBodyEntity);
                }
            }
        }
    }
}
