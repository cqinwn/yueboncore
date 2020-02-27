using System.Collections.Generic;
using System.Linq;
using Yuebon.CMS.Dtos;
using Yuebon.CMS.IServices;
using Yuebon.CMS.Models;
using Yuebon.Commons.IoC;
using Yuebon.Commons.Mapping;
using Yuebon.Commons.Pages;

namespace Yuebon.CMS.Application
{
    public class PageNewsApp
    {
        IPageNewsService pagenewsservice = IoCContainer.Resolve<IPageNewsService>();
        IPageCategoryService pageCategoryService = IoCContainer.Resolve<IPageCategoryService>();

        /// <summary>
        /// 根据ID得到内容
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PageNews GetInfoById(string id)
        {
            return pagenewsservice.Get(id);
        }

        /// <summary>
        /// 根据文章分类获取该分类下的所有可用且未逻辑删除文章
        /// </summary>
        /// <param name="categoryId">分类Id</param>
        /// <returns></returns>
        public List<PageNewsOutputDto> GetArticleNewsListBCategoryId(string categoryId)
        {
            string where = string.Format("CategoryId='{0}' and EnabledMark=1 and DeleteMark=0 order by SortCode asc", categoryId);
            IEnumerable<PageNewsOutputDto> list = pagenewsservice.GetListWhere(where).MapTo<PageNewsOutputDto>();
            return list.ToList();
        }

        /// <summary>
        /// 根据条件查询数据库,并返回对象集合(用于分页数据显示)
        /// </summary>
        /// <param name="condition">查询的条件</param>
        /// <param name="info">分页实体</param>
        /// <param name="fieldToSort">排序字段</param>
        /// <param name="desc">是否降序</param>
        /// <returns>指定对象的集合</returns>
        public List<PageNewsOutputDto> FindWithPager(string where, PagerInfo pagerInfo, string fieldToSort, bool desc)
        {
            List<PageNews> list= pagenewsservice.FindWithPager(where, pagerInfo, fieldToSort, desc);
            List<PageNewsOutputDto> resultList = new List<PageNewsOutputDto>();
            foreach(PageNews item in list)
            {
                PageNewsOutputDto PageNewsOutputDto = new PageNewsOutputDto();
                PageNewsOutputDto.Id = item.Id;
                PageNewsOutputDto.ImgUrl = item.ImgUrl;
                PageNewsOutputDto.IsHot = item.IsHot;
                PageNewsOutputDto.IsMsg = item.IsMsg;
                PageNewsOutputDto.IsRed = item.IsRed;
                PageNewsOutputDto.IsSlide = item.IsSlide;
                PageNewsOutputDto.IsSys = item.IsSys;
                PageNewsOutputDto.IsTop = item.IsTop;
                PageNewsOutputDto.Author = item.Author;
                PageNewsOutputDto.CategoryId = item.CategoryId;
                PageNewsOutputDto.CategoryName = pageCategoryService.Get(item.CategoryId).Title;
                PageNewsOutputDto.Click = item.Click;
                PageNewsOutputDto.CompanyId = item.CompanyId;
                PageNewsOutputDto.CreatorTime = item.CreatorTime;
                PageNewsOutputDto.CreatorUserId = item.CreatorUserId;
                PageNewsOutputDto.DeleteMark = item.DeleteMark;
                PageNewsOutputDto.DeleteTime = item.DeleteTime;
                PageNewsOutputDto.DeleteUserId = item.DeleteUserId;
                PageNewsOutputDto.DeptId = item.DeptId;
                PageNewsOutputDto.Description = item.Description;
                PageNewsOutputDto.EnabledMark = item.EnabledMark;
                PageNewsOutputDto.LastModifyTime = item.LastModifyTime;
                PageNewsOutputDto.LastModifyUserId = item.LastModifyUserId;
                PageNewsOutputDto.LikeCount = item.LikeCount;
                PageNewsOutputDto.LinkUrl = item.LinkUrl;
                PageNewsOutputDto.SeoDescription = item.SeoDescription;
                PageNewsOutputDto.SeoKeywords = item.SeoKeywords;
                PageNewsOutputDto.SeoTitle = item.SeoTitle;
                PageNewsOutputDto.SortCode = item.SortCode;
                PageNewsOutputDto.Source = item.Source;
                PageNewsOutputDto.SubTitle = item.SubTitle;
                PageNewsOutputDto.Tags = item.Tags;
                PageNewsOutputDto.Title = item.Title;
                PageNewsOutputDto.Zhaiyao = item.Zhaiyao;

                resultList.Add(PageNewsOutputDto);
            }
            return resultList;
        }
    }
}
