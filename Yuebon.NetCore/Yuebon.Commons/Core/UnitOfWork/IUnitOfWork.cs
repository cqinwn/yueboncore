using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yuebon.Commons.Core.UnitOfWork
{
    public interface IUnitOfWork
    {
        SqlSugarScope GetDbClient();

        void BeginTran();

        void CommitTran();
        void RollbackTran();
    }
}
