namespace Yuebon.Core.Models;

/// <summary>
///  定义逻辑删除功能审计信息
/// </summary>
public interface IDeleteAudited 
{
    /// <summary>
    /// 获取或设置 逻辑删除标记
    /// </summary>
    bool? DeleteMark { get; set; }

    /// <summary>
    /// 获取或设置 删除实体的用户
    /// </summary>
    long? DeleteUserId { get; set; }

    /// <summary>
    /// 获取或设置 删除实体时间
    /// </summary>
    DateTime? DeleteTime { get; set; } 
}