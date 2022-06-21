﻿
using Microsoft.Extensions.Caching.Memory;
using System.Collections;
using System.Reflection;
using System.Runtime.Caching;
using System.Text.RegularExpressions;

namespace Yuebon.Commons.Cache;

/// <summary>
/// MemoryCache缓存操作
/// </summary>
public class MemoryCacheService : ICacheService
{
    /// <summary>
    /// 
    /// </summary>
    private readonly IMemoryCache _cache= new Microsoft.Extensions.Caching.Memory.MemoryCache(new MemoryCacheOptions());


    #region 验证缓存项是否存在
    /// <summary>
    /// 验证缓存项是否存在,TryGetValue 来检测 Key是否存在的
    /// </summary>
    /// <param name="key">缓存Key</param>
    /// <returns></returns>
    public bool Exists(string key)
    {
        if (key == null)
        {
            throw new ArgumentNullException(nameof(key));
        }
        object cached;
        return _cache.TryGetValue(key, out cached);
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
        if (key == null)
        {
            throw new ArgumentNullException(nameof(key));
        }
        if (value == null)
        {
            throw new ArgumentNullException(nameof(value));
        }
        _cache.Set(key, value);
        return Exists(key);
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
        if (key == null)
        {
            throw new ArgumentNullException(nameof(key));
        }
        if (value == null)
        {
            throw new ArgumentNullException(nameof(value));
        }
        _cache.Set(key, value,
                new MemoryCacheEntryOptions()
                .SetSlidingExpiration(expiresSliding)
                .SetAbsoluteExpiration(expiressAbsoulte)
                );

        return Exists(key);
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
        if (key == null)
        {
            throw new ArgumentNullException(nameof(key));
        }
        if (value == null)
        {
            throw new ArgumentNullException(nameof(value));
        }
        if (isSliding)
            _cache.Set(key, value,
                new MemoryCacheEntryOptions()
                .SetSlidingExpiration(expiresIn)
                );
        else
            _cache.Set(key, value,
            new MemoryCacheEntryOptions()
            .SetAbsoluteExpiration(expiresIn)
            );

        return Exists(key);
    }


    /// <summary>
    /// 用键和值将某个缓存项插入缓存中，并指定基于时间的过期详细信息
    /// </summary>
    /// <param name="key">缓存Key</param>
    /// <param name="value">缓存Value</param>
    /// <param name="seconds">缓存时长，默认7200秒</param>
    public bool Add(string key, object value, int seconds = 7200)
    {
        if (key == null)
        {
            throw new ArgumentNullException(nameof(key));
        }
        if (value == null)
        {
            throw new ArgumentNullException(nameof(value));
        }
        var cache = System.Runtime.Caching.MemoryCache.Default;

        var policy = new CacheItemPolicy
        {
            AbsoluteExpiration = DateTime.Now.AddSeconds(seconds)
        };

        cache.Set(key, value, policy);
        return Exists(key);
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
        if (key == null)
        {
            throw new ArgumentNullException(nameof(key));
        }
        _cache.Remove(key);

        return !Exists(key);
    }
    /// <summary>
    /// 批量删除缓存
    /// </summary>
    /// <param name="keys">缓存Key集合</param>
    /// <returns></returns>
    public void RemoveAll(IEnumerable<string> keys)
    {
        if (keys == null)
        {
            throw new ArgumentNullException(nameof(keys));
        }

        keys.ToList().ForEach(item => _cache.Remove(item));
    }

    /// <summary>
    /// 删除所有缓存
    /// </summary>
    public void RemoveCacheAll()
    {
        var l = GetCacheKeys();
        foreach (var s in l)
        {
            Remove(s);
        }
    }

    /// <summary>
    /// 删除匹配到的缓存
    /// </summary>
    /// <param name="pattern"></param>
    /// <returns></returns>
    public void RemoveByPattern(string pattern)
    {
        IList<string> l = SearchCacheRegex(pattern);
        foreach (var s in l)
        {
            Remove(s);
        }
    }

    /// <summary>
    /// 搜索 匹配到的缓存
    ///</summary>
    /// <param name="pattern"></param>
    /// <returns></returns>
    public IList<string> SearchCacheRegex(string pattern)
    {
        var cacheKeys = GetCacheKeys();
        var l = cacheKeys.Where(k => Regex.IsMatch(k, pattern)).ToList();
        return l.AsReadOnly();
    }

    #endregion

    #region 获取缓存
    /// <summary>
    /// 获取缓存
    /// </summary>
    /// <param name="key">缓存Key</param>
    /// <returns></returns>
    public T GetByKey<T>(string key) where T : class
    {
        if (key == null)
        {
            throw new ArgumentNullException(nameof(key));
        }
        return _cache.Get(key) as T;
    }
    /// <summary>
    /// 获取缓存
    /// </summary>
    /// <param name="key">缓存Key</param>
    /// <returns></returns>
    public object GetByKey(string key)
    {
        if (key == null)
        {
            throw new ArgumentNullException(nameof(key));
        }
        return _cache.Get(key);
    }
    /// <summary>
    /// 获取缓存集合
    /// </summary>
    /// <param name="keys">缓存Key集合</param>
    /// <returns></returns>
    public IDictionary<string, object> GetAll(IEnumerable<string> keys)
    {
        if (keys == null)
        {
            throw new ArgumentNullException(nameof(keys));
        }

        var dict = new Dictionary<string, object>();

        keys.ToList().ForEach(item => dict.Add(item, _cache.Get(item)));

        return dict;
    }


    /// <summary>
    /// 获取所有缓存键
    /// </summary>
    /// <returns></returns>
    public List<string> GetCacheKeys()
    {
        const BindingFlags flags = BindingFlags.Instance | BindingFlags.NonPublic;
        var entries = _cache.GetType().GetField("_entries", flags).GetValue(_cache);
        var cacheItems = entries as IDictionary;
        var keys = new List<string>();
        if (cacheItems == null) return keys;
        foreach (DictionaryEntry cacheItem in cacheItems)
        {
            keys.Add(cacheItem.Key.ToString());
        }
        return keys;
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
        if (key == null)
        {
            throw new ArgumentNullException(nameof(key));
        }
        if (value == null)
        {
            throw new ArgumentNullException(nameof(value));
        }
        if (Exists(key))
            if (!Remove(key)) return false;

        return Add(key, value);

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
        if (key == null)
        {
            throw new ArgumentNullException(nameof(key));
        }
        if (value == null)
        {
            throw new ArgumentNullException(nameof(value));
        }
        if (Exists(key))
            if (!Remove(key)) return false;

        return Add(key, value, expiresSliding, expiressAbsoulte);
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
        if (key == null)
        {
            throw new ArgumentNullException(nameof(key));
        }
        if (value == null)
        {
            throw new ArgumentNullException(nameof(value));
        }
        if (Exists(key))
            if (!Remove(key)) return false;

        return Add(key, value, expiresIn, isSliding);
    }
    #endregion
}
