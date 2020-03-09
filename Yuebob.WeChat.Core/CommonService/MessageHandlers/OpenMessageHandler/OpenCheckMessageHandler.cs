using Senparc.NeuChar.Entities;
using Senparc.NeuChar.Helpers;
using Senparc.Weixin.MP.Entities;
using Senparc.Weixin.MP.Entities.Request;
using Senparc.Weixin.MP.MessageHandlers;
using Senparc.Weixin.Open.ComponentAPIs;
using System;
using System.IO;
using Yuebon.WeChat.CommonService.CustomMessageHandler;
using Yuebon.WeChat.CommonService.OpenTicket;

namespace Yuebon.WeChat.CommonService.OpenMessageHandler
{
    /// <summary>
    /// 开放平台全网发布之前需要做的验证
    /// </summary>
    public class OpenCheckMessageHandler : MessageHandler<CustomMessageContext>
    {
        /*
           https://open.weixin.qq.com/cgi-bin/showdocument?action=dir_list&t=resource/res_list&verify=1&id=open1419318611&lang=zh_CN
            自动化测试的专用测试公众号的信息如下：
            （1）appid： wx570bc396a51b8ff8
            （2）Username： gh_3c884a361561
        */

        //private string testAppId = "wx570bc396a51b8ff8";

        private string componentAppId = "ComponentAppId";
        private string componentSecret = "Component_Secret";



        public OpenCheckMessageHandler(Stream inputStream, PostModel postModel, int maxRecordCount = 0)
            : base(inputStream, postModel, maxRecordCount)
        {

        }

        public override IResponseMessageBase OnTextRequest(RequestMessageText requestMessage)
        {
            if (requestMessage.Content == "TESTCOMPONENT_MSG_TYPE_TEXT")
            {
                var responseMessage = requestMessage.CreateResponseMessage<ResponseMessageText>();
                responseMessage.Content = requestMessage.Content + "_callback";//固定为TESTCOMPONENT_MSG_TYPE_TEXT_callback
                return responseMessage;
            }

            if (requestMessage.Content.StartsWith("QUERY_AUTH_CODE:"))
            {
                string openTicket = OpenTicketHelper.GetOpenTicket(componentAppId);
                var query_auth_code = requestMessage.Content.Replace("QUERY_AUTH_CODE:", "");
                try
                {
                    var component_access_token =ComponentApi.GetComponentAccessToken(componentAppId, componentSecret, openTicket).component_access_token;
                    var oauthResult = ComponentApi.QueryAuth(component_access_token, componentAppId, query_auth_code);

                    //调用客服接口
                    var content = query_auth_code + "_from_api";
                    var sendResult = Senparc.Weixin.MP.AdvancedAPIs.CustomApi.SendText(oauthResult.authorization_info.authorizer_access_token,
                          requestMessage.FromUserName, content);
                }
                catch (Exception ex)
                {
                    throw;
                }

            }
            return null;
        }

        public override IResponseMessageBase OnEventRequest(IRequestMessageEventBase requestMessage)
        {
            var responseMessage = requestMessage.CreateResponseMessage<ResponseMessageText>();
            responseMessage.Content = requestMessage.Event + "from_callback";
            return responseMessage;
        }

        public override IResponseMessageBase DefaultResponseMessage(Senparc.NeuChar.Entities.IRequestMessageBase requestMessage)
        {
            var responseMessage = requestMessage.CreateResponseMessage<ResponseMessageText>();
            responseMessage.Content = "默认消息";
            return responseMessage;
        }
    }
}
