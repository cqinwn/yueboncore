using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yuebon.Commons.Options
{
    /// <summary>
    /// 缓存中可用的应用
    /// </summary>
    [Serializable]
    public class AllowCacheApp
    {
        /// <summary>
        /// 设置或获取 ID
        /// </summary>
        [MaxLength(50)]
        public long Id { get; set; }

        /// <summary>
        /// 设置或获取 应用Id
        /// </summary>
        [MaxLength(50)]
        public string AppId { get; set; }

        /// <summary>
        /// 设置或获取 应用密钥
        /// </summary>
        [MaxLength(50)]
        public string AppSecret { get; set; }

        /// <summary>
        /// 设置或获取 消息加密密钥
        /// </summary>
        [MaxLength(256)]
        public string EncodingAESKey { get; set; }

        /// <summary>
        /// 设置或获取 请求url
        /// </summary>
        [MaxLength(256)]
        public string RequestUrl { get; set; }

        /// <summary>
        /// 设置或获取 token
        /// </summary>
        [MaxLength(256)]
        public string Token { get; set; }

        /// <summary>
        /// 设置或获取  是否开启消息加解密
        /// </summary>
        public bool? IsOpenAEKey { get; set; }

    }
}
