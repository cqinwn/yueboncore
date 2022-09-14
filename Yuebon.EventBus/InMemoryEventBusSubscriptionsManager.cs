using Yuebon.EventBus.Abstractions;
using Yuebon.EventBus.Events;

namespace Yuebon.EventBus;

/// <summary>
/// 基于内存
/// 事件总线订阅管理器
/// </summary>
public partial class InMemoryEventBusSubscriptionsManager : IEventBusSubscriptionsManager
{

    /// <summary>
    /// 定义事件的名称和时间订阅的字典映射(1:N)
    /// </summary>
    private readonly Dictionary<string, List<SubscriptionInfo>> _handlers;
    /// <summary>
    /// 保存所有事件的处理类型
    /// </summary>
    private readonly List<Type> _eventTypes;
    /// <summary>
    /// 定义事件移除后的事件
    /// </summary>
    public event EventHandler<string> OnEventRemoved;
    /// <summary>
    /// 
    /// </summary>
    public InMemoryEventBusSubscriptionsManager()
    {
        _handlers = new Dictionary<string, List<SubscriptionInfo>>();
        _eventTypes = new List<Type>();
    }
    /// <summary>
    /// 是否为空
    /// </summary>
    public bool IsEmpty => _handlers is { Count: 0 };
    /// <summary>
    /// 清除
    /// </summary>
    public void Clear() => _handlers.Clear();
    /// <summary>
    /// 添加订阅
    /// </summary>
    /// <typeparam name="TH">约束：动态事件处理器接口</typeparam>
    /// <param name="eventName">事件名称</param>
    public void AddDynamicSubscription<TH>(string eventName)
        where TH : IDynamicIntegrationEventHandler
    {
        DoAddSubscription(typeof(TH), eventName, isDynamic: true);
    }
    /// <summary>
    /// 添加订阅
    /// </summary>
    /// <typeparam name="T">约束：事件</typeparam>
    /// <typeparam name="TH">约束：动态事件处理器接口</typeparam>
    public void AddSubscription<T, TH>()
        where T : IntegrationEvent
        where TH : IIntegrationEventHandler<T>
    {
        var eventName = GetEventKey<T>();

        DoAddSubscription(typeof(TH), eventName, isDynamic: false);

        if (!_eventTypes.Contains(typeof(T)))
        {
            _eventTypes.Add(typeof(T));
        }
    }
    /// <summary>
    /// 添加订阅
    /// </summary>
    /// <param name="handlerType">处理器类型</param>
    /// <param name="eventName">事件名称</param>
    /// <param name="isDynamic">是否为动态</param>
    /// <exception cref="ArgumentException"></exception>
    private void DoAddSubscription(Type handlerType, string eventName, bool isDynamic)
    {
        if (!HasSubscriptionsForEvent(eventName))
        {
            _handlers.Add(eventName, new List<SubscriptionInfo>());
        }

        if (_handlers[eventName].Any(s => s.HandlerType == handlerType))
        {
            throw new ArgumentException(
                $"Handler Type {handlerType.Name} already registered for '{eventName}'", nameof(handlerType));
        }

        if (isDynamic)
        {
            _handlers[eventName].Add(SubscriptionInfo.Dynamic(handlerType));
        }
        else
        {
            _handlers[eventName].Add(SubscriptionInfo.Typed(handlerType));
        }
    }

    /// <summary>
    /// 移除订阅
    /// </summary>
    /// <typeparam name="TH">约束：动态事件处理器接口</typeparam>
    /// <param name="eventName">事件名称</param>
    public void RemoveDynamicSubscription<TH>(string eventName)
        where TH : IDynamicIntegrationEventHandler
    {
        var handlerToRemove = FindDynamicSubscriptionToRemove<TH>(eventName);
        DoRemoveHandler(eventName, handlerToRemove);
    }

