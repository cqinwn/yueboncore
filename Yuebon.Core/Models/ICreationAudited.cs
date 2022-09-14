using System;

namespace Yuebon.Core.Models
{
    /// <summary>
    /// 定义创建审计信息：给实体添加创建时的 创建人CreatorUserId，创建时间CreatorTime 的审计信息，这些值将在数据层执行 创建Insert 时自动赋值。
    /// </summary>
    public interface ICreationAudited
    {

        /// <summary>
        /// 获取或设置 创建日期
        /// </summary>
        DateTime? CreatorTime { get; set; }

        /// <summary>
        /// 获取或设置 创建用户主键
        /// </summary>
        long? CreatorUserId { get; set; }
    }
}