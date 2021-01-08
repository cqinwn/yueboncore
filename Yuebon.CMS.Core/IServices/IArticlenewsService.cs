using System;
using Yuebon.Commons.IServices;
using Yuebon.CMS.Dtos;
using Yuebon.CMS.Models;

namespace Yuebon.CMS.IServices
{
    /// <summary>
    /// 定义文章服务接口
    /// </summary>
    public interface IArticlenewsService:IService<Articlenews,ArticlenewsOutputDto, string>
    {
    }
}
