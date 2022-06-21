namespace Yuebon.Commons.Core.Domain.Events;
/// <summary>
/// 领域事件处理器
/// </summary>
/// <typeparam name="TDomainEvent"></typeparam>
public interface IDomainEventHandler<TDomainEvent> : INotificationHandler<TDomainEvent>
    where TDomainEvent : IDomainEvent
{
}
