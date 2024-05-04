using Newtonsoft.Json;
using SqlSugar;
using Yuebon.Security.Repositories;

namespace Yuebon.Security.Services;

/// <summary>
/// ������Ϣ
/// </summary>
public class AreaService: BaseService<Area, AreaOutputDto>, IAreaService
{
    private readonly IAreaRepository _repository;
    public AreaService(IRepository<Area> areaRepository, IAreaRepository areaRepository1)
    {
        repository=areaRepository;
        _repository = areaRepository1;
    }

    /// <summary>
    /// ��ȡ��������������Vue �����б�
    /// </summary>
    /// <returns></returns>
    public async Task<List<Area>> GetAllAreaTreeTable()
    {
        return await _repository.GetAllAreaTreeTable();
    }

    #region ����uniapp����ѡ��
    /// <summary>
    /// ��ȡ���п��õĵ���������uniapp����ѡ��
    /// </summary>
    /// <returns></returns>
    public List<AreaPickerOutputDto> GetAllByEnable()
    {
        List<AreaPickerOutputDto> list = new List<AreaPickerOutputDto>();
        YuebonCacheHelper yuebonCacheHelper = new YuebonCacheHelper();
        list = JsonConvert.DeserializeObject<List<AreaPickerOutputDto>>(yuebonCacheHelper.Get("Area_Enable_Uniapp").ToJson());
        if (list == null || list.Count <= 0)
        {
            List<Area> listFunction = _repository.GetAllByIsNotDeleteAndEnabledMark("Layers in (0,1,2)").OrderBy(t => t.SortCode).ToList();
            list = UniappViewJson(listFunction, 0);
            yuebonCacheHelper.Add("Area_Enable_Uniapp", list);
        }
        return list;
    }
    /// <summary>
    /// ��ȡʡ���С���/���������õĵ���������uniapp����ѡ��
    /// </summary>
    /// <returns></returns>
    public List<AreaPickerOutputDto> GetProvinceToAreaByEnable()
    {
        List<AreaPickerOutputDto> list = new List<AreaPickerOutputDto>();
        YuebonCacheHelper yuebonCacheHelper = new YuebonCacheHelper();
        list = JsonConvert.DeserializeObject<List<AreaPickerOutputDto>>(yuebonCacheHelper.Get("Area_ProvinceToArea_Enable_Uniapp").ToJson());
        if (list == null || list.Count <= 0)
        {
            List<Area> listFunctionTemp = _repository.GetAllByIsNotDeleteAndEnabledMark("Layers in (1,2,3)").OrderBy(t => t.Id).ToList();
            List<Area> listFunction = new List<Area>();
            foreach (Area item in listFunctionTemp)
            {
                if (item.Layers == 1) { item.ParentId = 0; }
                listFunction.Add(item);
            }

            list = UniappViewJson(listFunction, 0);
            yuebonCacheHelper.Add("Area_ProvinceToArea_Enable_Uniapp", list);
        }
        return list;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="data"></param>
    /// <param name="parentId"></param>
    /// <returns></returns>
    public List<AreaPickerOutputDto> UniappViewJson(List<Area> data, long parentId)
    {
        List<AreaPickerOutputDto> list = new List<AreaPickerOutputDto>();
        var ChildNodeList = data.FindAll(t => t.ParentId == parentId).ToList();
        foreach (Area entity in ChildNodeList)
        {
            AreaPickerOutputDto treeViewModel = new AreaPickerOutputDto();
            treeViewModel.value = entity.Id;
            treeViewModel.label = entity.FullName;
            treeViewModel.children = ChildrenUniappViewList(data, entity.Id);
            list.Add(treeViewModel);
        }
        return list;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="data"></param>
    /// <param name="parentId"></param>
    /// <returns></returns>
    public List<AreaPickerOutputDto> ChildrenUniappViewList(List<Area> data, long parentId)
    {
        List<AreaPickerOutputDto> listChildren = new List<AreaPickerOutputDto>();
        var ChildNodeList = data.FindAll(t => t.ParentId == parentId).ToList();
        foreach (Area entity in ChildNodeList)
        {
            AreaPickerOutputDto treeViewModel = new AreaPickerOutputDto();
            treeViewModel.value = entity.Id;
            treeViewModel.label = entity.FullName;
            treeViewModel.children = ChildrenUniappViewList(data, entity.Id);
            listChildren.Add(treeViewModel);
        }
        return listChildren;
    }
    #endregion


    /// <summary>
    /// ����������ѯ���ݿ�,�����ض��󼯺�(���ڷ�ҳ������ʾ)
    /// ��ѯ�����任ʱ����д�÷�����
    /// </summary>
    /// <param name="search">��ѯ������</param>
    /// <returns>ָ������ļ���</returns>
    public virtual async Task<PageResult<AreaOutputDto>> FindWithPagerAsync(SearchInputDto<Area> search)
    {
        bool order = search.Order == "asc" ? false : true;
        var expressionWhere = Expressionable.Create<Area>()
           .AndIF(!string.IsNullOrEmpty(search.Keywords), it => it.FullName.Contains(search.Keywords) || it.EnCode.Contains(search.Keywords) || it.AreaCode.Contains(search.Keywords))
           .ToExpression();
        PagerInfo pagerInfo = new PagerInfo
        {
            CurrenetPageIndex = search.CurrenetPageIndex,
            PageSize = search.PageSize
        };
        List<Area> list = await repository.FindWithPagerAsync(expressionWhere, pagerInfo, search.Sort, order);
        PageResult<AreaOutputDto> pageResult = new PageResult<AreaOutputDto>
        {
            CurrentPage = pagerInfo.CurrenetPageIndex,
            Items = list.MapTo<AreaOutputDto>(),
            ItemsPerPage = pagerInfo.PageSize,
            TotalItems = pagerInfo.RecordCount
        };
        return pageResult;
    }
}