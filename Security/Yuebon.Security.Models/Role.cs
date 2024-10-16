﻿using Yuebon.Commons.Enums;

namespace Yuebon.Security.Models;

/// <summary>
/// 角色表，数据实体对象
/// </summary>
[SugarTable("Sys_Role", "角色表")]
public class Role: TenantEntity,ICreationAudited, IModificationAudited, IDeleteAudited, IOrgIdFilter
{ 

    #region Property Members
    /// <summary>
    /// 组织主键
    /// </summary>
    [SugarColumn(ColumnDescription = "组织主键")]
    public virtual long? OrganizeId { get; set; }
    /// <summary>
    /// 分类:1-角色2-岗位
    /// </summary>
    [SugarColumn(ColumnDescription= "分类:1-角色2-岗位")]
    public virtual int? Category { get; set; }

    /// <summary>
    /// 角色编码
    /// </summary>
    [MaxLength(50)]
    [SugarColumn(ColumnDescription= "角色编码")]
    public virtual string? EnCode { get; set; }

    /// <summary>
    /// 名称
    /// </summary>
    [MaxLength(50)]
    [SugarColumn(ColumnDescription= "名称")]
    public virtual string? FullName { get; set; }

    /// <summary>
    /// 类型
    /// </summary>
    [MaxLength(50)]
    [SugarColumn(ColumnDescription= "类型")]
    public virtual string? Type { get; set; }


    /// <summary>
    /// 数据范围（1全部数据 2本部门及以下数据 3本部门数据 4仅本人数据 5自定义数据）
    /// </summary>
    [SugarColumn(ColumnDescription = "数据范围")]
    public RoleDataScopeEnum DataScope { get; set; } = RoleDataScopeEnum.Self;
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
    public virtual string? Description { get; set; }



    /// <summary>
    /// 有效标志
    /// </summary>
    [SugarColumn(ColumnDescription= "有效标志")]
    public virtual bool EnabledMark { get; set; }


    /// <summary>
    /// 创建日期
    /// </summary>
    [SugarColumn(ColumnDescription = "创建日期")]
    public virtual DateTime? CreatorTime { get; set; }

    /// <summary>
    /// 创建用户主键
    /// </summary>
    [SugarColumn(ColumnDescription = "创建用户主键")]
    public virtual long? CreatorUserId { get; set; }

    /// <summary>
    /// 设置或获取 创建者部门Id
    /// </summary>
    [SugarColumn(ColumnDescription = "创建者部门Id", IsOnlyIgnoreUpdate = true)]
    public virtual long? CreateOrgId { get; set; }
    /// <summary>
    /// 最后修改时间
    /// </summary>
    [SugarColumn(ColumnDescription = "最后修改时间")]
    public virtual DateTime? LastModifyTime { get; set; }

    /// <summary>
    /// 最后修改用户
    /// </summary>
    [SugarColumn(ColumnDescription = "最后修改用户")]
    public virtual long? LastModifyUserId { get; set; }

    /// <summary>
    /// 删除标志
    /// </summary>
    [SugarColumn(ColumnDescription = "删除标志")]
    public virtual bool? DeleteMark { get; set; }
    /// <summary>
    /// 删除时间
    /// </summary>
    [SugarColumn(ColumnDescription = "删除时间")]
    public virtual DateTime? DeleteTime { get; set; }

    /// <summary>
    /// 删除用户
    /// </summary>
    [SugarColumn(ColumnDescription = "删除用户")]
    public virtual long? DeleteUserId { get; set; }
    #endregion

}