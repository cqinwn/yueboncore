using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Yuebon.Messages.Dtos
{
    /// <summary>
    /// 输出对象模型
    /// </summary>
    [Serializable]
    public class MemberSubscribeMsgOutputDto
    {
        /// <summary>
        /// 设置或获取 
        /// </summary>
        [MaxLength(50)]
        public string Id { get; set; }

        /// <summary>
        /// 设置或获取订阅用户
        /// </summary>
        [MaxLength(50)]
        public string SubscribeUserId { get; set; }

        /// <summary>
        /// 设置或获取订阅类型：SMS短信，WxApplet 微信小程序，InnerMessage站内消息 ，Email邮件通知
        /// </summary>
        [MaxLength(50)]
        public string SubscribeType { get; set; }

        /// <summary>
        /// 设置或获取消息模板Id主键
        /// </summary>
        [MaxLength(200)]
        public string MessageTemplateId { get; set; }

        /// <summary>
        /// 设置或获取 
        /// </summary>
        [MaxLength(200)]
        public string SubscribeTemplateId { get; set; }

        /// <summary>
        /// 设置或获取订阅状态
        /// </summary>
        [MaxLength(50)]
        public string SubscribeStatus { get; set; }


    }
}
