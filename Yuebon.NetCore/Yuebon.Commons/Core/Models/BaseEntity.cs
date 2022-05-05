using Microsoft.EntityFrameworkCore;
using SqlSugar;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Yuebon.Commons.Helpers;

namespace Yuebon.Commons.Models
{
    /// <summary>
    /// 定义领域对象框架实体类的基类，系统默认主键为Id
    /// </summary>

    [Serializable]
    public abstract class BaseEntity:Entity,IBaseEntity
    {
        /// <summary>
        /// 
        /// </summary>
        protected BaseEntity()
        {
        }

        /// <summary>
        /// 获取或设置 编号
        /// </summary>
        [DisplayName("编号")]
        [Key]
        [Column("Id")]
        [Comment("主键")]
        [SugarColumn(IsPrimaryKey = true)]
        [MaxLength(50)]
        public virtual string Id { get; set; }


        /// <summary>
        /// 判断主键是否为空
        /// </summary>
        /// <returns></returns>
        public override bool KeyIsNull()
        {
            if (Id == null)
            {
                return true;
            }
            else
            {
                return string.IsNullOrEmpty(Id.ToString());
            }
        }

        /// <summary>
        /// 创建默认的主键值
        /// </summary>
        public override void GenerateDefaultKeyVal()
        {
           Id = GuidUtils.CreateNo();
        }
    }
}
