using Microsoft.Extensions.Caching.StackExchangeRedis;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Yuebon.Commons.Core.App;
using Yuebon.Commons.Helpers;

namespace Yuebon.Commons.Cache
{
    /// <summary>
    /// Redis 操作类，比YuebonCacheHelper方法更为丰富
    /// </summary>
    public class RedisHelper
    {
        /// <summary>
        /// 
        /// </summary>
        public IDatabase _cache;
        /// <summary>
        /// 
        /// </summary>
        private ConnectionMultiplexer _connection;
        /// <summary>
        /// 
        /// </summary>
        private readonly string _instance;

        private readonly JsonSerializerOptions _jsonOptions;
        /// <summary>
        /// 缓存提供模式
        /// </summary>
        private static CacheProvider cacheProvider;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="database"></param>
        public RedisHelper(int database = 0)
        {
            cacheProvider = Appsettings.GetService<CacheProvider>();
            RedisCacheOptions redisCacheOptions = new RedisCacheOptions()
            {
                Configuration=cacheProvider.ConnectionString
            };
            _connection = ConnectionMultiplexer.Connect(cacheProvider.ConnectionString);
            _cache = _connection.GetDatabase(database);
            _instance = cacheProvider.InstanceName;
            var options = new JsonSerializerOptions();
            options.WriteIndented = true;
            options.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            options.AllowTrailingCommas = true;
            ////设置时间格式
            //options.Converters.Add(new DateTimeJsonConverter());
            //options.Converters.Add(new DateTimeNullableConverter());
            //设置bool获取格式
            options.Converters.Add(new BooleanJsonConverter());
            //设置数字
            options.Converters.Add(new IntJsonConverter());
            options.Converters.Add(new LongJsonConverter());
            options.PropertyNamingPolicy = new UpperFirstCaseNamingPolicy();
            options.PropertyNameCaseInsensitive = true;                     //忽略大小写
            _jsonOptions = options;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <param name="database"></param>
        /// <param name="jsonOptions"></param>
        public RedisHelper(RedisCacheOptions options, JsonSerializerOptions jsonOptions, int database = 0)
        {
            _connection = ConnectionMultiplexer.Connect(options.Configuration);
            _cache = _connection.GetDatabase(database);
            _instance = options.InstanceName;
            _jsonOptions = jsonOptions;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetKeyForRedis(string key)
        {
            return _instance + key;
        }
        #region 验证缓存项是否存在
        /// <summary>
        /// 验证缓存项是否存在
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <returns></returns>
        public bool Exists(string key)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }
            return _cache.KeyExists(GetKeyForRedis(key));
        }
        /// <summary>
        /// 验证缓存项是否存在
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <returns></returns>
        public Task<bool> ExistsAsync(string key)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }
            return _cache.KeyExistsAsync(GetKeyForRedis(key));
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

