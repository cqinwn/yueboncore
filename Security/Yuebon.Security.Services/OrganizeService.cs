using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Yuebon.Commons.Core.App;
using Yuebon.Core.Repositories;

namespace Yuebon.Security.Services;

/// <summary>
/// 组织机构
/// </summary>
public class OrganizeService: BaseService<Organize, OrganizeOutputDto>, IOrganizeService
{
    private readonly IOrganizeRepository _repository;
    private readonly IUserRepository _userRepository;
    private readonly IUserRoleRepository _userRoleRepository;
    private readonly IRoleDataRepository _roleDataRepository;
    private readonly BaseRepository<Organize> _orgRepos;
  

    public OrganizeService(IOrganizeRepository organizeRepository, IUserRepository userRepository, IUserRoleRepository userRoleRepository, IRoleDataRepository roleDataRepository, BaseRepository<Organize> orgRepos)
    {
        repository = organizeRepository;
        _repository = organizeRepository;
        _userRepository = userRepository;
        _userRoleRepository = userRoleRepository;
        _roleDataRepository = roleDataRepository;
        _orgRepos = orgRepos;
    }


    /// <summary>
    /// 获取组织机构适用于Vue 树形列表
    /// </summary>
    /// <returns></returns>
    public async Task<List<Organize>> GetAllOrganizeTreeTable()
    {
        return await _repository.GetAllOrganizeTreeTable();
    }


    /// <summary>
    /// 获取子集，递归调用
    /// </summary>
    /// <param name="data"></param>
    /// <param name="parentId">父级Id</param>
    /// <returns></returns>
    private List<OrganizeOutputDto> GetSubOrganizes(List<Organize> data, long parentId)
    {
        List<OrganizeOutputDto> list = new List<OrganizeOutputDto>();
        OrganizeOutputDto OrganizeOutputDto = new OrganizeOutputDto();
        var ChilList = data.FindAll(t => t.ParentId == parentId);
        foreach (Organize entity in ChilList)
        {
            OrganizeOutputDto = entity.MapTo<OrganizeOutputDto>();
            OrganizeOutputDto.Children = GetSubOrganizes(data, entity.Id).OrderBy(t => t.SortCode).MapTo<OrganizeOutputDto>();
            list.Add(OrganizeOutputDto);
        }
        return list;
    }

    /// <summary>
    /// 获取根节点组织
    /// </summary>
    /// <param name="id">组织Id</param>
    /// <returns></returns>
    public Organize GetRootOrganize(long? id)
    {
       return _repository.GetRootOrganize(id);
    }
    /// <summary>
    /// 根据当前登录用户获取机构Id集合
    /// </summary>
    /// <returns></returns>
    public async Task<List<long>> GetUserOrgIdList()
    {
        if (Appsettings.User.UserType==UserTypeEnum.SuperAdmin)
            return new List<long>();

        YuebonCacheHelper yuebonCacheHelper=new YuebonCacheHelper();
        var userId = Appsettings.User.UserId;
        var orgIdList = yuebonCacheHelper.Get<List<long>>($"{CacheConst.KeyUserOrg}{userId}"); // 取缓存
        if (orgIdList == null || orgIdList.Count < 1)
        {
            // 扩展机构集合
            //var orgList1 = await _sysUserExtOrgService.GetUserExtOrgList(userId);
            // 角色机构集合
            orgIdList = await GetUserRoleOrgIdList(userId);
            // 机构并集
            //orgIdList = orgList1.Select(u => u.OrgId).Union(orgList2).ToList();
            // 当前所属机构
            if (!orgIdList.Contains(Appsettings.User.CreateOrgId??0))
                orgIdList.Add(Appsettings.User.CreateOrgId??0);
            yuebonCacheHelper.Add($"{CacheConst.KeyUserOrg}{userId}", orgIdList); // 存缓存
        }
        return orgIdList;
    }
    /// <summary>
    /// 根据用户角色获取组织Id集合
    /// </summary>
    /// <param name = "userId" > 用户ID </ param >
    /// < returns ></ returns >
    public async Task<List<long>> GetUserRoleOrgIdList(long userId)
    {
        List<Role> roleList = await _userRoleRepository.GetUserRoleList(userId);
        if (roleList.Count== 0) return new List<long>();// 空机构Id集合

        return await GetUserOrgIdList(roleList);
    }

