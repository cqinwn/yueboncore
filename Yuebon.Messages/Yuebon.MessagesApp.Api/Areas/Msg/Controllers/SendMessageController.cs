using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Yuebon.AspNetCore.Controllers;
using Yuebon.AspNetCore.Models;
using Yuebon.Commons.Models;
using Yuebon.Messages.Application;

namespace Yuebon.MessagesApp.Api.Areas.Msg.Controllers
{
    /// <summary>
    /// 消息推送接口
    /// </summary>
    [Route("api/Msg/[controller]")]
    [ApiController]
    public class SendMessageController : ApiController
    {
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
                result= Messenger.SendCommentNotice(userId, text, date, page);
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
        /// <param name="userNickName">评论用户,20个以内字符</param>
        /// <param name="page"></param>
        [HttpGet("SendRemarkNotice")]
        public IActionResult SendRemarkNotice(string userId, string title, string desc, string date, string userNickName, string page)
        {
            CommonResult result = new CommonResult();
            result = CheckToken();
            if (result.ErrCode == ErrCode.successCode)
            {
                result = Messenger.SendRemarkNotice(userId, title,desc, date,userNickName, page);
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
        public IActionResult SendGoodNotice(string userId,  string date, string page)
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