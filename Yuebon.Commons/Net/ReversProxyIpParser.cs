﻿using Microsoft.AspNetCore.Http;
using System.Net;

namespace Yuebon.Commons.Net
{
    public class ReversProxyIpParser : RemoteIpParser
    {
        private readonly string _realIpHeader;

        public ReversProxyIpParser(string realIpHeader)
        {
            _realIpHeader = realIpHeader;
        }

        public override IPAddress GetClientIp(HttpContext context)
        {
            if (context.Request.Headers.Keys.Contains(_realIpHeader, StringComparer.CurrentCultureIgnoreCase))
            {
                return ParseIp(context.Request.Headers[_realIpHeader].First());
            }

            return base.GetClientIp(context);
        }
    }
}
