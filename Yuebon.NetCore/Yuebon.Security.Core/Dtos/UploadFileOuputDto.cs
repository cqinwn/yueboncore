using System;
using System.Collections.Generic;
using System.Text;
using Yuebon.Commons.Models;

namespace Yuebon.Security.Dtos
{
    /// <summary>
    /// 输出Dto:UploadFile
    /// </summary>
    [Serializable]
    public class UploadFileOuputDto : IOutputDto
    {

        /// <summary>
        /// Id
        /// </summary>
        public string Id { get; set; }
        /// <summary>
	    /// 文件名称
	    /// </summary>
        public string FileName { get; set; }
        /// <summary>
	    /// 文件路径
	    /// </summary>
        public string FilePath { get; set; }
        /// <summary>
	    /// 文件路径物理路径
	    /// </summary>
        public string PhysicsFilePath { get; set; }
        /// <summary>
	    /// 描述
	    /// </summary>
        public string Description { get; set; }
        /// <summary>
	    /// 文件类型
	    /// </summary>
        public string FileType { get; set; }
        /// <summary>
	    /// 文件大小
	    /// </summary>
        public long FileSize { get; set; }
        /// <summary>
	    /// 扩展名称
	    /// </summary>
        public string Extension { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int SortCode { get; set; }
        /// <summary>
        /// 删除标志
        /// </summary>
        public virtual bool? DeleteMark { get; set; }

        /// <summary>
        /// 有效标志
        /// </summary>
        public virtual bool EnabledMark { get; set; }
        /// <summary>
        /// 创建用户主键
        /// </summary>
        public virtual string CreatorUserId { get; set; }
        /// <summary>
	    /// 上传时间
	    /// </summary>
        public DateTime? CreatorTime { get; set; }
        /// <summary>
	    /// 缩略图
	    /// </summary>
        public string Thumbnail { get; set; }
        /// <summary>
	    /// 所属应用
	    /// </summary>
        public string BelongApp { get; set; }
        /// <summary>
	    /// 所属应用ID
	    /// </summary>
        public string BelongAppId { get; set; }
    }
}