            return _cache.StringSet(GetKeyForRedis(key), Encoding.UTF8.GetBytes(JsonSerializer.Serialize(value, _jsonOptions)));
        }
        /// <summary>
        /// 添加缓存
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <param name="value">缓存Value</param>
        /// <param name="expiresSliding">滑动过期时长（如果在过期时间内有操作，则以当前时间点延长过期时间,Redis中无效）</param>
        /// <param name="expiressAbsoulte">绝对过期时长</param>
        /// <returns></returns>
        public bool Add(string key, object value, TimeSpan expiresSliding, TimeSpan expiressAbsoulte)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            return _cache.StringSet(GetKeyForRedis(key), Encoding.UTF8.GetBytes(JsonSerializer.Serialize(value, _jsonOptions)), expiressAbsoulte);
        }
        /// <summary>
        /// 添加缓存
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <param name="value">缓存Value</param>
        /// <param name="expiresIn">缓存时长</param>
        /// <param name="isSliding">是否滑动过期（如果在过期时间内有操作，则以当前时间点延长过期时间,Redis中无效）</param>
        /// <returns></returns>
        public bool Add(string key, object value, TimeSpan expiresIn, bool isSliding = false)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }


            return _cache.StringSet(GetKeyForRedis(key), Encoding.UTF8.GetBytes(JsonSerializer.Serialize(value, _jsonOptions)), expiresIn);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public Task<bool> AddAsync(string key, object value)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            return _cache.StringSetAsync(GetKeyForRedis(key), Encoding.UTF8.GetBytes(JsonSerializer.Serialize(value, _jsonOptions)));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="expiresSliding"></param>
        /// <param name="expiressAbsoulte"></param>
        /// <returns></returns>
        public Task<bool> AddAsync(string key, object value, TimeSpan expiresSliding, TimeSpan expiressAbsoulte)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            return _cache.StringSetAsync(GetKeyForRedis(key), Encoding.UTF8.GetBytes(JsonSerializer.Serialize(value, _jsonOptions)), expiressAbsoulte);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="expiresIn"></param>
        /// <param name="isSliding"></param>
        /// <returns></returns>
        public Task<bool> AddAsync(string key, object value, TimeSpan expiresIn, bool isSliding = false)
        {

            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            return _cache.StringSetAsync(GetKeyForRedis(key), Encoding.UTF8.GetBytes(JsonSerializer.Serialize(value, _jsonOptions)), expiresIn);
        }
        /// <summary>
        /// 用键和值将某个缓存项插入缓存中，并指定基于时间的过期详细信息
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <param name="value">缓存Value</param>
        /// <param name="seconds">缓存时长</param>
        public bool Add(string key, object value, int seconds = 7200)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }


            TimeSpan expiresIn = DateTime.Now.AddSeconds(seconds) - DateTime.Now;
            return _cache.StringSet(GetKeyForRedis(key), Encoding.UTF8.GetBytes(JsonSerializer.Serialize(value, _jsonOptions)), expiresIn);
        }

        #endregion

        #region hash 操作
        /// <summary>
        /// 将哈希表 key 中的字段 field 的值设为 value
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <param name="field">字段</param>
        /// <param name="value">缓存Value</param>
        /// <returns></returns>
        public async Task<bool> HashSetAsync(string key,string field, object value)
        {
            return await _cache.HashSetAsync(GetKeyForRedis(key), field, Encoding.UTF8.GetBytes(JsonSerializer.Serialize(value, _jsonOptions)));
        }
        /// <summary>
        ///  获取存储在哈希表中指定字段的值
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <param name="field">字段</param>
        /// <returns></returns>
        public async Task<string> HashGetAsync(string key, string field)
        {
            return await _cache.HashGetAsync(GetKeyForRedis(key), Encoding.UTF8.GetBytes(field));
        }


        /// <summary>
        ///  获取存储在哈希表中指定key的值
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <returns></returns>
        public async Task<HashEntry[]> HashGetAllAsync(string key)
        {
            return await _cache.HashGetAllAsync(GetKeyForRedis(key));
        }
        /// <summary>
        ///  删除存储在哈希表中指定字段的值，不能删除key
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <param name="field">字段</param>
        /// <returns></returns>
        public async Task<bool> HashDeleteAsync(string key, string field)
        {
            return await _cache.HashDeleteAsync(GetKeyForRedis(key), Encoding.UTF8.GetBytes(field));
        }

        /// <summary>
        ///  批量删除存储在哈希表中指定字段的值，不能删除key
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <param name="hashFields">字段</param>
        /// <returns></returns>
        public async Task<long> HashDeletesAsync(string key, RedisValue[] hashFields)
        {
            return await _cache.HashDeleteAsync(GetKeyForRedis(key), hashFields);
        }
        #endregion

        #region List 操作
        /// <summary>
        /// 从底部插入数据
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <param name="value">缓存Value</param>
        /// <returns></returns>
        public async Task<long> ListRightPushAsync(string key, object value)
        {
            return await _cache.ListRightPushAsync(GetKeyForRedis(key), Encoding.UTF8.GetBytes(JsonSerializer.Serialize(value, _jsonOptions)));//从底部插入数据
        }
        /// <summary>
        /// 从顶部插入数据
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <param name="value">缓存Value</param>
        /// <returns></returns>
        public async Task<long> ListLeftPushAsync(string key, object value)
        {
            return await _cache.ListLeftPushAsync(GetKeyForRedis(key), Encoding.UTF8.GetBytes(JsonSerializer.Serialize(value, _jsonOptions)));//从顶部插入数据
        }
        /// <summary>
        /// 从顶部拿取数据
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <returns></returns>
        public string ListLeftPop(string key)
        {
            return _cache.ListLeftPop(GetKeyForRedis(key));//从顶部插入数据
        }
        /// <summary>
        /// 从底部拿取数据
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <returns></returns>
        public string ListRightPop(string key)
        {
            return _cache.ListRightPop(GetKeyForRedis(key));//从顶部插入数据
        }
        /// <summary>
        /// 移除与value相同的值
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <param name="value">缓存Value</param>
        /// <returns></returns>
        public async Task<long> ListRemoveAsync(string key,object value)
        {
            return await _cache.ListRemoveAsync(GetKeyForRedis(key), Encoding.UTF8.GetBytes(JsonSerializer.Serialize(value, _jsonOptions)));
        }
        /// <summary>
        /// 获取list的值
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <returns></returns>
        public async Task<RedisValue[]> ListRangeAsync(string key)
        {
            return await _cache.ListRangeAsync(GetKeyForRedis(key));
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
            return _cache.KeyDelete(GetKeyForRedis(key));
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

            keys.ToList().ForEach(item => Remove(item));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Task<bool> RemoveAsync(string key)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }
            return _cache.KeyDeleteAsync(GetKeyForRedis(key));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="keys"></param>
        /// <returns></returns>
        public Task RemoveAllAsync(IEnumerable<string> keys)
        {
            //if (keys == null)
            //{
            throw new ArgumentNullException(nameof(keys));
            //}

            //keys.ToList().ForEach(item => RemoveAsync(item));
        }
        /// <summary>
        /// 使用通配符找出所有的key然后逐个删除
        /// </summary>
        /// <param name="pattern">通配符</param>
        public virtual void RemoveByPattern(string pattern)
        {
            foreach (var ep in _connection.GetEndPoints())
            {
                var server = _connection.GetServer(ep);
                var keys = server.Keys(pattern: "*" + pattern + "*", database: _cache.Database);
                foreach (var key in keys)
                    _cache.KeyDelete(key);
            }
        }


        /// <summary>
        /// 删除所有缓存
        /// </summary>
        public void RemoveCacheAll()
        {
            RemoveByPattern("");
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
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            var value = _cache.StringGet(GetKeyForRedis(key));

            if (!value.HasValue)
            {
                return default(T);
            }

            return JsonSerializer.Deserialize<T>(value, _jsonOptions);
        }
        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <returns></returns>
        public object Get(string key)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            var value = _cache.StringGet(GetKeyForRedis(key));

            if (!value.HasValue)
            {
                return null;
            }

            return JsonSerializer.Deserialize<object>(value, _jsonOptions);


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

            keys.ToList().ForEach(item => dict.Add(item, Get(GetKeyForRedis(item))));

            return dict;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public Task<T> GetAsync<T>(string key) where T : class
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Task<object> GetAsync(string key)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="keys"></param>
        /// <returns></returns>
        public Task<IDictionary<string, object>> GetAllAsync(IEnumerable<string> keys)
        {

            throw new ArgumentNullException(nameof(keys));
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

            if (Exists(key))
                if (!Remove(key))
                    return false;

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

            if (Exists(key))
                if (!Remove(key))
                    return false;

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

            if (Exists(key))
                if (!Remove(key)) return false;

            return Add(key, value, expiresIn, isSliding);
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            if (_connection != null)
                _connection.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
