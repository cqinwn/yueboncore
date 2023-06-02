using SqlSugar;

namespace Yuebon.TMS.Dtos
{
    /// <summary>
    /// 运输计划输入对象模型
    /// </summary>
    [AutoMap(typeof(Transportplan))]
    [Serializable]
    public partial class TransportplanInputDto: IInputDto
    {
        /// <summary>
        /// 设置或获取主键
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// 设置或获取运输计划单号
        /// </summary>
        [MaxLength(100)]
        public string TransportNo { get; set; }

        /// <summary>
        /// 设置或获取原单号
        /// </summary>
        [MaxLength(255)]
        public string OrderSourceID { get; set; }

        /// <summary>
        /// 设置或获取订单类型
        /// </summary>
        [MaxLength(255)]
        public string OrderProperty { get; set; }

        /// <summary>
        /// 设置或获取
        /// </summary>
        [MaxLength(255)]
        public string PromotionID { get; set; }

        /// <summary>
        /// 设置或获取计划发货时间
        /// </summary>
        public DateTime? PlanReceiptdate { get; set; }

        /// <summary>
        /// 设置或获取实际发货时间
        /// </summary>
        public DateTime? Receiptdate { get; set; }

        /// <summary>
        /// 设置或获取仓库Id
        /// </summary>
        [MaxLength(255)]
        public string WareHoseID { get; set; }

        /// <summary>
        /// 设置或获取仓库名称
        /// </summary>
        [MaxLength(255)]
        public string WareHoseName { get; set; }

        /// <summary>
        /// 设置或获取承运商ID
        /// </summary>
        [MaxLength(255)]
        public string ShipperID { get; set; }

        /// <summary>
        /// 设置或获取承运商名称
        /// </summary>
        [MaxLength(255)]
        public string ShipperName { get; set; }

        /// <summary>
        /// 设置或获取客户Id
        /// </summary>
        [MaxLength(255)]
        public string CustomerID { get; set; }

        /// <summary>
        /// 设置或获取客户名称
        /// </summary>
        [MaxLength(255)]
        public string CustomerName { get; set; }

        /// <summary>
        /// 设置或获取客户简称
        /// </summary>
        [MaxLength(255)]
        public string CustomerSimapleName { get; set; }

        /// <summary>
        /// 设置或获取联系人
        /// </summary>
        [MaxLength(255)]
        public string Contact { get; set; }

        /// <summary>
        /// 设置或获取省份
        /// </summary>
        [MaxLength(255)]
        public string Province { get; set; }

        /// <summary>
        /// 设置或获取城市
        /// </summary>
        [MaxLength(255)]
        public string City { get; set; }

        /// <summary>
        /// 设置或获取县区
        /// </summary>
        [MaxLength(255)]
        public string District { get; set; }

        /// <summary>
        /// 设置或获取详细地址
        /// </summary>
        [MaxLength(255)]
        public string Address { get; set; }

        /// <summary>
        /// 设置或获取电话
        /// </summary>
        [MaxLength(255)]
        public string Telphone { get; set; }

        /// <summary>
        /// 设置或获取手机号
        /// </summary>
        [MaxLength(255)]
        public string Mobile { get; set; }

        /// <summary>
        /// 设置或获取预计件数
        /// </summary>
        [SugarColumn(ColumnDescription = "预计件数")]
        public int? TotalNumber { get; set; }

        /// <summary>
        /// 设置或获取总体积
        /// </summary>
        public decimal? TotalVolume { get; set; }

        /// <summary>
        /// 设置或获取总重量
        /// </summary>
        public decimal? TotalWeight { get; set; }

        /// <summary>
        /// 设置或获取说明
        /// </summary>
        [MaxLength(255)]
        public string Note { get; set; }

        /// <summary>
        /// 设置或获取装载车牌号
        /// </summary>
        [MaxLength(255)]
        public string EntruckingCarNumber { get; set; }

        /// <summary>
        /// 设置或获取打印次数
        /// </summary>
        public int? PrintCount { get; set; }

        /// <summary>
        /// 设置或获取状态
        /// </summary>
        [MaxLength(255)]
        public string Status { get; set; }

        /// <summary>
        /// 设置或获取是否可用
        /// </summary>
        public bool? EnabledMark { get; set; }

        /// <summary>
        /// 设置或获取租户
        /// </summary>
        public long? TenantId { get; set; }


    }
}
