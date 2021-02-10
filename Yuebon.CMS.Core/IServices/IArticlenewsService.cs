using System;
using Yuebon.Commons.IServices;
using Yuebon.CMS.Dtos;
using Yuebon.CMS.Models;
using System.Threading.Tasks;
using Yuebon.Commons.Pages;
using Yuebon.Commons.Dtos;
using System.Collections.Generic;

namespace Yuebon.CMS.IServices
{
    /// <summary>
    /// 定义文章服务接口
    /// </summary>
    public interface IArticlenewsService:IService<Articlenews,ArticlenewsOutputDto, string>
    {
        /// <summary>
        /// 根据用户角色获取分类及该分类的文章
        /// </summary>
        /// <returns></returns>
        Task<List<CategoryArticleOutputDto>> GetCategoryArticleList();
    }
}
