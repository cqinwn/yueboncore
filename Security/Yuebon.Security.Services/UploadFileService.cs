namespace Yuebon.Security.Services;

/// <summary>
/// 
/// </summary>
public class UploadFileService : BaseService<UploadFile, UploadFileOutputDto>, IUploadFileService
{
    private readonly IUploadFileRepository _uploadFileRepository;
    public UploadFileService(IUploadFileRepository uploadFileRepository)
    {
        _uploadFileRepository = uploadFileRepository;
        repository = uploadFileRepository;
    }

    /// <summary>
    /// 根据应用Id和应用标识批量更新数据
    /// </summary>
    /// <param name="beLongAppId">应用Id</param>
    /// <param name="oldBeLongAppId">更新前旧的应用Id</param>
    /// <param name="belongApp">应用标识</param>
    /// <returns></returns>
    public bool UpdateByBeLongAppId(string beLongAppId, string oldBeLongAppId,string belongApp = "")
    {
       return _uploadFileRepository.UpdateByBeLongAppId(beLongAppId, oldBeLongAppId, belongApp);
    }

    /// <summary>
    /// 根据条件查询数据库,并返回对象集合(用于分页数据显示)
    /// </summary>
    /// <param name="search">查询的条件</param>
    /// <returns>指定对象的集合</returns>
    public override async Task<PageResult<UploadFileOutputDto>> FindWithPagerAsync(SearchInputDto<UploadFile> search)
    {
        bool order = search.Order == "asc" ? false : true;
        string where = GetDataPrivilege(false);
        if (!string.IsNullOrEmpty(search.Keywords))
        {
            where += string.Format(" and  FileName like '%{0}%' ", search.Keywords);
        };
        PagerInfo pagerInfo = new PagerInfo
        {
            CurrenetPageIndex = search.CurrenetPageIndex,
            PageSize = search.PageSize
        };
        List<UploadFile> list = await _uploadFileRepository.FindWithPagerAsync(where, pagerInfo, search.Sort, order);
        PageResult<UploadFileOutputDto> pageResult = new PageResult<UploadFileOutputDto>
        {
            CurrentPage = pagerInfo.CurrenetPageIndex,
            Items = list.MapTo<UploadFileOutputDto>(),
            ItemsPerPage = pagerInfo.PageSize,
            TotalItems = pagerInfo.RecordCount
        };
        return pageResult;
    }
}
