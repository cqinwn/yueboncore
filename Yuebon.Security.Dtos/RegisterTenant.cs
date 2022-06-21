using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yuebon.Security.Dtos
{
    /// <summary>
    /// 租户注册信息
    /// </summary>
    public class RegisterTenant
    {
        /// <summary>
        /// 设置账号
        /// </summary>
        public string Account { get; set; }
        /// <summary>
        /// 设置邮箱
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 设置密码
        /// </summary>
        public string Password { get; set; }
    }
}
