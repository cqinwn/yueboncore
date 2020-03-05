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
    public class LogInPutDto : IInputDto<string>
    {

        /// <summary>
        /// 
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 日期
        /// </summary>
        public virtual DateTime? Date { get; set; }
        /// <summary>
        /// 组织主键
        /// </summary>
        public virtual string OrganizeId { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public virtual string Account { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public virtual string NickName { get; set; }

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
        /// 创建日期
        /// </summary>
        public virtual DateTime? CreatorTime { get; set; }

        /// <summary>
        /// 创建用户主键
        /// </summary>
        public virtual string CreatorUserId { get; set; }

    }
}
