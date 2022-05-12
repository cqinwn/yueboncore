using Yuebon.Commons.Core.UnitOfWork;
using Yuebon.Commons.Repositories;
using Yuebon.Messages.Dtos;
using Yuebon.Messages.IRepositories;
using Yuebon.Messages.Models;

namespace Yuebon.Messages.Repositories
{
    /// <summary>
    /// 仓储接口的实现
    /// </summary>
    public class MemberSubscribeMsgRepository : BaseRepository<MemberSubscribeMsg>, IMemberSubscribeMsgRepository
    {


        public MemberSubscribeMsgRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this.tableName = "Sys_MemberSubscribeMsg";
            this.primaryKey = "Id";
        }


        /// <summary>
        /// 根据消息类型查询消息模板
        /// </summary>
        /// <param name="messageType">消息类型</param>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public MemberMessageTemplatesOuputDto GetByMessageTypeWithUser(string messageType, long userId)
        {
            string sqlStr = @"select a.*,b.Id as MemberSubscribeMsgId,b.SubscribeStatus as SubscribeStatus,b.SubscribeType as SubscribeType  from Sys_MessageTemplates as a 
LEFT join Sys_MemberSubscribeMsg as b on a.Id = b.MessageTemplateId where a.UseInWxApplet =1 and a.WxAppletSubscribeTemplateId is not null and a.messageType = '" + messageType + "' and b.SubscribeUserId=" + userId ;
            return Db.Ado.SqlQuerySingle<MemberMessageTemplatesOuputDto>(sqlStr);
        }
        /// <summary>
        /// 按用户、订阅类型和消息模板主键查询
        /// </summary>
        /// <param name="subscribeType">消息类型</param>
        /// <param name="userId">用户</param>
        /// <param name="messageTemplateId">模板Id主键</param>
        /// <returns></returns>
        public MemberMessageTemplatesOuputDto GetByWithUser(string subscribeType, long userId, long messageTemplateId)
        {
            string sqlStr = @"select * from [dbo].[Sys_MemberSubscribeMsg]   where SubscribeUserId = '" + userId + "' and SubscribeType='" + subscribeType + "' and MessageTemplateId=" + messageTemplateId;
            return Db.Ado.SqlQuerySingle<MemberMessageTemplatesOuputDto>(sqlStr);
        }
    }
}