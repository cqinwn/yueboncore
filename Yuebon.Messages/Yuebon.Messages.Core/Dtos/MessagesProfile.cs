using AutoMapper;
using Yuebon.Messages.Models;

namespace Yuebon.Messages.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    public class MessagesProfile : Profile
    {
        /// <summary>
        /// 
        /// </summary>
        public MessagesProfile()
        {
            CreateMap<MessageTemplates, MessageTemplatesOuputDto>();
            CreateMap<MemberMessageBox, MemberMessageBoxOutPutDto>();

            CreateMap<MemberSubscribeMsgInputDto,MemberSubscribeMsg>();
        }
    }
}
