using System;
using System.Collections.Generic;
using System.Text;

namespace Yuebon.Core.Models
{
    /// <summary>
    /// 数据模型接口
    /// </summary>
    public interface IBaseEntity: IEntity
    {
        /// <summary>
        /// 获取 实体唯一标识，主键
        /// </summary>
        long Id { get; set; }
    }
}
