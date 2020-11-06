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
    public class MessageMailBoxService: BaseService<MessageMailBox,MessageMailBoxOutputDto, string>, IMessageMailBoxService
    {
		private readonly IMessageMailBoxRepository _repository;
        private readonly ILogService _logService;
        public MessageMailBoxService(IMessageMailBoxRepository repository,ILogService logService) : base(repository)
        {
			_repository=repository;
			_logService=logService;
        }
    }
}