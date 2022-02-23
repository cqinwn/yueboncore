using System;
using Yuebon.Commons.IServices;
using Yuebon.Messages.Dtos;
using Yuebon.Messages.Models;

namespace Yuebon.Messages.IServices
{
    /// <summary>
    /// 定义服务接口
    /// </summary>
    public interface IMessageMailBoxService:IService<MessageMailBox,MessageMailBoxOutputDto>
    {
    }
}
