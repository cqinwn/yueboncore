using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Yuebon.Commons.Core.App;
using Yuebon.Core.Repositories;

namespace Yuebon.Security.Services;

/// <summary>
/// ��֯����
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
    /// ��ȡ��֯����������Vue �����б�
    /// </summary>
    /// <returns></returns>
    public async Task<List<Organize>> GetAllOrganizeTreeTable()
    {
        return await _repository.GetAllOrganizeTreeTable();
    }


    /// <summary>
    /// ��ȡ�Ӽ����ݹ����
    /// </summary>
    /// <param name="data"></param>
    /// <param name="parentId">����Id</param>
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
    /// ��ȡ���ڵ���֯
    /// </summary>
    /// <param name="id">��֯Id</param>
    /// <returns></returns>
    public Organize GetRootOrganize(long? id)
    {
       return _repository.GetRootOrganize(id);
    }
    /// <summary>
    /// ���ݵ�ǰ��¼�û���ȡ����Id����
    /// </summary>
    /// <returns></returns>
    public async Task<List<long>> GetUserOrgIdList()
    {
        if (Appsettings.User.UserType==UserTypeEnum.SuperAdmin)
            return new List<long>();

        YuebonCacheHelper yuebonCacheHelper=new YuebonCacheHelper();
        var userId = Appsettings.User.UserId;
        var orgIdList = yuebonCacheHelper.Get<List<long>>($"{CacheConst.KeyUserOrg}{userId}"); // ȡ����
        if (orgIdList == null || orgIdList.Count < 1)
        {
            // ��չ��������
            //var orgList1 = await _sysUserExtOrgService.GetUserExtOrgList(userId);
            // ��ɫ��������
            orgIdList = await GetUserRoleOrgIdList(userId);
            // ��������
            //orgIdList = orgList1.Select(u => u.OrgId).Union(orgList2).ToList();
            // ��ǰ��������
            if (!orgIdList.Contains(Appsettings.User.CreateOrgId??0))
                orgIdList.Add(Appsettings.User.CreateOrgId??0);
            yuebonCacheHelper.Add($"{CacheConst.KeyUserOrg}{userId}", orgIdList); // �滺��
        }
        return orgIdList;
    }
    /// <summary>
    /// �����û���ɫ��ȡ��֯Id����
    /// </summary>
    /// <param name = "userId" > �û�ID </ param >
    /// < returns ></ returns >
    public async Task<List<long>> GetUserRoleOrgIdList(long userId)
    {
        List<Role> roleList = await _userRoleRepository.GetUserRoleList(userId);
        if (roleList.Count== 0) return new List<long>();// �ջ���Id����

        return await GetUserOrgIdList(roleList);
    }

    /// <summary>
    /// ���ݽ�ɫId���ϻ�ȡ����Id����
    /// </summary>
    /// <param name="roleList"></param>
    /// <returns></returns>
    private async Task<List<long>> GetUserOrgIdList(List<Role> roleList)
    {
        YuebonCacheHelper yuebonCacheHelper = new YuebonCacheHelper();
        // �����Χ�����趨(��ͬʱӵ��ALL��SELFȨ�ޣ�����ALL)
        int strongerDataScopeType = (int)RoleDataScopeEnum.Self;

        // ��ɫ����ӵ�е����ݷ�Χ
        var customDataScopeRoleIdList = new List<long>();
        if (roleList != null && roleList.Count > 0)
        {
            roleList.ForEach(u =>
            {
                if (u.DataScope == RoleDataScopeEnum.Define)
                {
                    customDataScopeRoleIdList.Add(u.Id);
                    strongerDataScopeType = (int)u.DataScope; // �Զ�������Ȩ��ʱҲҪ�������Χ
                }
                else if ((int)u.DataScope <= strongerDataScopeType)
                    strongerDataScopeType = (int)u.DataScope;
            });
        }

        // ���ݽ�ɫ���ϻ�ȡ��������,�Զ������ݷ�Χ
        var orgIdList1 = await _roleDataRepository.GetListDeptByRole(customDataScopeRoleIdList);
        // �������ݷ�Χ��ȡ��������
        var orgIdList2 = await GetOrgIdListByDataScope(strongerDataScopeType);

        // ���浱ǰ�û�����ɫ���ݷ�Χ
        yuebonCacheHelper.Add(CacheConst.KeyRoleMaxDataScope + Appsettings.User.UserId, strongerDataScopeType);

        // ������������
        return orgIdList1.Union(orgIdList2).ToList();
    }
    /// <summary>
    /// �������ݷ�Χ��ȡ����Id����
    /// </summary>
    /// <param name="dataScope"></param>
    /// <returns></returns>
    private async Task<List<long>> GetOrgIdListByDataScope(int dataScope)
    {
        var orgId = Appsettings.User.CreateOrgId ?? 0;
        var orgIdList = new List<long>();
        // �����ݷ�Χ��ȫ�������ȡ���л���Id����
        if (dataScope == (int)RoleDataScopeEnum.All)
        {
            orgIdList = await _orgRepos.AsQueryable().Select(u => u.Id).ToListAsync();
        }
        // �����ݷ�Χ�Ǳ����ż����£����ȡ���ڵ���ӽڵ㼯��
        else if (dataScope == (int)RoleDataScopeEnum.DeptChild)
        {
            orgIdList = await GetChildIdListWithSelfById(orgId);
        }
        // �����ݷ�Χ�Ǳ����Ų����ӽڵ㣬��ֱ�ӷ��ر�����
        else if (dataScope == (int)RoleDataScopeEnum.Dept)
        {
            orgIdList.Add(orgId);
        }
        return orgIdList;
    }

    /// <summary>
    /// ���ݽڵ�Id��ȡ�ӽڵ�Id����(�����Լ�)
    /// </summary>
    /// <param name="pid"></param>
    /// <returns></returns>
    public async Task<List<long>> GetChildIdListWithSelfById(long pid)
    {
        var orgTreeList = await _baseRepository.Db.Queryable<Organize>().ToChildListAsync(u => u.ParentId, pid);
        return orgTreeList.Select(u => u.Id).ToList();
    }

    /// <summary>
    /// ����������ɾ��
    /// </summary>
    /// <param name="idsInfo">����Id����</param>
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
                    result.ErrMsg = "�û��������û����ݣ�����ɾ��";
                    return result;
                }
                IEnumerable<Organize> list = _repository.GetListWhere(string.Format("ParentId='{0}'", idsInfo.Ids[0]));
                if (list.Count() > 0)
                {
                    result.ErrMsg = "�û��������Ӽ����ݣ�����ɾ��";
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
    /// ����������ɾ��
    /// </summary>
    /// <param name="idsInfo">����Id����</param>
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
                    result.ErrMsg = "�û��������û����ݣ�����ɾ��";
                    return result;
                }
                where = string.Format("ParentId='{0}'", idsInfo.Ids[0]);
                IEnumerable<Organize> list = _repository.GetListWhere(where);
                if (list.Count()>0)
                {
                    result.ErrMsg = "�û��������Ӽ����ݣ�����ɾ��";
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
    /// ������֯���ͻ�ȡ��˾����֯
    /// </summary>
    /// <param name="orgType">��֯����</param>
    /// <returns></returns>
    public async Task<List<Organize>> GetOrganizesByOrgTypeAsync(string orgType)
    {
        return await _baseRepository.Db.Queryable<Organize>().Where(o=>o.OrgType==orgType &&o.CategoryId== "Company").ToListAsync();
    }
}