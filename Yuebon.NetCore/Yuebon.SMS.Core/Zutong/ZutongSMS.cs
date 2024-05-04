using Newtonsoft.Json;
using StackExchange.Profiling.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Yuebon.Commons.Cache;
using Yuebon.Commons.Const;
using Yuebon.Commons.Encrypt;
using Yuebon.Commons.Extensions;
using Yuebon.Commons.Helpers;
using Yuebon.Commons.Log;
using Yuebon.Commons.Options;

namespace Yuebon.SMS.Zutong
{
    /// <summary>
    /// 助通科技融合云通信
    /// </summary>
    public class ZutongSMS
    {

        public ZutongSMS()
        {
            YuebonCacheHelper yuebonCacheHelper = new YuebonCacheHelper();
            AppSetting sysSetting = yuebonCacheHelper.Get<AppSetting>(CacheConst.KeySysSetting);
            if (sysSetting != null)
            {
                this.Appkey = DEncrypt.Decrypt(sysSetting.Smsusername);
                this.Appsecret = DEncrypt.Decrypt(sysSetting.Smspassword);
                this.Domain = sysSetting.Smsapiurl;
                this.SignName = sysSetting.SmsSignName;
            }
        }

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
        public bool Send(string cellPhone, string templateCode, string message, out string returnMsg, string OutId = "", string speed = "0")
        {
            if ((string.IsNullOrEmpty(cellPhone) || (cellPhone.Trim().Length == 0)))
            {
                returnMsg = "手机号码和消息内容不能为空";
                return false;
            }
            if (string.IsNullOrEmpty(message))
            {
                message = "";
            }
            try
            {
                SendSmsTp sendSmsTp = new SendSmsTp();
                TimeSpan ts = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc));
                sendSmsTp.username = this.Appkey;
                sendSmsTp.password = Encode(this.Appsecret);
                sendSmsTp.tKey = (long)ts.TotalMilliseconds / 1000;
                sendSmsTp.signature = this.SignName;
                sendSmsTp.tpId = templateCode.ToLong();
                List<record> records = new List<record>();
                record item=   new record
                {
                    mobile = cellPhone,
                    tpContent = message
                };
                records.Add(item);
                sendSmsTp.records = records;
                var json = sendSmsTp.ToJson();
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var response = HttpClientHelper.Post( data,this.Domain);
                SMSResult sMSResult = JsonConvert.DeserializeObject<SMSResult>(response);
                returnMsg = sMSResult.Msg;
                if (sMSResult.Code ==200)
                {
                    return true;
                }
                else
                {
                    Log4NetHelper.Error("发送短信错误，" + response.ToJson().ToString());
                    return false;
                }


            }
            catch (Exception e)
            {
                returnMsg = "未知错误(Exception )" + e.Message;
                return false;
            }
        }

        private static string Encode(string txt)
        {
            using (MD5 mi = MD5.Create())
            {
                byte[] buffer = Encoding.Default.GetBytes(txt);
                byte[] newBuffer = mi.ComputeHash(buffer);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < newBuffer.Length; i++)
                {
                    sb.Append(newBuffer[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }

        /// <summary>
        /// Appkey 应用Id
        /// </summary>
        public string Appkey { get; set; }
        /// <summary>
        /// Appsecret应用密钥
        /// </summary>
        public string Appsecret { get; set; }

        /// <summary>
        /// 签名
        /// </summary>
        public string SignName { get; set; }

        /// <summary>
        /// 短信API产品域名 Url地址
        /// </summary>
        public string Domain { get; set; }
    }
}
