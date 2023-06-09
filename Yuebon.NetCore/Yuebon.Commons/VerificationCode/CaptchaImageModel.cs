using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yuebon.Commons.VerificationCode
{
    public class CaptchaImageModel
    {
        public CaptchaImageModel()
        {
            Image_List = new List<string>();
        }
        /// <summary>
        /// 唯一ID
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 验证码种类（0表示通用型，1表示图片型）
        /// </summary>
        public int Type { get; private set; } = 1;
        /// <summary>
        /// 被选中的图片名称
        /// </summary>
        public string Image_Name { get; set; }
        /// <summary>
        /// Base64格式图片集合
        /// </summary>
        public List<string> Image_List { get; set; }
    }
}
