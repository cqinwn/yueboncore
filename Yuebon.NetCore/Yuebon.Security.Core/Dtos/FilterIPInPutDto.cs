using System;
using System.Collections.Generic;
using System.Text;
using Yuebon.Commons.Models;

namespace Yuebon.Security.Dtos
{
    /// <summary>
    /// 
    /// </summary>

    [Serializable]
    public class FilterIPInPutDto : IInputDto<string>
    {
        /// <summary>
        /// 
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public virtual bool? PolicyType { get; set; }

        /// <summary>
        /// 开始IP
        /// </summary>
        public virtual string StartIP { get; set; }

        /// <summary>
        /// 结束IP
        /// </summary>
        public virtual string EndIP { get; set; }

        /// <summary>
        /// 排序码
        /// </summary>
        public virtual int? SortCode { get; set; }


        /// <summary>
        /// 描述
        /// </summary>
        public virtual string Description { get; set; }
        /// <summary>
        /// 有效标志
        /// </summary>
        public virtual bool EnabledMark { get; set; }
    }
}
