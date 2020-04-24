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
    [AutoMap(typeof(Items))]
    [Serializable]
    public class ItemsInputDto: IInputDto<string>
    {
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public string Id { get; set; }

        /// 设置或获取 
        /// </summary>
        public string ParentId { get; set; }

        /// 设置或获取 
        /// </summary>
        public string EnCode { get; set; }

        /// 设置或获取 
        /// </summary>
        public string FullName { get; set; }

        /// 设置或获取 
        /// </summary>
        public bool IsTree { get; set; }

        /// 设置或获取 
        /// </summary>
        public int? Layers { get; set; }

        /// 设置或获取 
        /// </summary>
        public int? SortCode { get; set; }

        /// 设置或获取 
        /// </summary>
        public bool EnabledMark { get; set; }

        /// 设置或获取 
        /// </summary>
        public string Description { get; set; }

    }
}