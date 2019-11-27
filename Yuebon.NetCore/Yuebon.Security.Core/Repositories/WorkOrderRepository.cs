using System;

using Yuebon.Commons.Repositories;
using Yuebon.Security.IRepositories;
using Yuebon.Security.Models;

namespace Yuebon.Security.Repositories
{
    public class WorkOrderRepository : BaseRepository<WorkOrder, string>, IWorkOrderRepository
    {
		public WorkOrderRepository()
        {
            this.tableName = "Sys_WorkOrder";
            this.primaryKey = "Id";
        }
    }
}