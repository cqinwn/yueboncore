using Yuebon.Commons.Repositories;
using Yuebon.Messages.IRepositories;
using Yuebon.Messages.Models;

namespace Yuebon.Messages.Repositories
{
    public class MessageMailBoxRepository : BaseRepository<MessageMailBox, string>, IMessageMailBoxRepository
    {
        public MessageMailBoxRepository()
        {
            this.tableName = "Sys_MessageMailBox";
            this.primaryKey = "Id";
        }
    }
}
