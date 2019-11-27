using System;
using Yuebon.Commons.IServices;
using Yuebon.CMS.Models;
using System.Collections.Generic;
using Yuebon.CMS.Dtos;

namespace Yuebon.CMS.IServices
{
    public interface IArticleCategoryService : IService<ArticleCategory,string>
    {
        /// <summary>
        /// 得到分类列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IEnumerable<ArticleSimpleCategoryOutputDto> GetArticleCategoryListInfo(string id);


        /// <summary>
        /// 得到分类列表(用于首页)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IEnumerable<ArticleIndexCategoryOutputDto> GetArticleIndexCategoryListInfo(string id);



        /// <summary>
        /// 得到分类列表(用于首页)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IEnumerable<ArticleIndexCategoryOutputDto> GetUserArticleCategoryListInfo(string userid);


        /// <summary>
        /// 得到分类列表(用于首页)：新
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IEnumerable<ArticleIndexCategoryOutputDto> GetUserArticleCategoryListInfoNew(string userid);

        /// <summary>
        /// 得到未选择的分类列表(用于首页):新
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IEnumerable<ArticleIndexCategoryOutputDto> GetUserUnSelArticleCategoryListInfoNew(string userid);

        /// <summary>
        /// 得到未选择的分类列表(用于首页)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IEnumerable<ArticleIndexCategoryOutputDto> GetUserUnSelArticleCategoryListInfo(string userid);


        /// <summary>
        /// 保存用户自定义分类
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="selstr"></param>
        /// <param name="unselstr"></param>
        /// <returns></returns>
        bool SaveUserArticleCategoryList(string userid, string selstr, string unselstr);


        /// <summary>
        /// 根据分类D获取分类名称
        /// </summary>
        /// <param name="ids">分类ID字符串，用“,”分隔</param>
        /// <returns></returns>
        string GetCategoryNameStr(string ids);
    }
}