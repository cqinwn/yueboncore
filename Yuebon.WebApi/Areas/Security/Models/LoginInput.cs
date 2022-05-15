namespace Yuebon.WebApi.Areas.Security.Models
{
    /// <summary>
    /// 用户登录参数
    /// </summary>
    public class LoginInput
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Vcode { get; set; }
        public string Vkey { get; set; }
        public string AppId { get; set; }
        public string SystemCode { get; set; }
        /// <summary>
        /// 请求
        /// </summary>
        public string Host { get; set; }
    }
}
