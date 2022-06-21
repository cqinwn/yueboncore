using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System.Linq;
using System.Text.RegularExpressions;

namespace Yuebon.AspNetCore.Common
{
    /// <summary>
    /// 
    /// </summary>
    public class NameSpaceVersionRoutingConvention : IApplicationModelConvention
    {
        /// <summary>
        /// 定义一个路由前缀变量
        /// </summary>
        private readonly string apiPrefix;
        private const string urlTemplate = "{0}/{1}/{2}";
        /// <summary>
        /// 调用时传入指定的路由前缀
        /// </summary>
        /// <param name="apiPrefix">前缀</param>
        public NameSpaceVersionRoutingConvention(string apiPrefix = "api")
        {
            this.apiPrefix = apiPrefix;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="application"></param>
        public void Apply(ApplicationModel application)
        {
            foreach (var controller in application.Controllers)
            {

                var hasRouteAttribute = controller.Selectors
                .Any(x => x.AttributeRouteModel != null);
                if (!hasRouteAttribute)
                {
                    continue;
                }
                var nameSpaces = controller.ControllerType.Namespace.Split('.');

                //获取namespace中版本号部分
                var version = nameSpaces.FirstOrDefault(x => Regex.IsMatch(x, @"^v(\d+)$"));
                if (string.IsNullOrEmpty(version))
                {
                    continue;
                }
                string template = string.Format(urlTemplate, apiPrefix, version,
                controller.ControllerName);
                controller.Selectors[0].AttributeRouteModel = new AttributeRouteModel()
                {
                    Template = template
                };
            }
        }
    }
}
