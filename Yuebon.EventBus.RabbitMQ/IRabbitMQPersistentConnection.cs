namespace Yuebon.EventBus.RabbitMQ;

/// <summary>
/// RabbitMQ连接
/// </summary>
public interface IRabbitMQPersistentConnection
    : IDisposable
{
    /// <summary>
    /// 是否已连接
    /// </summary>
    bool IsConnected { get; }
    /// <summary>
    /// 连接
    /// </summary>
    /// <returns></returns>
    bool TryConnect();

    IModel CreateModel();
}
