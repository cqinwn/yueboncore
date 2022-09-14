using MediatR;
using System.ComponentModel;

namespace Yuebon.Core.Domain;

/// <summary>
/// 领域实体
/// </summary>
public abstract class Entity
{

    /// <summary>
    /// 获取或设置 编号
    /// </summary>
    [DisplayName("编号")]
    public virtual long Id { get; set; }

    /// <summary>
    /// 领域事件
    /// </summary>
    private List<INotification> _domainEvents;
    /// <summary>
    /// 
    /// </summary>
    public IReadOnlyCollection<INotification> DomainEvents => _domainEvents?.AsReadOnly();
    /// <summary>
    /// 新增领域事件
    /// </summary>
    /// <param name="eventItem"></param>
    public void AddDomainEvent(INotification eventItem)
    {
        _domainEvents = _domainEvents ?? new List<INotification>();
        _domainEvents.Add(eventItem);
    }
    /// <summary>
    /// 删除领域事件
    /// </summary>
    /// <param name="eventItem"></param>
    public void RemoveDomainEvent(INotification eventItem)
    {
        _domainEvents?.Remove(eventItem);
    }
    /// <summary>
    /// 清空领域事件
    /// </summary>
    public void ClearDomainEvents()
    {
        _domainEvents?.Clear();
    }

}
