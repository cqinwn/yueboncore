using System;
using Yuebon.Commons.Services;
using Yuebon.CMS.IRepositories;
using Yuebon.CMS.IServices;
using Yuebon.CMS.Models;
using Yuebon.Security.IServices;

namespace Yuebon.CMS.Services
{
    public class PageCategoryService : BaseService<PageCategory, string>, IPageCategoryService
    {
		private readonly IPageCategoryRepository _repository;
        private readonly ILogService _logService;
        public PageCategoryService(IPageCategoryRepository repository,ILogService logService) : base(repository)
        {
			_repository=repository;
			_logService=logService;
            _repository.OnOperationLog += _logService.OnOperationLog;
        }
    }
}