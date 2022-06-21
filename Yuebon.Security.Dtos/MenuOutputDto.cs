namespace Yuebon.Security.Dtos;

/// <summary>
/// 输出对象模型
/// </summary>
[Serializable]
public class MenuOutputDto
{
    /// <summary>
    /// 设置或获取 
    /// </summary>
    [MaxLength(50)]
    public long Id { get; set; }

    /// <summary>
    /// 设置或获取 
    /// </summary>
    [MaxLength(50)]
    public string SystemTypeId { get; set; }
    public string SystemTypeName { get; set; }

    /// <summary>
    /// 设置或获取 
    /// </summary>
    [MaxLength(50)]
    public long? ParentId { get; set; }

    /// <summary>
    /// 设置或获取 
    /// </summary>
    public int? Layers { get; set; }

    /// <summary>
    /// 设置或获取 
    /// </summary>
    [MaxLength(50)]
    public string EnCode { get; set; }

    /// <summary>
    /// 设置或获取 
    /// </summary>
    [MaxLength(50)]
    public string FullName { get; set; }

    /// <summary>
    /// 设置或获取 
    /// </summary>
    [MaxLength(50)]
    public string Icon { get; set; }

    /// <summary>
    /// 设置或获取路由
    /// </summary>
    public virtual string UrlAddress { get; set; }

    /// <summary>
    /// 设置或获取目标打开方式
    /// </summary>
    public virtual string Target { get; set; }

    /// <summary>
    /// 设置或获取菜单类型（C目录 M菜单 F按钮）
    /// </summary>
    public virtual string MenuType { get; set; }
    /// <summary>
    /// 设置或获取组件路径
    /// </summary>
    public virtual string Component { get; set; }
    /// <summary>
    /// 设置当前选中菜单，用于新增、编辑、查看操作为单独的路由时指定选中菜单路由
    /// 同时设置为隐藏时才有效
    /// </summary>
    public virtual string ActiveMenu { get; set; }

    /// <summary>
    /// 设置或获取 
    /// </summary>
    public bool? IsExpand { get; set; }

    /// <summary>
    /// 设置或获取 是否显示
    /// </summary>
    public bool IsShow { get; set; }
    /// <summary>
    /// 设置或获取 是否外链
    /// </summary>
    public bool IsFrame { get; set; }
    /// <summary>
    /// 设置或获取是否缓存
    /// </summary>
    public bool IsCache { get; set; }
    /// <summary>
    /// 设置或获取 
    /// </summary>
    public bool? IsPublic { get; set; }

    /// <summary>
    /// 设置或获取 
    /// </summary>
    public bool? AllowEdit { get; set; }

    /// <summary>
    /// 设置或获取 
    /// </summary>
    public bool? AllowDelete { get; set; }

    /// <summary>
    /// 设置或获取 
    /// </summary>
    public int? SortCode { get; set; }

    /// <summary>
    /// 设置或获取 
    /// </summary>
    public bool? DeleteMark { get; set; }

    /// <summary>
    /// 设置或获取 
    /// </summary>
    public bool EnabledMark { get; set; }

    /// <summary>
    /// 设置或获取 
    /// </summary>
    [MaxLength(500)]
    public string Description { get; set; }

    /// <summary>
    /// 设置或获取 
    /// </summary>
    public DateTime? CreatorTime { get; set; }

    /// <summary>
    /// 设置或获取 
    /// </summary>
    [MaxLength(50)]
    public long CreatorUserId { get; set; }

    /// <summary>
    /// 设置或获取 
    /// </summary>
    public DateTime? LastModifyTime { get; set; }

    /// <summary>
    /// 设置或获取 
    /// </summary>
    [MaxLength(50)]
    public long LastModifyUserId { get; set; }

    /// <summary>
    /// 设置或获取 
    /// </summary>
    public DateTime? DeleteTime { get; set; }

    /// <summary>
    /// 设置或获取 
    /// </summary>
    [MaxLength(50)]
    public long DeleteUserId { get; set; }

    /// <summary>
    /// 子菜单集合
    /// </summary>
    public List<MenuOutputDto> SubMenu { get; set; }


}
