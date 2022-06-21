using System.ComponentModel;

namespace Yuebon.Commons.Enums
{
    /// <summary>
    /// 租户类型枚举
    /// </summary>
    public enum TenantTypeEnum
    {
        /// <summary>
        /// 普通租户
        /// </summary>
        [Description("普通租户")]
        COMMON = 0,
        /// <summary>
        /// 系统租户
        /// </summary>
        [Description("系统租户")]
        SYSTEM = 1,
    }
}
