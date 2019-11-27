using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Yuebon.Commons.Models;

namespace Yuebon.Security.Models
{
    /// <summary>
    /// 数据库备份，数据实体对象
    /// </summary>

    [Table("Sys_DbBackup")]
    [Serializable]
    public class DbBackup : BaseEntity<string>, ICreationAudited, IModificationAudited, IDeleteAudited
    { 
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
	    public DbBackup()
		{
            //this.Id= System.Guid.NewGuid().ToString();

 		}

        #region Property Members

        /// <summary>
        /// 备份主键
        /// </summary>
        //[ExplicitKey]
        //public virtual string Id { get; set; }

        /// <summary>
        /// 备份类型
        /// </summary>
        public virtual string BackupType { get; set; }

        /// <summary>
        /// 数据库名称
        /// </summary>
        public virtual string DbName { get; set; }

        /// <summary>
        /// 文件名称
        /// </summary>
        public virtual string FileName { get; set; }

        /// <summary>
        /// 文件大小
        /// </summary>
        public virtual string FileSize { get; set; }

        /// <summary>
        /// 文件路径
        /// </summary>
        public virtual string FilePath { get; set; }

        /// <summary>
        /// 备份时间
        /// </summary>
        public virtual DateTime? BackupTime { get; set; }

        /// <summary>
        /// 排序码
        /// </summary>
        public virtual int? SortCode { get; set; }


        /// <summary>
        /// 描述
        /// </summary>
        public virtual string Description { get; set; }


        /// <summary>
        /// 删除标志
        /// </summary>
        public virtual bool? DeleteMark { get; set; }

        /// <summary>
        /// 有效标志
        /// </summary>
        public virtual bool EnabledMark { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        public virtual DateTime? CreatorTime { get; set; }

        /// <summary>
        /// 创建用户主键
        /// </summary>
        [MaxLength(50)]
        public virtual string CreatorUserId { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        public virtual DateTime? LastModifyTime { get; set; }

        /// <summary>
        /// 最后修改用户
        /// </summary>
        [MaxLength(50)]
        public virtual string LastModifyUserId { get; set; }

        /// <summary>
        /// 删除时间
        /// </summary>
        public virtual DateTime? DeleteTime { get; set; }

        /// <summary>
        /// 删除用户
        /// </summary>
        [MaxLength(50)]
        public virtual string DeleteUserId { get; set; }
        #endregion

    }
}