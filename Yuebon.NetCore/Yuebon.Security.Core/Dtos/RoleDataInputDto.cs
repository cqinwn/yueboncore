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
    [AutoMap(typeof(RoleData))]
    [Serializable]
    public class RoleDataInputDto: IInputDto
    {
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 设置或获取 
        /// </summary>
        public string RoleId { get; set; }

        /// <summary>
        /// 类型，company-公司，dept-部门，person-个人
        /// </summary>
        public virtual string DType { get; set; }

        /// <summary>
        /// 数据数据，部门ID或个人ID
        /// </summary>
        public virtual string AuthorizeData { get; set; }

        /// <summary>
        /// 设置或获取 
        /// </summary>
        public string Note { get; set; }


    }
}
