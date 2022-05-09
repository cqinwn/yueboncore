using System;

namespace Yuebon.Commons.Attributes
{
    /// <summary>
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class SwaggerControllerViewAttribute : Attribute
    {
        /// <summary>
        /// 控制器名称
        /// </summary>
        public string ControllerName { get; private set; }

        /// <summary>
        /// 版本号
        /// </summary>
        public string Version { get; private set; }

        /// <summary>
        /// Swagger文档显示
        /// </summary>
        /// <param name="cName">控制器名称</param>
        /// <param name="version">版本号</param>
        public SwaggerControllerViewAttribute(string cName, string version)
        {
            ControllerName = string.IsNullOrEmpty(cName) ? "请填写控制器名称" : cName;
            Version = string.IsNullOrEmpty(version) ? "请填写版本号" : version;
        }
    }
}
