using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yuebon.SMS.Zutong
{
    public class SMSResult
    {
        /// <summary>
        /// 请求状态码。返回200代表请求成功。
        /// 其他错误码详见错误码列表。
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// 状态码的描述。
        /// </summary>
        public string Msg { get; set; }
        /// <summary>
        /// 消息ID
        /// </summary>
        public long MsgId { get; set; }
    }
}
