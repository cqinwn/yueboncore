using System;
using Yuebon.Commons.IServices;
using Yuebon.CMS.Dtos;
using Yuebon.CMS.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Yuebon.CMS.IServices
{
    /// <summary>
    /// 定义文章分类服务接口
    /// </summary>
    public interface IArticlecategoryService:IService<Articlecategory,ArticlecategoryOutputDto, string>
    {

        /// <summary>
        /// 获取章分类适用于Vue 树形列表，关键词为空时获取所有
        /// <param name="keyword">名称关键词</param>
        /// </summary>
        /// <returns></returns>
        Task<List<ArticlecategoryOutputDto>> GetAllArticlecategoryTreeTable(string keyword);
    }
}
