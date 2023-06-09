using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yuebon.Commons.VerificationCode
{
    public class CaptchaVerifyModel
    {
        /// <summary>
        /// 唯一ID
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 验证码类型：SimpleInput|SimpleCalculate|SlideBlock|SlideImage|TouchLetter|TouchRotate|TouchImage
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 待验证数据：SimpleInput(xxxx)|SimpleCalculate(xxxx)|SlideBlock(x)|SlideImage(x)|TouchLetter([LetterModel,...])|TouchRotate([index:direct,...]|TouchImage(index,...))
        /// </summary>
        public string DataCode { get; set; }
    }
}
