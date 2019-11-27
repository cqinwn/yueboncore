using System;
using System.Collections.Generic;
using System.Text;

namespace Yuebon.Commons.Options
{
    /// <summary>
    /// 微信配置模型。
    /// </summary>
    public class WeixinOption
    {
        /// <summary>
        /// 小程序AppID
        /// </summary>
        public string WxAppId { get; set; }

        /// <summary>
        /// 小程序AppSecret。
        /// </summary>
        public string WxAppSecret { get; set; }

        /// <summary>
        /// 微信小程序后台的EncodingAESKey。
        /// </summary>
        public string WxEncodingAESKey { get; set; }

    }
}
