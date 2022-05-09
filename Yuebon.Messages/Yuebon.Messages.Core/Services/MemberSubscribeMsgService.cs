using System;
using Yuebon.Commons.Services;
using Yuebon.Security.IServices;
using Yuebon.Messages.IRepositories;
using Yuebon.Messages.IServices;
using Yuebon.Messages.Dtos;
using Yuebon.Messages.Models;

namespace Yuebon.Messages.Services
{
    /// <summary>
    /// 服务接口实现
    /// </summary>
    public class MemberSubscribeMsgService: BaseService<MemberSubscribeMsg,MemberSubscribeMsgOutputDto>, IMemberSubscribeMsgService
    {
		private readonly IMemberSubscribeMsgRepository _repository;
        private readonly ILogService _logService;
        public MemberSubscribeMsgService(IMemberSubscribeMsgRepository repository,ILogService logService) { 
			_repository=repository;
			_logService=logService;
        }


        /// <summary>
        /// 根据消息类型查询消息模板
        /// </summary>
        /// <param name="messageType">消息类型</param>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public MemberMessageTemplatesOuputDto GetByMessageTypeWithUser(string messageType, long userId)
        {
            return _repository.GetByMessageTypeWithUser(messageType, userId);
        }


        /// <summary>
        /// 按用户、订阅类型和消息模板主键查询
        /// </summary>
        /// <param name="subscribeType">消息类型</param>
        /// <param name="userId">用户</param>
        /// <param name="messageTemplateId">模板Id主键</param>
        /// <returns></returns>
        public MemberMessageTemplatesOuputDto GetByWithUser(string subscribeType, long userId, long messageTemplateId)
        {

            return _repository.GetByWithUser(subscribeType, userId, messageTemplateId);
        }


        /// <summary>
        /// 根据消息模板Id（主键）查询用户订阅消息
        /// </summary>
        /// <param name="messageTemplateId">消息模板主键</param>
        /// <param name="userId">用户</param>
        /// <param name="subscribeType">消息类型</param>
        /// <returns></returns>
        public MemberSubscribeMsg GetByMessageTemplateIdAndUser(long messageTemplateId, long userId, string subscribeType)
        {
            string sqlWhere = "MessageTemplateId='" + messageTemplateId + "' and SubscribeUserId='" + userId + "' and SubscribeType='" + subscribeType + "'";
            return _repository.GetWhere(sqlWhere);
        }
        /// <summary>
        /// 更新用户订阅消息
        /// </summary>
        /// <param name="messageTemplateId">消息模板主键</param>
        /// <param name="userId">用户</param>
        /// <param name="subscribeType">消息类型</param>
        /// <param name="subscribeStatus">订阅状态</param>
        /// <returns></returns>
        public bool UpdateByMessageTemplateIdAndUser(long messageTemplateId, long userId, string subscribeType, string subscribeStatus)
        {
            string sqlWhere = "MessageTemplateId='" + messageTemplateId + "' and SubscribeUserId='" + userId + "' and SubscribeType='" + subscribeType + "'";
            return _repository.UpdateTableField("SubscribeStatus", subscribeStatus, sqlWhere);
        }

        public long Insert(MemberSubscribeMsg info)
        {
            return _repository.Insert(info);
        }
        /// <summary>
        /// 更新订阅状态
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public bool UpdateSubscribeStatus(MemberSubscribeMsg info)
        {
            string sqlWhere = "MessageTemplateId='" + info.MessageTemplateId + "' and SubscribeUserId='" + info.SubscribeUserId + "' and SubscribeType='" + info.SubscribeType + "'";
            return _repository.UpdateTableField("SubscribeStatus", info.SubscribeStatus, sqlWhere);
        }
    }
}