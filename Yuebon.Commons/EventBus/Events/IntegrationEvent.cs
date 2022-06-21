using Yuebon.Commons.Helpers;

namespace Yuebon.Commons.EventBus.Events;

/// <summary>
/// 定义集成事件源接口，所有的事件源都要实现该接口
/// </summary>
public class IntegrationEvent
{
    /// <summary>
    /// 集成事件 构造函数
    /// </summary>
    public IntegrationEvent()
    {
        Id = IdGeneratorHelper.IdSnowflake();
        CreationDate = DateTime.UtcNow;
    }
    /// <summary>
    /// 集成事件 构造函数
    /// </summary>
    /// <param name="id">Id</param>
    /// <param name="createDate">创建事件</param>
    [JsonConstructor]
    public IntegrationEvent(long id, DateTime createDate)
    {
        Id = id;
        CreationDate = createDate;
    }
    /// <summary>
    /// 事件Id
    /// </summary>
    [JsonInclude]
    public long Id { get; private init; }
    /// <summary>
    /// 事件创建时间
    /// </summary>
    [JsonInclude]
    public DateTime CreationDate { get; private init; }
}
