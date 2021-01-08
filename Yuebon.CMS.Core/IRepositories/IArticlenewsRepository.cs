using System;
using Yuebon.Commons.IRepositories;
using Yuebon.CMS.Models;

namespace Yuebon.CMS.IRepositories
{
    /// <summary>
    /// 定义文章仓储接口
    /// </summary>
    public interface IArticlenewsRepository:IRepository<Articlenews, string>
    {
    }
}