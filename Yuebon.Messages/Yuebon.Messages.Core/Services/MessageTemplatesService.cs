using System.Collections.Generic;
using Yuebon.Commons.IRepositories;
using Yuebon.Commons.Services;
using Yuebon.Messages.Dtos;
using Yuebon.Messages.IRepositories;
using Yuebon.Messages.IServices;
using Yuebon.Messages.Models;
using Yuebon.Security.IServices;

namespace Yuebon.Messages.Services
{
    public class MessageTemplatesService : BaseService<MessageTemplates, string>, IMessageTemplatesService
    {

        private readonly IMessageTemplatesRepository _appRepository;
        private readonly ILogService _logService;
        public MessageTemplatesService(IMessageTemplatesRepository iRepository, ILogService logService) : base(iRepository)
        {

            _appRepository = iRepository;
            _logService = logService;
            _appRepository.OnOperationLog += _logService.OnOperationLog;
        }
        /// <summary>
        /// 根据消息类型查询消息模板
        /// </summary>
        /// <param name="messageType">消息类型</param>
        /// <returns></returns>
        public MessageTemplates GetByMessageType(string messageType)
        {
            return _appRepository.GetWhere("messageType='" + messageType + "'");
        }

        /// <summary>
        /// 根据用户查询微信小程序订阅消息模板列表，关联用户订阅表
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <returns></returns>
        public List<MemberMessageTemplatesOuputDto> ListByUseInWxApplet(string userId)
        {
            return _appRepository.ListByUseInWxApplet(userId);
        }
    }
}
