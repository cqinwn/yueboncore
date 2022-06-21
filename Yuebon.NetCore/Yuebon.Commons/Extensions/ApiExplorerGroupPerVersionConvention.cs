using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yuebon.Commons.Extensions
{
    public class ApiExplorerGroupPerVersionConvention : IControllerModelConvention
    {
        public void Apply(ControllerModel controller)
        {
            //var controllerNamespace = controller.ControllerType.Namespace; // e.g. "Controllers.V1"
            //var apiVersion = controllerNamespace.Split('.').Last().ToLower();

            //controller.ApiExplorer.GroupName = apiVersion;
        }
    }
}
