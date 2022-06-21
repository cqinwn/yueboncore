using System;
using System.Collections.Generic;
using System.Text;

namespace Yuebon.Commons.Cache
{
    /// <summary>
    /// 缓存提供模式，使用Redis或MemoryCache
    /// </summary>
    public class CacheProvider
    {
        private bool _isUseRedis;
        
        private string _connectionString;
        private string _instanceName;
        /// <summary>
        /// 是否使用Redis
        /// </summary>
        public bool IsUseRedis { get => _isUseRedis; set => _isUseRedis = value; }
        /// <summary>
        /// Redis连接
        /// </summary>
        public string ConnectionString { get => _connectionString; set => _connectionString = value; }
        /// <summary>
        /// Redis实例名称
        /// </summary>
        public string InstanceName { get => _instanceName; set => _instanceName = value; }
    }
}
