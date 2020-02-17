using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Yuebon.AspNetCore.Common
{
    /// <summary>
    /// 定义常用功能的控制ID，方便基类控制器对用户权限的控制
    /// </summary>
    [DataContract]
    [Serializable]
    public class AuthorizeKey
    {
        #region 常规功能控制ID
        /// <summary>
        /// 新增记录的功能控制ID
        /// </summary>
        public string InsertKey { get; set; }

        /// <summary>
        /// 更新记录的功能控制ID
        /// </summary>
        public string UpdateKey { get; set; }
        /// <summary>
        /// 启用/禁用记录的功能控制ID
        /// </summary>
        public string UpdateEnableKey { get; set; }
        /// <summary>
        /// 禁用记录的功能控制ID
        /// </summary>
        public string UpdateIsEnableKey { get; set; }

        /// <summary>
        /// 启用记录的功能控制ID
        /// </summary>
        public string UpdateNoEnableKey { get; set; }
        /// <summary>
        /// 删除记录的功能控制ID
        /// </summary>
        public string DeleteKey { get; set; }

        /// <summary>
        /// 软删除记录的功能控制ID
        /// </summary>
        public string DeleteSoftKey { get; set; }

        /// <summary>
        /// 查看列表的功能控制ID
        /// </summary>
        public string ListKey { get; set; }

        /// <summary>
        /// 查看明细的功能控制ID
        /// </summary>
        public string ViewKey { get; set; }

        /// <summary>
        /// 导出记录的功能控制ID
        /// </summary>
        public string ExportKey { get; set; }
        /// <summary>
        /// 导入记录的功能控制ID
        /// </summary>
        public string ImportKey { get; set; }

        /// <summary>
        /// 扩展的功能控制IDS
        /// </summary>
        public string ExtendKey { get; set; }
        #endregion

        #region 常规权限判断
        /// <summary>
        /// 判断是否具有插入权限
        /// </summary>
        public bool CanInsert { get; set; }

        /// <summary>
        /// 判断是否具有更新权限
        /// </summary>
        public bool CanUpdate { get; set; }

        /// <summary>
        /// 判断是否具有启用/禁用权限
        /// </summary>
        public bool CanUpdateEnable { get; set; }
        /// <summary>
        /// 判断是否具有禁用权限
        /// </summary>
        public bool CanUpdateIsEnable { get; set; }
        /// <summary>
        /// 判断是否具有启用权限
        /// </summary>
        public bool CanUpdateNoEnable { get; set; }
        /// <summary>
        /// 判断是否具有删除权限
        /// </summary>
        public bool CanDelete { get; set; }

        /// <summary>
        /// 判断是否具有软删除权限
        /// </summary>
        public bool CanDeleteSoft { get; set; }
        /// <summary>
        /// 判断是否具有列表权限
        /// </summary>
        public bool CanList { get; set; }

        /// <summary>
        /// 判断是否具有查看权限
        /// </summary>
        public bool CanView { get; set; }

        /// <summary>
        /// 判断是否具有导出权限
        /// </summary>
        public bool CanExport { get; set; }
        /// <summary>
        /// 判断是否具有导入权限
        /// </summary>
        public bool CanImport { get; set; }
        /// <summary>
        /// 判断是否具有扩展功能权限
        /// </summary>
        public bool CanExtend { get; set; }

        #endregion

        /// <summary>
        /// 默认构造函数
        /// </summary>
        public AuthorizeKey() { }

        /// <summary>
        /// 常用构造函数
        /// </summary>
        public AuthorizeKey(string insert, string update, string delete, string view = "")
        {
            this.InsertKey = insert;
            this.UpdateKey = update;
            this.DeleteKey = delete;
            this.ViewKey = view;
        }
        /// <summary>
        /// 常用构造函数
        /// </summary>
        public AuthorizeKey(string insert, string update, string delete, string deletesoft, string updateenable, string import, string view = "")
        {
            this.InsertKey = insert;
            this.UpdateKey = update;
            this.DeleteKey = delete;
            this.UpdateEnableKey = updateenable;
            this.DeleteSoftKey = deletesoft;
            this.ImportKey = import;
            this.ViewKey = view;
        }
    }
}
