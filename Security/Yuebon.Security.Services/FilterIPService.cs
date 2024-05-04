using SqlSugar;

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
    /// ��֤IP��ַ�Ƿ񱻾ܾ�
    /// </summary>
    /// <param name="ip"></param>
    /// <returns></returns>
    public bool ValidateIP(string ip)
    {
      return  _repository.ValidateIP(ip);
    }

    /// <summary>
    /// ����������ѯ���ݿ�,�����ض��󼯺�(���ڷ�ҳ������ʾ)
    /// </summary>
    /// <param name="search">��ѯ������</param>
    /// <returns>ָ������ļ���</returns>
    public override async Task<PageResult<FilterIPOutputDto>> FindWithPagerAsync(SearchInputDto<FilterIP> search)
    {
        bool order = search.Order == "asc" ? false : true;

        var expressionWhere = Expressionable.Create<FilterIP>()
           .AndIF(!string.IsNullOrEmpty(search.Keywords), it => it.StartIP.Contains(search.Keywords) || it.EndIP.Contains(search.Keywords))
           .ToExpression();
        PagerInfo pagerInfo = new PagerInfo
        {
            CurrenetPageIndex = search.CurrenetPageIndex,
            PageSize = search.PageSize
        };
        List<FilterIP> list = await repository.FindWithPagerAsync(expressionWhere, pagerInfo, search.Sort, order);
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