using Senparc.Weixin.Entities;
using Yuebon.Commons.Core.App;
using Yuebon.Commons.Helpers;
using Yuebon.Commons.Json;
using Yuebon.Commons.Models;
using Yuebon.Messages.IServices;
using Yuebon.Messages.Models;
using Yuebon.Security.Application;
using Yuebon.Security.IServices;
using Yuebon.Security.Models;
using Yuebon.SMS.AliYun;
using Yuebon.WeChat.CommonService.SubscribeMessage.WxApplet;

namespace Yuebon.Messages.Application
{
    public static class Messenger
    {
        static IMessageTemplatesService messageTemplatesService = App.GetService<IMessageTemplatesService>();
        static IMemberMessageBoxService memberMessageBoxService = App.GetService<IMemberMessageBoxService>();
        static IMemberSubscribeMsgService memberSubscribeMsgService = App.GetService<IMemberSubscribeMsgService>();
        static IUserService userService = App.GetService<IUserService>();

        /// <summary>
        /// 留言提醒
        /// </summary>
        /// <param name="userId">接收者（用户）的 userId</param>
        /// <param name="text">留言内容,20个以内字符</param>
        /// <param name="date">留言时间,4小时制时间格式（支持+年月日）	例如：15:01，或：2019年10月1日 15:01</param>
        /// <param name="page">点击模板卡片后的跳转页面，仅限本小程序内的页面。支持带参数,（示例index?foo=bar）。该字段不填则模板无跳转。</param>
        public static CommonResult SendCommentNotice(string userId, string text,string date,string page="")
        {
            CommonResult result = new CommonResult();
            User user = new UserApp().GetUserById(userId);
            if (user != null && !string.IsNullOrEmpty(text))
            {
                MessageTemplates template = messageTemplatesService.GetByMessageType("CommentNotice");
                if (!string.IsNullOrEmpty(template.InnerMessageSubject) && !string.IsNullOrEmpty(template.InnerMessageBody) && template.SendInnerMessage)
                {
                    MemberMessageBox memberMessageBox = new MemberMessageBox();
                    memberMessageBox.Id = GuidUtils.CreateNo();
                    memberMessageBox.IsRead = false;
                    memberMessageBox.Sernder = "系统消息";
                    memberMessageBox.Accepter = userId;
                    memberMessageBox.MsgContent = string.Format(template.InnerMessageBody, text, date);
                    memberMessageBoxService.Insert(memberMessageBox);
                }
                if (!string.IsNullOrEmpty(template.WxAppletSubscribeTemplateId) && template.UseInWxApplet)
                {
                    MemberSubscribeMsg memberSubscribeMsg= memberSubscribeMsgService.GetByMessageTemplateIdAndUser(template.Id,userId, "WxApplet");
                    if(memberSubscribeMsg.SubscribeStatus == "accept") { 
                        UserOpenIds userOpenIds = new UserApp().GetUserOpenIdById(userId, "yuebon.openid.wxapplet");
                        if (userOpenIds != null )
                        {
                            WxJsonResult wxJsonResult = WxAppletSubscribeMessage.SendCommentNotice(userOpenIds.OpenId, template.WxAppletSubscribeTemplateId, text, date, page);
                            result.ErrCode = wxJsonResult.errcode.ToString();
                            result.ErrMsg = wxJsonResult.errmsg;
                        }
                    }
                    else
                    {
                        result.Success = true;
                        result.ErrCode = "用户拒绝订阅";
                    }
                }
                else
                {
                    result.Success = true;
                    result.ErrCode = "用户未订阅";
                }

            }
            return result;
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
        public static CommonResult SendRemarkNotice(string userId, string title, string desc, string date,string remarkUserId, string page)
        {
            CommonResult result = new CommonResult();
            UserApp userApp = new UserApp();
            User user = userApp.GetUserById(userId);
            User remarkUser = userApp.GetUserById(remarkUserId);

            if (user != null && !string.IsNullOrEmpty(title))
            {
                MessageTemplates template = messageTemplatesService.GetByMessageType("RemarkNotice");
                if (!string.IsNullOrEmpty(template.InnerMessageSubject) && !string.IsNullOrEmpty(template.InnerMessageBody) && template.SendInnerMessage)
                {
                    MemberMessageBox memberMessageBox = new MemberMessageBox();
                    memberMessageBox.Id = GuidUtils.CreateNo();
                    memberMessageBox.IsRead = false;
                    memberMessageBox.Sernder = "系统消息";
                    memberMessageBox.Accepter = userId;
                    memberMessageBox.MsgContent = string.Format(template.InnerMessageBody, user.NickName,date, title);
                    memberMessageBoxService.Insert(memberMessageBox);
                }
                if (!string.IsNullOrEmpty(template.WxAppletSubscribeTemplateId) && template.UseInWxApplet )
                {
                    MemberSubscribeMsg memberSubscribeMsg = memberSubscribeMsgService.GetByMessageTemplateIdAndUser(template.Id, userId, "WxApplet");
                    if (memberSubscribeMsg.SubscribeStatus == "accept")
                    {
                        UserOpenIds userOpenIds = new UserApp().GetUserOpenIdById(userId, "yuebon.openid.wxapplet");
                        if (userOpenIds != null)
                        {
                            WxJsonResult wxJsonResult = WxAppletSubscribeMessage.SendRemarkNotice(userOpenIds.OpenId, template.WxAppletSubscribeTemplateId, title, desc, date, remarkUser.NickName, page);
                            result.ErrCode = wxJsonResult.errcode.ToString();
                            result.ErrMsg = wxJsonResult.errmsg;
                        }
                    }
                }
                else
                {
                    result.Success = true;
                    result.ErrCode = "用户拒绝或未订阅";
                }
            }
            return result;
        }

        /// <summary>
        /// 动态点赞通知
        /// </summary>
        /// <param name="userId">接收者（用户）的 userId</param>
        /// <param name="date">点赞时间,4小时制时间格式（支持+年月日）	例如：15:01，或：2019年10月1日 15:01</param>
        /// <param name="page"></param>
        public static CommonResult SendGoodNotice(string userId, string date, string page)
        {
            CommonResult result = new CommonResult();
            User user = new UserApp().GetUserById(userId);
            if (user != null && !string.IsNullOrEmpty(date))
            {
                MessageTemplates template = messageTemplatesService.GetByMessageType("RemarkNotice");

                if (!string.IsNullOrEmpty(template.WxAppletSubscribeTemplateId) && template.UseInWxApplet)
                {
                    MemberSubscribeMsg memberSubscribeMsg = memberSubscribeMsgService.GetByMessageTemplateIdAndUser(template.Id, userId, "WxApplet");
                    if (memberSubscribeMsg.SubscribeStatus == "accept")
                    {
                        UserOpenIds userOpenIds = new UserApp().GetUserOpenIdById(userId, "yuebon.openid.wxapplet");
                        if (userOpenIds != null)
                        {
                            WxJsonResult wxJsonResult = WxAppletSubscribeMessage.SendGoodNotice(userOpenIds.OpenId, template.WxAppletTemplateId, user.NickName, date, page);
                            result.ErrCode = wxJsonResult.errcode.ToString();
                            result.ErrMsg = wxJsonResult.errmsg;
                        }
                    }
                }
                else
                {
                    result.Success = true;
                    result.ErrCode = "用户拒绝或未订阅";
                }
            }
            return result;
        }
        /// <summary>
        /// 资讯早报提醒
        /// </summary>
        /// <param name="userId">接收者（用户）的 userId</param>
        /// <param name="title">更新内容,20个以内字符</param>
        /// <param name="remark">备注,20个以内字符</param>
        /// <param name="page"></param>
        /// <returns></returns>
        public static CommonResult SendNewsMorningNotice(string userId, string title, string remark, string page = "")
        {
            CommonResult result = new CommonResult();
            User user = new UserApp().GetUserById(userId);
            if (user != null && !string.IsNullOrEmpty(title))
            {
                MessageTemplates template = messageTemplatesService.GetByMessageType("NewsMorningNotice");
                if (!string.IsNullOrEmpty(template.InnerMessageSubject) && !string.IsNullOrEmpty(template.InnerMessageBody) && template.SendInnerMessage)
                {
                    MemberMessageBox memberMessageBox = new MemberMessageBox();
                    memberMessageBox.Id = GuidUtils.CreateNo();
                    memberMessageBox.IsRead = false;
                    memberMessageBox.Sernder = "资讯早报";
                    memberMessageBox.Accepter = userId;
                    memberMessageBox.MsgContent = string.Format(template.InnerMessageBody, title, remark);
                    memberMessageBoxService.Insert(memberMessageBox);
                }

                if (!string.IsNullOrEmpty(template.WxAppletSubscribeTemplateId) && template.UseInWxApplet)
                {
                    MemberSubscribeMsg memberSubscribeMsg = memberSubscribeMsgService.GetByMessageTemplateIdAndUser(template.Id, userId, "WxApplet");
                    if (memberSubscribeMsg!=null)
                    {
                        if (memberSubscribeMsg.SubscribeStatus == "accept")
                        {
                            UserOpenIds userOpenIds = new UserApp().GetUserOpenIdById(userId, "yuebon.openid.wxapplet");
                            if (userOpenIds != null)
                            {
                                WxJsonResult wxJsonResult = WxAppletSubscribeMessage.SendNewsMorningNotice(userOpenIds.OpenId, template.WxAppletSubscribeTemplateId, title, remark, page);
                                if (wxJsonResult.errcode.ToString() == "请求成功" || wxJsonResult.errcode.ToString() == "用户拒绝接受消息")
                                {
                                    result.ErrCode = "0";
                                    result.ErrMsg = wxJsonResult.errcode.ToString();
                                }
                                else
                                {
                                    result.ErrCode = "0";
                                    result.ErrMsg = wxJsonResult.errcode.ToString() + wxJsonResult.ToJson();
                                }
                            }
                        }
                        else
                        {
                            result.ErrCode = "0";
                            result.ErrMsg = "用户拒绝";
                        }
                    }
                    else
                    {
                        result.ErrCode = "0";
                        result.ErrMsg = "用户未订阅";
                    }
                }
                else
                {
                    result.ErrCode = "0";
                    result.ErrMsg = "用户拒绝";
                }

            }
            return result;
        }


        /// <summary>
        /// 阅读浏览提醒
        /// </summary>
        /// <param name="userId">接收者（用户）的 userId</param>
        /// <param name="phone">接收者（用户）的电话号码</param>
        /// <param name="title">更新内容,20个以内字符</param>
        /// <param name="remark">备注,20个以内字符</param>
        /// <param name="smsMessage">短信消息,可选:模板中的变量替换JSON串,如模板内容为"亲爱的${name},您的验证码为${code}"时,此处的值为 "{\"name\":\"Tom\"， \"code\":\"123\"}"</param>
        /// <param name="page"></param>
        /// <returns></returns>
        public static CommonResult SendReadNotice(string userId, string phone, string title, string remark,string smsMessage, string page = "")
        {
            CommonResult result = new CommonResult();
            User user = new UserApp().GetUserById(userId);
            if (user != null && !string.IsNullOrEmpty(title))
            {
                MessageTemplates template = messageTemplatesService.GetByMessageType("ReadNotice");

                if (!string.IsNullOrEmpty(template.InnerMessageSubject) && !string.IsNullOrEmpty(template.InnerMessageBody) && template.SendInnerMessage)
                {
                    MemberMessageBox memberMessageBox = new MemberMessageBox();
                    memberMessageBox.Id = GuidUtils.CreateNo();
                    memberMessageBox.IsRead = false;
                    memberMessageBox.Sernder = "浏览阅读";
                    memberMessageBox.Accepter = userId;
                    memberMessageBox.MsgContent = string.Format(template.InnerMessageBody, title, remark);
                    memberMessageBoxService.Insert(memberMessageBox);
                }

                #region 发送小程序模板消息
                if (!string.IsNullOrEmpty(template.WxAppletSubscribeTemplateId) && template.UseInWxApplet)
                {
                    MemberSubscribeMsg memberSubscribeMsg = memberSubscribeMsgService.GetByMessageTemplateIdAndUser(template.Id, userId, "WxApplet");
                    if (memberSubscribeMsg != null)
                    {
                        if (memberSubscribeMsg.SubscribeStatus == "accept")
                        {
                            UserOpenIds userOpenIds = new UserApp().GetUserOpenIdById(userId, "yuebon.openid.wxapplet");
                            if (userOpenIds != null)
                            {
                                WxJsonResult wxJsonResult = WxAppletSubscribeMessage.SendNewsMorningNotice(userOpenIds.OpenId, template.WxAppletSubscribeTemplateId, title, remark, page);
                                if (wxJsonResult.errcode.ToString() == "请求成功" || wxJsonResult.errcode.ToString() == "用户拒绝接受消息")
                                {
                                    result.ErrCode = "0";
                                    result.ErrMsg = wxJsonResult.errcode.ToString();
                                }
                                else
                                {
                                    result.ErrCode = "0";
                                    result.ErrMsg = wxJsonResult.errcode.ToString() + wxJsonResult.ToJson();
                                }
                            }
                        }
                        else
                        {
                            result.ErrCode = "0";
                            result.ErrMsg = "用户拒绝";
                        }
                    }
                    else
                    {
                        result.ErrCode = "0";
                        result.ErrMsg = "用户未订阅";
                    }
                }
                else
                {
                    result.ErrCode = "0";
                    result.ErrMsg = "用户拒绝";
                }
                #endregion

                #region 发送SMS短信
                if (!string.IsNullOrEmpty(template.SMSTemplateCode) && template.SendSMS)
                {
                    AliYunSMS aliYunSMS = new AliYunSMS();
                    string outmsg = string.Empty;
                    bool sendRs = aliYunSMS.Send(phone, template.SMSTemplateCode, smsMessage, out outmsg);
                    if (sendRs)
                    {
                        result.ErrCode = "0";
                        result.Success = true;
                        result.ErrMsg = "短信发送成功";
                    }
                }
                #endregion
            }
            return result;
        }

        /// <summary>
        /// 拨打电话通知
        /// </summary>
        /// <param name="userId">接收者（用户）的 userId</param>
        /// <param name="phone">接收者（用户）的电话号码</param>
        /// <param name="message">可选:模板中的变量替换JSON串,如模板内容为"亲爱的${name},您的验证码为${code}"时,此处的值为 "{\"name\":\"Tom\"， \"code\":\"123\"}"</param>
        /// <param name="page"></param>
        public static CommonResult SendMakePhoneCallNotice(string userId, string phone, string message, string page)
        {
            CommonResult result = new CommonResult();
            User user = new UserApp().GetUserById(userId);
            if (user != null && !string.IsNullOrEmpty(phone))
            {
                MessageTemplates template = messageTemplatesService.GetByMessageType("MakePhoneCallNotice");
                if (template != null)
                {
                    #region 发送微信小程序模板消息
                    if (!string.IsNullOrEmpty(template.WxAppletSubscribeTemplateId) && template.UseInWxApplet)
                    {
                        MemberSubscribeMsg memberSubscribeMsg = memberSubscribeMsgService.GetByMessageTemplateIdAndUser(template.Id, userId, "WxApplet");
                        if (memberSubscribeMsg.SubscribeStatus == "accept")
                        {
                            UserOpenIds userOpenIds = new UserApp().GetUserOpenIdById(userId, "yuebon.openid.wxapplet");
                            if (userOpenIds != null)
                            {
                                WxJsonResult wxJsonResult = WxAppletSubscribeMessage.SendGoodNotice(userOpenIds.OpenId, template.WxAppletTemplateId, user.NickName, phone, page);
                                result.ErrCode = wxJsonResult.errcode.ToString();
                                result.ErrMsg = wxJsonResult.errmsg;
                            }
                        }
                    }
                    else
                    {
                        result.ErrCode = "0";
                        result.Success = true;
                        result.ErrCode = "用户拒绝或未订阅";
                    }
                    #endregion

                    #region 发送SMS短信
                    if (!string.IsNullOrEmpty(template.SMSTemplateCode) && template.SendSMS)
                    {
                        AliYunSMS aliYunSMS = new AliYunSMS();
                        string outmsg = string.Empty;
                        bool sendRs = aliYunSMS.Send(phone, template.SMSTemplateCode, message, out outmsg);
                        if (sendRs)
                        {
                            result.ErrCode = "0";
                            result.Success = true;
                            result.ErrMsg = "短信发送成功";
                        }
                    }
                    #endregion
                }
            }
            return result;
        }
    }
}
