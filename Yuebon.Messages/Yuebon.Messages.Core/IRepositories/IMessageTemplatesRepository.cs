using System;
using System.Collections.Generic;
using Yuebon.Commons.IRepositories;
using Yuebon.Messages.Dtos;
using Yuebon.Messages.Models;

namespace Yuebon.Messages.IRepositories
{
    /// <summary>
    /// 定义仓储接口
    /// </summary>
    public interface IMessageTemplatesRepository:IRepository<MessageTemplates>
    {

        /// <summary>
        /// 根据用户查询微信小程序订阅消息模板列表，关联用户订阅表
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <returns></returns>
        List<MemberMessageTemplatesOuputDto> ListByUseInWxApplet(string userId);
    }
}