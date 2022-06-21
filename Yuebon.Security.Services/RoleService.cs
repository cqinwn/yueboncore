namespace Yuebon.Security.Services;

/// <summary>
/// ��ɫҵ�����
/// </summary>
public class RoleService: BaseService<Role, RoleOutputDto>, IRoleService
{
    private IOrganizeService _organizeService;
    /// <summary>
    /// 
    /// </summary>
    /// <param name="roleRepository"></param>
    /// <param name="organizeService"></param>
    public RoleService(IRepository<Role> roleRepository, IOrganizeService organizeService)
    {
        repository=roleRepository;
        _organizeService = organizeService;
    }

    /// <summary>
    /// ���ݽ�ɫ�����ȡ��ɫ
    /// </summary>
    /// <param name="enCode"></param>
    /// <returns></returns>
    public Role GetRole(string enCode)
    {
        string where = string.Format("EnCode='{0}'",enCode);
        return repository.GetWhere(where);
    }


    /// <summary>
    /// �����û���ɫID��ȡ��ɫ����
    /// </summary>
    /// <param name="ids">��ɫID�ַ������á�,���ָ�</param>
    /// <returns></returns>
    public string GetRoleEnCode(string ids)
    {
        string roleIDsStr = string.Format("'{0}'", ids.Replace(",", "','"));
        string sqlWhere = string.Format("Id in({0})", roleIDsStr);
        IEnumerable<Role> listRoles = repository.GetListWhere(sqlWhere);
        string strEnCode = string.Empty;
        foreach (Role item in listRoles)
        {
            strEnCode += item.EnCode + ",";
        }
        return strEnCode;

    }


    /// <summary>
    /// �����û���ɫID��ȡ��ɫ����
    /// </summary>
    /// <param name="ids">��ɫID�ַ������á�,���ָ�</param>
    /// <returns></returns>
    public string GetRoleNameStr(string ids)
    {
        string roleIDsStr = string.Format("'{0}'", ids.Replace(",", "','"));
        string sqlWhere = string.Format("Id in({0})", roleIDsStr);
        IEnumerable<Role> listRoles = repository.GetListWhere(sqlWhere);
        string strEnCode = string.Empty;
        foreach (Role item in listRoles)
        {
            strEnCode += item.FullName + ",";
        }
        return strEnCode;

    }

    /// <summary>
    /// ����������ѯ���ݿ�,�����ض��󼯺�(���ڷ�ҳ������ʾ)
    /// </summary>
    /// <param name="search">��ѯ������</param>
    /// <returns>ָ������ļ���</returns>
    public override async Task<PageResult<RoleOutputDto>> FindWithPagerAsync(SearchInputDto<Role> search)
    {
        bool order = search.Order == "asc" ? false : true;
        string where = GetDataPrivilege(false);
        if (!string.IsNullOrEmpty(search.Keywords))
        {
            where += string.Format(" and (FullName like '%{0}%' or EnCode like '%{0}%')", search.Keywords);
        };
        where += " and Category=1";
        PagerInfo pagerInfo = new PagerInfo
        {
            CurrenetPageIndex = search.CurrenetPageIndex,
            PageSize = search.PageSize
        };
        List<Role> list = await repository.FindWithPagerAsync(where, pagerInfo, search.Sort, order);
        List<RoleOutputDto> resultList = list.MapTo<RoleOutputDto>();
        List<RoleOutputDto> listResult = new List<RoleOutputDto>();
        foreach (RoleOutputDto item in resultList)
        {
            if (item.OrganizeId>0)
            {
                item.OrganizeName = _organizeService.GetById(item.OrganizeId).FullName;
            }
            listResult.Add(item);
        }
        PageResult<RoleOutputDto> pageResult = new PageResult<RoleOutputDto>
        {
            CurrentPage = pagerInfo.CurrenetPageIndex,
            Items = listResult.MapTo<RoleOutputDto>(),
            ItemsPerPage = pagerInfo.PageSize,
            TotalItems = pagerInfo.RecordCount
        };
        return pageResult;
    }
}