namespace Yuebon.Security.Services;

/// <summary>
/// ��֯����
/// </summary>
public class OrganizeService: BaseService<Organize, OrganizeOutputDto>, IOrganizeService
{
    private readonly IOrganizeRepository _repository;
    private readonly ILogService _logService;
    private readonly IUserRepository _userRepository;
    /// <summary>
    /// 
    /// </summary>
    /// <param name="repository"></param>
    /// <param name="logService"></param>
    public OrganizeService(IOrganizeRepository organizeRepository, ILogService logService, IUserRepository userRepository)
    {
        repository = organizeRepository;
        _repository = organizeRepository;
        _logService = logService;
        _userRepository = userRepository;
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
}