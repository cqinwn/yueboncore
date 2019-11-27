using System;
using Yuebon.Commons.IRepositories;
using Yuebon.Security.Models;

namespace Yuebon.Security.IRepositories
{
    public interface IWorkOrderRepository:IRepository<WorkOrder, string>
    {
    }
}