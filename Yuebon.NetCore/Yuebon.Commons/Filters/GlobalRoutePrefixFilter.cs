using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Routing;
using System.Text.RegularExpressions;
namespace Yuebon.Commons.Filters
{
    /// <summary>
    /// 全局路由前缀公约
    /// </summary>
    public class GlobalRoutePrefixFilter : IApplicationModelConvention
    {
        private readonly AttributeRouteModel _centralPrefix;

        /// <summary>
        /// 调用时传入指定的路由前缀
        /// </summary>
        /// <param name="routeTemplateProvider"></param>
        public GlobalRoutePrefixFilter(IRouteTemplateProvider routeTemplateProvider)
        {
            _centralPrefix = new AttributeRouteModel(routeTemplateProvider);
        }

        /// <summary>
        /// 接口的Apply方法
        /// </summary>
        /// <param name="application"></param>
        public void Apply(ApplicationModel application)
        {
            //遍历所有的 Controller
            foreach (var controller in application.Controllers)
            {

                var controllerNamespace = controller.ControllerType.Namespace.Split('.'); // e.g. "Controllers.V1"
                //var apiVersion = controllerNamespace.Split('.').Last().ToLower();
                var apiVersion = controllerNamespace.FirstOrDefault(x => Regex.IsMatch(x, @"^V(\d+)$"));
                if (string.IsNullOrEmpty(apiVersion))
                {
                    apiVersion = "V1";
                }
                controller.ApiExplorer.GroupName = apiVersion;
                //// 已经标记了 RouteAttribute 的 Controller
                //var matchedSelectors = controller.Selectors.Where(x => x.AttributeRouteModel != null).ToList();
                //if (matchedSelectors.Any())
                //{
                //    foreach (var selectorModel in matchedSelectors)
                //    {
                //        if (!string.IsNullOrEmpty(apiVersion))
                //        {
                //            string tm = selectorModel.AttributeRouteModel.Template;

                //            //selectorModel.AttributeRouteModel.Template = tm.Replace("{version}", apiVersion);
                //        }
                //        // 在 当前路由上 再 添加一个 路由前缀
                //        //selectorModel.AttributeRouteModel = AttributeRouteModel.CombineAttributeRouteModel(_centralPrefix,
                //            //selectorModel.AttributeRouteModel);
                //    }
                //}

                //// 没有标记 RouteAttribute 的 Controller
                //var unmatchedSelectors = controller.Selectors.Where(x => x.AttributeRouteModel == null).ToList();
                //if (unmatchedSelectors.Any())
                //{
                //    foreach (var selectorModel in unmatchedSelectors)
                //    {
                //        // 添加一个 路由前缀
                //        selectorModel.AttributeRouteModel = _centralPrefix;
                //    }
                //}
            }
        }
    }
}
