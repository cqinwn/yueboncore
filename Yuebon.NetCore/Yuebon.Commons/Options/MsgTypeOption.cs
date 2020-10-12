using System;
using System.Collections.Generic;
using System.Text;

namespace Yuebon.Commons.Options
{
    /// <summary>
    /// 通知操作类型
    /// </summary>
    public enum MsgTypeOption
    {
        /// <summary>
        /// 不通知
        /// </summary>
        No=0,
        /// <summary>
        /// 异常通知
        /// </summary>
        Error=1,
        /// <summary>
        /// 通知所有
        /// </summary>
        All = 2
    }
}
