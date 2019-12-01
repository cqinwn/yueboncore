using System;
using System.Collections.Generic;
using System.Text;

namespace Yuebon.Security.Dtos
{
    /// <summary>
    /// 过滤IP
    /// </summary>
    [Serializable]
    public class FilterIPOutPutDto
    {

        #region Property Members


        public  string Id { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public  bool? Type { get; set; }

        /// <summary>
        /// 开始IP
        /// </summary>
        public  string StartIP { get; set; }

        /// <summary>
        /// 结束IP
        /// </summary>
        public  string EndIP { get; set; }

        /// <summary>
        /// 排序码
        /// </summary>
        public  int? SortCode { get; set; }


        /// <summary>
        /// 描述
        /// </summary>
        public  string Description { get; set; }
        /// <summary>
        /// 删除标志
        /// </summary>
        public  bool? DeleteMark { get; set; }

        /// <summary>
        /// 有效标志
        /// </summary>
        public  bool EnabledMark { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        public  DateTime? CreatorTime { get; set; }

        /// <summary>
        /// 创建用户主键
        /// </summary>
        public  string CreatorUserId { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        public  DateTime? LastModifyTime { get; set; }

        /// <summary>
        /// 最后修改用户
        /// </summary>
        public  string LastModifyUserId { get; set; }

        /// <summary>
        /// 删除时间
        /// </summary>
        public  DateTime? DeleteTime { get; set; }

        /// <summary>
        /// 删除用户
        /// </summary>
        public  string DeleteUserId { get; set; }


        #endregion
    }
}
