using Yuebon.Commons.EventBus.Events;

namespace Yuebon.Commons.EventBus.Abstractions;
/// <summary>
/// 泛型事件处理器接口
/// </summary>
/// <typeparam name="TIntegrationEvent"></typeparam>
public interface IIntegrationEventHandler<in TIntegrationEvent> : IIntegrationEventHandler
    where TIntegrationEvent : IntegrationEvent
{
    /// <summary>
    ///  事件处理器实现该方法来处理事件
    /// </summary>
    /// <param name="event">集成事件</param>
    /// <returns></returns>
    Task Handle(TIntegrationEvent @event);
}
/// <summary>
/// 定义事件处理器公共接口，所有的事件处理都要实现该接口
/// </summary>
public interface IIntegrationEventHandler
{
}