    /// <summary>
    /// 移除订阅
    /// </summary>
    /// <typeparam name="T">约束：事件</typeparam>
    /// <typeparam name="TH">约束：动态事件处理器接口</typeparam>
    public void RemoveSubscription<T, TH>()
        where TH : IIntegrationEventHandler<T>
        where T : IntegrationEvent
    {
        var handlerToRemove = FindSubscriptionToRemove<T, TH>();
        var eventName = GetEventKey<T>();
        DoRemoveHandler(eventName, handlerToRemove);
    }

    /// <summary>
    /// 移除处理器
    /// </summary>
    /// <param name="eventName">事件名称</param>
    /// <param name="subsToRemove">订阅消息</param>
    private void DoRemoveHandler(string eventName, SubscriptionInfo subsToRemove)
    {
        if (subsToRemove != null)
        {
            _handlers[eventName].Remove(subsToRemove);
            if (!_handlers[eventName].Any())
            {
                _handlers.Remove(eventName);
                var eventType = _eventTypes.SingleOrDefault(e => e.Name == eventName);
                if (eventType != null)
                {
                    _eventTypes.Remove(eventType);
                }
                RaiseOnEventRemoved(eventName);
            }

        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T">约束：事件</typeparam>
    /// <returns></returns>
    public IEnumerable<SubscriptionInfo> GetHandlersForEvent<T>() where T : IntegrationEvent
    {
        var key = GetEventKey<T>();
        return GetHandlersForEvent(key);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="eventName"></param>
    /// <returns></returns>
    public IEnumerable<SubscriptionInfo> GetHandlersForEvent(string eventName) => _handlers[eventName];

    private void RaiseOnEventRemoved(string eventName)
    {
        var handler = OnEventRemoved;
        handler?.Invoke(this, eventName);
    }

    /// <summary>
    /// 查询订阅并移除
    /// </summary>
    /// <typeparam name="TH">约束：动态事件处理器接口</typeparam>
    /// <param name="eventName">事件名称</param>
    /// <returns></returns>
    private SubscriptionInfo FindDynamicSubscriptionToRemove<TH>(string eventName)
        where TH : IDynamicIntegrationEventHandler
    {
        return DoFindSubscriptionToRemove(eventName, typeof(TH));
    }

    /// <summary>
    /// 查询订阅并移除
    /// </summary>
    /// <typeparam name="T">约束：事件</typeparam>
    /// <typeparam name="TH">约束：动态事件处理器接口</typeparam>
    /// <returns></returns>
    private SubscriptionInfo FindSubscriptionToRemove<T, TH>()
            where T : IntegrationEvent
            where TH : IIntegrationEventHandler<T>
    {
        var eventName = GetEventKey<T>();
        return DoFindSubscriptionToRemove(eventName, typeof(TH));
    }

    private SubscriptionInfo DoFindSubscriptionToRemove(string eventName, Type handlerType)
    {
        if (!HasSubscriptionsForEvent(eventName))
        {
            return null;
        }

        return _handlers[eventName].SingleOrDefault(s => s.HandlerType == handlerType);

    }
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T">约束：事件</typeparam>
    /// <returns></returns>
    public bool HasSubscriptionsForEvent<T>() where T : IntegrationEvent
    {
        var key = GetEventKey<T>();
        return HasSubscriptionsForEvent(key);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="eventName">事件名称</param>
    /// <returns></returns>
    public bool HasSubscriptionsForEvent(string eventName) => _handlers.ContainsKey(eventName);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="eventName">事件名称</param>
    /// <returns></returns>
    public Type GetEventTypeByName(string eventName) => _eventTypes.SingleOrDefault(t => t.Name == eventName);
    /// <summary>
    /// 根据事件获取事件名称
    /// </summary>
    /// <typeparam name="T">约束：事件</typeparam>
    /// <returns></returns>
    public string GetEventKey<T>()
    {
        return typeof(T).Name;
    }
}
