using System.Diagnostics;
using System.Reflection;

using Yuebon.Commons.Extensions;


namespace Yuebon.Commons.Reflection
{
    /// <summary>
    /// 程序集扩展操作类
    /// </summary>
    public static class AssemblyExtensions
    {
        /// <summary>
        /// 获取程序集的文件版本
        /// </summary>
        public static string GetFileVersion(this Assembly assembly)
        {
            assembly.CheckNotNull("assembly");
            FileVersionInfo info = FileVersionInfo.GetVersionInfo(assembly.Location);
            return info.FileVersion;
        }

        /// <summary>
        /// 获取程序集的产品版本
        /// </summary>
        public static string GetProductVersion(this Assembly assembly)
        {
            assembly.CheckNotNull("assembly");
            FileVersionInfo info = FileVersionInfo.GetVersionInfo(assembly.Location);
            return info.ProductVersion;
        }
    }
}