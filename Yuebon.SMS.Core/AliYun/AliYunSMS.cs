using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Exceptions;
using Aliyun.Acs.Core.Http;
using Aliyun.Acs.Core.Profile;
using Newtonsoft.Json;
using System;
using Yuebon.Commons.Cache;
using Yuebon.Commons.Encrypt;
using Yuebon.Commons.Json;
using Yuebon.Commons.Log;
using Yuebon.Commons.Options;

namespace Yuebon.SMS.AliYun
{
    /// <summary>
    /// 阿里云短信接口
    /// </summary>
    public class AliYunSMS
    {
        //产品名称:云通信短信API产品
        private const string product = "Dysmsapi";
        //短信API产品域名
        private const string domain = "dysmsapi.aliyuncs.com";

        public AliYunSMS()
        {
            YuebonCacheHelper yuebonCacheHelper = new YuebonCacheHelper();
            AppSetting sysSetting = yuebonCacheHelper.Get<AppSetting>("SysSetting");
            if (sysSetting != null)
            {
                this.Appkey = DEncrypt.Decrypt(sysSetting.Smsusername);
                this.Appsecret = DEncrypt.Decrypt(sysSetting.Smspassword);
                this.SignName = sysSetting.SmsSignName;
            }
        }


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
        public bool Send(string[] phoneNumbers, string TemplateCode, string message, out string returnMsg, string OutId = "", string speed = "1")
        {
            if ((((phoneNumbers == null) || (phoneNumbers.Length == 0)) || string.IsNullOrEmpty(message)) || (message.Trim().Length == 0))
            {
                returnMsg = "手机号码和消息内容不能为空";
                return false;
            }
            string phoneNumbersTot = string.Join(",", phoneNumbers);

            return this.Send(phoneNumbersTot, TemplateCode, message, out returnMsg, OutId, "0");

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
        public  bool Send(string cellPhone, string templateCode, string message, out string returnMsg, string OutId = "", string speed = "0")
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
            IClientProfile profile = DefaultProfile.GetProfile("cn-hangzhou", Appkey, Appsecret);
            IAcsClient acsClient = new DefaultAcsClient(profile);
            CommonRequest request = new CommonRequest();
            if (string.IsNullOrEmpty(templateCode) || templateCode.Length <= 0)
            {
                templateCode = "SMS_139390116";//阿里云自带的
            }
            try
            {
                request.Domain = domain;
                request.Method = MethodType.POST;
                request.Action = "SendSms";
                request.Version = "2017-05-25";
                request.Product = "Dysmsapi";
                //必填:待发送手机号。支持以逗号分隔的形式进行批量调用，批量上限为20个手机号码,批量调用相对于单条调用及时性稍有延迟,验证码类型的短信推荐使用单条调用的方式
                request.AddQueryParameters("PhoneNumbers", cellPhone);
                //必填:短信签名-可在短信控制台中找到
                request.AddQueryParameters("SignName", SignName);
                //必填:短信模板-可在短信控制台中找到
                request.AddQueryParameters("TemplateCode", templateCode);
                //可选:模板中的变量替换JSON串,如模板内容为"亲爱的${name},您的验证码为${code}"时,此处的值为 "{\"name\":\"Tom\"， \"code\":\"123\"}"

                request.AddQueryParameters("TemplateParam", message);

                //可选:outId为提供给业务方扩展字段,最终在短信回执消息中将此值带回给调用者
                if (string.IsNullOrEmpty(OutId) || OutId.Length <= 0)
                {
                    OutId = DateTime.Now.Ticks.ToString();
                }
                request.AddQueryParameters("OutId", OutId);
                //请求失败这里会抛ClientException异常
                CommonResponse commonResponse = new CommonResponse();
                commonResponse = acsClient.GetCommonResponse(request);
                SMSResult sMSResult = JsonConvert.DeserializeObject<SMSResult>(commonResponse.Data);
                returnMsg = sMSResult.Message;
                if (sMSResult.Code == "OK")
                {
                    return true;
                }
                else
                {
                    Log4NetHelper.Error("发送短信错误，"+ commonResponse.ToJson().ToString()); 
                    return false;
                }


            }
            catch (ServerException e)
            {
                returnMsg = "未知错误(ServerException 1)" + e.ErrorMessage;
                return false;
            }
            catch (ClientException e)
            {
                returnMsg = "未知错误(ClientException 2)" + e.ErrorMessage;
                return false;
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

    }
}
