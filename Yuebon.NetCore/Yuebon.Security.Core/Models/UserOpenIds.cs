using SqlSugar;
using System.ComponentModel.DataAnnotations;
using Yuebon.Commons.Models;

namespace Yuebon.Security.Models
{
    /// <summary>
    /// 第三方登录与用户绑定表，数据实体对象
    /// </summary>
    [SugarTable("Sys_UserOpenIds", "第三方登录与用户绑定表")]
    public class UserOpenIds:BaseEntity
    {
        #region Property Members
        /// <summary>
        /// 用户编号
        /// </summary>
        [MaxLength(50)]
        [SugarColumn(ColumnDescription= "用户编号")]
        [Required]
        public virtual long UserId { get; set; }

        /// <summary>
        /// 第三方类型
        /// </summary>
        [MaxLength(200)]
        [SugarColumn(ColumnDescription= "第三方类型")]
        [Required]
        public virtual string OpenIdType { get; set; }

        /// <summary>
        /// OpenId
        /// </summary>
        [MaxLength(100)]
        [SugarColumn(ColumnDescription= "OpenId")]
        [Required]
        public virtual string OpenId { get; set; }

        #endregion

    }
}