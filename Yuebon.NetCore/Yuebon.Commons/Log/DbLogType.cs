using System.ComponentModel;

namespace Yuebon.Commons.Log
{
    /// <summary>
    /// 日志类型
    /// </summary>
    public enum DbLogType
    {
        /// <summary>
        /// 其他
        /// </summary>
        [Description("其他")]
        Other = 0,
        /// <summary>
        /// 登录
        /// </summary>
        [Description("登录")]
        Login = 1,
        /// <summary>
        /// 退出
        /// </summary>
        [Description("退出")]
        Exit = 2,
        /// <summary>
        /// 访问
        /// </summary>
        [Description("访问")]
        Visit = 3,
        /// <summary>
        /// 新增
        /// </summary>
        [Description("新增")]
        Create = 4,
        /// <summary>
        /// 删除
        /// </summary>
        [Description("删除")]
        Delete = 5,
        /// <summary>
        /// 修改
        /// </summary>
        [Description("修改")]
        Update = 6,
        /// <summary>
        /// 提交
        /// </summary>
        [Description("提交")]
        Submit = 7,
        /// <summary>
        /// 异常
        /// </summary>
        [Description("异常")]
        Exception = 8,
        /// <summary>
        /// 软删除
        /// </summary>
        [Description("软删除")]
        DeleteSoft = 9,
    }
}
