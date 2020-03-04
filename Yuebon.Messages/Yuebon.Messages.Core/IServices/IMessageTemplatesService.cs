using System;
using System.Collections.Generic;
using System.Text;
using Yuebon.Commons.IServices;
using Yuebon.Messages.Dtos;
using Yuebon.Messages.Models;

namespace Yuebon.Messages.IServices
{
    public interface IMessageTemplatesService : IService<MessageTemplates, string>
    {
        /// <summary>
        /// 根据消息类型查询消息模板
        /// </summary>
        /// <param name="messageType">消息类型</param>
        /// <returns></returns>
        MessageTemplates GetByMessageType(string messageType);


        /// <summary>
        /// 根据用户查询微信小程序订阅消息模板列表，关联用户订阅表
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <returns></returns>
       List<MemberMessageTemplatesOuputDto> ListByUseInWxApplet(string userId);

    }
}
