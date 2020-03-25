using System;
using Yuebon.Commons.IRepositories;
using Yuebon.Messages.Models;

namespace Yuebon.Messages.IRepositories
{
    /// <summary>
    /// 定义仓储接口
    /// </summary>
    public interface IMessageMailBoxRepository:IRepository<MessageMailBox, string>
    {
    }
}