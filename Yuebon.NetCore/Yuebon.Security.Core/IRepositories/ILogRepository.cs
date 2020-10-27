using System;
using System.Threading.Tasks;
using Yuebon.Commons.IRepositories;
using Yuebon.Security.Models;

namespace Yuebon.Security.IRepositories
{
    public interface ILogRepository:IRepository<Log, string>
    {
        Task<long> InsertTset(int len);
    }
}