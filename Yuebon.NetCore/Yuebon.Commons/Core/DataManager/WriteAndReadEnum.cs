using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yuebon.Commons.DataManager
{
    /// <summary>
    /// 数据库读、写操作枚举
    /// </summary>
    public enum WriteAndReadEnum
    {
        /// <summary>
        /// 写操作
        /// </summary>
        Write,
        /// <summary>
        /// 读操作
        /// </summary>
        Read,
        /// <summary>
        /// 默认，不区分读写
        /// </summary>
        Default
    }
}
