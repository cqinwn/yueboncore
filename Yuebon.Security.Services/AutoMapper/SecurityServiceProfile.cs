using AutoMapper;
using Yuebon.Security.Services.IntegrationEvents.Events;

namespace Yuebon.Security.Services.AutoMapper;

public class SecurityServiceProfile : Profile
{
    public SecurityServiceProfile()
    {
        CreateMap<VisitLogIntegrationEvent, VisitLog>()
     .ForMember(e => e.Id, s => s.MapFrom(o => o.PreId));
    }
}
