
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
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
    public class Log: BaseEntity<string>, ICreationAudited, IModificationAudited, IDeleteAudited
    { 
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
	    public Log()
		{
            this.Id = GuidUtils.CreateNo();
            this.EnabledMark = true;
            this.DeleteMark = false;
            this.CreatorTime = DateTime.Now;
 		}

        #region Property Members

       

        /// <summary>
        /// 日期
        /// </summary>
        public virtual DateTime? Date { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public virtual string Account { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public virtual string NickName { get; set; }

        /// <summary>
        /// 组织主键
        /// </summary>
        public virtual string OrganizeId { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public virtual string Type { get; set; }

        /// <summary>
        /// IP地址
        /// </summary>
        public virtual string IPAddress { get; set; }

        /// <summary>
        /// IP所在城市
        /// </summary>
        public virtual string IPAddressName { get; set; }

        /// <summary>
        /// 系统模块Id
        /// </summary>
        public virtual string ModuleId { get; set; }

        /// <summary>
        /// 系统模块
        /// </summary>
        public virtual string ModuleName { get; set; }

        /// <summary>
        /// 结果
        /// </summary>
        public virtual bool? Result { get; set; }

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