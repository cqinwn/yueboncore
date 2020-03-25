using System;
using Yuebon.Commons.Services;
using Yuebon.CMS.IRepositories;
using Yuebon.CMS.IServices;
using Yuebon.CMS.Models;
using Yuebon.Security.IServices;
using Yuebon.CMS.Dtos;

namespace Yuebon.CMS.Services
{
    public class ArticleStarService : BaseService<ArticleStar, ArticleStarOutputDto, string>, IArticleStarService
    {
		private readonly IArticleStarRepository _repository;
        private readonly ILogService _logService;
        public ArticleStarService(IArticleStarRepository repository,ILogService logService) : base(repository)
        {
			_repository=repository;
			_logService=logService;
            _repository.OnOperationLog += _logService.OnOperationLog;
        }
    }
}