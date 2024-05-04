using SqlSugar;

namespace Yuebon.Security.Services;

/// <summary>
/// 访问/操作日志服务接口实现
/// </summary>
public class VisitlogService: BaseService<VisitLog,VisitlogOutputDto>, IVisitlogService
{
    public VisitlogService(IRepository<VisitLog> _repository)
    {
        repository = _repository;
    }


    public async void AddAsync(VisitLogInputDto entity)
    {
        await repository.InsertAsync(entity.MapTo<VisitLog>());
    }
    /// <summary>
    /// 根据条件查询数据库,并返回对象集合(用于分页数据显示)
    /// </summary>
    /// <param name="search">查询的条件</param>
    /// <returns>指定对象的集合</returns>
    public async Task<PageResult<VisitlogOutputDto>> FindWithPagerSearchAsync(SearchVisitLogModel search)
    {
        bool order = search.Order == "asc" ? false : true;

        var expressionWhere = Expressionable.Create<VisitLog>()
           .AndIF(!string.IsNullOrEmpty(search.CreatorTime1.ToString()), it => it.CreatorTime >= search.CreatorTime1)
           .AndIF(!string.IsNullOrEmpty(search.CreatorTime2.ToString()), it => it.CreatorTime <= search.CreatorTime2)
           .AndIF(!string.IsNullOrEmpty(search.Filter.Account), it => it.Account.Contains(search.Filter.Account))
           .AndIF(!string.IsNullOrEmpty(search.Filter.IPAddress), it => it.IPAddress.Contains(search.Filter.IPAddress))
           .ToExpression();
        PagerInfo pagerInfo = new PagerInfo
        {
            CurrenetPageIndex = search.CurrenetPageIndex,
            PageSize = search.PageSize
        };
        List<VisitLog> list = await repository.FindWithPagerAsync(expressionWhere, pagerInfo, search.Sort, order);
        PageResult<VisitlogOutputDto> pageResult = new PageResult<VisitlogOutputDto>
        {
            CurrentPage = pagerInfo.CurrenetPageIndex,
            Items = list.MapTo<VisitlogOutputDto>(),
            ItemsPerPage = pagerInfo.PageSize,
            TotalItems = pagerInfo.RecordCount
        };
        return pageResult;
    }
}