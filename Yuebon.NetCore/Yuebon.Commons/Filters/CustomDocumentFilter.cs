using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Yuebon.Commons.Filters
{
    /// <summary>
    /// 自定义文档过滤器
    /// </summary>
    public class CustomDocumentFilter : IDocumentFilter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="swaggerDoc">文档</param>
        /// <param name="context"></param>
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {

            //多版本接口名修正
            var match = new OpenApiPaths();
            foreach (var apiDesc in context.ApiDescriptions)
            {
                var key = "/" + apiDesc.RelativePath;
                if (!swaggerDoc.Paths.ContainsKey(key)) continue;//swaggerDoc.paths是当前选择版本的接口，例：v1

                ControllerActionDescriptor actionDescriptor = (ControllerActionDescriptor)apiDesc.ActionDescriptor;
                var controllerName = actionDescriptor.ControllerName;
                var actionName = actionDescriptor.ActionName;
                if (!string.IsNullOrEmpty(controllerName) && !string.IsNullOrEmpty(actionName))
                {
                    var t = Type.GetType(actionDescriptor.ControllerTypeInfo.Namespace + "." + controllerName);
                    if (t != null)
                    {
                        var baseControllerName = t.GetMethod(actionName).DeclaringType.Name;
                        if (controllerName != baseControllerName)
                        {
                            if (key.Contains("?"))
                                key = key.Substring(0, key.IndexOf("?", StringComparison.Ordinal));
                            swaggerDoc.Paths.Remove(key);//移除继承的Action，避免文档中重复展示
                        }
                    }
                }

                var path = swaggerDoc.Paths.FirstOrDefault(o => o.Key == key);
                var lsXG = path.Key.Split('/');
                var index = Array.IndexOf(lsXG, controllerName);
                string vc = lsXG.FirstOrDefault<string>(controllerName);
                var lsXXG = lsXG[index].Split('_');
                if (lsXXG.Count() == 4)
                {
                    match.Add(path.Key.Replace(lsXG[index], lsXXG[0]) + "?version=v" + lsXXG[1] + "." + lsXXG[2] + "." + lsXXG[3], path.Value);
                }
                else
                {
                    match.Add(path.Key, path.Value);
                }

            }
            swaggerDoc.Paths = match;
        }
    }
}
