using System;
using Yuebon.Commons.Core.UnitOfWork;
using Yuebon.Commons.Repositories;
using Yuebon.CodeGenerator.IRepositories;
using Yuebon.CodeGenerator.Models;

namespace Yuebon.CodeGenerator.Repositories
{
    /// <summary>
    /// 数据库信息仓储接口的实现
    /// </summary>
    public class DatabaseRepository : BaseRepository<Database>, IDatabaseRepository
    {

        public DatabaseRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

    }
}