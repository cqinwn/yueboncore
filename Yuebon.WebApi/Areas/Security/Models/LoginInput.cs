namespace Yuebon.WebApi.Areas.Security.Models
{
    /// <summary>
    /// 用户登录参数
    /// </summary>
    public class LoginInput
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 验证码
        /// </summary>
        public string Vcode { get; set; }
        /// <summary>
        /// 验证码key
        /// </summary>
        public string Vkey { get; set; }
        /// <summary>
        /// 应用Id
        /// </summary>
        public string AppId { get; set; }
        /// <summary>
        /// 系统代码
        /// </summary>
        public string SystemCode { get; set; }
        /// <summary>
        /// 请求主机
        /// </summary>
        public string Host { get; set; }
    }
}
