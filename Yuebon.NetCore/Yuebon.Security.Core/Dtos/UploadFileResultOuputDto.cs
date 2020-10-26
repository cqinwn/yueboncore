using System;
using System.Collections.Generic;
using System.Text;
using Yuebon.Commons.Dtos;
using Yuebon.Commons.Models;

namespace Yuebon.Security.Dtos
{
    /// <summary>
    /// 上传结束输出文件对象
    /// </summary>
    [Serializable]
    public class UploadFileResultOuputDto : IOutputDto
    {
        /// <summary>
	    ///
	    /// </summary>
        public string Id { get; set; }
        /// <summary>
	    /// 文件名称
	    /// </summary>
        public string FileName { get; set; }
        /// <summary>
	    /// 文件路径物理路径
	    /// </summary>
        public string PhysicsFilePath { get; set; }
        /// <summary>
	    /// 缩略图
	    /// </summary>
        public string Thumbnail { get; set; }
        /// <summary>
	    /// 文件路径
	    /// </summary>
        public string FilePath { get; set; }
       
        /// <summary>
	    /// 文件大小
	    /// </summary>
        public long FileSize { get; set; }
        /// <summary>
	    /// 文件类型
	    /// </summary>
        public string FileType { get; set; }
        

    }
}
