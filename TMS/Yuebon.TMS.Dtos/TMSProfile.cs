namespace Yuebon.TMS.Dtos
{
    public class TMSProfile : Profile
    {
        public TMSProfile()
        {
           CreateMap<Transportplan, TransportplanOutputDto>();
           CreateMap<TransportplanInputDto, Transportplan>();
            CreateMap<WmsToTransportplanInputDto, Transportplan>();

        }
    }
}
