namespace Yuebon.EventBus;

/// <summary>
/// 本地内存中事件管理器
/// </summary>
public partial class InMemoryEventBusSubscriptionsManager : IEventBusSubscriptionsManager
{
    /// <summary>
    /// 订阅信息模型
    /// </summary>
    public class SubscriptionInfo
    {
        /// <summary>
        /// 是否是动态
        /// </summary>
        public bool IsDynamic { get; }
        /// <summary>
        /// 集成器类型
        /// </summary>
        public Type HandlerType { get; }
        /// <summary>
        /// 订阅消息
        /// </summary>
        /// <param name="isDynamic">是否为动态</param>
        /// <param name="handlerType">集成器类型</param>

        private SubscriptionInfo(bool isDynamic, Type handlerType)
        {
            IsDynamic = isDynamic;
            HandlerType = handlerType;
        }
        /// <summary>
        /// 订阅消息
        /// </summary>
        /// <param name="handlerType">集成器类型</param>
        /// <returns></returns>
        public static SubscriptionInfo Dynamic(Type handlerType) =>
            new SubscriptionInfo(true, handlerType);
        /// <summary>
        /// 订阅消息
        /// </summary>
        /// <param name="handlerType">集成器类型</param>
        /// <returns></returns>
        public static SubscriptionInfo Typed(Type handlerType) =>
            new SubscriptionInfo(false, handlerType);
    }
}
