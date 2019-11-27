using System;
using System.Collections.Generic;
using System.Text;

namespace Yuebon.AspNetCore.SSO
{
    /// <summary>
    /// 系统登录请求实体
    /// </summary>
    public class PassportLoginRequest
    {
        /// <summary>
        /// 账号
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 系统编码
        /// </summary>
        public string SystemCode{ get; set; }

        public void Trim()
        {
            if (string.IsNullOrEmpty(Account))
            {
                throw new Exception("用户名不能为空");
            }

            if (string.IsNullOrEmpty(Password))
            {
                throw new Exception("密码不能为空");
            }
            Account = Account.Trim();
            Password = Password.Trim();
            if (!string.IsNullOrEmpty(SystemCode)) SystemCode = SystemCode.Trim();
        }
    }
}
