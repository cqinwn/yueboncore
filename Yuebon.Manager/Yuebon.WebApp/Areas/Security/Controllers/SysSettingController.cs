using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Yuebon.Commons.Cache;
using Yuebon.Commons.Helpers;
using Yuebon.Commons.Models;
using Yuebon.Security.IServices;
using Yuebon.Security.Models;
using Yuebon.WebApp.Controllers;

namespace Yuebon.WebApp.Areas.Security.Controllers
{
    [Area("Security")]
    [Route("Security/[controller]/[action]")]
    public class SysSettingController : BusinessController<Menu, IMenuService>
    {

        private readonly IWebHostEnvironment _hostingEnvironment;
        public SysSettingController(IMenuService _iService, IWebHostEnvironment hostingEnvironment) : base(_iService)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public override IActionResult Index()
        {
            ViewData["Account"] = CurrentUser.Account;
            ViewData["RealName"] = CurrentUser.RealName;
            SysSetting sysSetting = XmlConverter.Deserialize<SysSetting>("xmlconfig/sys.config");
            YuebonCacheHelper yuebonCacheHelper = new YuebonCacheHelper();
            yuebonCacheHelper.Add("SysSetting", sysSetting);
            return View(sysSetting);
        }

        [HttpPost]
        public IActionResult Save(SysSetting info)
        {
            CommonResult result = new CommonResult();
            info.LocalPath = _hostingEnvironment.WebRootPath;
            SysSetting sysSetting = XmlConverter.Deserialize<SysSetting>("xmlconfig/sys.config");
            sysSetting = info;
            string uploadPath = _hostingEnvironment.WebRootPath + "/"+sysSetting.Filepath;
            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }
            YuebonCacheHelper yuebonCacheHelper = new YuebonCacheHelper();
            if (yuebonCacheHelper.Exists("SysSetting"))
            {
                yuebonCacheHelper.Replace("SysSetting", sysSetting);
            }
            else
            {
                //写入缓存
                yuebonCacheHelper.Add("SysSetting", sysSetting);
            }
            XmlConverter.Serialize<SysSetting>(sysSetting, "xmlconfig/sys.config");
            result.Success = true;
            return ToJsonContent(result);
        }
    }
}