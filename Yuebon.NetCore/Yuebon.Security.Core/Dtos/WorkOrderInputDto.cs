using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Yuebon.Commons.Models;
using Yuebon.Security.Models;

namespace Yuebon.Security.Dtos
{
    /// <summary>
    /// 输入对象模型
    /// </summary>
    [AutoMap(typeof(WorkOrder))]
    [Serializable]
    public class WorkOrderInputDto: IInputDto<string>
    {
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public string Category { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public string SecretContent { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public string Mobile { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public string Attachment { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public string Customer { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public string Description { get; set; }

    }
}
