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
    [AutoMap(typeof(RoleData))]
    [Serializable]
    public class RoleDataInputDto: IInputDto<string>
    {
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public string RoleId { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public string BelongCompanys { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public string BelongDepts { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public string ExcludeDepts { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public string Note { get; set; }

    }
}
