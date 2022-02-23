using System;
using Yuebon.Commons.IDbContext;
using Yuebon.Commons.Repositories;
using Yuebon.Security.IRepositories;
using Yuebon.Security.Models;

namespace Yuebon.Security.Repositories
{
    /// <summary>
    /// 序号编码规则表仓储接口的实现
    /// </summary>
    public class SequenceRuleRepository : BaseRepository<SequenceRule>, ISequenceRuleRepository
    {
		public SequenceRuleRepository()
        {
        }

        public SequenceRuleRepository(IDbContextCore dbContext) : base(dbContext)
        {
        }
    }
}