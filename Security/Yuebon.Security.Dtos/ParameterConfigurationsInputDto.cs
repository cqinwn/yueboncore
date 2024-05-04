namespace Yuebon.Security.Dtos
{
    /// <summary>
    /// 系统参数配置输入对象模型
    /// </summary>
    [AutoMap(typeof(ParameterConfigurations))]
    [Serializable]
    public partial class ParameterConfigurationsInputDto: IInputDto
    {
        /// <summary>
        /// 设置或获取编号,主键
        /// </summary>
        public long? Id { get; set; }
        /// <summary>
        /// 设置或获取参数名称
        /// </summary>
        [MaxLength(255)]
        public string ParameterName { get; set; }
        /// <summary>
        /// 设置或获取参数值
        /// </summary>
        [MaxLength(500)]
        public string ParameterValue { get; set; }
        /// <summary>
        /// 设置或获取描述
        /// </summary>
        [MaxLength(500)]
        public string Description { get; set; }
        /// <summary>
        /// 设置或获取创建用户组织主键
        /// </summary>
        public long? OrganizeId { get; set; }
        /// <summary>
        /// 设置或获取创建用户部门主键
        /// </summary>
        public long? DepartmentId { get; set; }
        /// <summary>
        /// 设置或获取有效标志
        /// </summary>
        public bool? EnabledMark { get; set; }
        /// <summary>
        /// 设置或获取租户
        /// </summary>
        public long? TenantId { get; set; }

    }
}
