using System;
using System.Collections.Generic;
using System.Text;
using Yuebon.Commons.IServices;
using Yuebon.Messages.Dtos;
using Yuebon.Messages.Models;

namespace Yuebon.Messages.IServices
{
   public interface IMemberSubscribeMsgService : IService<MemberSubscribeMsg, string>
    {

        /// <summary>
        /// 根据消息类型查询消息模板
        /// </summary>
        /// <param name="messageType">消息类型</param>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        MemberMessageTemplatesOuputDto GetByMessageTypeWithUser(string messageType,string userId);
        /// <summary>
        /// 按用户、订阅类型和消息模板主键查询
        /// </summary>
        /// <param name="subscribeType">消息类型</param>
        /// <param name="userId">用户</param>
        /// <param name="messageTemplateId">模板Id主键</param>
        /// <returns></returns>
        MemberMessageTemplatesOuputDto GetByWithUser(string subscribeType, string userId, string messageTemplateId);
    }
}
