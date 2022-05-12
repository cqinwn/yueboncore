
using Senparc.Weixin.Entities;
using Senparc.Weixin.Entities.TemplateMessage;
using Senparc.Weixin.WxOpen.AdvancedAPIs;
using Yuebon.Commons.Core.App;

namespace Yuebon.WeChat.CommonService.SubscribeMessage.WxApplet
{
    /// <summary>
    /// 小程序订阅消息
    /// </summary>
    public class WxAppletSubscribeMessage
    {
        private static SenparcWeixinSetting senparcWeixinSetting = Appsettings.GetService<SenparcWeixinSetting>();
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

        /// <summary>
        /// 校验一张图片是否含有违法违规内容
        /// <para>https://developers.weixin.qq.com/miniprogram/dev/api/imgSecCheck.html</para>
        /// </summary>
        /// <param name="accessTokenOrAppId">AccessToken或AppId（推荐使用AppId，需要先注册）</param>
        /// <param name="filePath">文件完整物理路径<para>格式支持PNG、JPEG、JPG、GIF，图片尺寸不超过 750px * 1334px</para></param>
        /// <param name="timeOut"></param>
        /// <returns></returns>
        //[ApiBind(Senparc.NeuChar.PlatformType.WeChat_MiniProgram, "WxAppApi.ImgSecCheck", true)]
        //public async static Task<WxJsonResult> ImgSecCheck(string accessTokenOrAppId, string filePath, int timeOut = Config.TIME_OUT)
        //{
        //    return WxOpenApiHandlerWapper.TryCommonApi(async accessToken =>
        //    {
        //        string urlFormat = Config.ApiMpHost + "/wxa/img_sec_check?access_token={0}";
        //        var url = urlFormat.FormatWith(accessToken);
        //        var fileDic = new Dictionary<string, string>();
        //        fileDic["media"] = filePath;
        //        return await Senparc.CO2NET.HttpUtility.Post.PostFileGetJsonAsync<WxJsonResult>(url,fileDictionary: fileDic);

        //    }, accessTokenOrAppId);
        //}
       
    }
}
