using SqlSugar;
using System;
using System.ComponentModel.DataAnnotations;
using Yuebon.Commons.Helpers;
using Yuebon.Commons.Models;

namespace Yuebon.Security.Models
{
    /// <summary>
    /// 系统菜单，数据实体对象
    /// </summary>
    [SugarTable("Sys_Menu", "系统菜单")]
    [Serializable]
    public class Menu: BaseEntity, ICreationAudited, IModificationAudited, IDeleteAudited
    { 
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
	    public Menu()
		{
        }

        #region Property Members

        /// <summary>
        /// 所属系统主键
        /// </summary>
        [MaxLength(50)]
        [SugarColumn(ColumnDescription= "所属系统主键")]
        [Required]
        public virtual long SystemTypeId { get; set; }

        /// <summary>
        /// 父级
        /// </summary>
        [MaxLength(50)]
        [SugarColumn(ColumnDescription= "父级")]
        public virtual long ParentId { get; set; }

        /// <summary>
        /// 层次
        /// </summary>
        [SugarColumn(ColumnDescription= "层次")]
        public virtual int? Layers { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        [MaxLength(50)]
        [SugarColumn(ColumnDescription= "编码")]
        [Required]
        public virtual string EnCode { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [MaxLength(50)]
        [SugarColumn(ColumnDescription= "名称")]
        [Required]
        public virtual string FullName { get; set; }
        /// <summary>
        /// 英文名称
        /// </summary>
        [MaxLength(50)]
        [SugarColumn(ColumnDescription = "英文名称")]
        public virtual string EnglishFullName { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        [MaxLength(50)]
        [SugarColumn(ColumnDescription= "图标")]
        public virtual string Icon { get; set; }

        /// <summary>
        /// 路由
        /// </summary>
        [MaxLength(250)]
        [SugarColumn(ColumnDescription= "路由")]
        public virtual string UrlAddress { get; set; }

        /// <summary>
        /// 目标打开方式
        /// </summary>
        [MaxLength(50)]
        [SugarColumn(ColumnDescription= "目标打开方式")]
        public virtual string Target { get; set; }

        /// <summary>
        /// 菜单类型（C目录 M菜单 F按钮）
        /// </summary>
        [MaxLength(50)]
        [SugarColumn(ColumnDescription= "菜单类型（C目录 M菜单 F按钮）")]
        public virtual string MenuType { get; set; }
        /// <summary>
        /// 组件路径
        /// </summary>
        [MaxLength(254)]
        [SugarColumn(ColumnDescription= "组件路径")]
        public virtual string Component { get; set; }
        /// <summary>
        /// 设置当前选中菜单，用于新增、编辑、查看操作为单独的路由时指定选中菜单路由
        /// 同时设置为隐藏时才有效
        /// </summary>
        [MaxLength(200)]
        [SugarColumn(ColumnDescription= "设置当前选中菜单，用于新增、编辑、查看操作为单独的路由时指定选中菜单路由，同时设置为隐藏时才有效")]
        public virtual string ActiveMenu { get; set; }
        /// <summary>
        /// 展开
        /// </summary>
        [SugarColumn(ColumnDescription= "展开")]
        public virtual bool IsExpand { get; set; }

        /// <summary>
        /// 设置或获取 是否显示
        /// </summary>
        [SugarColumn(ColumnDescription= "是否显示")]
        public bool? IsShow { get; set; }
        /// <summary>
        /// 设置或获取 是否外链
        /// </summary>
        [SugarColumn(ColumnDescription= "是否外链")]
        public bool? IsFrame { get; set; }
        /// <summary>
        /// 设置或获取是否缓存
        /// </summary>
        [SugarColumn(ColumnDescription= "设置或获取是否缓存")]
        public bool? IsCache { get; set; }
        /// <summary>
        /// 公共
        /// </summary>
        [SugarColumn(ColumnDescription= "公共")]
        public virtual bool? IsPublic { get; set; }

        /// <summary>
        /// 允许编辑
        /// </summary>
        [SugarColumn(ColumnDescription= "允许编辑")]
        public virtual bool? AllowEdit { get; set; }

        /// <summary>
        /// 允许删除
        /// </summary>
        [SugarColumn(ColumnDescription= "允许删除")]
        public virtual bool? AllowDelete { get; set; }

        /// <summary>
        /// 排序码
        /// </summary>
        [SugarColumn(ColumnDescription= "排序码")]
        public virtual int? SortCode { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [MaxLength(500)]
        [SugarColumn(ColumnDescription= "描述")]
        public virtual string Description { get; set; }


        /// <summary>
        /// 删除标志
        /// </summary>
        [SugarColumn(ColumnDescription= "删除标志")]
        public virtual bool? DeleteMark { get; set; }

        /// <summary>
        /// 有效标志
        /// </summary>
        [SugarColumn(ColumnDescription= "有效标志")]
        public virtual bool EnabledMark { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        [SugarColumn(ColumnDescription= "创建日期")]
        public virtual DateTime? CreatorTime { get; set; }

        /// <summary>
        /// 创建用户主键
        /// </summary>
        [MaxLength(50)]
        [SugarColumn(ColumnDescription= "创建用户主键")]
        public virtual long? CreatorUserId { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        [SugarColumn(ColumnDescription= "最后修改时间")]
        public virtual DateTime? LastModifyTime { get; set; }

        /// <summary>
        /// 最后修改用户
        /// </summary>
        [MaxLength(50)]
        [SugarColumn(ColumnDescription= "最后修改用户")]
        public virtual long? LastModifyUserId { get; set; }

        /// <summary>
        /// 删除时间
        /// </summary>
        [SugarColumn(ColumnDescription= "删除时间")]
        public virtual DateTime? DeleteTime { get; set; }

        /// <summary>
        /// 删除用户
        /// </summary>
        [MaxLength(50)]
        [SugarColumn(ColumnDescription= "删除用户")]
        public virtual long? DeleteUserId { get; set; }
        #endregion

    }
}