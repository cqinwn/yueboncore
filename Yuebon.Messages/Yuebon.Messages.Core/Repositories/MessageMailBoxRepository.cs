using System;

using Yuebon.Commons.Repositories;
using Yuebon.Messages.IRepositories;
using Yuebon.Messages.Models;

namespace Yuebon.Messages.Repositories
{
    /// <summary>
    /// 仓储接口的实现
    /// </summary>
    public class MessageMailBoxRepository : BaseRepository<MessageMailBox>, IMessageMailBoxRepository
    {
		public MessageMailBoxRepository()
        {
            this.tableName = "Sys_MessageMailBox";
            this.primaryKey = "Id";
        }
    }
}