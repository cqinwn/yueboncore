using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yuebon.Commons.VerificationCode
{
    public class CaptchaModel
    {
        /// <summary>
        /// 唯一ID
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 验证码种类（0表示通用型，1表示图片型）
        /// </summary>
        public int Type { get; private set; } = 0;
        /// <summary>
        /// 验证码图片
        /// </summary>
        public string Image_Base64 { get; set; }
        /// <summary>
        /// 验证码图片
        /// </summary>
        public string Image2_Base64 { get; set; }
        /// <summary>
        /// 偏移位（X轴）
        /// </summary>
        public int Image2_Offset_X { get; set; }
        /// <summary>
        /// 偏移位（Y轴）
        /// </summary>
        public int Image2_Offset_Y { get; set; }
    }
}
