using RabbitMQ.Client;

namespace Yuebon.Extensions.ServiceExtensions;

/// <summary>
/// RabbitMQ启动服务
/// </summary>
public static class RabbitMQSetup
{
    /// <summary>
    /// RabbitMQ启动服务
    /// </summary>
    /// <param name="services"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public static void AddRabbitMQSetup(this IServiceCollection services)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));

        if (Appsettings.app(new string[] { "RabbitMQ", "Enabled" }).ObjToBool())
        {
            services.AddSingleton<IRabbitMQPersistentConnection>(sp =>
            {
                var logger = sp.GetRequiredService<ILogger<DefaultRabbitMQPersistentConnection>>();

                var factory = new ConnectionFactory()
                {
                    HostName = Appsettings.app(new string[] { "RabbitMQ", "Connection" }),
                    DispatchConsumersAsync = true
                };

                if (!string.IsNullOrEmpty(Appsettings.app(new string[] { "RabbitMQ", "UserName" })))
                {
                    factory.UserName = Appsettings.app(new string[] { "RabbitMQ", "UserName" });
                }

                if (!string.IsNullOrEmpty(Appsettings.app(new string[] { "RabbitMQ", "Password" })))
                {
                    factory.Password = Appsettings.app(new string[] { "RabbitMQ", "Password" });
                }

                if (!string.IsNullOrEmpty(Appsettings.app(new string[] { "RabbitMQ", "Port" })))
                {
                    factory.Port = Appsettings.app(new string[] { "RabbitMQ", "Port" }).ObjToInt();
                }

                var retryCount = 5;
                if (!string.IsNullOrEmpty(Appsettings.app(new string[] { "RabbitMQ", "RetryCount" })))
                {
                    retryCount = Appsettings.app(new string[] { "RabbitMQ", "RetryCount" }).ObjToInt();
                }

                return new DefaultRabbitMQPersistentConnection(factory, logger, retryCount);
            });
        }
    }
}
