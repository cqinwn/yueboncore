using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yuebon.SMS.Zutong
{
    /// <summary>
    /// 模板短信实体
    /// </summary>
    public class SendSmsTp
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string username { get; set; }
        /// <summary>
        /// 密码，密码采用32位小写MD5二次加密，例：md5( md5( password ) + tKey ))
        /// </summary>
        public string password { get; set; }
        /// <summary>
        /// tKey为东八区当前时间戳，精确到秒，10位长度。例如：1577352217
        /// </summary>
        public long tKey { get; set; }
        /// <summary>
        /// 已报备的签名
        /// </summary>
        public string signature { get; set; }
        /// <summary>
        /// 模板id
        /// </summary>
        public long tpId { get; set; }
        /// <summary>
        /// 扩展号。纯数字，最多8位。
        /// </summary>
        public int ext { get; set; }
        /// <summary>
        /// 用户自定义信息，在用户获取状态报告时返回
        /// </summary>
        public string extend { get; set; }
        /// <summary>
        /// 模板变量信息
        /// </summary>
        public List<record> records { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class record{

        /// <summary>
        /// 单个手机号码
        /// </summary>
        public string mobile { get; set; }
        /// <summary>
        /// 需要替换的变量JSON
        /// </summary>
        public string tpContent { get; set; }
    }
}
