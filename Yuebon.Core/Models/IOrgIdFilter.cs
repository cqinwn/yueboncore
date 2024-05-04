namespace Yuebon.Core.Models;

/// <summary>
/// 机构Id接口过滤器
/// </summary>
public interface IOrgIdFilter
{
    /// <summary>
    /// 创建者部门Id
    /// </summary>
    long? CreateOrgId { get; set; }
}
