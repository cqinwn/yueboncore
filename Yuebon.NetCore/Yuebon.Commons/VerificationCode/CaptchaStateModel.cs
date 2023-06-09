using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yuebon.Commons.VerificationCode
{
    public class CaptchaStateModel
    {
        /// <summary>
        /// 唯一ID
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 待验证数据：SimpleInput(xxxx)|SimpleCalculate(xxxx)|SlideBlock(x)|SlideImage(x)|TouchSelect([LetterModel,...])||TouchRotate([index:direct,...]|TouchImage(index,...))
        /// </summary>
        public string DataCode { get; set; }
        /// <summary>
        /// 验证成功与否
        /// </summary>
        public bool IsSuccess { get; set; }
    }
}
