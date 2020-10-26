using System;
using Yuebon.Commons.Dtos;
using Yuebon.Commons.Models;

namespace Yuebon.Messages.Dtos
{
    /// <summary>
    /// 用户订阅消息模板定义
    /// </summary>
    [Serializable]
    public class MemberMessageTemplatesOuputDto : IOutputDto
    {
        #region Property Members

        /// <summary>
        /// 
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 消息类型
        /// </summary>
        public  string MessageType
        {
            get; set;
        }
        /// <summary>
        /// 消息名称
        /// </summary>
        public  string Name
        {
            get; set;
        }
        /// <summary>
        /// 是否发送邮件
        /// </summary>
        public  bool SendEmail
        {
            get; set;
        }
        /// <summary>
        /// 是否发送短信
        /// </summary>
        public  bool SendSMS
        {

            get; set;
        }
        /// <summary>
        /// 是否发送站内消息
        /// </summary>
        public  bool SendInnerMessage
        {

            get; set;
        }
        /// <summary>
        /// 是否发送微信公众号消息
        /// </summary>
        public  bool SendWeixin
        {

            get; set;
        }
        /// <summary>
        /// 微信公众号消息模板Id
        /// </summary>
        public  string WeixinTemplateId
        {

            get; set;
        }
        /// <summary>
        /// 消息内容
        /// </summary>

        public  string TagDescription
        {

            get; set;
        }
        /// <summary>
        /// Email邮件消息主题
        /// </summary>
        public  string EmailSubject
        {

            get; set;
        }
        /// <summary>
        /// Email邮件消息内容
        /// </summary>
        public  string EmailBody
        {

            get; set;
        }
        /// <summary>
        /// 站内消息主题
        /// </summary>
        public  string InnerMessageSubject
        {

            get; set;
        }
        /// <summary>
        /// 站内消息内容
        /// </summary>
        public  string InnerMessageBody
        {

            get; set;
        }
        /// <summary>
        /// 短信内容
        /// </summary>
        public  string SMSBody
        {

            get; set;
        }

        /// <summary>
        /// 微信模板编号，如果为空则表示不支持微信消息提醒
        /// </summary>
        public  string WeiXinTemplateNo
        {

            get; set;
        }

        /// <summary>
        /// 微信模板中对应的名称
        /// </summary>
        public  string WeiXinName
        {

            get; set;
        }

        /// <summary>
        /// 是否用于微信小程序
        /// </summary>
        public  bool UseInWxApplet
        {

            get; set;
        }

        /// <summary>
        /// 小程序模板ID
        /// </summary>
        public  string WxAppletTemplateId
        {

            get; set;
        }

        /// <summary>
        /// 小程序模板编号
        /// </summary>
        public  string AppletTemplateNo
        {

            get; set;
        }

        /// <summary>
        /// 小程序模板名称
        /// </summary>
        public  string AppletTemplateName
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
        public  string SMSTemplateCode
        {

            get; set;
        }
        /// <summary>
        /// 短信模板内容
        /// </summary>
        public  string SMSTemplateContent
        {

            get; set;
        }

        /// <summary>
        /// O2O小程序模板ID 
        /// </summary>
        public  string WxO2OAppletTemplateId
        {

            get; set;
        }

        /// <summary>
        /// 是否在O2O小程序中使用
        /// </summary>
        public  bool UseInO2OApplet
        {

            get; set;
        }

        /// <summary>
        /// 消息订阅者订阅消息ID 
        /// </summary>
        public string MemberSubscribeMsgId
        {

            get; set;
        }
        /// <summary>
        /// 消息订阅者订阅消息状态
        /// </summary>
        public string SubscribeStatus
        {

            get; set;
        }
        /// <summary>
        /// 消息订阅者订阅类型：SMS短信，WxApplet 微信小程序，InnerMessage站内消息 ，Email邮件通知
        /// </summary>
        public string SubscribeType
        {

            get; set;
        }
        
        #endregion
    }
}
