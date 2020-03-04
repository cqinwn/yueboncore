using System;
using System.Collections.Generic;
using System.Text;
using Yuebon.Commons.IoC;
using Yuebon.Messages.Dtos;
using Yuebon.Messages.IServices;
using Yuebon.Messages.Models;

namespace Yuebon.Messages.Application
{
    public class MemberSubscribeMsgApp
    {
        IMemberSubscribeMsgService memberSubscribeMsgService = IoCContainer.Resolve<IMemberSubscribeMsgService>();

        /// <summary>
        /// 根据消息模板Id（主键）查询用户订阅消息
        /// </summary>
        /// <param name="messageTemplateId">消息模板主键</param>
        /// <param name="userId">用户</param>
        /// <param name="subscribeType">消息类型</param>
        /// <returns></returns>
        public MemberSubscribeMsg GetByMessageTemplateIdAndUser(string messageTemplateId, string userId, string subscribeType)
        {
            string sqlWhere = "MessageTemplateId='" + messageTemplateId + "' and SubscribeUserId='" + userId + "' and SubscribeType='" + subscribeType + "'";
            return memberSubscribeMsgService.GetWhere(sqlWhere);
        }
        /// <summary>
        /// 更新用户订阅消息
        /// </summary>
        /// <param name="messageTemplateId">消息模板主键</param>
        /// <param name="userId">用户</param>
        /// <param name="subscribeType">消息类型</param>
        /// <param name="subscribeStatus">订阅状态</param>
        /// <returns></returns>
        public bool UpdateByMessageTemplateIdAndUser(string messageTemplateId,string userId,string subscribeType,string subscribeStatus)
        {
            string sqlWhere = "MessageTemplateId='" + messageTemplateId + "' and SubscribeUserId='" + userId + "' and SubscribeType='" + subscribeType + "'";
            return memberSubscribeMsgService.UpdateTableField("SubscribeStatus", subscribeStatus, sqlWhere);
        }

        public long Insert(MemberSubscribeMsg info)
        {
            return memberSubscribeMsgService.Insert(info);
        }
        /// <summary>
        /// 更新订阅状态
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public bool UpdateSubscribeStatus(MemberSubscribeMsg info)
        {
            string sqlWhere = "MessageTemplateId='" + info.MessageTemplateId + "' and SubscribeUserId='" +info.SubscribeUserId + "' and SubscribeType='" + info.SubscribeType + "'";
            return memberSubscribeMsgService.UpdateTableField("SubscribeStatus",info.SubscribeStatus, sqlWhere);
        }
    }
}
