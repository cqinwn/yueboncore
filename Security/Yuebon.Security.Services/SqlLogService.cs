using SqlSugar;

namespace Yuebon.Security.Services;

/// <summary>
/// SQL日志服务接口实现
/// </summary>
public class SqlLogService: BaseService<SqlLog, SqlLogOutputDto>, ISqlLogService
{
    public SqlLogService(IRepository<SqlLog> _repository)
    {
			repository=_repository;
    }


    public async void AddAsync(SqlLogInputDto entity)
    {
        await repository.InsertAsync(entity.MapTo<SqlLog>());
    }
    /// <summary>
    /// 根据条件查询数据库,并返回对象集合(用于分页数据显示)
    /// </summary>
    /// <param name="search">查询的条件</param>
    /// <returns>指定对象的集合</returns>
    public async Task<PageResult<SqlLogOutputDto>> FindWithPagerSearchAsync(SearchVisitLogModel search)
    {
        bool order = search.Order == "asc" ? false : true;
        var expressionWhere = Expressionable.Create<SqlLog>()
           .AndIF(!string.IsNullOrEmpty(search.CreatorTime1.ToString()), it => it.CreatorTime >= search.CreatorTime1)
           .AndIF(!string.IsNullOrEmpty(search.CreatorTime2.ToString()), it => it.CreatorTime <= search.CreatorTime2)
           .AndIF(!string.IsNullOrEmpty(search.Filter.Account), it => it.Account.Contains(search.Filter.Account))
           .ToExpression();
        PagerInfo pagerInfo = new PagerInfo
        {
            CurrenetPageIndex = search.CurrenetPageIndex,
            PageSize = search.PageSize
        };
        List<SqlLog> list = await repository.FindWithPagerAsync(expressionWhere, pagerInfo, search.Sort, order);
        PageResult<SqlLogOutputDto> pageResult = new PageResult<SqlLogOutputDto>
        {
            CurrentPage = pagerInfo.CurrenetPageIndex,
            Items = list.MapTo<SqlLogOutputDto>(),
            ItemsPerPage = pagerInfo.PageSize,
            TotalItems = pagerInfo.RecordCount
        };
        return pageResult;
    }
}