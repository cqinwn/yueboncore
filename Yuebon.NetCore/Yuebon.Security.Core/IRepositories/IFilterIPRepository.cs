using System;
using Yuebon.Commons.IRepositories;
using Yuebon.Security.Models;

namespace Yuebon.Security.IRepositories
{
    public interface IFilterIPRepository:IRepository<FilterIP>
    {
        /// <summary>
        /// 验证IP地址是否被拒绝
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        bool ValidateIP(string ip);
    }
}