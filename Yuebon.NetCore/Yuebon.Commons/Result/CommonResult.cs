using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Yuebon.Commons.Models
{
    /// <summary>
    ///  公共返回结果对象
    /// </summary>
    [Serializable]
    public class CommonResult
    {

        /// <summary>
        /// BaseResult构造函数
        /// </summary>
        public CommonResult()
        {
        }
        /// <summary>
        /// BaseResult构造函数
        /// </summary>
        /// <param name="errmsg">错误消息</param>
        /// <param name="errcode">错误代码</param>
        public CommonResult(string errmsg, string errcode)
        {
            this.m_ErrMsg = errmsg;
            this.ErrCode = errcode;
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="errmsg">错误消息</param>
        /// <param name="success">成功或失败</param>
        /// <param name="errcode">错误代码</param>
        public CommonResult(string errmsg, bool success, string errcode)
        {
            this.ErrMsg = errmsg;
            this.ErrCode = errcode;
            this.Success = success;
        }

        /// <summary>
        /// 错误代码
        /// </summary>
        private string m_ErrCode = "-1";
        /// <summary>
        /// 错误描述信息
        /// </summary>
        private string m_ErrMsg;
        /// <summary>
        /// 成功或失败
        /// </summary>
        private bool m_Success = false;
        /// <summary>
        /// 用来传递的object内容
        /// </summary>
        [DataMember]
        private object m_ResData;

        /// <summary>
        /// 错误代码
        /// </summary>
        [DataMember]
        public string ErrCode
        {
            get { return m_ErrCode; }
            set { 
                m_ErrCode = value;
                if (value == "0")
                {
                    Success= m_Success = true;
                }
                else
                {
                    Success = m_Success = false;
                }
            }
        }

        /// <summary>
        /// 如果不成功，返回的错误描述信息
        /// </summary>
        [DataMember]
        public string ErrMsg
        {
            get { return m_ErrMsg; }
            set { m_ErrMsg = value; }
        }
        /// <summary>
        /// 成功返回true，失败返回false
        /// </summary>
        [DataMember]
        public bool Success
        {
            get {
                if (ErrCode == "0")
                {
                    m_Success = true;
                }
                return m_Success; 
            }
            set { 
                m_Success = value;
            }
        }
        /// <summary>
        /// 用来传递的object内容
        /// </summary>
        [DataMember]
        public object ResData
        {
            get => m_ResData;
            set => m_ResData = value;
        }
    }

    /// <summary>
    /// WEBAPI通用返回泛型基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CommonResult<T> : CommonResult
    {
        /// <summary>
        /// 回传的结果
        /// </summary>
        public T Result { get; set; }
    }
}
