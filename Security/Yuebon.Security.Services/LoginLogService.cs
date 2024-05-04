using SqlSugar;

namespace Yuebon.Security.Services;

public class LoginLogService : BaseService<LoginLog, LoginLogOutputDto>, ILoginLogService
{
    public LoginLogService(IRepository<LoginLog> loginLogRepository)
    {
        repository = loginLogRepository;
    }


    /// <summary>
    /// 根据条件查询数据库,并返回对象集合(用于分页数据显示)
    /// </summary>
    /// <param name="search">查询的条件</param>
    /// <returns>指定对象的集合</returns>
    public async Task<PageResult<LoginLogOutputDto>> FindWithPagerSearchAsync(SearchLoginLogModel search)
    {
        bool order = search.Order == "asc" ? false : true;

        var expressionWhere = Expressionable.Create<LoginLog>()
           .AndIF(!string.IsNullOrEmpty(search.CreatorTime1.ToString()), it => it.CreatorTime>= search.CreatorTime1)
           .AndIF(!string.IsNullOrEmpty(search.CreatorTime2.ToString()), it => it.CreatorTime <= search.CreatorTime2)
           .AndIF(!string.IsNullOrEmpty(search.Filter.Account), it => it.Account.Contains(search.Filter.Account))
           .AndIF(!string.IsNullOrEmpty(search.Filter.IPAddress), it => it.IPAddress.Contains(search.Filter.IPAddress))
           .ToExpression();
        PagerInfo pagerInfo = new PagerInfo
        {
            CurrenetPageIndex = search.CurrenetPageIndex,
            PageSize = search.PageSize
        };
        List<LoginLog> list = await repository.FindWithPagerAsync(expressionWhere, pagerInfo, search.Sort, order);
        PageResult<LoginLogOutputDto> pageResult = new PageResult<LoginLogOutputDto>
        {
            CurrentPage = pagerInfo.CurrenetPageIndex,
            Items = list.MapTo<LoginLogOutputDto>(),
            ItemsPerPage = pagerInfo.PageSize,
            TotalItems = pagerInfo.RecordCount
        };
        return pageResult;
    }
}
