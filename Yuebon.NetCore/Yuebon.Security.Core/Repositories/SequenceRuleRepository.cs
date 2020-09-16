using System;

using Yuebon.Commons.Repositories;
using Yuebon.Security.IRepositories;
using Yuebon.Security.Models;

namespace Yuebon.Security.Repositories
{
    /// <summary>
    /// 序号编码规则表仓储接口的实现
    /// </summary>
    public class SequenceRuleRepository : BaseRepository<SequenceRule, string>, ISequenceRuleRepository
    {
		public SequenceRuleRepository()
        {
            this.tableName = "Sys_SequenceRule";
            this.primaryKey = "Id";
        }
    }
}