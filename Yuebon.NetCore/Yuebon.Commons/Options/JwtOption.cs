using System;
using System.Collections.Generic;
using System.Text;

namespace Yuebon.Commons.Options
{
    /// <summary>
    /// JsonWebToken配置模型。
    /// </summary>
    public class JwtOption
    {
        /// <summary>
        /// 签发者。
        /// </summary>
        public string Issuer { get; set; }

        /// <summary>
        /// 收发者。
        /// </summary>
        public string Audience { get; set; }

        /// <summary>
        /// 密钥。
        /// </summary>
        public string Secret { get; set; }

        /// <summary>
        /// Token有效期（单位：分钟）。
        /// </summary>
        public int Expiration { get; set; }


        /// <summary>
        /// Token有效刷新时间（单位：分钟）。
        /// </summary>
        public int refreshJwtTime { get; set; }
    }
}
