using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace Yuebon.Commons.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public static class HttpRequestHelper
    {

        #region 同步方法

        /// <summary>
        /// 使用Get方法获取字符串结果
        /// </summary>
        /// <param name="url"></param>
        /// <param name="encoding"></param>
        /// <param name="timeOut"></param>
        /// <returns></returns>
        public static string HttpGet(string url, Encoding encoding = null, int timeOut = 60000)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.Timeout = timeOut;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (Stream responseStream = response.GetResponseStream())
            {
                using (StreamReader myStreamReader = new StreamReader(responseStream, encoding ?? Encoding.GetEncoding("utf-8")))
                {
                    string retString = myStreamReader.ReadToEnd();
                    return retString;
                }
            }
        }

        /// <summary>
        /// 使用Post方法获取字符串结果，常规提交
        /// </summary>
        /// <returns></returns>
        public static string HttpPost(string url, Dictionary<string, string> formData = null, Encoding encoding = null, int timeOut = 60000, Dictionary<string, string> headers = null)
        {
            MemoryStream ms = new MemoryStream();
            formData.FillFormDataStream(ms);//填充formData
            return HttpPost(url, ms, "application/x-www-form-urlencoded", encoding, headers, timeOut);
        }

        /// <summary>
        /// 发送HttpPost请求，使用JSON格式传输数据
        /// </summary>
        /// <param name="url"></param>
        /// <param name="postData"></param>
        /// <param name="encoding"></param>
        /// <param name="headers"></param>
        /// <returns></returns>
        public static string HttpPost(string url, string postData, Encoding encoding = null, Dictionary<string, string> headers = null)
        {
            if (encoding == null)
                encoding = Encoding.UTF8;
            if (string.IsNullOrWhiteSpace(postData))
                throw new ArgumentNullException("postData");
            byte[] data = encoding.GetBytes(postData);
            MemoryStream stream = new MemoryStream();
            var formDataBytes = postData == null ? new byte[0] : Encoding.UTF8.GetBytes(postData);
            stream.Write(formDataBytes, 0, formDataBytes.Length);
            stream.Seek(0, SeekOrigin.Begin);//设置指针读取位置
            return HttpPost(url, stream, "application/json", encoding, headers);
        }

        /// <summary>
        /// 使用POST请求数据，使用JSON传输数据
        /// </summary>
        /// <param name="url"></param>
        /// <param name="dataObj">传输对象，转换为JSON传输</param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string HttpPost(string url, object dataObj, Encoding encoding = null, Dictionary<string, string> headers = null)
        {
            if (encoding == null)
                encoding = Encoding.UTF8;
            if (dataObj == null)
                throw new ArgumentNullException("dataObj");
            string postData = JsonConvert.SerializeObject(dataObj, new JsonSerializerSettings(){DateFormatString = "yyyy-MM-dd HH:mm:ss"});
            byte[] data = encoding.GetBytes(postData);
            MemoryStream stream = new MemoryStream();
            var formDataBytes = postData == null ? new byte[0] : Encoding.UTF8.GetBytes(postData);
            stream.Write(formDataBytes, 0, formDataBytes.Length);
            stream.Seek(0, SeekOrigin.Begin);//设置指针读取位置
            return HttpPost(url, stream, "application/json", encoding, headers);
        }

        /// <summary>
        /// 使用Post方法获取字符串结果
        /// </summary>
        /// <param name="url"></param>
        /// <param name="postStream"></param>
        /// <param name="contentType"></param>
        /// <param name="encoding"></param>
        /// <param name="timeOut"></param>
        /// <returns></returns>
        public static string HttpPost(string url, Stream postStream = null, string contentType = "application/x-www-form-urlencoded", Encoding encoding = null, Dictionary<string, string> headers=null, int timeOut = 60000)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.Timeout = timeOut;

            request.ContentLength = postStream != null ? postStream.Length : 0;
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
            request.KeepAlive = false;

            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/45.0.2454.87 Safari/537.36 QQBrowser/9.2.5748.400";
            request.ContentType = contentType;

            if (headers != null)
            {
                foreach (var header in headers)
                {
                    request.Headers.Add(header.Key, header.Value);
                }
            }

            #region 输入二进制流
            if (postStream != null)
            {
                postStream.Position = 0;

                //直接写入流
                Stream requestStream = request.GetRequestStream();

                byte[] buffer = new byte[1024];
                int bytesRead = 0;
                while ((bytesRead = postStream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    requestStream.Write(buffer, 0, bytesRead);
                }

                postStream.Close();//关闭文件访问
            }
            #endregion

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            using (Stream responseStream = response.GetResponseStream())
            {
                using (StreamReader myStreamReader = new StreamReader(responseStream, encoding ?? Encoding.GetEncoding("utf-8")))
                {
                    string retString = myStreamReader.ReadToEnd();
                    return retString;
                }
            }
        }

        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="formData"></param>
        /// <param name="stream"></param>
        public static void FillFormDataStream(this Dictionary<string, string> formData, Stream stream)
        {
            string dataString = GetQueryString(formData);
            var formDataBytes = formData == null ? new byte[0] : Encoding.UTF8.GetBytes(dataString);
            stream.Write(formDataBytes, 0, formDataBytes.Length);
            stream.Seek(0, SeekOrigin.Begin);//设置指针读取位置
        }

        /// <summary>
        /// 组装QueryString的方法
        /// 参数之间用&amp;连接，首位没有符号，如：a=1&amp;b=2&amp;c=3
        /// </summary>
        /// <param name="formData"></param>
        /// <returns></returns>
        public static string GetQueryString(this Dictionary<string, string> formData)
        {
            if (formData == null || formData.Count == 0)
            {
                return "";
            }
            StringBuilder sb = new StringBuilder();
            var i = 0;
            foreach (var kv in formData)
            {
                i++;
                sb.AppendFormat("{0}={1}", kv.Key, kv.Value);
                if (i < formData.Count)
                {
                    sb.Append("&");
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="apiPath"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string HttpEmployee_Post(string apiPath, string data)
        {
            string returnStr = "";
            try
            {

                //对所有代码产生的垃圾资源进行强制回收-慎用
                //System.GC.Collect();
                //请求地址获取用户授权信息
                WebRequest webRequest = System.Net.WebRequest.Create(apiPath);
                webRequest.Timeout = 1000000;//设置请求超时时间10秒

                HttpWebRequest httpRequest = webRequest as System.Net.HttpWebRequest;
                httpRequest.Method = "post";
                httpRequest.ContentType = "application/json";
                httpRequest.KeepAlive = false;//设置不是常连接

                System.Text.Encoding encoding = System.Text.Encoding.UTF8;
                byte[] bytesToPost = encoding.GetBytes(data);
                httpRequest.ContentLength = bytesToPost.Length;
                System.IO.Stream requestStream = httpRequest.GetRequestStream();
                requestStream.Write(bytesToPost, 0, bytesToPost.Length);

                HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();
                Stream stream = response.GetResponseStream();
                StreamReader Reader = new StreamReader(stream, Encoding.UTF8);
                returnStr = Reader.ReadToEnd();
                if (!string.IsNullOrEmpty(returnStr))
                {
                    returnStr = returnStr.Replace("\\", "");
                    returnStr = returnStr.TrimEnd('\"');
                    returnStr = returnStr.TrimStart('\"');
                }

                if (webRequest != null)
                {
                    webRequest.Abort();
                }
                if (httpRequest != null)
                {
                    httpRequest.Abort();
                }
                if (response != null)
                {
                    response.Dispose();
                    response.Close();
                }
                if (stream != null)
                {
                    stream.Dispose();
                    stream.Close();
                }
                if (Reader != null)
                {
                    Reader.Dispose();
                    Reader.Close();
                }
            }
            catch
            {
                returnStr = "";
            }
            return returnStr;
        }
    }
}
