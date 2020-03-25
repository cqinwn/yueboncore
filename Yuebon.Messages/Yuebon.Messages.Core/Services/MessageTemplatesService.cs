using System;
using Yuebon.Commons.Services;
using Yuebon.Security.IServices;
using Yuebon.Messages.IRepositories;
using Yuebon.Messages.IServices;
using Yuebon.Messages.Dtos;
using Yuebon.Messages.Models;
using System.Collections.Generic;

namespace Yuebon.Messages.Services
{
    /// <summary>
    /// 服务接口实现
    /// </summary>
    public class MessageTemplatesService: BaseService<MessageTemplates,MessageTemplatesOutputDto, string>, IMessageTemplatesService
    {
		private readonly IMessageTemplatesRepository _repository;
        private readonly ILogService _logService;
        public MessageTemplatesService(IMessageTemplatesRepository repository,ILogService logService) : base(repository)
        {
			_repository=repository;
			_logService=logService;
            _repository.OnOperationLog += _logService.OnOperationLog;
        }

        /// <summary>
        /// 根据消息类型查询消息模板
        /// </summary>
        /// <param name="messageType">消息类型</param>
        /// <returns></returns>
        public MessageTemplates GetByMessageType(string messageType)
        {
            return _repository.GetWhere("messageType='" + messageType + "'");
        }

        /// <summary>
        /// 根据用户查询微信小程序订阅消息模板列表，关联用户订阅表
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <returns></returns>
        public List<MemberMessageTemplatesOuputDto> ListByUseInWxApplet(string userId)
        {
            return _repository.ListByUseInWxApplet(userId);
        }
    }
}