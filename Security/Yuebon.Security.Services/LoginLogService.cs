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
        List<LoginLog> list = await repository.FindWithPagerAsync(where, pagerInfo, search.Sort, order);
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
