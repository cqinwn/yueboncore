using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yuebon.Commons.VerificationCode
{
    class CaptchaLetterModel
    {
        /// <summary>
        /// 字符
        /// </summary>
        public string Letter { get; set; }
        /// <summary>
        /// 坐标x
        /// </summary>
        public int x { get; set; }
        /// <summary>
        /// 坐标y
        /// </summary>
        public int y { get; set; }
        /// <summary>
        /// 坐标x2
        /// </summary>
        public int x2 { get; set; }
        /// <summary>
        /// 坐标y2
        /// </summary>
        public int y2 { get; set; }
    }
}
