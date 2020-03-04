using Senparc.Weixin.Entities;
using Senparc.Weixin.MP.AdvancedAPIs.TemplateMessage;
using Senparc.Weixin.WxOpen.AdvancedAPIs.Template;
using System;
using System.Collections.Generic;
using System.Text;

namespace Yuebon.WeChat.CommonService.TemplateMessage
{
    public class WxAppletTemplateMessage
    {
        private static readonly string weixinAppId = "wx3821f908eabc524d";
        /// <summary>
        /// 留言提醒，模板编号：1069
        /// </summary>
        /// <param name="toUser">接收者（用户）的 openid</param>
        /// <param name="templateId">消息模板Id</param>
        /// <param name="text">留言内容,20个以内字符</param>
        /// <param name="date">留言时间,4小时制时间格式（支持+年月日）	例如：15:01，或：2019年10月1日 15:01</param>
        /// <param name="page">点击模板卡片后的跳转页面，仅限本小程序内的页面。支持带参数,（示例index?foo=bar）。该字段不填则模板无跳转。</param>
        public static WxJsonResult SendCommentNotice(string toUser, string templateId, string text, string date, string page)
        {
            var templateMessageService = new TemplateMessageService();
            //var sess = templateMessageService.RunTemplateTest();
            TemplateDataItem keyword1 = new TemplateDataItem(text);
            TemplateDataItem keyword2 = new TemplateDataItem(date);
            var data = new List<TemplateDataItem> {
                keyword1, keyword2
                };
            string formId = "2222";
            toUser = "o4Uv25WxCveS6QYtBK0xhYeWiZK0";
            templateId = "3J81cBpTaZVKvy_5dW9307iW7Wzfzc5Lrzi7RuhJMUU";
            return TemplateApi.SendTemplateMessage(weixinAppId, toUser, templateId, data,formId, page);
        }
    }
}
