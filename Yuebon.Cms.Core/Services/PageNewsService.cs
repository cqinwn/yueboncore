using System;
using Yuebon.Commons.Services;
using Yuebon.CMS.IRepositories;
using Yuebon.CMS.IServices;
using Yuebon.CMS.Models;
using Yuebon.Security.IServices;
using Yuebon.CMS.Dtos;

namespace Yuebon.CMS.Services
{
    public class PageNewsService : BaseService<PageNews, PageNewsOutputDto, string>, IPageNewsService
    {
		private readonly IPageNewsRepository _repository;
        private readonly ILogService _logService;
        public PageNewsService(IPageNewsRepository repository,ILogService logService) : base(repository)
        {
			_repository=repository;
			_logService=logService;
            _repository.OnOperationLog += _logService.OnOperationLog;
        }
    }
}