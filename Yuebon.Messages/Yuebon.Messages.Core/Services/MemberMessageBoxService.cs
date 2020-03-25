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
    public class MemberMessageBoxService: BaseService<MemberMessageBox,MemberMessageBoxOutputDto, string>, IMemberMessageBoxService
    {
		private readonly IMemberMessageBoxRepository _repository;
        private readonly ILogService _logService;
        public MemberMessageBoxService(IMemberMessageBoxRepository repository,ILogService logService) : base(repository)
        {
			_repository=repository;
			_logService=logService;
            _repository.OnOperationLog += _logService.OnOperationLog;
        }

        public int GetTotalCounts(int isread, string userid)
        {
            return _repository.GetTotalCounts(isread,userid);
        }

        public bool UpdateIsReadStatus(string id, int isread, string userid)
        {
            return _repository.UpdateIsReadStatus(id, isread, userid);
        }
    }
}