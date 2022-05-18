using System;
using Yuebon.Commons.Core.UnitOfWork;
using Yuebon.Commons.Repositories;
using Yuebon.CodeGenerator.IRepositories;
using Yuebon.CodeGenerator.Models;

namespace Yuebon.CodeGenerator.Repositories
{
    /// <summary>
    /// 表字段仓储接口的实现
    /// </summary>
    public class CodeColumnsRepository : BaseRepository<CodeColumns>, ICodeColumnsRepository
    {

        public CodeColumnsRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

    }
}