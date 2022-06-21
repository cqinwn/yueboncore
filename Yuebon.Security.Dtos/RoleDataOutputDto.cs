namespace Yuebon.Security.Dtos;

/// <summary>
/// 输出对象模型
/// </summary>
[Serializable]
public class RoleDataOutputDto
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
    public string RoleId { get; set; }

    /// <summary>
    /// 类型，company-公司，dept-部门，person-个人
    /// </summary>
    public virtual string DType { get; set; }

    /// <summary>
    /// 数据数据，部门ID或个人ID
    /// </summary>
    public virtual string AuthorizeData { get; set; }

    /// <summary>
    /// 设置或获取 
    /// </summary>
    [MaxLength(1073741823)]
    public string Note { get; set; }


}
