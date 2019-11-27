using System;
using System.Collections.Generic;
using System.Text;

namespace Yuebon.Common.Attributes
{
    /// <summary>
    /// Specifies that this is a computed column.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class ComputedAttribute : Attribute
    {
    }
}
