namespace Yuebon.Security.Dtos;

/// <summary>
/// 模块功能
/// </summary>
[Serializable]
public class ModuleFunctionOutputDto
{
    /// <summary>
    /// 功能Id
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// 设置或获取  功能名称
    /// </summary>
    public string FullName { get; set; }

    /// <summary>
    /// 设置或获取  功能标识 0-子系统 1-标识菜单/模块，2标识按钮功能
    /// </summary>
    public int FunctionTag { get; set; }
    /// <summary>
    /// 设置或获取 是否禁止选择
    /// </summary>
    public bool IsShow { get; set; }

    /// <summary>
    /// 设置或获取  功能标识 M-标识菜单，F标识功能
    /// </summary>
    public  List<MenuOutputDto> listFunction{ get; set; }
    /// <summary>
    /// 子菜单
    /// </summary>
    public List<ModuleFunctionOutputDto> Children { get; set; }
}
