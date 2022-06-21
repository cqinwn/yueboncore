namespace Yuebon.Commons.VerificationCode
{
    /// <summary>
    /// 验证码接口
    /// </summary>
    public interface ICaptcha
    {
        /// <summary>
        /// 生成随机验证码
        /// </summary>
        /// <param name="codeLength"></param>
        /// <returns></returns>
        Task<string> GenerateRandomCaptchaAsync(int codeLength = 4);

        /// <summary>
        /// 生成验证码图片
        /// </summary>
        /// <param name="captchaCode">验证码</param>
        /// <param name="width">宽为0将根据验证码长度自动匹配合适宽度</param>
        /// <param name="height">高</param>
        /// <returns></returns>
        Task<CaptchaResult> GenerateCaptchaImageAsync(string captchaCode, int width = 0, int height = 30);
    }
}
