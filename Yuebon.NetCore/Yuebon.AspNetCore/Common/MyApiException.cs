using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;

namespace Yuebon.AspNetCore.Common
{
    /// <summary>
    /// 自定义异常信息
    /// </summary>
    public class MyApiException : Exception
    {
        private string _msg;
        private bool _success;
        private string _errCode;

        /// <summary>
        /// 异常消息
        /// </summary>
        public string Msg
        {
            get => _msg;
            set => _msg = value;
        }
        /// <summary>
        /// 成功状态
        /// </summary>
        public bool Success
        {
            get => _success;
            set => _success = value;
        }
        /// <summary>
        /// 提示代码
        /// </summary>
        public string ErrCode
        {
            get => _errCode;
            set => _errCode = value;
        }
        /// <summary>
        /// 异常
        /// </summary>
        /// <param name="message"></param>
        public MyApiException(string message)
        {
            this.Msg = message;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="errcode"></param>
        public MyApiException(string message, string errcode)
        {
            this.Msg = message;
            this.ErrCode = errcode;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="success"></param>
        /// <param name="errcode"></param>
        public MyApiException(string message, bool success, string errcode)
        {
            this.Msg = message;
            this.Success = success;
            this.ErrCode = errcode;
        }

    }

}