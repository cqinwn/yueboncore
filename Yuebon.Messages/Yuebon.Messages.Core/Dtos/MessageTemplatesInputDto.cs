using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Yuebon.Commons.Models;
using Yuebon.Messages.Models;

namespace Yuebon.Messages.Dtos
{
    /// <summary>
    /// 输入对象模型
    /// </summary>
    [AutoMap(typeof(MessageTemplates))]
    [Serializable]
    public class MessageTemplatesInputDto
    {
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 设置或获取 
        /// </summary>
        public string MessageType { get; set; }

        /// <summary>
        /// 设置或获取 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 设置或获取 
        /// </summary>
        public bool SendEmail { get; set; }

        /// <summary>
        /// 设置或获取 
        /// </summary>
        public bool SendSMS { get; set; }

        /// <summary>
        /// 设置或获取 
        /// </summary>
        public bool SendInnerMessage { get; set; }

        /// <summary>
        /// 设置或获取 
        /// </summary>
        public bool SendWeixin { get; set; }

        /// <summary>
        /// 设置或获取 
        /// </summary>
        public string WeixinTemplateId { get; set; }

        /// <summary>
        /// 设置或获取 
        /// </summary>
        public string TagDescription { get; set; }

        /// <summary>
        /// 设置或获取 
        /// </summary>
        public string EmailSubject { get; set; }

        /// <summary>
        /// 设置或获取 
        /// </summary>
        public string EmailBody { get; set; }

        /// <summary>
        /// 设置或获取 
        /// </summary>
        public string InnerMessageSubject { get; set; }

        /// <summary>
        /// 设置或获取 
        /// </summary>
        public string InnerMessageBody { get; set; }

        /// <summary>
        /// 设置或获取 
        /// </summary>
        public string SMSBody { get; set; }

        /// <summary>
        /// 设置或获取微信模板编号，如果为空则表示不支持微信消息提醒
        /// </summary>
        public string WeiXinTemplateNo { get; set; }

        /// <summary>
        /// 设置或获取微信模板中对应的名称
        /// </summary>
        public string WeiXinName { get; set; }

        /// <summary>
        /// 设置或获取是否用于微信小程序
        /// </summary>
        public bool? UseInWxApplet { get; set; }

        /// <summary>
        /// 设置或获取小程序模板ID
        /// </summary>
        public string WxAppletTemplateId { get; set; }

        /// <summary>
        /// 设置或获取小程序模板编号
        /// </summary>
        public string AppletTemplateNo { get; set; }

        /// <summary>
        /// 设置或获取小程序模板名称
        /// </summary>
        public string AppletTemplateName { get; set; }

        /// <summary>
        /// 设置或获取订阅消息模板ID
        /// </summary>
        public string WxAppletSubscribeTemplateId { get; set; }

        /// <summary>
        /// 设置或获取模板编号
        /// </summary>
        public string WxAppletSubscribeTemplateNo { get; set; }

        /// <summary>
        /// 设置或获取标题
        /// </summary>
        public string WxAppletSubscribeTemplateName { get; set; }

        /// <summary>
        /// 设置或获取 
        /// </summary>
        public string SMSTemplateCode { get; set; }

        /// <summary>
        /// 设置或获取 
        /// </summary>
        public string SMSTemplateContent { get; set; }

        /// <summary>
        /// 设置或获取O2O小程序模板ID 
        /// </summary>
        public string WxO2OAppletTemplateId { get; set; }

        /// <summary>
        /// 设置或获取是否在O2O小程序中使用
        /// </summary>
        public bool? UseInO2OApplet { get; set; }


    }
}
