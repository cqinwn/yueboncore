using SqlSugar;

namespace Yuebon.Security.Services;

/// <summary>
/// 角色业务服务
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
    /// 根据角色编码获取角色
    /// </summary>
    /// <param name="enCode"></param>
    /// <returns></returns>
    public Role GetRole(string enCode)
    {
        string where = string.Format("EnCode='{0}'",enCode);
        return repository.GetWhere(where);
    }

    /// <summary>
    /// 根据用户ID获取角色编码
    /// </summary>
    /// <param name="userId">用户ID</param>
    /// <returns></returns>
   public async Task<List<long>> GetRoleIdsByUserId(long userId)
   {       
        return  await _roleRepository.GetRoleIdsByUserId(userId);
   }

    /// <summary>
    /// 根据用户角色ID获取角色编码
    /// </summary>
    /// <param name="ids">角色ID字符串，用“,”分格</param>
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
    /// 根据用户角色ID获取角色编码
    /// </summary>
    /// <param name="ids">角色ID字符串，用“,”分格</param>
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
    /// 根据条件查询数据库,并返回对象集合(用于分页数据显示)
    /// </summary>
    /// <param name="search">查询的条件</param>
    /// <returns>指定对象的集合</returns>
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