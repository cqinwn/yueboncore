using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Yuebon.Commons.VerificationCode
{
    /// <summary>
    /// 验证码返回结果
    /// </summary>
    public class CaptchaResult
    {
        /// <summary>
        /// 验证码字符串
        /// </summary>
        public string CaptchaCode { get; set; }

        /// <summary>
        /// 验证码内存流
        /// </summary>
        public MemoryStream CaptchaMemoryStream { get; set; }

        /// <summary>
        /// 验证码生成时间
        /// </summary>
        public DateTime Timestamp { get; set; }
    }
}
