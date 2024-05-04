using Quartz;
using SqlSugar;
using Yuebon.Commons.DependencyInjection;
using Yuebon.Commons.Enums;
using Yuebon.Commons.Helpers;

namespace Yuebon.Security.Services;

/// <summary>
/// 定时任务服务接口实现
/// </summary>
public class TaskManagerService : BaseService<TaskManager, TaskManagerOutputDto>, ITaskManagerService, IScopedDependency
{
    private readonly ITaskManagerRepository _repository;
    private readonly ITaskJobsLogService _taskJobsLogService;
    /// <summary>
    /// 
    /// </summary>
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="repository"></param>
    /// <param name="taskJobsLogService"></param>
    public TaskManagerService(ITaskManagerRepository taskManagerRepository, ITaskJobsLogService taskJobsLogService)
    {
        repository = taskManagerRepository;
        _repository = taskManagerRepository;
        _taskJobsLogService = taskJobsLogService;
    }

    /// <summary>
    /// 记录任务运行结果
    /// </summary>
    /// <param name="jobId">任务Id</param>
    /// <param name="jobAction">任务执行动作</param>
    /// <param name="blresultTag">任务执行结果表示，true成功，false失败，初始执行为true</param>
    /// <param name="resume">结果简述</param>
    /// <param name="desc">返回消息详情</param>
    public void RecordRun(long jobId, JobAction jobAction, bool blresultTag = true, string resume = "",string desc="")
    {
        DateTime addTime = DateTime.Now;
        TaskManager job = _repository.Db.Queryable<TaskManager>().First(t => t.Id == jobId);
        if (job == null)
        {
            _taskJobsLogService.Insert(new TaskJobsLog
            {
                Id = IdGeneratorHelper.IdSnowflake(),
                CreatorTime = DateTime.Now,
                TaskId = jobId,
                TaskName = "",
                JobAction = jobAction.ToString(),
                Status = false,
                Resume = $"未能找到定时任务：{jobId}",
                Description = desc
                
            });
            return;
        }
        string  strDesc = string.Empty;
        if (!blresultTag)
        {
            job.ErrorCount++;
            job.LastErrorTime = addTime;
            strDesc = $"异常，" + resume;

        }
        else
        {
            strDesc = $"正常，" + resume;
        }
        if (jobAction == JobAction.开始)
        {
            job.RunCount++;
            job.LastRunTime = addTime;
            CronExpression cronExpression = new CronExpression(job.Cron);
            job.NextRunTime = cronExpression.GetNextValidTimeAfter(addTime).ToDateTime();
        }
        _repository.Update(job);

        _taskJobsLogService.Insert(new TaskJobsLog
        {
            Id = IdGeneratorHelper.IdSnowflake(),
            CreatorTime = DateTime.Now,
            TaskId = job.Id,
            TaskName = job.TaskName,
            JobAction = jobAction.ToString(),
            Status = blresultTag,
            Resume = strDesc,
            Description= desc
        });
    }

    /// <summary>
    /// 根据条件查询数据库,并返回对象集合(用于分页数据显示)
    /// </summary>
    /// <param name="search">查询的条件</param>
    /// <returns>指定对象的集合</returns>
    public override async Task<PageResult<TaskManagerOutputDto>> FindWithPagerAsync(SearchInputDto<TaskManager> search)
    {
        bool order = search.Order == "asc" ? false : true;
        var expressionWhere = Expressionable.Create<TaskManager>()
           .AndIF(!string.IsNullOrEmpty(search.Keywords), it => it.TaskName.Contains(search.Keywords)||it.GroupName.Contains(search.Keywords))
           .AndIF(!string.IsNullOrEmpty(search.Filter?.Cron), it => it.Cron.Contains(search.Filter.Cron))
           .ToExpression();
        PagerInfo pagerInfo = new PagerInfo
        {
            CurrenetPageIndex = search.CurrenetPageIndex,
            PageSize = search.PageSize
        };
        List<TaskManager> list = await repository.FindWithPagerAsync(expressionWhere, pagerInfo, search.Sort, order);
        PageResult<TaskManagerOutputDto> pageResult = new PageResult<TaskManagerOutputDto>
        {
            CurrentPage = pagerInfo.CurrenetPageIndex,
            Items = list.MapTo<TaskManagerOutputDto>(),
            ItemsPerPage = pagerInfo.PageSize,
            TotalItems = pagerInfo.RecordCount
        };
        return pageResult;
    }
}