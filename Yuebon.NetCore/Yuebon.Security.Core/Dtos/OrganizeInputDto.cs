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
    [AutoMap(typeof(Organize))]
    [Serializable]
    public class OrganizeInputDto: IInputDto
    {
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 设置或获取 
        /// </summary>
        public string ParentId { get; set; }

        /// <summary>
        /// 设置或获取 
        /// </summary>
        public int? Layers { get; set; }

        /// <summary>
        /// 设置或获取 
        /// </summary>
        public string EnCode { get; set; }

        /// <summary>
        /// 设置或获取 
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// 设置或获取 
        /// </summary>
        public string ShortName { get; set; }

        /// <summary>
        /// 设置或获取 
        /// </summary>
        public string CategoryId { get; set; }

        /// <summary>
        /// 设置或获取 
        /// </summary>
        public string ManagerId { get; set; }

        /// <summary>
        /// 设置或获取 
        /// </summary>
        public string TelePhone { get; set; }

        /// <summary>
        /// 设置或获取 
        /// </summary>
        public string MobilePhone { get; set; }

        /// <summary>
        /// 设置或获取 
        /// </summary>
        public string WeChat { get; set; }

        /// <summary>
        /// 设置或获取 
        /// </summary>
        public string Fax { get; set; }

        /// <summary>
        /// 设置或获取 
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 设置或获取 
        /// </summary>
        public string AreaId { get; set; }

        /// <summary>
        /// 设置或获取 
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 设置或获取 
        /// </summary>
        public bool? AllowEdit { get; set; }

        /// <summary>
        /// 设置或获取 
        /// </summary>
        public bool? AllowDelete { get; set; }

        /// <summary>
        /// 设置或获取 
        /// </summary>
        public int? SortCode { get; set; }

        /// <summary>
        /// 设置或获取 
        /// </summary>
        public bool EnabledMark { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public bool DeleteMark { get; set; }

        /// <summary>
        /// 设置或获取 
        /// </summary>
        public string Description { get; set; }


    }
}
