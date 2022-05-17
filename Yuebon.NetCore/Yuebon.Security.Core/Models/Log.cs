using SqlSugar;
using System;
using System.ComponentModel.DataAnnotations;
using Yuebon.Commons.Core.DataManager;
using Yuebon.Commons.Helpers;
using Yuebon.Commons.Models;


namespace Yuebon.Security.Models
{
    /// <summary>
    /// 系统日志，数据实体对象
    /// </summary>
    [AppDBContext("DefaultDb")]
    [SugarTable("Sys_Log", "系统日志")]
    [Serializable]
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
        [SugarColumn(ColumnDescription= "日期")]
        public virtual DateTime? Date { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        [MaxLength(50)]
        [SugarColumn(ColumnDescription= "用户名")]
        public virtual string Account { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [MaxLength(50)]
        [SugarColumn(ColumnDescription= "姓名")]
        public virtual string NickName { get; set; }

        /// <summary>
        /// 组织主键
        /// </summary>
        [MaxLength(50)]
        [SugarColumn(ColumnDescription= "组织主键")]
        public virtual long? OrganizeId { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        [MaxLength(50)]
        [SugarColumn(ColumnDescription= "类型")]
        public virtual string Type { get; set; }

        /// <summary>
        /// IP地址
        /// </summary>
        [MaxLength(50)]
        [SugarColumn(ColumnDescription= "IP地址")]
        public virtual string IPAddress { get; set; }

        /// <summary>
        /// IP所在城市
        /// </summary
        [MaxLength(50)]
        [SugarColumn(ColumnDescription= "IP所在城市")]
        public virtual string IPAddressName { get; set; }

        /// <summary>
        /// 系统模块Id
        /// </summary>
        [MaxLength(50)]
        [SugarColumn(ColumnDescription= "系统模块Id")]
        public virtual string ModuleId { get; set; }

        /// <summary>
        /// 系统模块
        /// </summary>
        [MaxLength(100)]
        [SugarColumn(ColumnDescription= "系统模块",Length =100)]
        public virtual string ModuleName { get; set; }

        /// <summary>
        /// 请求
        /// </summary>
        [MaxLength(600)]
        [SugarColumn(ColumnDescription = "请求",Length =600)]
        public virtual string RequestUrl { get; set; }

        /// <summary>
        /// 浏览器
        /// </summary>
        [MaxLength(100)]
        [SugarColumn(ColumnDescription = "浏览器", Length = 100)]
        public virtual string Browser { get; set; }

        /// <summary>
        /// 操作系统
        /// </summary>
        [MaxLength(100)]
        [SugarColumn(ColumnDescription = "操作系统", Length = 100)]
        public virtual string OS { get; set; }
        /// <summary>
        /// 结果
        /// </summary>
        [SugarColumn(ColumnDescription= "结果")]
        public virtual bool? Result { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [SugarColumn(ColumnDescription= "描述",ColumnDataType ="nvarchar(4000)")]        
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