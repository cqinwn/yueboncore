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
    public class ArticlenewsService : BaseService<Articlenews, ArticlenewsOutputDto, string>, IArticlenewsService
    {
        private readonly IArticlenewsRepository _repository;
        public ArticlenewsService(IArticlenewsRepository repository) : base(repository)
        {
            _repository = repository;
        }


        /// <summary>
        /// 根据条件查询数据库,并返回对象集合(用于分页数据显示)
        /// </summary>
        /// <param name="search">查询的条件</param>
        /// <returns>指定对象的集合</returns>
        public override async Task<PageResult<ArticlenewsOutputDto>> FindWithPagerAsync(SearchInputDto<Articlenews> search)
        {
            bool order = search.Order == "asc" ? false : true;
            string where = GetDataPrivilege();
            if (search.Keywords is { Length: > 0 })
            {
                where += string.Format(" and  Title like '%{0}%'", search.Keywords);
            };
            PagerInfo pagerInfo = new PagerInfo
            {
                CurrenetPageIndex = search.CurrenetPageIndex,
                PageSize = search.PageSize
            };
            List<Articlenews> list = await _repository.FindWithPagerAsync(where, pagerInfo, search.Sort, order);
            PageResult<ArticlenewsOutputDto> pageResult = new PageResult<ArticlenewsOutputDto>
            {
                CurrentPage = pagerInfo.CurrenetPageIndex,
                Items = list.MapTo<ArticlenewsOutputDto>(),
                ItemsPerPage = pagerInfo.PageSize,
                TotalItems = pagerInfo.RecordCount
            };
            return pageResult;
        }
    }
}