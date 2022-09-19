using Microsoft.AspNetCore.Builder;
using Yuebon.Commons.Log;
using Yuebon.Security.Services.IntegrationEvents.Events;

namespace Yuebon.Extensions.ServiceExtensions;

public static class EventBusSetup
{
    public static void AddEventBusSetup(this IServiceCollection services)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));
        if (Appsettings.app(new string[] { "EventBus", "Enabled" }).ObjToBool())
        {
            var subscriptionClientName = Appsettings.app(new string[] { "EventBus", "SubscriptionClientName" });

            services.AddSingleton<IEventBusSubscriptionsManager, InMemoryEventBusSubscriptionsManager>();
            services.AddTransient<VisitLogIntegrationEventHandler>();
            if (Appsettings.app(new string[] { "RabbitMQ", "Enabled" }).ObjToBool())
            {
                services.AddSingleton<IEventBus, EventBusRabbitMQ>(sp =>
                {
                    var rabbitMQPersistentConnection = sp.GetRequiredService<IRabbitMQPersistentConnection>();
                    var iLifetimeScope = sp.GetRequiredService<ILifetimeScope>();
                    var logger = sp.GetRequiredService<ILogger<EventBusRabbitMQ>>();
                    var eventBusSubcriptionsManager = sp.GetRequiredService<IEventBusSubscriptionsManager>();

                    var retryCount = 5;
                    if (!string.IsNullOrEmpty(Appsettings.app(new string[] { "RabbitMQ", "RetryCount" })))
                    {
                        retryCount = int.Parse(Appsettings.app(new string[] { "RabbitMQ", "RetryCount" }));
                    }
                    return new EventBusRabbitMQ(rabbitMQPersistentConnection, logger, iLifetimeScope, eventBusSubcriptionsManager, subscriptionClientName, retryCount);
                });
            }
        }
    }

    public static void ConfigureEventBus(this IApplicationBuilder app)
    {
        if (Appsettings.app(new string[] { "EventBus", "Enabled" }).ObjToBool())
        {
            var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();
            //eventBus.Subscribe<VisitLogIntegrationEvent, VisitLogIntegrationEventHandler>();
        }
    }
}
