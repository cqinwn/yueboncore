using System;
using Yuebon.Commons.IRepositories;
using Yuebon.Authorizer.Models;

namespace Yuebon.Authorizer.IRepositories
{
    /// <summary>
    /// 定义仓储接口
    /// </summary>
    public interface IRegistryCodeRepository:IRepository<RegistryCode, string>
    {
    }
}