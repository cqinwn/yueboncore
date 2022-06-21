using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Yuebon.Commons.Json;

namespace Yuebon.Commons.Helpers
{
    /// <summary>
    /// http请求类
    /// </summary>
    public static class HttpClientHelper
    {
        /// <summary>
        /// 
        /// </summary>
        ///public static string _baseIPAddress="";
        static readonly HttpClient _httpClient = new HttpClient();

        /// <summary>
        /// Get请求数据
        /// <para>最终以url参数的方式提交</para>
        /// </summary>
        /// <param name="parameters">参数字典,可为空</param>
        /// <param name="requestUri">例如/api/Files/UploadFile</param>
        /// <returns></returns>
        public static string Get(Dictionary<string, string> parameters, string requestUri)
        {
            if (parameters != null)
            {
                var strParam = string.Join("&", parameters.Select(o => o.Key + "=" + o.Value));
                requestUri = string.Concat(ConcatURL(requestUri), '?', strParam);
            }
            else
            {
                requestUri = ConcatURL(requestUri);
            }

            var result = _httpClient.GetStringAsync(requestUri);
            return result.Result;
        }

        /// <summary>
        /// Get请求数据
        /// <para>最终以url参数的方式提交</para>
        /// </summary>
        /// <param name="parameters">参数字典</param>
        /// <param name="requestUri">例如/api/Files/UploadFile</param>
        /// <returns>实体对象</returns>
        public static T Get<T>(Dictionary<string, string> parameters, string requestUri) where T : class
        {
            string jsonString = Get(parameters, requestUri);
            if (string.IsNullOrEmpty(jsonString))
                return null;

            return JsonHelper.ToObject<T>(jsonString);
        }

        /// <summary>
        /// 同步GET请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="headers"></param>
        /// <param name="timeout">请求响应超时时间，单位/s(默认100秒)</param>
        /// <returns></returns>
        public static string HttpGet(string url, Dictionary<string, string> headers = null, int timeout = 0)
        {
            if (headers != null)
            {
                foreach (KeyValuePair<string, string> header in headers)
                {
                    _httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);
                }
            }
            if (timeout > 0)
            {
                _httpClient.Timeout = new TimeSpan(0, 0, timeout);
            }
            var result = _httpClient.GetAsync(ConcatURL(url));
            Byte[] resultBytes = result.Result.Content.ReadAsByteArrayAsync().Result;
            return Encoding.UTF8.GetString(resultBytes);
        }

        /// <summary>
        /// 异步GET请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="headers"></param>
        /// <param name="timeout">请求响应超时时间，单位/s(默认100秒)</param>
        /// <returns></returns>
        public static async Task<string> HttpGetAsync(string url, Dictionary<string, string> headers = null, int timeout = 0)
        {
            if (headers != null)
            {
                foreach (KeyValuePair<string, string> header in headers)
                {
                    _httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);
                }
            }
            if (timeout > 0)
            {
                _httpClient.Timeout = new TimeSpan(0, 0, timeout);
            }
            var result = await _httpClient.GetAsync(ConcatURL(url));
            Byte[] resultBytes = result.Content.ReadAsByteArrayAsync().Result;
            return Encoding.UTF8.GetString(resultBytes);
        }
        /// <summary>
        /// 以json的方式Post数据 返回string类型
        /// <para>最终以json的方式放置在http体中</para>
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="requestUri">例如/api/Files/UploadFile</param>
        /// <param name="headers"></param>
        /// <param name="contentType"></param>
        /// <param name="timeout">请求响应超时时间，单位/s(默认100秒)</param>
        /// <param name="encoding">默认UTF8</param>
        /// <returns></returns>
        public static string Post(object entity, string requestUri, Dictionary<string, string> headers = null, string contentType = "application/json", int timeout = 0, Encoding encoding = null)
        {
            string request = string.Empty;
            if (entity != null)
                request = entity.ToJson();
            if (headers != null)
            {
                foreach (KeyValuePair<string, string> header in headers)
                {
                    _httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);
                }
            }
            if (timeout > 0)
            {
                _httpClient.Timeout = new TimeSpan(0, 0, timeout);
            }
            HttpContent httpContent = new StringContent(request ?? "", encoding ?? Encoding.UTF8);
            if (contentType != null)
            {
                httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(contentType);
            }
            return Post(requestUri, httpContent);
        }


        /// <summary>
        /// Post Dic数据
        /// <para>最终以formurlencode的方式放置在http体中</para>
        /// </summary>
        /// <returns>System.String.</returns>
        public static string PostDic(Dictionary<string, string> temp, string requestUri)
        {
            HttpContent httpContent = new FormUrlEncodedContent(temp);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
            return Post(requestUri, httpContent);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="requestUrl"></param>
        /// <returns></returns>
        public static string PostByte(byte[] bytes, string requestUrl)
        {
            HttpContent content = new ByteArrayContent(bytes);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            return Post(requestUrl, content);
        }

        private static string Post(string requestUrl, HttpContent content)
        {
            var result = _httpClient.PostAsync(ConcatURL(requestUrl), content);
            Byte[] resultBytes = result.Result.Content.ReadAsByteArrayAsync().Result;
            return Encoding.UTF8.GetString(resultBytes);
            //return result.Result.Content.ReadAsStringAsync().Result;
        }

        /// <summary>
        /// 把请求的URL相对路径组合成绝对路径
        /// </summary>
        private static string ConcatURL(string requestUrl)
        {
            if (!string.IsNullOrEmpty(_httpClient.BaseAddress?.Host))
            {
                return new Uri(_httpClient.BaseAddress, requestUrl).OriginalString;
            }
            else
            {
                return new Uri(requestUrl).OriginalString;
            }
        }
    }
}
