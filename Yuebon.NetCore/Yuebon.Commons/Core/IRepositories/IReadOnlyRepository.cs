using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yuebon.Commons.Models;

namespace Yuebon.Commons.Core.IRepositories
{
    /// <summary>
    /// 只读仓储接口,提供查询相关方法
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    public interface IReadOnlyRepository<T, TKey> : IDisposable where T : Entity
    {

    }
}
