using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Yuebon.Commons.Models;
using Yuebon.Security.Models;

namespace Yuebon.Security.Dtos
{
    /// <summary>
    /// 输入对象模型
    /// </summary>
    [AutoMap(typeof(UserOpenIds))]
    [Serializable]
    public class UserOpenIdsInputDto
    {
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public string OpenIdType { get; set; }

        /// <summary>
        /// 设置或获取 
        /// </summary>
        public string OpenId { get; set; }


    }
}
