using System;
using System.Collections.Generic;
using System.Text;
using Yuebon.Commons.Models;

namespace Yuebon.Messages.Dtos
{
    public class MemberSubscribeMsgInputDto : IInputDto<string>
    {
        public string Id { get; set; }

        /// <summary>
        /// 订阅类型：SMS短信，WxApplet 微信小程序，InnerMessage站内消息 ，Email邮件通知
        /// </summary>
        public virtual string SubscribeType
        {
            get;
            set;
        }
        /// <summary>
        /// 消息模板Id主键
        /// </summary>
        public virtual string MessageTemplateId
        {
            get;
            set;
        }
        /// <summary>
        /// 订阅消息的模板ID
        /// </summary>
        public virtual string SubscribeTemplateId
        {
            get;
            set;
        }
        /// <summary>
        /// 订阅状态
        /// </summary>
        public virtual string SubscribeStatus
        {
            get;
            set;
        }
    }
}
