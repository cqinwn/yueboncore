using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Yuebon.Commons;
using Yuebon.Commons.Helpers;
using Yuebon.Commons.Json;
using Yuebon.Commons.Models;

namespace Yuebon.WebApp.Areas.Base
{
    public class TokenController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetAccessToken()
        {
            CommonResult result = new CommonResult();
            string appId = Configs.GetConfigurationValue("AppSetting", "AppId");
            string appSecret = Configs.GetConfigurationValue("AppSetting", "AppSecret");
            string apiUrl = Configs.GetConfigurationValue("AppSetting", "ApiUrl");
            string url = string.Format("{0}Token?grant_type=client_credential&appid={1}&secret={2}", apiUrl, appId, appSecret);
            string result1 = HttpRequestHelper.HttpGet(url);
            TokenResult tokenResult = JsonHelper.ToObject<TokenResult>(result1);
            return Content(JsonHelper.ToJson(tokenResult));
        }
    }
}