using System;
using System.Collections.Generic;
using System.Text;

namespace Yuebon.Security.Dtos
{
    /// <summary>
    /// 模块功能
    /// </summary>
    [Serializable]
    public class ModuleFunctionOutputDto
    {
        /// <summary>
        /// 功能Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 设置或获取  功能名称
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// 设置或获取  功能标识 S-子系统 M-标识菜单，F标识功能
        /// </summary>
        public string FunctionTag { get; set; }

        /// <summary>
        /// 设置或获取  功能标识 M-标识菜单，F标识功能
        /// </summary>
        public  List<FunctionOutputDto> listFunction{ get; set; }
        /// <summary>
        /// 子菜单
        /// </summary>
        public List<ModuleFunctionOutputDto> Children { get; set; }
    }
}
