using MailKit;
using MailKit.Net.Smtp;
using MailKit.Security;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using Yuebon.Commons.Cache;
using Yuebon.Commons.Encrypt;
using Yuebon.Commons.Extensions;
using Yuebon.Commons.Json;
using Yuebon.Commons.Options;

namespace Yuebon.Email
{
    /// <summary>
    /// 发送邮件
    /// </summary>
    public static class SendMailHelper
    {

        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="mailBodyEntity">邮件基础信息</param>
        public static SendResultEntity SendMail(MailBodyEntity mailBodyEntity)
        {
            var sendResultEntity = new SendResultEntity();
            if (mailBodyEntity == null)
            {
                throw new ArgumentNullException();
            }

            SendServerConfigurationEntity sendServerConfiguration = new SendServerConfigurationEntity();
            YuebonCacheHelper yuebonCacheHelper = new YuebonCacheHelper();
            AppSetting sysSetting = JsonSerializer.Deserialize<AppSetting>(yuebonCacheHelper.Get("SysSetting").ToJson());
            if (sysSetting != null)
            {
                sendServerConfiguration.SmtpHost = DEncrypt.Decrypt(sysSetting.Emailsmtp);
                sendServerConfiguration.SenderAccount = sysSetting.Emailusername;
                sendServerConfiguration.SenderPassword = DEncrypt.Decrypt(sysSetting.Emailpassword);
                sendServerConfiguration.SmtpPort = sysSetting.Emailport.ToInt();
                sendServerConfiguration.IsSsl =sysSetting.Emailssl.ToBool();
                sendServerConfiguration.MailEncoding ="utf-8";

                mailBodyEntity.Sender = sysSetting.Emailnickname;
                mailBodyEntity.SenderAddress = sysSetting.Emailusername;

            }
            else
            {
                sendResultEntity.ResultInformation ="邮件服务器未配置";
                sendResultEntity.ResultStatus = false;
                throw new ArgumentNullException();
            }
            sendResultEntity= SendMail(mailBodyEntity, sendServerConfiguration);
            return sendResultEntity;
        }
        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="mailBodyEntity">邮件基础信息</param>
        /// <param name="sendServerConfiguration">发件人基础信息</param>
        public static SendResultEntity SendMail(MailBodyEntity mailBodyEntity,
            SendServerConfigurationEntity sendServerConfiguration)
        {

            var sendResultEntity = new SendResultEntity();
            if (mailBodyEntity == null)
            {
                throw new ArgumentNullException();
            }

            if (sendServerConfiguration == null)
            {
                sendResultEntity.ResultInformation = "邮件服务器未配置";
                sendResultEntity.ResultStatus = false;
                throw new ArgumentNullException();
            }

            using (var client = new SmtpClient(new ProtocolLogger(MailMessage.CreateMailLog())))
            {
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                Connection(mailBodyEntity, sendServerConfiguration, client, sendResultEntity);

                if (sendResultEntity.ResultStatus == false)
                {
                    return sendResultEntity;
                }

                SmtpClientBaseMessage(client);

                // Note: since we don't have an OAuth2 token, disable
                // the XOAUTH2 authentication mechanism.
                client.AuthenticationMechanisms.Remove("XOAUTH2");

                Authenticate(mailBodyEntity, sendServerConfiguration, client, sendResultEntity);

                if (sendResultEntity.ResultStatus == false)
                {
                    return sendResultEntity;
                }

                Send(mailBodyEntity, sendServerConfiguration, client, sendResultEntity);

                if (sendResultEntity.ResultStatus == false)
                {
                    return sendResultEntity;
                }
                client.Disconnect(true);
            }
            return sendResultEntity;
        }


        /// <summary>
        /// 连接服务器
        /// </summary>
        /// <param name="mailBodyEntity">邮件内容</param>
        /// <param name="sendServerConfiguration">发送配置</param>
        /// <param name="client">客户端对象</param>
        /// <param name="sendResultEntity">发送结果</param>
        public static void Connection(MailBodyEntity mailBodyEntity, SendServerConfigurationEntity sendServerConfiguration,
            SmtpClient client, SendResultEntity sendResultEntity)
        {
            try
            {
                client.Connect(sendServerConfiguration.SmtpHost, sendServerConfiguration.SmtpPort, sendServerConfiguration.IsSsl);
            }
            catch (SmtpCommandException ex)
            {
                sendResultEntity.ResultInformation = $"尝试连接时出错:{0}" + ex.Message;
                sendResultEntity.ResultStatus = false;
            }
            catch (SmtpProtocolException ex)
            {
                sendResultEntity.ResultInformation = $"尝试连接时的协议错误:{0}" + ex.Message;
                sendResultEntity.ResultStatus = false;
            }
            catch (Exception ex)
            {
                sendResultEntity.ResultInformation = $"服务器连接错误:{0}" + ex.Message;
                sendResultEntity.ResultStatus = false;
            }
        }

