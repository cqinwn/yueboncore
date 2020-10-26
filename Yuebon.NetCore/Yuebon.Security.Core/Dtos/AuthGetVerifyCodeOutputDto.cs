using System;
using System.Collections.Generic;
using System.Text;

namespace Yuebon.Security.Dtos
{
    /// <summary>
    /// 验证码输出实体
    /// </summary>
    public class AuthGetVerifyCodeOutputDto
    {
        /// <summary>
        /// 缓存键
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// 图片
        /// </summary>
        public string Img { get; set; }
    }
}
