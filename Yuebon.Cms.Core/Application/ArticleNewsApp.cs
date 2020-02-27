using System.Collections.Generic;
using System.Linq;
using Yuebon.CMS.Dtos;
using Yuebon.CMS.IServices;
using Yuebon.CMS.Models;
using Yuebon.Commons;
using Yuebon.Commons.IoC;
using Yuebon.Commons.Mapping;
using Yuebon.Commons.Models;
using Yuebon.Commons.Pages;

namespace Yuebon.CMS.Application
{
    public class ArticleNewsApp
    {
        IArticleNewsService service = IoCContainer.Resolve<IArticleNewsService>();
        IArticleCategoryService serviceArticleCategory = IoCContainer.Resolve<IArticleCategoryService>();

        /// <summary>
        /// 根据文章id获取文章详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ArticleNewsOutputDto Get(string id)
        {
            ArticleNews articleNews = new ArticleNews();
            articleNews = service.Get(id);
            ArticleNewsOutputDto articleNewsDto = new ArticleNewsOutputDto();
            articleNewsDto.Id = articleNews.Id;
            articleNewsDto.ImgUrl = articleNews.ImgUrl;
            articleNewsDto.IsHot = articleNews.IsHot;
            articleNewsDto.IsMsg = articleNews.IsMsg;
            articleNewsDto.IsRed = articleNews.IsRed;
            articleNewsDto.IsSlide = articleNews.IsSlide;
            articleNewsDto.IsSys = articleNews.IsSys;
            articleNewsDto.IsTop = articleNews.IsTop;
            articleNewsDto.Author = articleNews.Author;
            articleNewsDto.CategoryId = articleNews.CategoryId;
            ArticleCategory articleCategory = new ArticleCategory();
            articleCategory = serviceArticleCategory.Get(articleNews.CategoryId);
            if (articleCategory != null)
            {
                articleNewsDto.CategoryName = articleCategory.Title;
            }
            articleNewsDto.Click = articleNews.Click;
            articleNewsDto.CompanyId = articleNews.CompanyId;
            articleNewsDto.CreatorTime = articleNews.CreatorTime;
            articleNewsDto.CreatorUserId = articleNews.CreatorUserId;
            articleNewsDto.DeleteMark = articleNews.DeleteMark;
            articleNewsDto.DeleteTime = articleNews.DeleteTime;
            articleNewsDto.DeleteUserId = articleNews.DeleteUserId;
            articleNewsDto.DeptId = articleNews.DeptId;
            articleNewsDto.Description = articleNews.Description;
            articleNewsDto.EnabledMark = articleNews.EnabledMark;
            articleNewsDto.LastModifyTime = articleNews.LastModifyTime;
            articleNewsDto.LastModifyUserId = articleNews.LastModifyUserId;
            articleNewsDto.LikeCount = articleNews.LikeCount;
            articleNewsDto.LinkUrl = articleNews.LinkUrl;
            articleNewsDto.SeoDescription = articleNews.SeoDescription;
            articleNewsDto.SeoKeywords = articleNews.SeoKeywords;
            articleNewsDto.SeoTitle = articleNews.SeoTitle;
            articleNewsDto.SortCode = articleNews.SortCode;
            articleNewsDto.Source = articleNews.Source;
            articleNewsDto.SubTitle = articleNews.SubTitle;
            articleNewsDto.Tags = articleNews.Tags;
            articleNewsDto.Title = articleNews.Title;
            articleNewsDto.Zhaiyao = articleNews.Zhaiyao;
            return articleNewsDto;
        }


        /// <summary>
        /// 得到文章列表，id为空则加载全部
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ArticleNewsOutputDto GetArticleNewsListInfo(string id)
        {
            return service.GetArticleNewsListInfo(id);
        }
        /// <summary>
        /// 根据文章分类获取该分类下的所有可用且未逻辑删除文章
        /// </summary>
        /// <param name="categoryId">分类Id</param>
        /// <returns></returns>
        public List<ArticleNewsOutputDto> GetArticleNewsListBCategoryId(string categoryId)
        {
            string where = string.Format("CategoryId='{0}' and EnabledMark=1 and DeleteMark=0 order by SortCode asc", categoryId);
            IEnumerable<ArticleNewsOutputDto> list = service.GetListWhere(where).MapTo<ArticleNewsOutputDto>();
            return list.ToList();
        }
        /// <summary>
        /// 按页返回数据
        /// </summary>
        /// <returns></returns>
        public List<ArticleNews> GetArticleNewsListByPage(string condition, PagerInfo info, string fieldToSort, bool desc)
        {
            List<ArticleNews> list = service.FindWithPager(condition, info, fieldToSort, desc);
            return list;
        }

        /// <summary>
        /// 分页得到文章表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<ArticleNewsOutputDto> GetArticleListByPageWithFlag(string currentpage,
            string pagesize, int flag, string userid)
        {
            return service.GetArticleListByPageWithFlag(currentpage, pagesize, flag, userid);

        }

        /// <summary>
        /// 删除记录，仅物理删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DelArticle(string articleid)
        { 
            return service.DeleteSoft(true, articleid);
        }


        /// <summary>
        /// 根据ID得到文章标题和分类
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetTitleAndCategoryById(string articleid)
        {
            ArticleNews modle = service.Get(articleid);
            if(modle!=null)
            {
                return modle.Title + ">" + modle.CategoryName;
            }
            else
            {
                return "";
            }
        }
    }
}
