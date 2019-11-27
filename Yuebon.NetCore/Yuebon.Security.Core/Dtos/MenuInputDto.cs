using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Yuebon.Commons.Models;
using Yuebon.Security.Models;

namespace Yuebon.Security.Dtos
{
    /// <summary>
    /// 
    /// </summary>

    [AutoMap(typeof(Menu))]
    public class MenuInputDto : IInputDto<string>
    {

        #region Property MenuDto

        /// <summary>
        /// 模块主键
        /// </summary>
        public virtual string Id { get; set; }

        /// <summary>
        /// 所属系统主键
        /// </summary>
        public virtual string SystemTypeId { get; set; }
        /// <summary>
        /// 所属系统名称
        /// </summary>
        public virtual string SystemTypeName { get; set; }
        /// <summary>
        /// 父级
        /// </summary>
        public virtual string ParentId { get; set; }

        /// <summary>
        /// 层次
        /// </summary>
        public virtual int? Layers { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        public virtual string EnCode { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public virtual string FullName { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        public virtual string Icon { get; set; }

        /// <summary>
        /// 连接
        /// </summary>
        public virtual string UrlAddress { get; set; }

        /// <summary>
        /// 目标
        /// </summary>
        public virtual string Target { get; set; }

        /// <summary>
        /// 菜单
        /// </summary>
        public virtual bool? IsMenu { get; set; }

        /// <summary>
        /// 展开
        /// </summary>
        public virtual bool IsExpand { get; set; }

        /// <summary>
        /// 公共
        /// </summary>
        public virtual bool? IsPublic { get; set; }

        /// <summary>
        /// 允许编辑
        /// </summary>
        public virtual bool? AllowEdit { get; set; }

        /// <summary>
        /// 允许删除
        /// </summary>
        public virtual bool? AllowDelete { get; set; }

        /// <summary>
        /// 排序码
        /// </summary>
        public virtual int? SortCode { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public virtual string Description { get; set; }

        /// <summary>
        /// 删除标志
        /// </summary>
        public virtual bool? DeleteMark { get; set; }

        /// <summary>
        /// 有效标志
        /// </summary>
        public virtual bool EnabledMark { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        public virtual DateTime? CreatorTime { get; set; }

        /// <summary>
        /// 创建用户主键
        /// </summary>
        public virtual string CreatorUserId { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        public virtual DateTime? LastModifyTime { get; set; }

        /// <summary>
        /// 最后修改用户
        /// </summary>
        public virtual string LastModifyUserId { get; set; }

        /// <summary>
        /// 删除时间
        /// </summary>
        public virtual DateTime? DeleteTime { get; set; }

        /// <summary>
        /// 删除用户
        /// </summary>
        public virtual string DeleteUserId { get; set; }

        public List<MenuOutputDto> SubMenu { get; set; }
        #endregion
    }
}
