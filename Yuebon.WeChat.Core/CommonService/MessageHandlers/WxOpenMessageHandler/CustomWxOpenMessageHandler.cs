using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Senparc.Weixin.WxOpen;
using Senparc.Weixin.WxOpen.MessageHandlers;
using Senparc.Weixin.WxOpen.Entities;
using Senparc.Weixin.WxOpen.Entities.Request;
using Yuebon.WeChat.CommonService.Utilities;
using Senparc.NeuChar.MessageHandlers;
using Senparc.NeuChar.Entities;
using Senparc.CO2NET.Utilities;
using Senparc.Weixin;
using Senparc.Weixin.MP.AdvancedAPIs;
using Senparc.Weixin.MP;
using System.Threading;
using System;

namespace Yuebon.WeChat.MessageHandlers.WxOpenMessageHandler
{

    /// <summary>
    /// 自定义MessageHandler
    /// 把MessageHandler作为基类，重写对应请求的处理方法
    /// </summary>
    public partial class CustomWxOpenMessageHandler : WxOpenMessageHandler<CustomWxOpenMessageContext>
    {
        private string appId = Config.SenparcWeixinSetting.WxOpenAppId;
        private string appSecret = Config.SenparcWeixinSetting.WxOpenAppSecret;

        /// <summary>
        /// 为中间件提供生成当前类的委托
        /// </summary>
        public static Func<Stream, PostModel, int, CustomWxOpenMessageHandler> GenerateMessageHandler = (stream, postModel, maxRecordCount) => new CustomWxOpenMessageHandler(stream, postModel, maxRecordCount);


        public CustomWxOpenMessageHandler(Stream inputStream, PostModel postModel, int maxRecordCount = 0)
            : base(inputStream, postModel, maxRecordCount)
        {
            //这里设置仅用于测试，实际开发可以在外部更全局的地方设置，
            //比如MessageHandler<MessageContext>.GlobalGlobalMessageContext.ExpireMinutes = 3。
            GlobalMessageContext.ExpireMinutes = 3;

            if (!string.IsNullOrEmpty(postModel.AppId))
            {
                appId = postModel.AppId;//通过第三方开放平台发送过来的请求
            }

            //在指定条件下，不使用消息去重
            base.OmitRepeatedMessageFunc = requestMessage =>
            {
                var textRequestMessage = requestMessage as RequestMessageText;
                if (textRequestMessage != null && textRequestMessage.Content == "容错")
                {
                    return false;
                }
                return true;
            };
        }


        public override async Task OnExecutingAsync(CancellationToken cancellationToken)
        {
            //测试MessageContext.StorageData
            var currentMessageContext = await base.GetCurrentMessageContext();
            if (currentMessageContext.StorageData == null || (currentMessageContext.StorageData is int))
            {
                currentMessageContext.StorageData = 0;
            }
            await base.OnExecutingAsync(cancellationToken);
        }

        public override async Task OnExecutedAsync(CancellationToken cancellationToken)
        {
            await base.OnExecutedAsync(cancellationToken);
            var currentMessageContext = await base.GetCurrentMessageContext();
            currentMessageContext.StorageData = ((int)currentMessageContext.StorageData) + 1;
        }



        public override IResponseMessageBase DefaultResponseMessage(IRequestMessageBase requestMessage)
        {
            //所有没有被处理的消息会默认返回这里的结果

            return new SuccessResponseMessage();

            //return new SuccessResponseMessage();等效于：
            //base.TextResponseMessage = "success";
            //return null;
        }
    }
}