using SqlSugar;

namespace Yuebon.Security.Services;

/// <summary>
/// ��ɫҵ�����
/// </summary>
public class RoleService: BaseService<Role, RoleOutputDto>, IRoleService
{
    private IOrganizeService _organizeService;
    private IUserRoleService _userRoleService;
    private IRoleRepository  _roleRepository;
    /// <summary>
    /// 
    /// </summary>
    /// <param name="_repository"></param>
    /// <param name="organizeService"></param>
    /// <param name="userRoleService"></param>
    /// <param name="roleRepository"></param>
    public RoleService(IRepository<Role> _repository, IOrganizeService organizeService, IUserRoleService userRoleService,IRoleRepository roleRepository)
    {
        repository = _repository;
        _roleRepository = roleRepository;
        _organizeService = organizeService;
        _userRoleService = userRoleService;
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
    /// �����û�ID��ȡ��ɫ����
    /// </summary>
    /// <param name="userId">�û�ID</param>
    /// <returns></returns>
   public async Task<List<long>> GetRoleIdsByUserId(long userId)
   {       
        return  await _roleRepository.GetRoleIdsByUserId(userId);
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
        string where = string.Empty;
        List<long> orgIds = new List<long>();
        if (search.Filter?.OrganizeId != 0)
        {
            orgIds = await _organizeService.GetChildIdListWithSelfById((long)search.Filter.OrganizeId);
        }
        var exp= Expressionable.Create<Role>();
        exp.AndIF(!string.IsNullOrEmpty(search.Keywords), it => it.FullName.Contains(search.Keywords) || it.EnCode.Contains(search.Keywords))
            .AndIF(orgIds.Count != 0, it => orgIds.Contains((long)it.OrganizeId))
            .And(it=>it.Category==1);

        PagerInfo pagerInfo = new PagerInfo
        {
            CurrenetPageIndex = search.CurrenetPageIndex,
            PageSize = search.PageSize
        };
        List<Role> list = await repository.FindWithPagerAsync(exp.ToExpression(), pagerInfo, search.Sort, order);
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