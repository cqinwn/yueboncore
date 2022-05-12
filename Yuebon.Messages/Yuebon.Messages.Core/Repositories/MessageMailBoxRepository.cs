using System;
using Yuebon.Commons.Core.UnitOfWork;
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
        public MessageMailBoxRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this.tableName = "Sys_MessageMailBox";
            this.primaryKey = "Id";
        }
    }
}