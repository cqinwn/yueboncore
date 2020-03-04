using System.Collections.Generic;
using Yuebon.Commons.Services;
using Yuebon.Messages.Dtos;
using Yuebon.Messages.IRepositories;
using Yuebon.Messages.IServices;
using Yuebon.Messages.Models;
using Yuebon.Security.IServices;

namespace Yuebon.Messages.Services
{
    public class MemberSubscribeMsgService : BaseService<MemberSubscribeMsg, string>, IMemberSubscribeMsgService
    {

        private readonly IMemberSubscribeMsgRepository _appRepository;
        private readonly ILogService _logService;
        public MemberSubscribeMsgService(IMemberSubscribeMsgRepository iRepository, ILogService logService) : base(iRepository)
        {
            _appRepository = iRepository;
            _logService = logService;
            _appRepository.OnOperationLog += _logService.OnOperationLog;
        }


        /// <summary>
        /// 根据消息类型查询消息模板
        /// </summary>
        /// <param name="messageType">消息类型</param>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public MemberMessageTemplatesOuputDto GetByMessageTypeWithUser(string messageType,string userId)
        {
            return _appRepository.GetByMessageTypeWithUser(messageType,userId);
        }


        /// <summary>
        /// 按用户、订阅类型和消息模板主键查询
        /// </summary>
        /// <param name="subscribeType">消息类型</param>
        /// <param name="userId">用户</param>
        /// <param name="messageTemplateId">模板Id主键</param>
        /// <returns></returns>
        public MemberMessageTemplatesOuputDto GetByWithUser(string subscribeType, string userId, string messageTemplateId)
        {

            return _appRepository.GetByWithUser(subscribeType, userId,messageTemplateId);
        }
    }
}
