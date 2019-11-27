using System.Collections.Generic;
using System.Linq;
using Yuebon.CMS.Dtos;
using Yuebon.CMS.IServices;
using Yuebon.CMS.Models;
using Yuebon.Commons;
using Yuebon.Commons.IoC;
using Yuebon.Commons.Mapping;
using Yuebon.Commons.Pages;

namespace Yuebon.CMS.Application
{
    public class ArticleCategoryApp
    {

        IArticleCategoryService service = IoCContainer.Resolve<IArticleCategoryService>();
        // <summary>
        /// 获取所有可用的分类
        /// </summary>
        /// <returns></returns>
        public List<CategoryPickerOutputDto> GetAllByEnable()
        {
            List<CategoryPickerOutputDto> list = service.GetAllByIsNotDeleteAndEnabledMark().OrderBy(t => t.SortCode).ToList().MapTo<CategoryPickerOutputDto>();
            return list;
        }
        /// <summary>
        /// 得到文件分类列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<ArticleSimpleCategoryOutputDto> GetArticleCategoryListInfo(string id)
        {
            return service.GetArticleCategoryListInfo(id);
        }

        /// <summary>
        /// 得到文章分类列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<ArticleIndexCategoryOutputDto> GetArticleIndexCategoryListInfo(string id)
        {
            return service.GetArticleIndexCategoryListInfo(id);
        }

        /// <summary>
        /// 得到文章分类列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<ArticleIndexCategoryOutputDto> GetAllByIsNotDeleteAndEnabledMark(string where)
        {
            return service.GetAllByIsNotDeleteAndEnabledMark(where).MapTo<ArticleIndexCategoryOutputDto>();
        }

        /// <summary>
        /// 得到文章用户自定义分类列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<ArticleIndexCategoryOutputDto> GetUserArticleCategoryListInfo(string userid)
        {
            return service.GetUserArticleCategoryListInfo(userid);
        }

        /// <summary>
        /// 得到文章用户自定义分类列表:新
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<ArticleIndexCategoryOutputDto> GetUserArticleCategoryListInfoNew(string userid)
        {
            return service.GetUserArticleCategoryListInfoNew(userid);
        }

        /// <summary>
        /// 得到文章用户自定义未选择分类列表:新
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<ArticleIndexCategoryOutputDto> GetUserUnSelArticleCategoryListInfoNew(string userid)
        {
            return service.GetUserUnSelArticleCategoryListInfoNew(userid);
        }

        /// <summary>
        /// 得到文章用户自定义未选择分类列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<ArticleIndexCategoryOutputDto> GetUserUnSelArticleCategoryListInfo(string userid)
        {
            return service.GetUserUnSelArticleCategoryListInfo(userid);
        }

        /// <summary>
        /// 保存用户自定义分类
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="selstr"></param>
        /// <param name="unselstr"></param>
        /// <returns></returns>
        public bool SaveUserArticleCategoryList(string userid, string selstr, string unselstr)
        {
            return service.SaveUserArticleCategoryList(userid, selstr, unselstr);
        }


        /// <summary>
        /// 根据分类D获取分类名称
        /// </summary>
        /// <param name="ids">分类ID字符串，用“,”分格</param>
        /// <returns></returns>
        public string GetCategoryNameStr(string ids)
        {
            string roleIDsStr = string.Format("'{0}'", ids.Replace(",", "','"));
            string sqlWhere = string.Format("Id in({0})", roleIDsStr);
            List<ArticleCategory> listCategories = service.GetListWhere(sqlWhere).ToList();
            string strEnCode = string.Empty;
            foreach (ArticleCategory item in listCategories)
            {
                strEnCode += item.Title + ",";
            }
            return strEnCode;
        }
    }
}
