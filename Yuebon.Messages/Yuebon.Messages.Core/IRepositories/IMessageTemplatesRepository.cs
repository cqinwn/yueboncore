using System.Collections.Generic;
using Yuebon.Commons.IRepositories;
using Yuebon.Messages.Dtos;
using Yuebon.Messages.Models;

namespace Yuebon.Messages.IRepositories
{
    public interface IMessageTemplatesRepository : IRepository<MessageTemplates, string>
    {


        /// <summary>
        /// 根据用户查询微信小程序订阅消息模板列表，关联用户订阅表
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <returns></returns>
        List<MemberMessageTemplatesOuputDto> ListByUseInWxApplet(string userId);
    }
}
