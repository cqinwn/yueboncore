using SqlSugar;
using System;
using System.ComponentModel.DataAnnotations;
using Yuebon.Commons.Models;

namespace Yuebon.Security.Models
{
    /// <summary>
    /// 数据库备份，数据实体对象
    /// </summary>

    [SugarTable("Sys_DbBackup","数据库备份记录")]
    [Serializable]
    public class DbBackup : BaseEntity, ICreationAudited, IModificationAudited, IDeleteAudited
    { 
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
	    public DbBackup()
		{

 		}

        #region Property Members
        /// <summary>
        /// 备份类型
        /// </summary>
        [SugarColumn(ColumnDescription= "备份类型")]
        [MaxLength(50)]
        [Required]
        public virtual string BackupType { get; set; }

        /// <summary>
        /// 数据库名称
        /// </summary>
        [SugarColumn(ColumnDescription= "数据库名称")]
        [MaxLength(50)]
        [Required]
        public virtual string DbName { get; set; }

        /// <summary>
        /// 文件名称
        /// </summary>
        [SugarColumn(ColumnDescription= "文件名称")]
        [MaxLength(254)]
        [Required]
        public virtual string FileName { get; set; }

        /// <summary>
        /// 文件大小
        /// </summary>
        [SugarColumn(ColumnDescription= "文件大小")]
        [MaxLength(50)]
        public virtual string FileSize { get; set; }

        /// <summary>
        /// 文件路径
        /// </summary>
        [SugarColumn(ColumnDescription= "文件路径")]
        [MaxLength(254)]
        public virtual string FilePath { get; set; }

        /// <summary>
        /// 备份时间
        /// </summary>
        [SugarColumn(ColumnDescription= "备份时间")]
        public virtual DateTime? BackupTime { get; set; }

        /// <summary>
        /// 排序码
        /// </summary>
        [SugarColumn(ColumnDescription= "排序码")]
        public virtual int? SortCode { get; set; }


        /// <summary>
        /// 描述
        /// </summary>
        [SugarColumn(ColumnDescription= "描述")]
        [MaxLength(500)]
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