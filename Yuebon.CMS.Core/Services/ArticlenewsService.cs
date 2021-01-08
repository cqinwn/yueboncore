using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Yuebon.Commons.Dtos;
using Yuebon.Commons.Mapping;
using Yuebon.Commons.Pages;
using Yuebon.Commons.Services;
using Yuebon.CMS.IRepositories;
using Yuebon.CMS.IServices;
using Yuebon.CMS.Dtos;
using Yuebon.CMS.Models;

namespace Yuebon.CMS.Services
{
    /// <summary>
    /// 文章服务接口实现
    /// </summary>
    public class ArticlenewsService: BaseService<Articlenews,ArticlenewsOutputDto, string>, IArticlenewsService
    {
		private readonly IArticlenewsRepository _repository;
        public ArticlenewsService(IArticlenewsRepository repository) : base(repository)
        {
			_repository=repository;
        }
    }
}