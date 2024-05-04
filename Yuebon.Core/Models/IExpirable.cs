namespace Yuebon.Core.Models;

/// <summary>
/// 定义可过期性，包含生效时间和过期时间：给实体添加 生效时间BeginTime，过期时间EndTime 的属性
/// </summary>
public interface IExpirable
{
    /// <summary>
    /// 获取或设置 生效时间
    /// </summary>
    DateTime? BeginTime { get; set; }

    /// <summary>
    /// 获取或设置 过期时间
    /// </summary>
    DateTime? EndTime { get; set; }
}
