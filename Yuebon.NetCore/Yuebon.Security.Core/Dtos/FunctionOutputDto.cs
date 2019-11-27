using System;
using System.Collections.Generic;
using System.Text;
using Yuebon.Commons.Models;

namespace Yuebon.Security.Dtos
{
    /// <summary>
    /// 输出Dto: Function功能信息
    /// </summary>
    public class FunctionOutputDto: IOutputDto
    {

        #region Property Members

        /// <summary>
        /// 按钮主键
        /// </summary>
        public virtual string Id { get; set; }

        /// <summary>
        /// 所属系统主键
        /// </summary>
        public virtual string SystemTypeId { get; set; }
        /// <summary>
        /// 所属系统名称
        /// </summary>
        public virtual string SystemTypeName { get; set; }

        /// <summary>
        /// 父级
        /// </summary>
        public virtual string ParentId { get; set; }

        /// <summary>
        /// 父级名称
        /// </summary>
        public virtual string ParentName { get; set; }

        /// <summary>
        /// 层次
        /// </summary>
        public virtual int? Layers { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        public virtual string EnCode { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public virtual string FullName { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        public virtual string Icon { get; set; }

        /// <summary>
        /// 位置
        /// </summary>
        public virtual int? Location { get; set; }

        /// <summary>
        /// 事件
        /// </summary>
        public virtual string JsEvent { get; set; }

        /// <summary>
        /// 连接
        /// </summary>
        public virtual string UrlAddress { get; set; }

        /// <summary>
        /// 分开线
        /// </summary>
        public virtual bool? Split { get; set; }

        /// <summary>
        /// 公共
        /// </summary>
        public virtual bool? IsPublic { get; set; }

        /// <summary>
        /// 允许编辑
        /// </summary>
        public virtual bool? AllowEdit { get; set; }

        /// <summary>
        /// 允许删除
        /// </summary>
        public virtual bool? AllowDelete { get; set; }

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
