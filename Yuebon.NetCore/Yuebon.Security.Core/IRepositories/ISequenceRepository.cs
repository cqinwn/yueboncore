using System;
using Yuebon.Commons.IRepositories;
using Yuebon.Security.Models;

namespace Yuebon.Security.IRepositories
{
    /// <summary>
    /// 定义单据编码仓储接口
    /// </summary>
    public interface ISequenceRepository:IRepository<Sequence>
    {
    }
}