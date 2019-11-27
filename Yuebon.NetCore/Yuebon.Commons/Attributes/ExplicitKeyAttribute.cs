using System;
using System.Collections.Generic;
using System.Text;

namespace Yuebon.Common.Attributes
{
    /// <summary>
    /// Specifies that this field is a explicitly set primary key in the database
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class ExplicitKeyAttribute : Attribute
    {

    }
}
