using SqlSugar;
using Yuebon.Commons.Const;

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
    /// ͬ������ʵ�塣
    /// </summary>
    /// <param name="entity">ʵ��</param>
    /// <param name="trans">�������</param>
    /// <returns></returns>
    public override int Insert(APP entity)
    {
        int result = repository.Insert(entity); 
        this.UpdateCacheAllowApp();
        return result;
    }

    /// <summary>
    /// �첽����ʵ�塣
    /// </summary>
    /// <param name="entity">ʵ��</param>
    /// <param name="where">����</param>
    /// <returns></returns>
    public override async Task<bool> UpdateAsync(APP entity, string where)
    {
        bool result=await repository.UpdateAsync(entity, where);
        this.UpdateCacheAllowApp();
        return result;
    }
    /// <summary>
    /// �첽������ʵ�塣
    /// </summary>
    /// <param name="entity">ʵ��</param>
    /// <param name="trans">�������</param>
    /// <returns></returns>
    public override async Task<int> InsertAsync(APP entity)
    {
        int result = await repository.InsertAsync(entity);
        this.UpdateCacheAllowApp();
        return result;
    }
    /// <summary>
    /// ��ȡapp����
    /// </summary>
    /// <param name="appid">Ӧ��ID</param>
    /// <param name="secret">Ӧ����ԿAppSecret</param>
    /// <returns></returns>
    public async Task<APP> GetAPP(string appid, string secret)
    {
        return await repository.Db.Queryable<APP>().Where(o=>o.AppId==appid &&o.AppSecret==secret).FirstAsync();
    }
    /// <summary>
    /// ��ȡapp����
    /// </summary>
    /// <param name="appid">Ӧ��ID</param>
    /// <returns></returns>
    public async Task<APP> GetAPP(string appid)
    {
        return await repository.Db.Queryable<APP>().Where(o => o.AppId == appid).FirstAsync();
    }
    /// <summary>
    /// ����������ѯ���ݿ�,�����ض��󼯺�(���ڷ�ҳ������ʾ)
    /// </summary>
    /// <param name="search">��ѯ������</param>
    /// <returns>ָ������ļ���</returns>
    public override async Task<PageResult<AppOutputDto>> FindWithPagerAsync(SearchInputDto<APP> search)
    {
        bool order = search.Order == "asc" ? false : true;
        var exp = Expressionable.Create<APP>()
           .AndIF(!string.IsNullOrEmpty(search.Keywords), it => it.AppId.Contains(search.Keywords)|| it.RequestUrl.Contains(search.Keywords))
           .ToExpression();
        PagerInfo pagerInfo = new PagerInfo
        {
            CurrenetPageIndex = search.CurrenetPageIndex,
            PageSize = search.PageSize
        };
        List<APP> list = await repository.FindWithPagerAsync(exp, pagerInfo, search.Sort, order);
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
    /// ���¿���Ӧ�û���
    /// </summary>
    public void UpdateCacheAllowApp()
    {
        IEnumerable<APP> appList = repository.GetAllByIsNotDeleteAndEnabledMark();
        YuebonCacheHelper yuebonCacheHelper = new YuebonCacheHelper();
        yuebonCacheHelper.Add(CacheConst.KeyAppList, appList);
    }
}