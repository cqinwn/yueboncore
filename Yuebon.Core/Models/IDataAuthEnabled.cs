using System;
using System.Collections.Generic;
using System.Text;

namespace Yuebon.Core.Models
{
    /// <summary>
    /// 定义数据权限的更新，删除状态
    /// </summary>
    public interface IDataAuthEnabled
    {
        /// <summary>
        /// 获取或设置 是否可更新的数据权限状态
        /// </summary>
        bool Updatable { get; set; }

        /// <summary>
        /// 获取或设置 是否可删除的数据权限状态
        /// </summary>
        bool Deletable { get; set; }
    }
}
