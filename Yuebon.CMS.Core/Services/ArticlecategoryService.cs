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
using System.Linq;

namespace Yuebon.CMS.Services
{
    /// <summary>
    /// 文章分类服务接口实现
    /// </summary>
    public class ArticlecategoryService: BaseService<Articlecategory,ArticlecategoryOutputDto, string>, IArticlecategoryService
    {
		private readonly IArticlecategoryRepository _repository;
        public ArticlecategoryService(IArticlecategoryRepository repository) : base(repository)
        {
			_repository=repository;
        }

        /// <summary>
        /// 根据条件查询数据库,并返回对象集合(用于分页数据显示)
        /// </summary>
        /// <param name="search">查询的条件</param>
        /// <returns>指定对象的集合</returns>
        public override async Task<PageResult<ArticlecategoryOutputDto>> FindWithPagerAsync(SearchInputDto<Articlecategory> search)
        {
            bool order = search.Order == "asc" ? false : true;
            string where = GetDataPrivilege();
            if (search.Keywords is { Length: > 0 })
            {
                where += string.Format(" and  Title '%{0}%'", search.Keywords);
            };
            PagerInfo pagerInfo = new PagerInfo
            {
                CurrenetPageIndex = search.CurrenetPageIndex,
                PageSize = search.PageSize
            };
            List<Articlecategory> list = await repository.FindWithPagerAsync(where, pagerInfo, search.Sort, order);
            PageResult<ArticlecategoryOutputDto> pageResult = new PageResult<ArticlecategoryOutputDto>
            {
                CurrentPage = pagerInfo.CurrenetPageIndex,
                Items = list.MapTo<ArticlecategoryOutputDto>(),
                ItemsPerPage = pagerInfo.PageSize,
                TotalItems = pagerInfo.RecordCount
            };
            return pageResult;
        }


        /// <summary>
        /// 获取分类适用于Vue 树形列表，关键词为空时获取所有
        /// </summary>
        /// <param name="keyword">名称关键词</param>
        /// <returns></returns>
        public async Task<List<ArticlecategoryOutputDto>> GetAllArticlecategoryTreeTable(string keyword)
        {
            List<ArticlecategoryOutputDto> reslist = new List<ArticlecategoryOutputDto>();
            string where = "1=1";
            if(keyword is { Length: > 0 })
            {
                where = string.Format("Title like '%{0}%'", keyword);
            }
            where += " order by ClassLayer,SortCode";
            IEnumerable<Articlecategory> elist = await _repository.GetListWhereAsync(where);
            if (elist != null)
            {
                List<Articlecategory> list = elist.ToList();
                var ChilList = list.FindAll(t => t.ParentId == "");
                if (ChilList.Count==0)
                {
                    Articlecategory articlecategoryOutputDto = elist.FirstOrDefault<Articlecategory>();
                    reslist = GetSubArticlecategorys(list, articlecategoryOutputDto.ParentId).ToList<ArticlecategoryOutputDto>();
                }
                else
                {
                    reslist = GetSubArticlecategorys(list, "").ToList<ArticlecategoryOutputDto>();
                }
            }
            return reslist;
        }


        /// <summary>
        /// 获取子集，递归调用
        /// </summary>
        /// <param name="data"></param>
        /// <param name="parentId">父级Id</param>
        /// <returns></returns>
        private List<ArticlecategoryOutputDto> GetSubArticlecategorys(List<Articlecategory> data, string parentId)
        {
            List<ArticlecategoryOutputDto> list = new List<ArticlecategoryOutputDto>();
            ArticlecategoryOutputDto articlecategoryOutputDto = new ArticlecategoryOutputDto();
            var ChilList = data.FindAll(t => t.ParentId == parentId);
            foreach (Articlecategory entity in ChilList)
            {
                articlecategoryOutputDto = entity.MapTo<ArticlecategoryOutputDto>();
                articlecategoryOutputDto.Children = GetSubArticlecategorys(data, entity.Id).OrderBy(t => t.SortCode).MapTo<ArticlecategoryOutputDto>();
                list.Add(articlecategoryOutputDto);
            }
            return list;
        }
    }
}