        /// <summary>
        /// 账户认证
        /// </summary>
        /// <param name="mailBodyEntity">邮件内容</param>
        /// <param name="sendServerConfiguration">发送配置</param>
        /// <param name="client">客户端对象</param>
        /// <param name="sendResultEntity">发送结果</param>
        public static void Authenticate(MailBodyEntity mailBodyEntity, SendServerConfigurationEntity sendServerConfiguration,
            SmtpClient client, SendResultEntity sendResultEntity)
        {
            try
            {
                client.Authenticate(sendServerConfiguration.SenderAccount, sendServerConfiguration.SenderPassword);
            }
            catch (AuthenticationException ex)
            {
                sendResultEntity.ResultInformation = $"无效的用户名或密码:{0}" + ex.Message;
                sendResultEntity.ResultStatus = false;
            }
            catch (SmtpCommandException ex)
            {
                sendResultEntity.ResultInformation = $"尝试验证错误:{0}" + ex.Message;
                sendResultEntity.ResultStatus = false;
            }
            catch (SmtpProtocolException ex)
            {
                sendResultEntity.ResultInformation = $"尝试验证时的协议错误:{0}" + ex.Message;
                sendResultEntity.ResultStatus = false;
            }
            catch (Exception ex)
            {
                sendResultEntity.ResultInformation = $"账户认证错误:{0}" + ex.Message;
                sendResultEntity.ResultStatus = false;
            }
        }

        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="mailBodyEntity">邮件内容</param>
        /// <param name="sendServerConfiguration">发送配置</param>
        /// <param name="client">客户端对象</param>
        /// <param name="sendResultEntity">发送结果</param>
        public static void Send(MailBodyEntity mailBodyEntity, SendServerConfigurationEntity sendServerConfiguration,
            SmtpClient client, SendResultEntity sendResultEntity)
        {
            try
            {
                client.Send(MailMessage.AssemblyMailMessage(mailBodyEntity));
            }
            catch (SmtpCommandException ex)
            {
                switch (ex.ErrorCode)
                {
                    case SmtpErrorCode.RecipientNotAccepted:
                        sendResultEntity.ResultInformation = $"收件人未被接受:{ex.Message}";
                        break;
                    case SmtpErrorCode.SenderNotAccepted:
                        sendResultEntity.ResultInformation = $"发件人未被接受:{ex.Message}";
                        break;
                    case SmtpErrorCode.MessageNotAccepted:
                        sendResultEntity.ResultInformation = $"消息未被接受:{ex.Message}";
                        break;
                }
                sendResultEntity.ResultStatus = false;
            }
            catch (SmtpProtocolException ex)
            {
                sendResultEntity.ResultInformation = $"发送消息时的协议错误:{ex.Message}";
                sendResultEntity.ResultStatus = false;
            }
            catch (Exception ex)
            {
                sendResultEntity.ResultInformation = $"邮件接收失败:{ex.Message}";
                sendResultEntity.ResultStatus = false;
            }
        }

        /// <summary>
        /// 获取SMTP基础信息
        /// </summary>
        /// <param name="client">客户端对象</param>
        /// <returns></returns>
        public static MailServerInformation SmtpClientBaseMessage(SmtpClient client)
        {
            var mailServerInformation = new MailServerInformation
            {
                Authentication = client.Capabilities.HasFlag(SmtpCapabilities.Authentication),
                BinaryMime = client.Capabilities.HasFlag(SmtpCapabilities.BinaryMime),
                Dsn = client.Capabilities.HasFlag(SmtpCapabilities.Dsn),
                EightBitMime = client.Capabilities.HasFlag(SmtpCapabilities.EightBitMime),
                Size = client.MaxSize
            };

            return mailServerInformation;
        }
    }
}
