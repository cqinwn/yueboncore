using System;
using Yuebon.Commons.IRepositories;
using Yuebon.Security.Models;

namespace Yuebon.Security.IRepositories
{
    /// <summary>
    /// 定义租户仓储接口
    /// </summary>
    public interface ITentantRepository:IRepository<Tentant, string>
    {
    }
}