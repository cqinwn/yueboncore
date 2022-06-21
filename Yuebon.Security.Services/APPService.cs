namespace Yuebon.Security.Services;

/// <summary>
/// 
/// </summary>
public class APPService: BaseService<APP,AppOutputDto>, IAPPService
{
    public APPService(IRepository<APP> appRepository)
    {
        repository = appRepository;
    }

    /// <summary>
    /// 同步新增实体。
    /// </summary>
    /// <param name="entity">实体</param>
    /// <param name="trans">事务对象</param>
    /// <returns></returns>
    public override int Insert(APP entity)
    {
        int result = repository.Insert(entity); 
        this.UpdateCacheAllowApp();
        return result;
    }

    /// <summary>
    /// 异步更新实体。
    /// </summary>
    /// <param name="entity">实体</param>
    /// <param name="where">条件</param>
    /// <returns></returns>
    public override async Task<bool> UpdateAsync(APP entity, string where)
    {
        bool result=await repository.UpdateAsync(entity, where);
        this.UpdateCacheAllowApp();
        return result;
    }
    /// <summary>
    /// 异步步新增实体。
    /// </summary>
    /// <param name="entity">实体</param>
    /// <param name="trans">事务对象</param>
    /// <returns></returns>
    public override async Task<int> InsertAsync(APP entity)
    {
        int result = await repository.InsertAsync(entity);
        this.UpdateCacheAllowApp();
        return result;
    }
    /// <summary>
    /// 获取app对象
    /// </summary>
    /// <param name="appid">应用ID</param>
    /// <param name="secret">应用密钥AppSecret</param>
    /// <returns></returns>
    public async Task<APP> GetAPP(string appid, string secret)
    {
        return await repository.Db.Queryable<APP>().Where(o=>o.AppId==appid &&o.AppSecret==secret).FirstAsync();
    }
    /// <summary>
    /// 获取app对象
    /// </summary>
    /// <param name="appid">应用ID</param>
    /// <returns></returns>
    public async Task<APP> GetAPP(string appid)
    {
        return await repository.Db.Queryable<APP>().Where(o => o.AppId == appid).FirstAsync();
    }
    /// <summary>
    /// 根据条件查询数据库,并返回对象集合(用于分页数据显示)
    /// </summary>
    /// <param name="search">查询的条件</param>
    /// <returns>指定对象的集合</returns>
    public override async Task<PageResult<AppOutputDto>> FindWithPagerAsync(SearchInputDto<APP> search)
    {
        bool order = search.Order == "asc" ? false : true;
        string where = GetDataPrivilege(false);
        if (!string.IsNullOrEmpty(search.Keywords))
        {
            where += string.Format(" and (AppId like '%{0}%' or RequestUrl like '%{0}%')", search.Keywords);
        };
        PagerInfo pagerInfo = new PagerInfo
        {
            CurrenetPageIndex = search.CurrenetPageIndex,
            PageSize = search.PageSize
        };
        List<APP> list = await repository.FindWithPagerAsync(where, pagerInfo, search.Sort, order);
        PageResult<AppOutputDto> pageResult = new PageResult<AppOutputDto>
        {
            CurrentPage = pagerInfo.CurrenetPageIndex,
            Items = list.MapTo<AppOutputDto>(),
            ItemsPerPage = pagerInfo.PageSize,
            TotalItems = pagerInfo.RecordCount
        };
        return pageResult;
    }
    /// <summary>
    /// 更新可用应用缓存
    /// </summary>
    public void UpdateCacheAllowApp()
    {
        IEnumerable<APP> appList = repository.GetAllByIsNotDeleteAndEnabledMark();
        YuebonCacheHelper yuebonCacheHelper = new YuebonCacheHelper();
        yuebonCacheHelper.Add("cacheAppList", appList);
    }
}