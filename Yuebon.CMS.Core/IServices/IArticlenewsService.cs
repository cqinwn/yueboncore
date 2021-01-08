using System;
using Yuebon.Commons.IServices;
using Yuebon.CMS.Dtos;
using Yuebon.CMS.Models;
using System.Threading.Tasks;
using Yuebon.Commons.Pages;
using Yuebon.Commons.Dtos;

namespace Yuebon.CMS.IServices
{
    /// <summary>
    /// 定义文章服务接口
    /// </summary>
    public interface IArticlenewsService:IService<Articlenews,ArticlenewsOutputDto, string>
    {
        /// <summary>
        /// 根据条件查询数据库,并返回对象集合(用于分页数据显示)
        /// </summary>
        /// <param name="search">查询的条件</param>
        /// <returns>指定对象的集合</returns>
        Task<PageResult<ArticlenewsOutputDto>> FindWithPagerAsync(SearchInputDto<Articlenews> search);
    }
}
