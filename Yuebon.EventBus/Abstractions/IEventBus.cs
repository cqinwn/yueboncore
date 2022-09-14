using Yuebon.EventBus.Events;

namespace Yuebon.EventBus.Abstractions;

/// <summary>
/// 事件总线接口
/// </summary>
public interface IEventBus
{
    /// <summary>
    /// 发布事件
    /// </summary>
    /// <param name="event"></param>
    void Publish(IntegrationEvent @event);

    /// <summary>
    /// 订阅事件
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TH"></typeparam>
    void Subscribe<T, TH>()
        where T : IntegrationEvent
        where TH : IIntegrationEventHandler<T>;

    /// <summary>
    /// 订阅动态事件
    /// </summary>
    /// <typeparam name="TH"></typeparam>
    /// <param name="eventName"></param>
    void SubscribeDynamic<TH>(string eventName)
        where TH : IDynamicIntegrationEventHandler;

    /// <summary>
    /// 取消订阅动态事件
    /// </summary>
    /// <typeparam name="TH"></typeparam>
    /// <param name="eventName"></param>
    void UnsubscribeDynamic<TH>(string eventName)
        where TH : IDynamicIntegrationEventHandler;
    /// <summary>
    /// 取消订阅事件
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TH"></typeparam>
    void Unsubscribe<T, TH>()
        where TH : IIntegrationEventHandler<T>
        where T : IntegrationEvent;
}
