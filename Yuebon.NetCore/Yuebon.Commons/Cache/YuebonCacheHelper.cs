using System;
using System.Collections.Generic;
using Yuebon.Commons.Core.App;

namespace Yuebon.Commons.Cache
{
    /// <summary>
    /// 缓存操作帮助类
    /// </summary>
    public class YuebonCacheHelper
    {
        /// <summary>
        /// 缓存提供模式
        /// </summary>
        private static CacheProvider cacheProvider;
        /// <summary>
        /// 缓存接口
        /// </summary>
        private ICacheService cacheservice;
        /// <summary>
        /// 
        /// </summary>
        public YuebonCacheHelper()
        {

            cacheProvider = Appsettings.GetService<CacheProvider>();
            if (cacheProvider == null)
            {
                throw new ArgumentNullException(nameof(cacheProvider));
            }
            else
            {
                cacheservice= Appsettings.GetService<ICacheService>();
            }
        }

        /// <summary>
        /// 使用MemoryCache缓存操作
        /// </summary>
        /// <param name="isMemoryCache">是否使用MemoryCache</param>
        public YuebonCacheHelper(bool isMemoryCache=false)
        {

            cacheProvider = Appsettings.GetService<CacheProvider>();
            if (cacheProvider == null)
            {
                throw new ArgumentNullException(nameof(cacheProvider));
            }
            else
            {
                if (isMemoryCache)
                {
                    cacheservice = Appsettings.GetService<MemoryCacheService>();
                }
                else
                {
                    cacheservice = Appsettings.GetService<ICacheService>();

                }
            }
        }
        #region 验证缓存项是否存在
        /// <summary>
        /// 验证缓存项是否存在,TryGetValue 来检测 Key是否存在的
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <returns></returns>
        public bool Exists(string key)
        {
            return cacheservice.Exists(key);
        }
        #endregion

        #region 添加缓存

        /// <summary>
        /// 添加缓存
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <param name="value">缓存Value</param>
        /// <returns></returns>
        public bool Add(string key, object value)
        {
            return cacheservice.Add(key, value);
        }
        /// <summary>
        /// 添加缓存
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <param name="value">缓存Value</param>
        /// <param name="expiresSliding">滑动过期时长（如果在过期时间内有操作，则以当前时间点延长过期时间）</param>
        /// <param name="expiressAbsoulte">绝对过期时长</param>
        /// <returns></returns>
        public bool Add(string key, object value, TimeSpan expiresSliding, TimeSpan expiressAbsoulte)
        {
            return cacheservice.Add(key, value, expiresSliding, expiressAbsoulte);
        }
        /// <summary>
        /// 添加缓存
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <param name="value">缓存Value</param>
        /// <param name="expiresIn">缓存时长</param>
        /// <param name="isSliding">是否滑动过期（如果在过期时间内有操作，则以当前时间点延长过期时间）</param>
        /// <returns></returns>
        public bool Add(string key, object value, TimeSpan expiresIn, bool isSliding = false)
        {
            return cacheservice.Add(key,value,expiresIn,isSliding);
        }
        #endregion

        #region 删除缓存

        /// <summary>
        /// 删除缓存
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <returns></returns>
        public bool Remove(string key)
        {
            return cacheservice.Remove(key);
        }
        /// <summary>
        /// 批量删除缓存
        /// </summary>
        /// <param name="keys">缓存Key集合</param>
        /// <returns></returns>
        public void RemoveAll(IEnumerable<string> keys)
        {
            cacheservice.RemoveAll(keys);
        }
        /// <summary>
        /// 删除匹配到的缓存
        /// </summary>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public void RemoveByPattern(string pattern)
        {
            cacheservice.RemoveByPattern(pattern);
        }
        /// <summary>
        /// 删除所有缓存
        /// </summary>
        public void RemoveCacheAll()
        {
            cacheservice.RemoveCacheAll();
        }
        #endregion

        #region 获取缓存
        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <returns></returns>
        public T Get<T>(string key) where T : class
        {
            return cacheservice.Get<T>(key);
        }
        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <returns></returns>
        public object Get(string key)
        {
            return cacheservice.Get(key);
        }
        /// <summary>
        /// 获取缓存集合
        /// </summary>
        /// <param name="keys">缓存Key集合</param>
        /// <returns></returns>
        public IDictionary<string, object> GetAll(IEnumerable<string> keys)
        {
            return cacheservice.GetAll(keys);
        }

        #endregion

        #region 修改缓存
        /// <summary>
        /// 修改缓存
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <param name="value">新的缓存Value</param>
        /// <returns></returns>
        public bool Replace(string key, object value)
        {
            return cacheservice.Replace(key, value);

        }
        /// <summary>
        /// 修改缓存
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <param name="value">新的缓存Value</param>
        /// <param name="expiresSliding">滑动过期时长（如果在过期时间内有操作，则以当前时间点延长过期时间）</param>
        /// <param name="expiressAbsoulte">绝对过期时长</param>
        /// <returns></returns>
        public bool Replace(string key, object value, TimeSpan expiresSliding, TimeSpan expiressAbsoulte)
        {
            return cacheservice.Replace(key, value, expiresSliding, expiressAbsoulte);
        }
        /// <summary>
        /// 修改缓存
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <param name="value">新的缓存Value</param>
        /// <param name="expiresIn">缓存时长</param>
        /// <param name="isSliding">是否滑动过期（如果在过期时间内有操作，则以当前时间点延长过期时间）</param>
        /// <returns></returns>
        public bool Replace(string key, object value, TimeSpan expiresIn, bool isSliding = false)
        {
            return cacheservice.Replace(key,value,expiresIn,isSliding);
        }
        #endregion

    }
}
