using Dapper.Contrib.Extensions;
using System;
using Yuebon.Commons.Models;

namespace Yuebon.Messages.Models
{
    /// <summary>
    /// 消息模板定义，数据实体对象
    /// </summary>
    [Table("Sys_MessageTemplates")]
    [Serializable]
    public class MessageTemplates:BaseEntity<string>
    {
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
        public MessageTemplates()
        {
        }
        #region Property Members
        /// <summary>
        /// 消息类型
        /// </summary>
        public virtual string MessageType
        {
            get;set;
        }
        /// <summary>
        /// 消息名称
        /// </summary>
        public virtual string Name
        {
            get; set;
        }
        /// <summary>
        /// 是否发送邮件
        /// </summary>
        public virtual bool SendEmail
        {
            get; set;
        }
        /// <summary>
        /// 是否发送短信
        /// </summary>
        public virtual bool SendSMS
        {

            get; set;
        }
        /// <summary>
        /// 是否发送站内消息
        /// </summary>
        public virtual bool SendInnerMessage
        {

            get; set;
        }
        /// <summary>
        /// 是否发送微信公众号消息
        /// </summary>
        public virtual bool SendWeixin
        {

            get; set;
        }
        /// <summary>
        /// 微信公众号消息模板Id
        /// </summary>
        public virtual string WeixinTemplateId
        {

            get; set;
        }
        /// <summary>
        /// 消息内容
        /// </summary>

        public virtual string TagDescription
        {

            get; set;
        }
        /// <summary>
        /// Email邮件消息主题
        /// </summary>
        public virtual string EmailSubject
        {

            get; set;
        }
        /// <summary>
        /// Email邮件消息内容
        /// </summary>
        public virtual string EmailBody
        {

            get; set;
        }
        /// <summary>
        /// 站内消息主题
        /// </summary>
        public virtual string InnerMessageSubject
        {

            get; set;
        }
        /// <summary>
        /// 站内消息内容
        /// </summary>
        public virtual string InnerMessageBody
        {

            get; set;
        }
        /// <summary>
        /// 短信内容
        /// </summary>
        public virtual string SMSBody
        {

            get; set;
        }

        /// <summary>
        /// 微信模板编号，如果为空则表示不支持微信消息提醒
        /// </summary>
        public virtual string WeiXinTemplateNo
        {

            get; set;
        }

        /// <summary>
        /// 微信模板中对应的名称
        /// </summary>
        public virtual string WeiXinName
        {

            get; set;
        }

        /// <summary>
        /// 是否用于微信小程序
        /// </summary>
        public virtual bool UseInWxApplet
        {

            get; set;
        }

        /// <summary>
        /// 小程序模板ID
        /// </summary>
        public virtual string WxAppletTemplateId
        {

            get; set;
        }

        /// <summary>
        /// 小程序模板编号
        /// </summary>
        public virtual string AppletTemplateNo
        {
            get; set;
        }

        /// <summary>
        /// 小程序模板名称
        /// </summary>
        public virtual string AppletTemplateName
        {
            get; set;
        }

        /// <summary>
        /// 小程序模板消息模板ID
        /// </summary>
        public virtual string WxAppletSubscribeTemplateId
        {
            get; set;
        }
        /// <summary>
        /// 小程序订阅消息模板编号
        /// </summary>
        public virtual string WxAppletSubscribeTemplateNo
        {
            get; set;
        }
        /// <summary>
        /// 小程序订阅消息模板名称
        /// </summary>
        public virtual string WxAppletSubscribeTemplateName
        {
            get; set;
        }
        /// <summary>
        /// 短信模板代码
        /// </summary>
        public virtual string SMSTemplateCode
        {

            get; set;
        }
        /// <summary>
        /// 短信模板内容
        /// </summary>
        public virtual string SMSTemplateContent
        {

            get; set;
        }

        /// <summary>
        /// O2O小程序模板ID 
        /// </summary>
        public virtual string WxO2OAppletTemplateId
        {

            get; set;
        }

        /// <summary>
        /// 是否在O2O小程序中使用
        /// </summary>
        public virtual bool UseInO2OApplet
        {

            get; set;
        }


        #endregion
    }
}
