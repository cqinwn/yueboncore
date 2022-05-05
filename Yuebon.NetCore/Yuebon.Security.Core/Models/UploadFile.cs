
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Yuebon.Commons.Models;
using Yuebon.Commons.Helpers;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using SqlSugar;

namespace Yuebon.Security.Models
{
    /// <summary>
	/// 用户上传附件管理，文件、图片等
	/// </summary>
    [SugarTable("Sys_UploadFile")]
    [Comment("用户上传附件管理")]
    public class UploadFile : BaseEntity, ICreationAudited
    {
        /// <summary>
        /// 
        /// </summary>
        public UploadFile()
        {
            this.Id = GuidUtils.CreateNo();
            this.FileName = string.Empty;
            this.FilePath = string.Empty;
            this.Description = string.Empty;
            this.FileType = string.Empty;
            this.Extension = string.Empty;
            this.SortCode = 0;
            this.CreatorTime = DateTime.Now;
            this.Thumbnail = string.Empty;
            this.BelongApp = string.Empty;
            this.BelongAppId = string.Empty;
            this.EnabledMark = true;
            this.DeleteMark = false;
        }

        /// <summary>
	    /// 文件名称
	    /// </summary>
        [MaxLength(200)]
        [Comment("文件名称")]
        [Required]
        [Column(TypeName = "NVARCHAR(200)")]
        public string FileName { get; set; }
        /// <summary>
	    /// 文件路径
	    /// </summary>
        [MaxLength(500)]
        [Comment("文件路径")]
        [Required]
        [Unicode(true)]
        [Column(TypeName = "NVARCHAR(500)")]
        public string FilePath { get; set; }
        /// <summary>
	    /// 描述
	    /// </summary>
        [MaxLength(500)]
        [Comment("描述")]
        [Unicode(true)]
        public string Description { get; set; }
        /// <summary>
	    /// 文件类型
	    /// </summary>
        [MaxLength(20)]
        [Comment("文件类型")]
        [Column(TypeName = "NVARCHAR(20)")]
        public string FileType { get; set; }
        /// <summary>
	    /// 文件大小
	    /// </summary>
        [Comment("文件大小")]
        public int FileSize { get; set; }
        /// <summary>
	    /// 扩展名称
	    /// </summary>
        [MaxLength(20)]
        [Comment("扩展名称")]
        [Column(TypeName = "NVARCHAR(20)")]
        public string Extension { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        [Comment("排序")]
        public int SortCode { get; set; }
        /// <summary>
        /// 删除标志
        /// </summary>
        [Comment("删除标志")]
        public virtual bool? DeleteMark { get; set; }

        /// <summary>
        /// 有效标志
        /// </summary>
        [Comment("有效标志")]
        public virtual bool? EnabledMark { get; set; }
        /// <summary>
        /// 创建用户主键
        /// </summary>
        [MaxLength(50)]
        [Comment("创建用户主键")]
        public virtual string CreatorUserId { get; set; }
        /// <summary>
	    /// 上传时间
	    /// </summary>
        [Comment("上传时间")]
        public DateTime? CreatorTime { get; set; }
        /// <summary>
	    /// 缩略图
	    /// </summary>
        [MaxLength(500)]
        [Comment("缩略图")]
        [Column(TypeName =("NVARCHAR(500)"))]
        public string Thumbnail { get; set; }
        /// <summary>
	    /// 所属应用
	    /// </summary>
        [MaxLength(200)]
        [Comment("所属应用")]
        public string BelongApp { get; set; }
        /// <summary>
	    /// 所属应用ID
	    /// </summary>
        [MaxLength(50)]
        [Comment("所属应用ID")]
        public string BelongAppId { get; set; }
    }
}
