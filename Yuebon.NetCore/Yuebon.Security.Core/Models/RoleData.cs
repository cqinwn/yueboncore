using SqlSugar;
using System.ComponentModel.DataAnnotations;
using Yuebon.Commons.Models;

namespace Yuebon.Security.Models
{
    /// <summary>
    /// 角色的数据权限，数据实体对象
    /// </summary>
    [SugarTable("Sys_RoleData", "角色的数据权限")]
    public class RoleData:BaseEntity
    { 
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
	    public RoleData()
        {
            
        }

        #region Property Members

        /// <summary>
        /// 角色ID
        /// </summary>
        [MaxLength(50)]
        [SugarColumn(ColumnDescription= "角色ID")]
        [Required]
        public virtual long RoleId { get; set; }

        /// <summary>
        /// 类型，company-公司，dept-部门，person-个人
        /// </summary>
        [MaxLength(50)]
        [SugarColumn(ColumnDescription= "类型，company-公司，dept-部门，person-个人")]
        [Required]
        public virtual string DType { get; set; }

        /// <summary>
        /// 数据数据，部门ID或个人ID
        /// </summary>
        [MaxLength(50)]
        [SugarColumn(ColumnDescription= "数据数据，部门ID或个人ID")]
        [Required]
        public virtual long AuthorizeData { get; set; }



        #endregion

    }
}