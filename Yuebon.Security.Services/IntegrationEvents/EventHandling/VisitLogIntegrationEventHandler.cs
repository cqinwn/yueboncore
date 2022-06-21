using Yuebon.Commons.EventBus.Abstractions;
using Yuebon.Security.Services.IntegrationEvents.Events;

namespace Yuebon.Security.Services.EventHandling
{
    /// <summary>
    /// 访问日志事件
    /// </summary>
    public class VisitLogIntegrationEventHandler : IIntegrationEventHandler<VisitLogIntegrationEvent>
    {
        private readonly IVisitlogService _visitLogService;
        public VisitLogIntegrationEventHandler(IVisitlogService visitLogService)
        {
            _visitLogService = visitLogService;
        }

        public async Task Handle(VisitLogIntegrationEvent @event)
        {
            VisitLog visitLog = new VisitLog();
            visitLog = @event.MapTo<VisitLog>();
           await _visitLogService.InsertAsync(visitLog);
        }
    }
}
