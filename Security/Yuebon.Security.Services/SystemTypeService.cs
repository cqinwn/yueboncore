using SqlSugar;

namespace Yuebon.Security.Services;

/// <summary>
/// 
/// </summary>
public class SystemTypeService : BaseService<SystemType, SystemTypeOutputDto>, ISystemTypeService
{
    private readonly ISystemTypeRepository _repository;
    private readonly IRoleAuthorizeService roleAuthorizeService;
    /// <summary>
    /// 
    /// </summary>
    /// <param name="repository"></param>
    /// <param name="logService"></param>
    public SystemTypeService(ISystemTypeRepository systemTypeRepository,  IRoleAuthorizeService _roleAuthorizeService)
    {
        repository = systemTypeRepository;
        _repository = systemTypeRepository;
        roleAuthorizeService = _roleAuthorizeService;
    }

    /// <summary>
    /// ����ϵͳ�����ѯϵͳ����
    /// </summary>
    /// <param name="appkey">ϵͳ����</param>
    /// <returns></returns>
    public SystemType GetByCode(string appkey)
    {
        return _repository.GetByCode(appkey);
    }

    /// <summary>
    /// ����ϵͳ�����ѯϵͳ����
    /// </summary>
    /// <param name="appkey">ϵͳ����</param>
    /// <param name="tenantId">�⻧id</param>
    /// <returns></returns>
    public SystemType GetByCode(string appkey, long tenantId)
    { 
        return _repository.GetByCode(appkey, tenantId);
    }

    /// <summary>
    /// ���ݽ�ɫ��ȡ���Է�����ϵͳ
    /// </summary>
    /// <param name="roleIds">��ɫId����','����</param>
    /// <returns></returns>
    public async Task<List<UserVisitSystemnTypes>> GetSubSystemList(List<long> roleIds)
    {       
        List<int> ints = new List<int>();
        ints.Add(0);
        IEnumerable<RoleAuthorize> roleAuthorizes = await roleAuthorizeService.GetListRoleAuthorizeByRoleId(roleIds, ints);
        string strWhere = string.Empty;
        if (roleAuthorizes.Count() > 0)
        {
            strWhere = " Id in (";
            foreach (RoleAuthorize item in roleAuthorizes)
            {
                strWhere += "'" + item.ItemId + "',";
            }
            strWhere = strWhere.Substring(0, strWhere.Length - 1) + ")";
        }
        List<UserVisitSystemnTypes> list = _repository.GetAllByIsNotDeleteAndEnabledMark(strWhere).OrderBy(t => t.SortCode).ToList().MapTo<UserVisitSystemnTypes>();
        return list;        
    }



    /// <summary>
    /// ����������ѯ���ݿ�,�����ض��󼯺�(���ڷ�ҳ������ʾ)
    /// </summary>
    /// <param name="search">��ѯ������</param>
    /// <returns>ָ������ļ���</returns>
    public override async Task<PageResult<SystemTypeOutputDto>> FindWithPagerAsync(SearchInputDto<SystemType> search)
    {
        bool order = search.Order == "asc" ? false : true;
        var expressionWhere = Expressionable.Create<SystemType>()
           .AndIF(!string.IsNullOrEmpty(search.Keywords), it => it.FullName.Contains(search.Keywords)|| it.EnCode.Contains(search.Keywords))
           .ToExpression();
        PagerInfo pagerInfo = new PagerInfo
        {
            CurrenetPageIndex = search.CurrenetPageIndex,
            PageSize = search.PageSize
        };
        List<SystemType> list = await repository.FindWithPagerAsync(expressionWhere, pagerInfo, search.Sort, order);
        PageResult<SystemTypeOutputDto> pageResult = new PageResult<SystemTypeOutputDto>
        {
            CurrentPage = pagerInfo.CurrenetPageIndex,
            Items = list.MapTo<SystemTypeOutputDto>(),
            ItemsPerPage = pagerInfo.PageSize,
            TotalItems = pagerInfo.RecordCount
        };
        return pageResult;
    }
}