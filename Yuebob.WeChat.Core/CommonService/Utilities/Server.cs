using Senparc.CO2NET.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace Yuebon.WeChat.CommonService.Utilities
{
    public static class Server
    {
        public static HttpContext HttpContext
        {
            get
            {
                HttpContext context = new DefaultHttpContext();
                return context;
            }
        }
    }
}
