using Newtonsoft.Json;

namespace Yuebon.Security.Services;

/// <summary>
/// ������Ϣ
/// </summary>
public class AreaService: BaseService<Area, AreaOutputDto>, IAreaService
{
    private readonly IRepository<Area> _repository;
    public AreaService(IRepository<Area> areaRepository)
    {
        repository=areaRepository;
        _repository = areaRepository;
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
}