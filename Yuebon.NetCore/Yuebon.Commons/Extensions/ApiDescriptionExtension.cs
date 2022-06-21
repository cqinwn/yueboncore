using Microsoft.AspNetCore.Mvc.ApiExplorer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Yuebon.Commons.Extensions
{
    /// <summary>
    /// API描述器扩展
    /// </summary>
    public static class ApiDescriptionExtension
    {
        /// <summary>
        /// 获取区域名称
        /// </summary>
        /// <param name="description"></param>
        /// <returns></returns>
        public static List<string> GetAreaName(this ApiDescription description)
        {
            string areaName = description.ActionDescriptor.RouteValues["area"];
            string controlName = description.ActionDescriptor.RouteValues["controller"];
            List<string> areaList = new List<string>();
            areaList.Add(controlName);
            if (!string.IsNullOrEmpty(areaName))
            {
                description.RelativePath = $"api/{areaName}/{controlName}/{description.RelativePath}";
            }
            return areaList;
        }
    }
}
