using System;
using Yuebon.Commons.Services;
using Yuebon.CMS.IRepositories;
using Yuebon.CMS.IServices;
using Yuebon.CMS.Models;
using Yuebon.Security.IServices;

namespace Yuebon.CMS.Services
{
    public class ArticleCommentsGoodService : BaseService<ArticleCommentsGood, string>, IArticleCommentsGoodService
    {
		private readonly IArticleCommentsGoodRepository _repository;
        private readonly ILogService _logService;
        public ArticleCommentsGoodService(IArticleCommentsGoodRepository repository,ILogService logService) : base(repository)
        {
			_repository=repository;
			_logService=logService;
            _repository.OnOperationLog += _logService.OnOperationLog;
        }
    }
}