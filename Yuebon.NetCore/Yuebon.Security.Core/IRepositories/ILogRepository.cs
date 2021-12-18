using System;
using System.Threading.Tasks;
using Yuebon.Commons.IRepositories;
using Yuebon.Security.Models;

namespace Yuebon.Security.IRepositories
{
    public interface ILogRepository:IRepository<Log, Int64>
    {
        long InsertTset(int len);
    }
}