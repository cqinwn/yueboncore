using System;
using System.Collections.Generic;
using System.Text;
using Yuebon.Commons.IoC;
using Yuebon.Commons.Linq;
using Yuebon.Commons.Mapping;
using Yuebon.Messages.Dtos;
using Yuebon.Messages.IServices;
using Yuebon.Messages.Services;

namespace Yuebon.Messages.Application
{
   public class MessageTemplatesApp
    {
        IMessageTemplatesService messageTemplatesService = IoCContainer.Resolve<IMessageTemplatesService>();

        /// <summary>
        /// 查询微信小程序订阅消息模板列表
        /// </summary>
        /// <returns></returns>
        public List<MemberMessageTemplatesOuputDto> ListByUseInWxApplet(string userId)
        {
            return messageTemplatesService.ListByUseInWxApplet(userId);
        }


    }
}
