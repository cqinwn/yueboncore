namespace Yuebon.Security.IServices;

/// <summary>
/// 
/// </summary>
public interface IAreaService:IService<Area, AreaOutputDto>
{

    /// <summary>
    /// 树型查询递归查询,获取行政地区适用于Vue 树形列表
    /// </summary>
    /// <returns></returns>
    Task<List<Area>> GetAllAreaTreeTable();

    #region 用于uniapp下拉选项
    /// <summary>
    /// 获取所有可用的地区，用于uniapp下拉选项
    /// </summary>
    /// <returns></returns>
    List<AreaPickerOutputDto> GetAllByEnable();
    /// <summary>
    /// 获取省、市、县/区三级可用的地区，用于uniapp下拉选项
    /// </summary>
    /// <returns></returns>
    List<AreaPickerOutputDto> GetProvinceToAreaByEnable();
    #endregion
}
