using System;
using System.Collections.Generic;
using System.Text;

namespace Yuebon.Common.Attributes
{
    /// <summary>
    /// 忽略属性，标识该实体属性不在表中映射列。
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class IgnoreAttrbute : Attribute
    {
    }
}
