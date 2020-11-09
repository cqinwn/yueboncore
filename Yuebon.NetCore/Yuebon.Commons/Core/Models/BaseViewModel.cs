using System;
using System.Collections.Generic;
using System.Text;
using Yuebon.Commons.Models;

namespace Yuebon.Commons.Models
{
    /// <summary>
    /// 所有数据库视图对应实体类必须继承此类
    /// </summary>
    [Serializable]
    public abstract class BaseViewModel : IEntity
    {

    }
}
