using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace Yuebon.AspNetCore.Common
{
    public class VersionControllerSelector :IHttpControllerSelector
    {
        public IDictionary<string, HttpControllerDescriptor> GetControllerMapping()
        {
            throw new System.NotImplementedException();
        }

        public HttpControllerDescriptor SelectController(HttpRequestMessage request)
        {
            throw new System.NotImplementedException();
        }
    }
}
