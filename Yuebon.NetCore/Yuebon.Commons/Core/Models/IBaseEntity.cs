using System;
using System.Collections.Generic;
using System.Text;

namespace Yuebon.Commons.Models
{
    /// <summary>
    /// 数据模型接口
    /// </summary>
    /// <typeparam name="TKey">实体主键类型</typeparam>
    public interface IBaseEntity<out TKey>: IEntity
    {
        /// <summary>
        /// 获取 实体唯一标识，主键
        /// </summary>
        TKey Id { get; }
    }
}
