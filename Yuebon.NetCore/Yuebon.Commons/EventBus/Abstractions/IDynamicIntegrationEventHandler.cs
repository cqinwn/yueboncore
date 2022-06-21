namespace Yuebon.Commons.EventBus.Abstractions;

/// <summary>
/// 集成动态事件处理程序
/// </summary>
public interface IDynamicIntegrationEventHandler
{
    /// <summary>
    /// 处理器
    /// </summary>
    /// <param name="eventData">集成事件</param>
    /// <returns></returns>
    Task Handle(dynamic eventData);
}
