
using Senparc.Weixin.WxOpen.AdvancedAPIs;
using System;
using System.Collections.Generic;
using System.Text;
using Senparc.Weixin;
using Senparc.Weixin.Entities.TemplateMessage;
using Senparc.Weixin.Entities;
using System.Threading.Tasks;
using Senparc.Weixin.WxOpen;
using Senparc.Weixin.CommonAPIs;
using Yuebon.Commons.IoC;
using Senparc.NeuChar;
using Senparc.CO2NET.Extensions;

namespace Yuebon.WeChat.CommonService.SubscribeMessage.WxApplet
{
    /// <summary>
    /// 小程序订阅消息
    /// </summary>
   public class WxAppletSubscribeMessage
    {
        private static SenparcWeixinSetting senparcWeixinSetting = IoCContainer.Resolve<SenparcWeixinSetting>();
        private static readonly string weixinAppId = senparcWeixinSetting.WxOpenAppId;

        /// <summary>
        /// 留言提醒，模板编号：1069
        /// </summary>
        /// <param name="toUser">接收者（用户）的 openid</param>
        /// <param name="templateId">消息模板Id</param>
        /// <param name="text">留言内容,20个以内字符</param>
        /// <param name="date">留言时间,4小时制时间格式（支持+年月日）	例如：15:01，或：2019年10月1日 15:01</param>
        /// <param name="page">点击模板卡片后的跳转页面，仅限本小程序内的页面。支持带参数,（示例index?foo=bar）。该字段不填则模板无跳转。</param>
        public static WxJsonResult SendCommentNotice(string toUser,string templateId,string text,string date,string page)
        {
            var  data = new TemplateMessageData();
            data["thing1"]=new TemplateMessageDataValue(text);
            data["time2"]= new TemplateMessageDataValue(date);
            var submitData = new
            {
                touser = toUser,
                template_id = templateId,
                page = page,
                data = data
            };
            return MessageApi.SendSubscribe(weixinAppId, toUser, templateId, data, page);
        }

        /// <summary>
        /// 新的评论提醒 ，模板编号：484
        /// </summary>
        /// <param name="toUser">接收者（用户）的 openid</param>
        /// <param name="templateId">消息模板Id</param>
        /// <param name="title">文章标题,20个以内字符</param>
        /// <param name="desc">评论内容,20个以内字符</param>
        /// <param name="date">评论时间，4小时制时间格式（支持+年月日）	例如：15:01，或：2019年10月1日 15:01</param>
        /// <param name="userNick">评论用户,20个以内字符</param>
        /// <param name="page"></param>
        public static WxJsonResult SendRemarkNotice(string toUser, string templateId, string title, string desc, string date, string userNick, string page)
        {
            var data = new TemplateMessageData();
            data.Add("thing1", new TemplateMessageDataValue(title));
            data.Add("thing2", new TemplateMessageDataValue(desc));
            data.Add("time3", new TemplateMessageDataValue(date));
            data.Add("thing5", new TemplateMessageDataValue(userNick));
           return MessageApi.SendSubscribe(weixinAppId, toUser, templateId, data, page);
        }

        /// <summary>
        /// 动态点赞通知，模板编号：579
        /// </summary>
        /// <param name="toUser">接收者（用户）的 openid</param>
        /// <param name="templateId">消息模板Id</param>
        /// <param name="name">点赞用户,20个以内字符</param>
        /// <param name="date">点赞时间,4小时制时间格式（支持+年月日）	例如：15:01，或：2019年10月1日 15:01</param>
        /// <param name="page">点击模板卡片后的跳转页面，仅限本小程序内的页面。支持带参数,（示例index?foo=bar）。该字段不填则模板无跳转。</param>
        public static WxJsonResult SendGoodNotice(string toUser, string templateId, string name, string date, string page)
        {
            var data = new TemplateMessageData();
            data.Add("name1", new TemplateMessageDataValue(name));
            data.Add("date2", new TemplateMessageDataValue(date));
            return MessageApi.SendSubscribe(weixinAppId, toUser, templateId, data, page);
        }

        /// <summary>
        /// 资讯早报通知，模板编号：269
        /// </summary>
        /// <param name="toUser">接收者（用户）的 openid</param>
        /// <param name="templateId">消息模板Id</param>
        /// <param name="title">更新内容,20个以内字符</param>
        /// <param name="remark">备注,20个以内字符</param>
        /// <param name="page">点击模板卡片后的跳转页面，仅限本小程序内的页面。支持带参数,（示例index?foo=bar）。该字段不填则模板无跳转。</param>
        public static WxJsonResult SendNewsMorningNotice(string toUser, string templateId, string title, string remark, string page)
        {
            var data = new TemplateMessageData();
            data["thing1"] = new TemplateMessageDataValue(title);
            data["thing2"] = new TemplateMessageDataValue(remark);
            var submitData = new
            {
                touser = toUser,
                template_id = templateId,
                page = page,
                data = data
            };
            return MessageApi.SendSubscribe(weixinAppId, toUser, templateId, data, page);
        }

    }
}
