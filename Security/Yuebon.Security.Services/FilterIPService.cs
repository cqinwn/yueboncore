namespace Yuebon.Security.Services;

public class FilterIPService: BaseService<FilterIP, FilterIPOutputDto>, IFilterIPService
{
    private readonly IFilterIPRepository _repository;
    public FilterIPService(IFilterIPRepository filterIPRepository)
    {
        repository = filterIPRepository;
        _repository = filterIPRepository;
    }
    /// <summary>
    /// 验证IP地址是否被拒绝
    /// </summary>
    /// <param name="ip"></param>
    /// <returns></returns>
    public bool ValidateIP(string ip)
    {
      return  _repository.ValidateIP(ip);
    }

    /// <summary>
    /// 根据条件查询数据库,并返回对象集合(用于分页数据显示)
    /// </summary>
    /// <param name="search">查询的条件</param>
    /// <returns>指定对象的集合</returns>
    public override async Task<PageResult<FilterIPOutputDto>> FindWithPagerAsync(SearchInputDto<FilterIP> search)
    {
        bool order = search.Order == "asc" ? false : true;
        string where = GetDataPrivilege(false);
        if (!string.IsNullOrEmpty(search.Keywords))
        {
            where += string.Format(" and (StartIP like '%{0}%' or EndIP like '%{0}%')", search.Keywords);
        };
        PagerInfo pagerInfo = new PagerInfo
        {
            CurrenetPageIndex = search.CurrenetPageIndex,
            PageSize = search.PageSize
        };
        List<FilterIP> list = await repository.FindWithPagerAsync(where, pagerInfo, search.Sort, order);
        PageResult<FilterIPOutputDto> pageResult = new PageResult<FilterIPOutputDto>
        {
            CurrentPage = pagerInfo.CurrenetPageIndex,
            Items = list.MapTo<FilterIPOutputDto>(),
            ItemsPerPage = pagerInfo.PageSize,
            TotalItems = pagerInfo.RecordCount
        };
        return pageResult;
    }
}