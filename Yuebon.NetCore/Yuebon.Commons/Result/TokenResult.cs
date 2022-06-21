using System;
using System.Collections.Generic;
using System.Text;

namespace Yuebon.Commons.Models
{
    /// <summary>
    /// Token返回结果对象
    /// </summary>
    public class TokenResult
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public TokenResult()
        {
        }
        private string m_AccessToken;
        private int m_ExpiresIn;

        /// <summary>
        /// 获取到的凭证值
        /// </summary>
        public string AccessToken
        {
            get { return m_AccessToken; }
            set { m_AccessToken = value; }
        }
        /// <summary>
        /// 凭证有效时间，单位：分钟
        /// </summary>
        public int ExpiresIn
        {
            get { return m_ExpiresIn; }
            set { m_ExpiresIn = value; }
        }
    }
    public class GrantType
    {

        /// <summary>
        /// 密码校验。
        /// </summary>
        public const string Password = "password";

        /// <summary>
        /// ClientCredential。
        /// </summary>
        public const string ClientCredentials = "client_credential";
    }
}
