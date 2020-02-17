using System;
using System.Collections.Generic;
using System.Text;
using Yuebon.Commons.Models;

namespace Yuebon.Security.Dtos
{

    /// <summary>
    /// 数据字典 数据输出对象
    /// </summary>
    [Serializable]
    public class ItemsDetailOutputDto:IOutputDto
    {

        #region Property Members

        /// <summary>
        /// 明细主键
        /// </summary>
        public virtual string Id { get; set; }

        /// <summary>
        /// 主表主键
        /// </summary>
        public virtual string ItemId { get; set; }

        /// <summary>
        /// 父级
        /// </summary>
        public virtual string ParentId { get; set; }
        /// <summary>
        /// 父级
        /// </summary>
        public virtual string ParentName { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        public virtual string ItemCode { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public virtual string ItemName { get; set; }

        /// <summary>
        /// 简拼
        /// </summary>
        public virtual string SimpleSpelling { get; set; }

        /// <summary>
        /// 默认
        /// </summary>
        public virtual bool? IsDefault { get; set; }

        /// <summary>
        /// 层次
        /// </summary>
        public virtual int? Layers { get; set; }

        /// <summary>
        /// 排序码
        /// </summary>
        public virtual int? SortCode { get; set; }


        /// <summary>
        /// 描述
        /// </summary>
        public virtual string Description { get; set; }


        /// <summary>
        /// 删除标志
        /// </summary>
        public virtual bool? DeleteMark { get; set; }

        /// <summary>
        /// 有效标志
        /// </summary>
        public virtual bool EnabledMark { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        public virtual DateTime? CreatorTime { get; set; }

        /// <summary>
        /// 创建用户主键
        /// </summary>
        public virtual string CreatorUserId { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        public virtual DateTime? LastModifyTime { get; set; }

        /// <summary>
        /// 最后修改用户
        /// </summary>
        public virtual string LastModifyUserId { get; set; }

        /// <summary>
        /// 删除时间
        /// </summary>
        public virtual DateTime? DeleteTime { get; set; }

        /// <summary>
        /// 删除用户
        /// </summary>
        public virtual string DeleteUserId { get; set; }
        #endregion
    }
}
