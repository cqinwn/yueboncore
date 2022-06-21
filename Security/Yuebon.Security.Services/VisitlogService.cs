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
        string where = GetDataPrivilege(false);
        if (!string.IsNullOrEmpty(search.CreatorTime1))
        {
            where += " and CreatorTime >='" + search.CreatorTime1.ToDateTime() + "'";
        }
        if (!string.IsNullOrEmpty(search.CreatorTime2))
        {
            where += " and CreatorTime <='" + search.CreatorTime2.ToDateTime() + "'";
        }
        if (!string.IsNullOrEmpty(search.Filter.IPAddress))
        {
            where += string.Format(" and IPAddress = '{0}'", search.Filter.IPAddress);
        };
        if (!string.IsNullOrEmpty(search.Filter.Account))
        {
            where += string.Format(" and Account = '{0}'", search.Filter.Account);
        };
        PagerInfo pagerInfo = new PagerInfo
        {
            CurrenetPageIndex = search.CurrenetPageIndex,
            PageSize = search.PageSize
        };
        List<VisitLog> list = await repository.FindWithPagerAsync(where, pagerInfo, search.Sort, order);
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