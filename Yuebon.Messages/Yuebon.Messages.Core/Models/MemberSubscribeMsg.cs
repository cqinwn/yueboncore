using SqlSugar;
using System;
using Yuebon.Commons.Models;

namespace Yuebon.Messages.Models
{
    /// <summary>
    /// 用户订阅消息表，数据实体对象
    /// </summary>
    [SugarTable("Sys_MemberSubscribeMsg", "用户订阅消息表")]
    [Serializable]
    public class MemberSubscribeMsg:BaseEntity
    {

        /// <summary>
        /// 设置或获取订阅用户
        /// </summary>
        public string SubscribeUserId { get; set; }

        /// <summary>
        /// 设置或获取订阅类型：SMS短信，WxApplet 微信小程序，InnerMessage站内消息 ，Email邮件通知
        /// </summary>
        public string SubscribeType { get; set; }

        /// <summary>
        /// 设置或获取消息模板Id主键
        /// </summary>
        public string MessageTemplateId { get; set; }

        /// <summary>
        /// 设置或获取 订阅模板id
        /// </summary>
        public string SubscribeTemplateId { get; set; }

        /// <summary>
        /// 设置或获取订阅状态
        /// </summary>
        public string SubscribeStatus { get; set; }


    }
}
