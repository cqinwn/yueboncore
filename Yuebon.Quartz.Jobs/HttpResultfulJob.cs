using MediatR;
using Yuebon.Email.CommandHandler;

namespace Yuebon.Quartz.Jobs;

/// <summary>
/// 处理远程接口url的定时任务
/// </summary>
public class HttpResultfulJob : IJob
{
    private readonly ITaskManagerService _iService;
    private IMediator _mediatR;
    public HttpResultfulJob(ITaskManagerService iService, IMediator mediatR)
    {
        _iService = iService;
        _mediatR= mediatR;
    }

    /// <summary>
    /// 执行远程接口url的定时任务
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public Task Execute(IJobExecutionContext context)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        AbstractTrigger trigger = (context as JobExecutionContextImpl).Trigger as AbstractTrigger;
        string sqlWhere = string.Format("Id='{0}' and GroupName='{1}'", trigger.Name, trigger.Group);
        TaskManager taskManager = _iService.GetWhere(sqlWhere);
        string httpMessage = "";
        if (taskManager == null)
        {
            FileQuartz.WriteErrorLog($"任务不存在");
            return Task.Delay(1);
        }
        FileQuartz.InitTaskJobLogPath(taskManager.Id);
        string msg = $"开始时间:{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ffff")}";
        //记录任务执行记录
        _iService.RecordRun(taskManager.Id, JobAction.开始, true, msg);
        if (string.IsNullOrEmpty(taskManager.JobCallAddress) || taskManager.JobCallAddress == "/")
        {
            FileQuartz.WriteErrorLog($"{ DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ffff")}未配置任务地址,");
            _iService.RecordRun(taskManager.Id, JobAction.结束, false, "未配置任务地址");
            return Task.Delay(1);
        }
        try
        {
            Dictionary<string, string> header = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(taskManager.JobCallParams))
            {
                httpMessage = HttpClientHelper.Post(taskManager.JobCallParams, taskManager.JobCallAddress, header);
            }
            else
            {
                httpMessage = HttpClientHelper.HttpGet(taskManager.JobCallAddress);
            }
            stopwatch.Stop();
            string resume = $"结束时间:{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ffff")} 共耗时{stopwatch.ElapsedMilliseconds} 毫秒\r\n";
            _iService.RecordRun(taskManager.Id, JobAction.结束, true, resume,  $"消息:{ httpMessage ?? "OK"}");
            if ((MsgType)taskManager.SendMail == MsgType.All)
            {
                if (!string.IsNullOrEmpty(taskManager.EmailAddress))
                {
                    List<string> recipients = new List<string>();
                    recipients = taskManager.EmailAddress.Split(",").ToList();
                    var mailBodyEntity = new MailBodyEntity()
                    {
                        Body = resume + "\n\r请勿直接回复本邮件！",
                        Recipients = recipients,
                        Subject = taskManager.TaskName,
                    };
                    SendMailCommand sendMailCommand = new SendMailCommand(mailBodyEntity);
                    _mediatR.Send(sendMailCommand);
                }
            }
        }
        catch (Exception ex)
        {
            stopwatch.Stop();
            string resume = $"结束时间:{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ffff")} 共耗时{stopwatch.ElapsedMilliseconds} 毫秒\r\n";
            _iService.RecordRun(taskManager.Id, JobAction.结束, true, resume, ex.Message);
            FileQuartz.WriteErrorLog(ex.Message); 
            if ((MsgType)taskManager.SendMail== MsgType.Error|| (MsgType)taskManager.SendMail == MsgType.All)
            {
                if (!string.IsNullOrEmpty(taskManager.EmailAddress))
                {
                    List<string> recipients = new List<string>();
                    recipients = taskManager.EmailAddress.Split(",").ToList();
                    var mailBodyEntity = new MailBodyEntity()
                    {
                        Body = resume + ex.Message + "\n\r请勿直接回复本邮件!",
                        Recipients = recipients,
                        Subject = taskManager.TaskName,
                    };
                    SendMailCommand sendMailCommand = new SendMailCommand(mailBodyEntity);
                    _mediatR.Send(sendMailCommand);
                }
            }
        }

        return Task.Delay(1);
    }
}
