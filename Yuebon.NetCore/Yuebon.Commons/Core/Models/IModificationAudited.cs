using System;

namespace Yuebon.Commons.Models
{
    /// <summary>
    /// 定义更新审计的信息
    /// </summary>
    public interface IModificationAudited
    {
        /// <summary>
        /// 获取或设置 最后修改用户
        /// </summary>
        long? LastModifyUserId { get; set; }
        /// <summary>
        /// 获取或设置 最后修改时间
        /// </summary>
        DateTime? LastModifyTime { get; set; }
    }
}