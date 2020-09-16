using System;
using Yuebon.Commons.Services;
using Yuebon.Security.IServices;
using Yuebon.Security.IRepositories;
using Yuebon.Security.IServices;
using Yuebon.Security.Dtos;
using Yuebon.Security.Models;

namespace Yuebon.Security.Services
{
    /// <summary>
    /// 序号编码规则表服务接口实现
    /// </summary>
    public class SequenceRuleService: BaseService<SequenceRule,SequenceRuleOutputDto, string>, ISequenceRuleService
    {
		private readonly ISequenceRuleRepository _repository;
        private readonly ILogService _logService;
        public SequenceRuleService(ISequenceRuleRepository repository,ILogService logService) : base(repository)
        {
			_repository=repository;
			_logService=logService;
            _repository.OnOperationLog += _logService.OnOperationLog;
        }
    }
}