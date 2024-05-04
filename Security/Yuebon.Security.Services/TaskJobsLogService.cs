using SqlSugar;

namespace Yuebon.Security.Services;

/// <summary>
/// 定时任务执行日志服务接口实现
/// </summary>
public class TaskJobsLogService: BaseService<TaskJobsLog,TaskJobsLogOutputDto>, ITaskJobsLogService
{
		private readonly ITaskJobsLogRepository _repository;
    public TaskJobsLogService(ITaskJobsLogRepository taskJobsLogRepository)
    {
        repository = taskJobsLogRepository;
        _repository = taskJobsLogRepository;
    }
    /// <summary>
    /// 清空日志
    /// </summary>
    /// <returns></returns>
    public bool ClearLog() 
    {
      return repository.Db.DbMaintenance.TruncateTable<TaskJobsLog>();
    }
    /// <summary>
    /// 根据条件查询数据库,并返回对象集合(用于分页数据显示)
    /// </summary>
    /// <param name="search">查询的条件</param>
    /// <returns>指定对象的集合</returns>
    public override async Task<PageResult<TaskJobsLogOutputDto>> FindWithPagerAsync(SearchInputDto<TaskJobsLog> search)
    {
        bool order = search.Order == "asc" ? false : true;
        var expressionWhere = Expressionable.Create<TaskJobsLog>()
           .AndIF(!string.IsNullOrEmpty(search.Keywords), it => it.TaskName.Contains(search.Keywords))
           .ToExpression();
        PagerInfo pagerInfo = new PagerInfo
        {
            CurrenetPageIndex = search.CurrenetPageIndex,
            PageSize = search.PageSize
        };
        List<TaskJobsLog> list = await repository.FindWithPagerAsync(expressionWhere, pagerInfo, search.Sort, order);
        PageResult<TaskJobsLogOutputDto> pageResult = new PageResult<TaskJobsLogOutputDto>
        {
            CurrentPage = pagerInfo.CurrenetPageIndex,
            Items = list.MapTo<TaskJobsLogOutputDto>(),
            ItemsPerPage = pagerInfo.PageSize,
            TotalItems = pagerInfo.RecordCount
        };
        return pageResult;
    }
}