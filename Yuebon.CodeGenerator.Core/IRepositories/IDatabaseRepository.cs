using System;
using Yuebon.Commons.IRepositories;
using Yuebon.CodeGenerator.Models;

namespace Yuebon.CodeGenerator.IRepositories
{
    /// <summary>
    /// 定义数据库信息仓储接口
    /// </summary>
    public interface IDatabaseRepository:IRepository<Database>
    {
    }
}