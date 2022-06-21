using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Yuebon.AspNetCore.ViewModel
{
    /// <summary>
    /// 数据库连接返回结果实体
    /// </summary>
    [Serializable]
    public class DBConnResult
    {
        /// <summary>
        /// 未加密字符串
        /// </summary>
        [DataMember]
        public string ConnStr { get; set; }
        /// <summary>
        /// 数据库名称
        /// </summary>
        [DataMember]
        public string EncryptConnStr { get; set; }
    }
}
