using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yuebon.SMS.AliYun
{
    public class SMSResult
    {
        /// <summary>
        /// 发送回执ID
        /// </summary>
        public string BizId { get; set; }
        /// <summary>
        /// 请求状态码。返回OK代表请求成功。
        /// 其他错误码详见错误码列表。
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 状态码的描述。
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 请求ID。
        /// </summary>
        public string RequestId { get; set; }
    }
}
