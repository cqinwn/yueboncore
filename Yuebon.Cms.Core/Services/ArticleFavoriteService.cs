using System;
using Yuebon.Commons.Services;
using Yuebon.CMS.IRepositories;
using Yuebon.CMS.IServices;
using Yuebon.CMS.Models;
using Yuebon.Security.IServices;

namespace Yuebon.CMS.Services
{
    public class ArticleFavoriteService : BaseService<ArticleFavorite, string>, IArticleFavoriteService
    {
		private readonly IArticleFavoriteRepository _repository;
        private readonly ILogService _logService;
        public ArticleFavoriteService(IArticleFavoriteRepository repository,ILogService logService) : base(repository)
        {
			_repository=repository;
			_logService=logService;
            _repository.OnOperationLog += _logService.OnOperationLog;
        }
    }
}