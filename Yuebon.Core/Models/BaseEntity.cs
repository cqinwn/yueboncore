using SqlSugar;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Yuebon.Commons.Helpers;

namespace Yuebon.Core.Models
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
        /// 获取或设置 Id，雪花Id 
        /// </summary>
        [DisplayName("Id")]
        [SugarColumn(IsPrimaryKey = true,ColumnDescription = "编号,主键", IsIdentity = false)]
        public virtual long Id { get; set; }


        /// <summary>
        /// 判断主键是否为空
        /// </summary>
        /// <returns></returns>
        public override bool KeyIsNull()
        {
            if (Id >0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 创建默认的主键值
        /// </summary>
        public override void GenerateDefaultKeyVal()
        {
            Id = IdGeneratorHelper.IdSnowflake();
        }
    }
}
