namespace Yuebon.Commons.Enums
{
    /// <summary>
    /// 账号类型枚举
    /// </summary>
    public enum UserTypeEnum
    {
        /// <summary>
        /// 会员
        /// </summary>
        [Description("会员")]
        Member =0,

        /// <summary>
        /// 普通账号
        /// </summary>
        [Description("普通账号")]
        NormalUser = 777,
        /// <summary>
        /// 管理员
        /// </summary>
        [Description("系统管理员")]
        SysManager =888,
        /// <summary>
        /// 超级管理员
        /// </summary>
        [Description("超级管理员")]
        SuperAdmin = 999,
    }
}
