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
    public class MessageTemplatesOutputDto
    {
        /// <summary>
        /// 设置或获取 
        /// </summary>
        [MaxLength(50)]
        public string Id { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        [MaxLength(100)]
        public string MessageType { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        [MaxLength(100)]
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
        [MaxLength(150)]
        public string WeixinTemplateId { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        [MaxLength(-1)]
        public string TagDescription { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        [MaxLength(-1)]
        public string EmailSubject { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        [MaxLength(1073741823)]
        public string EmailBody { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        [MaxLength(-1)]
        public string InnerMessageSubject { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        [MaxLength(1073741823)]
        public string InnerMessageBody { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        [MaxLength(-1)]
        public string SMSBody { get; set; }
        /// <summary>
        /// 设置或获取微信模板编号，如果为空则表示不支持微信消息提醒
        /// </summary>
        [MaxLength(50)]
        public string WeiXinTemplateNo { get; set; }
        /// <summary>
        /// 设置或获取微信模板中对应的名称
        /// </summary>
        [MaxLength(100)]
        public string WeiXinName { get; set; }
        /// <summary>
        /// 设置或获取是否用于微信小程序
        /// </summary>
        public bool? UseInWxApplet { get; set; }
        /// <summary>
        /// 设置或获取小程序模板ID
        /// </summary>
        [MaxLength(50)]
        public string WxAppletTemplateId { get; set; }
        /// <summary>
        /// 设置或获取小程序模板编号
        /// </summary>
        [MaxLength(50)]
        public string AppletTemplateNo { get; set; }
        /// <summary>
        /// 设置或获取小程序模板名称
        /// </summary>
        [MaxLength(100)]
        public string AppletTemplateName { get; set; }
        /// <summary>
        /// 设置或获取订阅消息模板ID
        /// </summary>
        [MaxLength(50)]
        public string WxAppletSubscribeTemplateId { get; set; }
        /// <summary>
        /// 设置或获取模板编号
        /// </summary>
        [MaxLength(50)]
        public string WxAppletSubscribeTemplateNo { get; set; }
        /// <summary>
        /// 设置或获取标题
        /// </summary>
        [MaxLength(50)]
        public string WxAppletSubscribeTemplateName { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        [MaxLength(-1)]
        public string SMSTemplateCode { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        [MaxLength(-1)]
        public string SMSTemplateContent { get; set; }
        /// <summary>
        /// 设置或获取O2O小程序模板ID 
        /// </summary>
        [MaxLength(50)]
        public string WxO2OAppletTemplateId { get; set; }
        /// <summary>
        /// 设置或获取是否在O2O小程序中使用
        /// </summary>
        public bool? UseInO2OApplet { get; set; }

    }
}
