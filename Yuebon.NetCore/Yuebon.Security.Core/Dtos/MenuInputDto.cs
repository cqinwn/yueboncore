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
    [AutoMap(typeof(Menu))]
    [Serializable]
    public class MenuInputDto: IInputDto<string>
    {
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 设置或获取 
        /// </summary>
        public string SystemTypeId { get; set; }

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
        public string Icon { get; set; }

        /// <summary>
        /// 设置或获取路由
        /// </summary>
        public virtual string UrlAddress { get; set; }

        /// <summary>
        /// 设置或获取目标打开方式
        /// </summary>
        public virtual string Target { get; set; }

        /// <summary>
        /// 设置或获取菜单类型（C目录 M菜单 F按钮）
        /// </summary>
        public virtual string MenuType { get; set; }
        /// <summary>
        /// 设置或获取组件路径
        /// </summary>
        public virtual string Component { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public bool? IsExpand { get; set; }
        /// <summary>
        /// 设置或获取 是否显示
        /// </summary>
        public bool? IsShow { get; set; }
        /// <summary>
        /// 设置或获取是否缓存
        /// </summary>
        public bool? IsCache { get; set; }
        /// <summary>
        /// 设置或获取 是否外链
        /// </summary>
        public bool? IsFrame { get; set; }
        /// <summary>
        /// 设置或获取 批量添加
        /// </summary>
        public bool IsBatch { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public bool? IsPublic { get; set; }

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
        public string Description { get; set; }


        /// <summary>
        /// 创建日期
        /// </summary>
        public virtual DateTime? CreatorTime { get; set; }



        /// <summary>
        /// 设置或获取 
        /// </summary>
        public string SystemTypeName { get; set; }
    }
}
