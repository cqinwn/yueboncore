using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Yuebon.Commons.Dtos;
using Yuebon.Commons.Models;
using Yuebon.Security.Models;

namespace Yuebon.Security.Dtos
{
    /// <summary>
    /// 输入对象模型
    /// </summary>
    [AutoMap(typeof(RoleAuthorize))]
    [Serializable]
    public class RoleAuthorizeInputDto : IInputDto
    {
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 设置或获取 
        /// </summary>
        public int? ItemType { get; set; }

        /// <summary>
        /// 设置或获取 
        /// </summary>
        public string ItemId { get; set; }

        /// <summary>
        /// 设置或获取 
        /// </summary>
        public int? ObjectType { get; set; }

        /// <summary>
        /// 设置或获取 
        /// </summary>
        public string ObjectId { get; set; }

        /// <summary>
        /// 设置或获取 
        /// </summary>
        public int? SortCode { get; set; }


    }
}
