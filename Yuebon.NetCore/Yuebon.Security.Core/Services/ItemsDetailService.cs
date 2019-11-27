using System;
using Yuebon.Commons.Services;
using Yuebon.Security.IRepositories;
using Yuebon.Security.IServices;
using Yuebon.Security.Models;

namespace Yuebon.Security.Services
{
    public class ItemsDetailService: BaseService<ItemsDetail, string>, IItemsDetailService
    {
        private readonly IItemsDetailRepository _repository;
        private readonly ILogService _logService;
        public ItemsDetailService(IItemsDetailRepository repository, ILogService logService) : base(repository)
        {
            _repository = repository;
            _logService = logService;
            _repository.OnOperationLog += _logService.OnOperationLog;
        }
    }
}