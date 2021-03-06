using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yuebon.SMS
{
    /// <summary>
    /// 短信发送接口
    /// 所有平台短信发送都要实现这些接口方法
    /// </summary>
    public interface ISendSMS
    {
        /// <summary>
        /// 群发
        /// </summary>
        /// <param name="phoneNumbers">必填:待发送手机号。支持JSON格式的批量调用，批量上限为100个手机号码</param>
        /// <param name="TemplateCode">必填:短信模板</param>
        /// <param name="message">必填:模板中的变量替换JSON串,如模板内容为"亲爱的${name},您的验证码为${code}"时,此处的值为 "{\"name\":\"Tom\"， \"code\":\"123\"}"</param>
        /// <param name="returnMsg"></param>
        /// <param name="OutId">可选:outId为提供给业务方扩展字段,最终在短信回执消息中将此值带回给调用者</param>
        /// <param name="speed"></param>
        /// <returns></returns>
        bool Send(string[] phoneNumbers, string TemplateCode, string message, out string returnMsg, string OutId = "", string speed = "1");
        /// <summary>
        /// 短信发送
        /// </summary>
        /// <param name="cellPhone">必填:待发送手机号。支持以逗号分隔的形式进行批量调用，批量上限为1000个手机号码,批量调用相对于单条调用及时性稍有延迟,验证码类型的短信推荐使用单条调用的方式，发送国际/港澳台消息时，接收号码格式为00+国际区号+号码，如“0085200000000”</param>
        /// <param name="templateCode">模板code</param>
        /// <param name="OutId">可选:outId为提供给业务方扩展字段,最终在短信回执消息中将此值带回给调用者</param>
        /// <param name="message">可选:模板中的变量替换JSON串,如模板内容为"亲爱的${name},您的验证码为${code}"时,此处的值为 "{\"name\":\"Tom\"， \"code\":\"123\"}"</param>
        /// <param name="returnMsg"></param>
        /// <param name="speed"></param>
        /// <returns></returns>
        bool Send(string cellPhone, string templateCode, string message, out string returnMsg, string OutId = "", string speed = "0");
    }
}
