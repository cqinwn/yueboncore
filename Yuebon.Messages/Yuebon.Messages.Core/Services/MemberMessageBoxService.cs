using Yuebon.Commons.IRepositories;
using Yuebon.Commons.Repositories;
using Yuebon.Commons.Services;
using Yuebon.Messages.IRepositories;
using Yuebon.Messages.IServices;
using Yuebon.Messages.Models;
using Yuebon.Security.IServices;

namespace Yuebon.Messages.Services
{
    public class MemberMessageBoxService : BaseService<MemberMessageBox, string>, IMemberMessageBoxService
    {

        private readonly IMemberMessageBoxRepository _repository;
        private readonly ILogService _logService;
        public MemberMessageBoxService(IMemberMessageBoxRepository iRepository, ILogService logService) : base(iRepository)
        {
            _repository = iRepository;
            _logService = logService;
            _repository.OnOperationLog += _logService.OnOperationLog;
        }

        /// <summary>
        /// 更新已读状态
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool UpdateIsReadStatus(string id, int isread,string userid)
        {
            return _repository.UpdateIsReadStatus(id, isread,userid);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isread">2:全部，0：未读，1：已读</param>
        /// <param name="userid"></param>
        /// <returns></returns>
        public int GetTotalCounts(int isread, string userid)
        {
            return _repository.GetTotalCounts(isread, userid);
        }
    }
}
