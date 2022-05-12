using System;
using Yuebon.Commons.IRepositories;
using Yuebon.Security.Models;

namespace Yuebon.Security.IRepositories
{
    /// <summary>
    /// 定义序号编码规则表仓储接口
    /// </summary>
    public interface ISequenceRuleRepository:IRepository<SequenceRule>
    {
    }
}