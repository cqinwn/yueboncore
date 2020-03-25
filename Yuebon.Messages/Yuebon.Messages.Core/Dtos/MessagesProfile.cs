using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Yuebon.Messages.Models;

namespace Yuebon.Messages.Dtos
{
    public class MessagesProfile : Profile
    {
        public MessagesProfile()
        {
           CreateMap<MemberMessageBox, MemberMessageBoxOutputDto>();
           CreateMap<MemberMessageBoxInputDto, MemberMessageBox>();
           CreateMap<MemberSubscribeMsg, MemberSubscribeMsgOutputDto>();
           CreateMap<MemberSubscribeMsgInputDto, MemberSubscribeMsg>();
           CreateMap<MessageMailBox, MessageMailBoxOutputDto>();
           CreateMap<MessageMailBoxInputDto, MessageMailBox>();
           CreateMap<MessageTemplates, MessageTemplatesOutputDto>();
           CreateMap<MessageTemplatesInputDto, MessageTemplates>();

        }
    }
}