    /// <summary>
    /// 根据角色Id集合获取机构Id集合
    /// </summary>
    /// <param name="roleList"></param>
    /// <returns></returns>
    private async Task<List<long>> GetUserOrgIdList(List<Role> roleList)
    {
        YuebonCacheHelper yuebonCacheHelper = new YuebonCacheHelper();
        // 按最大范围策略设定(若同时拥有ALL和SELF权限，则结果ALL)
        int strongerDataScopeType = (int)RoleDataScopeEnum.Self;

        // 角色集合拥有的数据范围
        var customDataScopeRoleIdList = new List<long>();
        if (roleList != null && roleList.Count > 0)
        {
            roleList.ForEach(u =>
            {
                if (u.DataScope == RoleDataScopeEnum.Define)
                {
                    customDataScopeRoleIdList.Add(u.Id);
                    strongerDataScopeType = (int)u.DataScope; // 自定义数据权限时也要更新最大范围
                }
                else if ((int)u.DataScope <= strongerDataScopeType)
                    strongerDataScopeType = (int)u.DataScope;
            });
        }

        // 根据角色集合获取机构集合,自定义数据范围
        var orgIdList1 = await _roleDataRepository.GetListDeptByRole(customDataScopeRoleIdList);
        // 根据数据范围获取机构集合
        var orgIdList2 = await GetOrgIdListByDataScope(strongerDataScopeType);

        // 缓存当前用户最大角色数据范围
        yuebonCacheHelper.Add(CacheConst.KeyRoleMaxDataScope + Appsettings.User.UserId, strongerDataScopeType);

        // 并集机构集合
        return orgIdList1.Union(orgIdList2).ToList();
    }
    /// <summary>
    /// 根据数据范围获取机构Id集合
    /// </summary>
    /// <param name="dataScope"></param>
    /// <returns></returns>
    private async Task<List<long>> GetOrgIdListByDataScope(int dataScope)
    {
        var orgId = Appsettings.User.CreateOrgId ?? 0;
        var orgIdList = new List<long>();
        // 若数据范围是全部，则获取所有机构Id集合
        if (dataScope == (int)RoleDataScopeEnum.All)
        {
            orgIdList = await _orgRepos.AsQueryable().Select(u => u.Id).ToListAsync();
        }
        // 若数据范围是本部门及以下，则获取本节点和子节点集合
        else if (dataScope == (int)RoleDataScopeEnum.DeptChild)
        {
            orgIdList = await GetChildIdListWithSelfById(orgId);
        }
        // 若数据范围是本部门不含子节点，则直接返回本部门
        else if (dataScope == (int)RoleDataScopeEnum.Dept)
        {
            orgIdList.Add(orgId);
        }
        return orgIdList;
    }

    /// <summary>
    /// 根据节点Id获取子节点Id集合(包含自己)
    /// </summary>
    /// <param name="pid"></param>
    /// <returns></returns>
    public async Task<List<long>> GetChildIdListWithSelfById(long pid)
    {
        var orgTreeList = await _baseRepository.Db.Queryable<Organize>().ToChildListAsync(u => u.ParentId, pid);
        return orgTreeList.Select(u => u.Id).ToList();
    }

    /// <summary>
    /// 按条件批量删除
    /// </summary>
    /// <param name="idsInfo">主键Id集合</param>
    /// <returns></returns>
    public CommonResult DeleteBatchWhere(DeletesInputDto idsInfo)
    {
        CommonResult result = new CommonResult();
        string where = string.Empty;
        for (int i = 0; i < idsInfo.Ids.Length; i++)
        {
            if (idsInfo.Ids[0] !=0)
            {
                if (_userRepository.GetCountByWhere(string.Format("OrganizeId='{0}' or DepartmentId='{0}'", idsInfo.Ids[0])) > 0)
                {
                    result.ErrMsg = "该机构已有用户数据，不能删除";
                    return result;
                }
                IEnumerable<Organize> list = _repository.GetListWhere(string.Format("ParentId='{0}'", idsInfo.Ids[0]));
                if (list.Count() > 0)
                {
                    result.ErrMsg = "该机构存在子集数据，不能删除";
                    return result;
                }
            }
        }
        where = "id in (" + String.Join(",", idsInfo.Ids) + ")";
        bool bl = repository.DeleteBatchWhere(where);
        if (bl)
        {
            result.ErrCode = "0";
        }
        return result;
    }

    /// <summary>
    /// 按条件批量删除
    /// </summary>
    /// <param name="idsInfo">主键Id集合</param>
    /// <returns></returns>
    public async Task<CommonResult> DeleteBatchWhereAsync(DeletesInputDto idsInfo)
    {
        CommonResult result = new CommonResult();
        string where = string.Empty;
        for (int i = 0; i < idsInfo.Ids.Length; i++)
        {
            if (idsInfo.Ids[0].ToString().Length > 0)
            {
                if(_userRepository.GetCountByWhere(string.Format("OrganizeId='{0}' or DepartmentId='{0}'", idsInfo.Ids[0])) > 0)
                {
                    result.ErrMsg = "该机构已有用户数据，不能删除";
                    return result;
                }
                where = string.Format("ParentId='{0}'", idsInfo.Ids[0]);
                IEnumerable<Organize> list = _repository.GetListWhere(where);
                if (list.Count()>0)
                {
                    result.ErrMsg = "该机构存在子集数据，不能删除";
                    return result;
                }
            }
        }
        where = "id in (" + String.Join(",", idsInfo.Ids) + ")";
        bool bl = await repository.DeleteBatchWhereAsync(where);
        if (bl)
        {
            result.ErrCode = "0";
        }
        return result;
    }

    /// <summary>
    /// 根据组织类型获取公司级组织
    /// </summary>
    /// <param name="orgType">组织类型</param>
    /// <returns></returns>
    public async Task<List<Organize>> GetOrganizesByOrgTypeAsync(string orgType)
    {
        return await _baseRepository.Db.Queryable<Organize>().Where(o=>o.OrgType==orgType &&o.CategoryId== "Company").ToListAsync();
    }
}