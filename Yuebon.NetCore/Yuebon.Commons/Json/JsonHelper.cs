using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Yuebon.Commons.Json
{

    /// <summary>
    /// JSON序列化、反序列化扩展类。
    /// </summary>
    public static class JsonHelper
    {
        /// <summary>
        /// 对象序列化成JSON字符串。
        /// </summary>
        /// <param name="obj">序列化对象</param>
        /// <returns></returns>
        public static string ToJson(this object obj)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.Formatting = Formatting.Indented;
            settings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
            settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            settings.ContractResolver = new DefaultContractResolver();
            string result = JsonConvert.SerializeObject(obj, settings);
            return JsonConvert.SerializeObject(obj, settings);
        }

        /// <summary>
        /// JSON字符串序列化成对象。
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="json">JSON字符串</param>
        /// <returns></returns>
        public static T ToObject<T>(this string json)
        {
            return json == null ? default(T) : JsonConvert.DeserializeObject<T>(json);
        }

        /// <summary>
        /// JSON字符串序列化成集合。
        /// </summary>
        /// <typeparam name="T">集合类型</typeparam>
        /// <param name="json">JSON字符串</param>
        /// <returns></returns>
        public static List<T> ToList<T>(this string json)
        {
            return json == null ? null : JsonConvert.DeserializeObject<List<T>>(json);
        }

        /// <summary>
        /// JSON字符串序列化成DataTable。
        /// </summary>
        /// <param name="json">JSON字符串</param>
        /// <returns></returns>
        public static DataTable ToTable(this string json)
        {
            return json == null ? null : JsonConvert.DeserializeObject<DataTable>(json);
        }
    }

    /// <summary>
    /// JSON分解器。
    /// </summary>
    public class JsonPropertyContractResolver : DefaultContractResolver
    {
        /// <summary>
        /// 需要排除的属性。
        /// </summary>
        private IEnumerable<string> _listExclude;

        public JsonPropertyContractResolver(params string[] ignoreProperties)
        {
            this._listExclude = ignoreProperties;
        }

    }
}
