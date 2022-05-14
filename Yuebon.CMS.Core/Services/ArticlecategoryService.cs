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
using Yuebon.Commons.Core.Dtos;
using Yuebon.Commons.Models;
using System.Data;
using Yuebon.Commons.Extensions;

namespace Yuebon.CMS.Services
{
    /// <summary>
    /// 文章分类服务接口实现
    /// </summary>
    public class ArticlecategoryService: BaseService<Articlecategory,ArticlecategoryOutputDto>, IArticlecategoryService
    {
        private readonly IArticlenewsRepository _articleRepository;
        public ArticlecategoryService(IArticlecategoryRepository arepository, IArticlenewsRepository articleRepository) 
        {
            repository = arepository;
            _articleRepository = articleRepository;
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
            IEnumerable<Articlecategory> elist = await repository.GetListWhereAsync(where);
            if (elist.Count() >0)
            {
                List<Articlecategory> list = elist.ToList();
                var ChilList = list.FindAll(t => t.ParentId == null);
                if (ChilList.Count==0)
                {
                    Articlecategory articlecategoryOutputDto = elist.FirstOrDefault<Articlecategory>();
                    reslist = GetSubArticlecategorys(list, articlecategoryOutputDto.ParentId).ToList<ArticlecategoryOutputDto>();
                }
                else
                {
                    reslist = GetSubArticlecategorys(list,0).ToList<ArticlecategoryOutputDto>();
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
        private List<ArticlecategoryOutputDto> GetSubArticlecategorys(List<Articlecategory> data, long? parentId)
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

        /// <summary>
        /// 按条件批量删除
        /// </summary>
        /// <param name="idsInfo">主键Id集合</param>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        public CommonResult DeleteBatchWhere(DeletesInputDto idsInfo, IDbTransaction trans = null)
        {
            CommonResult result = new CommonResult();
            string where = string.Empty;
            for (int i = 0; i < idsInfo.Ids.Length; i++)
            {
                if (idsInfo.Ids[0] != null)
                {
                    where = string.Format("ParentId='{0}'", idsInfo.Ids[0]);
                    IEnumerable<Articlecategory> list = repository.GetListWhere(where);
                    if (list.Count()>0)
                    {
                        result.ErrMsg = "该分类存在子分类，不能删除";
                        return result;
                    }

                    where = string.Format("CategoryId='{0}'", idsInfo.Ids[0]);
                    IEnumerable<Articlenews> listArticle = _articleRepository.GetListWhere(where);
                    if (listArticle.Count() > 0)
                    {
                        result.ErrMsg = "该分类有文章数据，不能删除";
                        return result;
                    }
                }
            }
            where = "id in ('" + idsInfo.Ids.Join(",").Trim(',').Replace(",", "','") + "')";
            bool bl = repository.DeleteBatchWhere(where);
            if (bl)
            {
                result.ErrCode = "0";
            }
            return result;
        }

        /// <summary>
        /// 按条件批量删除
        /// </summary>
        /// <param name="idsInfo">主键Id集合</param>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        public async Task<CommonResult> DeleteBatchWhereAsync(DeletesInputDto idsInfo, IDbTransaction trans = null)
        {
            CommonResult result = new CommonResult();
            string where = string.Empty;
            for (int i = 0; i < idsInfo.Ids.Length; i++)
            {
                where = string.Format("ParentId='{0}'", idsInfo.Ids[0]);
                IEnumerable<Articlecategory> list = repository.GetListWhere(where);
                if (list.Count()> 0)
                {
                    result.ErrMsg = "该分类存在子分类，不能删除";
                    return result;
                }

                where = string.Format("CategoryId='{0}'", idsInfo.Ids[0]);
                IEnumerable<Articlenews> listArticle = _articleRepository.GetListWhere(where);
                if (listArticle.Count()>0)
                {
                    result.ErrMsg = "该分类有文章数据，不能删除";
                    return result;
                }
            }
            where = "id in ('" + idsInfo.Ids.Join(",").Trim(',').Replace(",", "','") + "')";
            bool bl = await repository.DeleteBatchWhereAsync(where);
            if (bl)
            {
                result.ErrCode = "0";
            }
            return result;
        }
    }
}