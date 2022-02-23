
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Yuebon.Commons.Core.DataManager;
using Yuebon.Commons.Helpers;
using Yuebon.Commons.Models;


namespace Yuebon.Security.Models
{
    /// <summary>
    /// 系统日志，数据实体对象
    /// </summary>
    [AppDBContext("DefaultDb")]
    [Table("Sys_Log")]
    [Serializable]
    [Comment("系统日志")]
    public class Log: LongEntity, ICreationAudited, IModificationAudited, IDeleteAudited
    { 
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
	    public Log()
		{
            this.Id = IdGeneratorHelper.IdSnowflake();
            this.EnabledMark = true;
            this.DeleteMark = false;
            this.CreatorTime = DateTime.Now;
 		}

        #region Property Members



        /// <summary>
        /// 日期
        /// </summary>
        [MaxLength(50)]
        [Comment("日期")]
        public virtual DateTime? Date { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        [MaxLength(50)]
        [Comment("用户名")]
        public virtual string Account { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [MaxLength(50)]
        [Comment("姓名")]
        public virtual string NickName { get; set; }

        /// <summary>
        /// 组织主键
        /// </summary>
        [MaxLength(50)]
        [Comment("组织主键")]
        public virtual string OrganizeId { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        [MaxLength(50)]
        [Comment("类型")]
        public virtual string Type { get; set; }

        /// <summary>
        /// IP地址
        /// </summary>
        [MaxLength(50)]
        [Comment("IP地址")]
        public virtual string IPAddress { get; set; }

        /// <summary>
        /// IP所在城市
        /// </summary
        [MaxLength(50)]
        [Comment("IP所在城市")]
        public virtual string IPAddressName { get; set; }

        /// <summary>
        /// 系统模块Id
        /// </summary>
        [MaxLength(50)]
        [Comment("系统模块Id")]
        public virtual string ModuleId { get; set; }

        /// <summary>
        /// 系统模块
        /// </summary>
        [MaxLength(50)]
        [Comment("系统模块")]
        public virtual string ModuleName { get; set; }

        /// <summary>
        /// 结果
        /// </summary>
        [Comment("结果")]
        public virtual bool? Result { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [Comment("描述")]
        public virtual string Description { get; set; }


        /// <summary>
        /// 删除标志
        /// </summary>
        [Comment("删除标志")]
        public virtual bool? DeleteMark { get; set; }

        /// <summary>
        /// 有效标志
        /// </summary>
        [Comment("有效标志")]
        public virtual bool EnabledMark { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        [Comment("创建日期")]
        public virtual DateTime? CreatorTime { get; set; }

        /// <summary>
        /// 创建用户主键
        /// </summary>
        [MaxLength(50)]
        [Comment("创建用户主键")]
        public virtual string CreatorUserId { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        [Comment("最后修改时间")]
        public virtual DateTime? LastModifyTime { get; set; }

        /// <summary>
        /// 最后修改用户
        /// </summary>
        [MaxLength(50)]
        [Comment("最后修改用户")]
        public virtual string LastModifyUserId { get; set; }

        /// <summary>
        /// 删除时间
        /// </summary>
        [Comment("删除时间")]
        public virtual DateTime? DeleteTime { get; set; }

        /// <summary>
        /// 删除用户
        /// </summary>
        [MaxLength(50)]
        [Comment("删除用户")]
        public virtual string DeleteUserId { get; set; }
        #endregion

    }
}