using System;
using System.Collections.Generic;
using System.Text;
using Yuebon.Commons.Models;

namespace Yuebon.Security.Dtos
{
    /// <summary>
    /// 输出Dto:Log
    /// </summary>
    [Serializable]
    public class LogOutPutDto : IOutputDto
    {

        #region Property Members

        /// <summary>
        /// 日志主键
        /// </summary>
        public  string Id { get; set; }

        /// <summary>
        /// 日期
        /// </summary>
        public  DateTime? Date { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public  string Account { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public  string NickName { get; set; }

        /// <summary>
        /// 组织主键
        /// </summary>
        public  string OrganizeId { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public  string Type { get; set; }

        /// <summary>
        /// IP地址
        /// </summary>
        public  string IPAddress { get; set; }

        /// <summary>
        /// IP所在城市
        /// </summary>
        public  string IPAddressName { get; set; }

        /// <summary>
        /// 系统模块Id
        /// </summary>
        public  string ModuleId { get; set; }

        /// <summary>
        /// 系统模块
        /// </summary>
        public  string ModuleName { get; set; }

        /// <summary>
        /// 结果
        /// </summary>
        public  bool? Result { get; set; }

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
