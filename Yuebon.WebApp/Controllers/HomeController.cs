using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using Yuebon.Commons;
using Yuebon.Commons.Cache;
using Yuebon.Commons.Helpers;
using Yuebon.Commons.Json;
using Yuebon.Security.Application;
using Yuebon.Security.Dtos;
using Yuebon.Security.IServices;
using Yuebon.Security.Models;

namespace Yuebon.WebApp.Controllers
{
    public class HomeController : BusinessController<User, UserOutputDto, IUserService,string>
    {
        public HomeController(IUserService _iService) : base(_iService)
        {
        }

        public override IActionResult Index()
        {
            if (CurrentUser==null)
            {
                return Redirect("/");
            }
            YuebonCacheHelper yuebonCacheHelper = new YuebonCacheHelper();
            SysSetting sysSetting= JsonConvert.DeserializeObject<SysSetting>(yuebonCacheHelper.Get("SysSetting").ToJson()); ;
            ViewData["Account"] = CurrentUser.Account;
            ViewData["RealName"] = CurrentUser.RealName;
            ViewData["UserName"] = string.Format("{0}({1})", CurrentUser.RealName, CurrentUser.Account);
            ViewData["SoftName"] = sysSetting.SoftName;
            ViewData["CertificatedCompany"] = sysSetting.CompanyName;
            ViewData["WebUrl"] = sysSetting.WebUrl;
            ViewData["MachineName"] = Environment.MachineName;

            ViewData["OSName"] = RuntimeInformation.IsOSPlatform(OSPlatform.Linux)? "Linux" : RuntimeInformation.IsOSPlatform(OSPlatform.OSX)? "OSX":"Windows";
            ViewData["OSDescription"] = RuntimeInformation.OSDescription+" "+ RuntimeInformation.OSArchitecture;
            ViewData["Directory"] = AppContext.BaseDirectory;
            ViewData["SystemVersion"] = Environment.Version;
            ViewData["Version"] = AppVersionHelper.Version;
            ViewData["Manufacturer"] = AppVersionHelper.Manufacturer;
            ViewData["WebSite"] = AppVersionHelper.WebSite;
            ViewData["UpdateUrl"] = AppVersionHelper.UpdateUrl;
            ViewData["IPAdress"] = Request.HttpContext.Connection.RemoteIpAddress.ToString(); 
            ViewData["Port"] = Request.HttpContext.Connection.LocalPort.ToString();
            ViewData["Title"] = sysSetting.SoftName;
            ViewData["Copyriht"] = string.Format("<strong>Copyright &copy; 2017-{0} <a href=\"http://www.yuebon.com\" target=\"_blank\">Yuebon Tech</a>.</strong> All rights reserved.", DateTime.Now.Year);
            ViewData["TotalUser"] = new UserApp().GetCountTotal();
            //ViewData["TotalArticle"] = new ArticleNewsApp().GetCountTotal();
            ViewData["TotalUploadFile"] = new UploadFileApp().GetCountTotal();
            return View(CurrentUser);
        }

    }
}
