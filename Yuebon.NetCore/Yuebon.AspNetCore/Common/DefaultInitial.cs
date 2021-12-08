using System.Collections.Generic;
using System.Linq;
using Yuebon.Commons.Cache;
using Yuebon.Commons.Core.App;
using Yuebon.Security.IServices;
using Yuebon.Security.Models;

namespace Yuebon.AspNetCore.Common
{
    /// <summary>
    /// 默认初始化内容
    /// </summary>
    public  class DefaultInitial : YuebonInitialization
    {
        IAPPService _aPPService = App.GetService<IAPPService>();

        /// <summary>
        /// 内存中缓存多应用
        /// </summary>
        public  void CacheAppList()
        {
            _aPPService.UpdateCacheAllowApp();
        }
    }
}
