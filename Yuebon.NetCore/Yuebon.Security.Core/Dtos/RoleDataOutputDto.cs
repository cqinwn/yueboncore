using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Yuebon.Security.Dtos
{
    /// <summary>
    /// 输出对象模型
    /// </summary>
    [Serializable]
    public class RoleDataOutputDto
    {
        /// <summary>
        /// 设置或获取 
        /// </summary>
        [MaxLength(50)]
        public string Id { get; set; }

        /// <summary>
        /// 设置或获取 
        /// </summary>
        [MaxLength(50)]
        public string RoleId { get; set; }

        /// <summary>
        /// 设置或获取 
        /// </summary>
        [MaxLength(1073741823)]
        public string BelongCompanys { get; set; }

        /// <summary>
        /// 设置或获取 
        /// </summary>
        [MaxLength(1073741823)]
        public string BelongDepts { get; set; }

        /// <summary>
        /// 设置或获取 
        /// </summary>
        [MaxLength(1073741823)]
        public string ExcludeDepts { get; set; }

        /// <summary>
        /// 设置或获取 
        /// </summary>
        [MaxLength(1073741823)]
        public string Note { get; set; }


    }
}
