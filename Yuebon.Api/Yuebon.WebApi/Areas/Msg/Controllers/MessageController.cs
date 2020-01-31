using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Yuebon.AspNetCore.Controllers;
using Yuebon.AspNetCore.Models;
using Yuebon.Commons.Helpers;
using Yuebon.Commons.Mapping;
using Yuebon.Commons.Models;
using Yuebon.Messages.Application;
using Yuebon.Messages.Dtos;
using Yuebon.Messages.IServices;
using Yuebon.Messages.Models;

namespace Yuebon.WebApi.Areas.Msg.Controllers
{
    /// <summary>
    /// 消息接口
    /// </summary>
    [Route("api/Msg/[controller]")]
    public class MessageController : AreaApiController<MessageTemplates, IMessageTemplatesService>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="service">服务</param>
        public MessageController(IMessageTemplatesService service) : base(service)
        {
        }

        /// <summary>
        /// 获取微信小程序订阅消息列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetListByUseInWxApplet")]
        public IActionResult GetListByUseInWxApplet()
        {
            CommonResult result = new CommonResult();
            result = CheckToken();
            if (result.ErrCode == ErrCode.successCode)
            {
                List<MemberMessageTemplatesOuputDto> list = new MessageTemplatesApp().ListByUseInWxApplet(CurrentUser.UserId);
                result.ResData = list;
                result.ErrCode = ErrCode.successCode;
            }
            return ToJsonContent(result);
        }
        /// <summary>
        /// 修改用户订阅消息
        /// </summary>
        /// <returns></returns>
        [HttpPost("UpdateUserSubscribeMsg")]
        public IActionResult UpdateUserSubscribeMsg(MemberSubscribeMsgInputDto info)
        {
            CommonResult result = new CommonResult();
            result = CheckToken();
            if (result.ErrCode == ErrCode.successCode)
            {
                MemberSubscribeMsgApp memberSubscribeMsgApp = new MemberSubscribeMsgApp();
                MemberSubscribeMsg memberSubscribeMsg= memberSubscribeMsgApp.GetByMessageTemplateIdAndUser(info.MessageTemplateId, CurrentUser.UserId,info.SubscribeType);
                if (memberSubscribeMsg == null)
                {
                    memberSubscribeMsg = info.MapTo<MemberSubscribeMsg>();
                    memberSubscribeMsg.Id = GuidUtils.CreateNo();
                    memberSubscribeMsg.SubscribeUserId = CurrentUser.UserId;
                    result.Success = memberSubscribeMsgApp.Insert(memberSubscribeMsg)>0?true:false;
                }
                else
                {
                    memberSubscribeMsg.SubscribeStatus = info.SubscribeStatus;
                   result.Success= memberSubscribeMsgApp.UpdateSubscribeStatus(memberSubscribeMsg);
                }
            }
            return ToJsonContent(result);
        }


        /// <summary>
        /// 留言提醒
        /// </summary>
        /// <param name="userId">接收者（用户）的 userId</param>
        /// <param name="text">留言内容,20个以内字符</param>
        /// <param name="date">留言时间,4小时制时间格式（支持+年月日）	例如：15:01，或：2019年10月1日 15:01</param>
        /// <param name="page">点击模板卡片后的跳转页面，仅限本小程序内的页面。支持带参数,（示例index?foo=bar）。该字段不填则模板无跳转。</param>
        [HttpGet("SendCommentNotice")]
        public IActionResult SendCommentNotice(string userId, string text, string date, string page = "")
        {
            CommonResult result = new CommonResult();
            result = CheckToken();
            if (result.ErrCode == ErrCode.successCode)
            {
                result = Messenger.SendCommentNotice(userId, text, date, page);
            }
            return ToJsonContent(result);
        }
        /// <summary>
        /// 新的评论提醒
        /// </summary>
        /// <param name="userId">接收者（用户）的 userId</param>
        /// <param name="title">文章标题,20个以内字符</param>
        /// <param name="desc">评论内容,20个以内字符</param>
        /// <param name="date">评论时间，4小时制时间格式（支持+年月日）	例如：15:01，或：2019年10月1日 15:01</param>
        /// <param name="remarkUserId">评论者（用户）的 userId</param>
        /// <param name="page"></param>
        [HttpGet("SendRemarkNotice")]
        public IActionResult SendRemarkNotice(string userId, string title, string desc, string date, string remarkUserId, string page)
        {
            CommonResult result = new CommonResult();
            result = CheckToken();
            if (result.ErrCode == ErrCode.successCode)
            {
                result = Messenger.SendRemarkNotice(userId, title, desc, date, remarkUserId, page);
            }
            return ToJsonContent(result);
        }

        /// <summary>
        /// 动态点赞通知
        /// </summary>
        /// <param name="userId">接收者（用户）的 userId</param>
        /// <param name="date">点赞时间,4小时制时间格式（支持+年月日）	例如：15:01，或：2019年10月1日 15:01</param>
        /// <param name="page"></param>
        [HttpGet("SendGoodNotice")]
        public IActionResult SendGoodNotice(string userId, string date, string page)
        {
            CommonResult result = new CommonResult();
            result = CheckToken();
            if (result.ErrCode == ErrCode.successCode)
            {
                result = Messenger.SendGoodNotice(userId, date, page);
            }
            return ToJsonContent(result);
        }
    }
}
