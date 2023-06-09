namespace Yuebon.TMS.Models
{
    /// <summary>
    /// 运输计划，数据实体对象
    /// </summary>

    [SugarTable("tms_transportplan", "运输计划")]
    [Serializable]
    public partial class Transportplan:BaseEntity, ICreationAudited, IModificationAudited, IDeleteAudited
    {
        /// <summary>
        /// 设置或获取运输计划单号
        /// </summary>
        [MaxLength(100)]
        [SugarColumn(ColumnDescription="运输计划单号")]
        public string TransportNo { get; set; }

        /// <summary>
        /// 设置或获取原单号
        /// </summary>
        [MaxLength(255)]
        [SugarColumn(ColumnDescription="原单号")]
        public string OrderSourceID { get; set; }

        /// <summary>
        /// 设置或获取订单类型
        /// </summary>
        [MaxLength(255)]
        [SugarColumn(ColumnDescription="订单类型")]
        public string OrderProperty { get; set; }

        /// <summary>
        /// 设置或获取
        /// </summary>
        [MaxLength(255)]
        [SugarColumn(ColumnDescription="")]
        public string PromotionID { get; set; }

        /// <summary>
        /// 设置或获取计划发货时间
        /// </summary>
        [SugarColumn(ColumnDescription="计划发货时间")]
        public DateTime? PlanReceiptdate { get; set; }

        /// <summary>
        /// 设置或获取实际发货时间
        /// </summary>
        [SugarColumn(ColumnDescription="实际发货时间")]
        public DateTime? Receiptdate { get; set; }

        /// <summary>
        /// 设置或获取仓库Id
        /// </summary>
        [MaxLength(255)]
        [SugarColumn(ColumnDescription="仓库Id")]
        public string WareHoseID { get; set; }

        /// <summary>
        /// 设置或获取仓库名称
        /// </summary>
        [MaxLength(255)]
        [SugarColumn(ColumnDescription="仓库名称")]
        public string WareHoseName { get; set; }

        /// <summary>
        /// 设置或获取承运商ID
        /// </summary>
        [MaxLength(255)]
        [SugarColumn(ColumnDescription="承运商ID")]
        public string ShipperID { get; set; }

        /// <summary>
        /// 设置或获取承运商名称
        /// </summary>
        [MaxLength(255)]
        [SugarColumn(ColumnDescription="承运商名称")]
        public string ShipperName { get; set; }

        /// <summary>
        /// 设置或获取客户Id
        /// </summary>
        [MaxLength(255)]
        [SugarColumn(ColumnDescription="客户Id")]
        public string CustomerID { get; set; }

        /// <summary>
        /// 设置或获取客户名称
        /// </summary>
        [MaxLength(255)]
        [SugarColumn(ColumnDescription="客户名称")]
        public string CustomerName { get; set; }

        /// <summary>
        /// 设置或获取客户简称
        /// </summary>
        [MaxLength(255)]
        [SugarColumn(ColumnDescription="客户简称")]
        public string CustomerSimapleName { get; set; }

        /// <summary>
        /// 设置或获取联系人
        /// </summary>
        [MaxLength(255)]
        [SugarColumn(ColumnDescription="联系人")]
        public string Contact { get; set; }

        /// <summary>
        /// 设置或获取省份
        /// </summary>
        [MaxLength(255)]
        [SugarColumn(ColumnDescription="省份")]
        public string Province { get; set; }

        /// <summary>
        /// 设置或获取城市
        /// </summary>
        [MaxLength(255)]
        [SugarColumn(ColumnDescription="城市")]
        public string City { get; set; }

        /// <summary>
        /// 设置或获取县区
        /// </summary>
        [MaxLength(255)]
        [SugarColumn(ColumnDescription="县区")]
        public string District { get; set; }

        /// <summary>
        /// 设置或获取详细地址
        /// </summary>
        [MaxLength(255)]
        [SugarColumn(ColumnDescription="详细地址")]
        public string Address { get; set; }

        /// <summary>
        /// 设置或获取电话
        /// </summary>
        [MaxLength(255)]
        [SugarColumn(ColumnDescription="电话")]
        public string Telphone { get; set; }

        /// <summary>
        /// 设置或获取手机号
        /// </summary>
        [MaxLength(255)]
        [SugarColumn(ColumnDescription="手机号")]
        public string Mobile { get; set; }

        /// <summary>
        /// 设置或获取预计件数
        /// </summary>
        [SugarColumn(ColumnDescription = "预计件数")]
        public decimal? TotalNumber { get; set; }

        /// <summary>
        /// 设置或获取总体积
        /// </summary>
        [SugarColumn(ColumnDescription="总体积")]
        public decimal? TotalVolume { get; set; }

        /// <summary>
        /// 设置或获取总重量
        /// </summary>
        [SugarColumn(ColumnDescription="总重量")]
        public decimal? TotalWeight { get; set; }

        /// <summary>
        /// 设置或获取说明
        /// </summary>
        [MaxLength(255)]
        [SugarColumn(ColumnDescription="说明")]
        public string Note { get; set; }

        /// <summary>
        /// 设置或获取装载车牌号
        /// </summary>
        [MaxLength(255)]
        [SugarColumn(ColumnDescription="装载车牌号")]
        public string EntruckingCarNumber { get; set; }

        /// <summary>
        /// 设置或获取打印次数
        /// </summary>
        [SugarColumn(ColumnDescription="打印次数")]
        public int? PrintCount { get; set; }

        /// <summary>
        /// 设置或获取状态
        /// </summary>
        [MaxLength(255)]
        [SugarColumn(ColumnDescription="状态")]
        public string Status { get; set; }

        /// <summary>
        /// 设置或获取是否可用
        /// </summary>
        [SugarColumn(ColumnDescription="是否可用")]
        public bool? EnabledMark { get; set; }

        /// <summary>
        /// 设置或获取删除标记
        /// </summary>
        [SugarColumn(ColumnDescription="删除标记")]
        public bool? DeleteMark { get; set; }

        /// <summary>
        /// 设置或获取创建时间
        /// </summary>
        [SugarColumn(ColumnDescription="创建时间")]
        public DateTime? CreatorTime { get; set; }

        /// <summary>
        /// 设置或获取创建人Id
        /// </summary>
        [SugarColumn(ColumnDescription="创建人Id")]
        public long? CreatorUserId { get; set; }

        /// <summary>
        /// 设置或获取公司
        /// </summary>
        [SugarColumn(ColumnDescription="公司")]
        public long? CompanyId { get; set; }

        /// <summary>
        /// 设置或获取部门
        /// </summary>
        [SugarColumn(ColumnDescription="部门")]
        public long? DeptId { get; set; }

        /// <summary>
        /// 设置或获取上一次修改时间
        /// </summary>
        [SugarColumn(ColumnDescription="上一次修改时间")]
        public DateTime? LastModifyTime { get; set; }

        /// <summary>
        /// 设置或获取上一次修改人ID
        /// </summary>
        [SugarColumn(ColumnDescription="上一次修改人ID")]
        public long? LastModifyUserId { get; set; }

        /// <summary>
        /// 设置或获取删除时间
        /// </summary>
        [SugarColumn(ColumnDescription="删除时间")]
        public DateTime? DeleteTime { get; set; }

        /// <summary>
        /// 设置或获取删除人ID
        /// </summary>
        [SugarColumn(ColumnDescription="删除人ID")]
        public long? DeleteUserId { get; set; }

        /// <summary>
        /// 设置或获取租户
        /// </summary>
        [SugarColumn(ColumnDescription="租户")]
        public long? TenantId { get; set; }


    }
}
