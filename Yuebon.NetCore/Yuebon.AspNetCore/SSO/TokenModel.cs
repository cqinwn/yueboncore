using System;
using System.Collections.Generic;
using System.Text;

namespace Yuebon.AspNetCore.SSO
{
    /// <summary>
    /// 
    /// </summary>
    public class TokenModel
    {
        private string _access_token;
        private string _token_type;
        private string _refresh_token;
        private int _expires_in;
        /// <summary>
        /// 获取到的凭证值
        /// </summary>
        public string Access_Token
        {
            get=>_access_token;
            set => _access_token = value;
        }

        /// <summary>
        /// 获取到的凭证值
        /// </summary>
        public int Expires_In
        {
            get => _expires_in;
            set => _expires_in = value;
        }

        public string Token_Type
        {
            get => _token_type;
            set => _token_type = value;
        }

        public string Refresh_Token
        {
            get => _refresh_token;
            set => _refresh_token = value;
        }
    }
}
