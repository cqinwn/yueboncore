using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Yuebon.Commons.Dtos;
using Yuebon.Commons.Models;
using Yuebon.Security.Models;

namespace Yuebon.Security.Dtos
{
    /// <summary>
    /// 输入对象模型
    /// </summary>
    [AutoMap(typeof(UploadFile))]
    [Serializable]
    public class UploadFileInputDto: IInputDto<string>
    {
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 设置或获取 
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// 设置或获取 
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// 设置或获取 
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 设置或获取 
        /// </summary>
        public string FileType { get; set; }

        /// <summary>
        /// 设置或获取 
        /// </summary>
        public int? FileSize { get; set; }

        /// <summary>
        /// 设置或获取 
        /// </summary>
        public string Extension { get; set; }

        /// <summary>
        /// 设置或获取 
        /// </summary>
        public bool EnabledMark { get; set; }

        /// <summary>
        /// 设置或获取 
        /// </summary>
        public int SortCode { get; set; }

        /// <summary>
        /// 设置或获取 
        /// </summary>
        public string CreateUserName { get; set; }

        /// <summary>
        /// 设置或获取 
        /// </summary>
        public string Thumbnail { get; set; }

        /// <summary>
        /// 设置或获取 
        /// </summary>
        public string BelongApp { get; set; }

        /// <summary>
        /// 设置或获取 
        /// </summary>
        public string BelongAppId { get; set; }


    }
}
