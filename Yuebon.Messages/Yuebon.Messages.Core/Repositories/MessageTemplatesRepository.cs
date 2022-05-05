using System.Collections.Generic;
using Yuebon.Commons.Core.UnitOfWork;
using Yuebon.Commons.Linq;
using Yuebon.Commons.Repositories;
using Yuebon.Messages.Dtos;
using Yuebon.Messages.IRepositories;
using Yuebon.Messages.Models;

namespace Yuebon.Messages.Repositories
{
    /// <summary>
    /// 仓储接口的实现
    /// </summary>
    public class MessageTemplatesRepository : BaseRepository<MessageTemplates>, IMessageTemplatesRepository
    {
        public MessageTemplatesRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this.tableName = "Sys_MessageTemplates";
            this.primaryKey = "Id";
        }

        /// <summary>
        /// 根据用户查询微信小程序订阅消息模板列表，关联用户订阅表
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <returns></returns>
        public List<MemberMessageTemplatesOuputDto> ListByUseInWxApplet(string userId)
        {
            string sqlStr = @"select a.*,b.Id as MemberSubscribeMsgId,b.SubscribeStatus as SubscribeStatus  from Sys_MessageTemplates as a 
LEFT join Sys_MemberSubscribeMsg as b on a.Id = b.MessageTemplateId and a.UseInWxApplet =1 and b.SubscribeUserId='" + userId + "'  where  a.WxAppletSubscribeTemplateId is not null";

            return Db.Ado.SqlQuery<MemberMessageTemplatesOuputDto>(sqlStr).AsToList();
        }
    }
}