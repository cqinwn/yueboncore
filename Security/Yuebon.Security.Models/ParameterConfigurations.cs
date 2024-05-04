namespace Yuebon.Security.Models
{
    /// <summary>
    /// 系统参数配置
    /// </summary>
    [SugarTable("sys_parameter_configurations", "系统参数配置")]
    [Serializable]
    public class ParameterConfigurations : TenantEntity, ICreationAudited, IModificationAudited, IDeleteAudited
    {
        /// <summary>
        /// 获取或设置 编号
        /// </summary>
        [DisplayName("编号")]
        [SugarColumn(IsPrimaryKey = true, ColumnDescription = "编号,主键")]
        public override long Id { get; set; }
        /// <summary>
        /// 参数名称
        /// </summary>
        [SugarColumn(ColumnDescription = "参数名称")]
        [Description("参数名称")]
        public virtual string ParameterName { get; set; }

        /// <summary>
        /// 参数值
        /// </summary>
        [Description("参数值")]
        [SugarColumn(ColumnDescription = "参数值", Length = 500)]
        public virtual string ParameterValue { get; set; }


        /// <summary>
        /// 描述
        /// </summary>
        [Display(Name = "描述")]
        [Description("描述")]
        [MaxLength(500)]
        [SugarColumn(ColumnDescription = "描述", Length = 500)]
        public virtual string Description { get; set; }


        /// <summary>
        /// 创建用户组织主键
        /// </summary>
        [SugarColumn(ColumnDescription = "创建用户组织主键")]
        public virtual long OrganizeId { get; set; }
        /// <summary>
        /// 创建用户部门主键
        /// </summary>
        [SugarColumn(ColumnDescription = "创建用户部门主键")]
        public virtual long? DepartmentId { get; set; }

        /// <summary>
        /// 删除标志
        /// </summary>
        [SugarColumn(ColumnDescription = "删除标志")]
        public virtual bool? DeleteMark { get; set; }

        /// <summary>
        /// 有效标志
        /// </summary>
        [SugarColumn(ColumnDescription = "有效标志")]
        public virtual bool? EnabledMark { get; set; }

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
        /// 删除时间
        /// </summary>
        [SugarColumn(ColumnDescription = "删除时间")]
        public virtual DateTime? DeleteTime { get; set; }

        /// <summary>
        /// 删除用户
        /// </summary>
        [SugarColumn(ColumnDescription = "删除用户")]
        public virtual long? DeleteUserId { get; set; }
    }
}
