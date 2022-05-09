using System;
using Yuebon.Commons.IServices;
using Yuebon.Messages.Dtos;
using Yuebon.Messages.Models;

namespace Yuebon.Messages.IServices
{
    /// <summary>
    /// 定义服务接口
    /// </summary>
    public interface IMemberSubscribeMsgService:IService<MemberSubscribeMsg,MemberSubscribeMsgOutputDto>
    {

        /// <summary>
        /// 根据消息类型查询消息模板
        /// </summary>
        /// <param name="messageType">消息类型</param>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        MemberMessageTemplatesOuputDto GetByMessageTypeWithUser(string messageType, long userId);

        /// <summary>
        /// 按用户、订阅类型和消息模板主键查询
        /// </summary>
        /// <param name="subscribeType">消息类型</param>
        /// <param name="userId">用户</param>
        /// <param name="messageTemplateId">模板Id主键</param>
        /// <returns></returns>
        MemberMessageTemplatesOuputDto GetByWithUser(string subscribeType, long userId, long messageTemplateId);


        /// <summary>
        /// 根据消息模板Id（主键）查询用户订阅消息
        /// </summary>
        /// <param name="messageTemplateId">消息模板主键</param>
        /// <param name="userId">用户</param>
        /// <param name="subscribeType">消息类型</param>
        /// <returns></returns>
        MemberSubscribeMsg GetByMessageTemplateIdAndUser(long messageTemplateId, long userId, string subscribeType);
        /// <summary>
        /// 更新用户订阅消息
        /// </summary>
        /// <param name="messageTemplateId">消息模板主键</param>
        /// <param name="userId">用户</param>
        /// <param name="subscribeType">消息类型</param>
        /// <param name="subscribeStatus">订阅状态</param>
        /// <returns></returns>
        bool UpdateByMessageTemplateIdAndUser(long messageTemplateId, long userId, string subscribeType, string subscribeStatus);

        long Insert(MemberSubscribeMsg info);
        /// <summary>
        /// 更新订阅状态
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        bool UpdateSubscribeStatus(MemberSubscribeMsg info);
    }
}
