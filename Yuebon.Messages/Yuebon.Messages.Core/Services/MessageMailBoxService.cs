using Yuebon.Commons.Services;
using Yuebon.Messages.IRepositories;
using Yuebon.Messages.IServices;
using Yuebon.Messages.Models;
using Yuebon.Security.IServices;

namespace Yuebon.Messages.Services
{
    public class MessageMailBoxService : BaseService<MessageMailBox, string>, IMessageMailBoxService
    {

        private readonly IMessageMailBoxRepository _appRepository;
        private readonly ILogService _logService;
        public MessageMailBoxService(IMessageMailBoxRepository iRepository, ILogService logService) : base(iRepository)
        {
            _appRepository = iRepository;
            _logService = logService;
            _appRepository.OnOperationLog += _logService.OnOperationLog;
        }
    }
}
