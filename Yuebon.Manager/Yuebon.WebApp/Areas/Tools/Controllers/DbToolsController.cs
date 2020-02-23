using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Yuebon.WebApp.Areas.Tools.Models;
using Yuebon.Commons.Encrypt;
using Yuebon.Commons.Json;
using Yuebon.Commons.Models;
using Yuebon.WebApp.Controllers;
using Yuebon.Security.Models;
using Yuebon.Security.IServices;

namespace Yuebon.WebApp.Areas.Tools.Controllers
{
    [Area("Tools")]
    [Route("Tools/[controller]/[action]")]
    public class DbToolsController : BusinessController<Menu, IMenuService>
    {
        public DbToolsController(IMenuService _iService) : base(_iService)
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override IActionResult Index()
        {
            ViewData["Title"] = "数据库连接加解密";
            ViewData["Account"] = CurrentUser.Account;
            ViewData["RealName"] = CurrentUser.RealName;
            return View();
        }

        /// <summary>
        /// 连接字符串加密
        /// </summary>
        /// <returns></returns>

        [HttpPost]
        public IActionResult ConnStrEncrypt([FromForm]DbConnInfo dbConnInfo)
        {
            CommonResult result = new CommonResult();
            DBConnResult dBConnResult = new DBConnResult();
            if (dbConnInfo!=null)
            {
                if (string.IsNullOrEmpty(dbConnInfo.DbName))
                {
                    result.ErrMsg = "数据库名称不能为空";
                    
                }else if (string.IsNullOrEmpty(dbConnInfo.DbAddress))
                {
                    result.ErrMsg = "访问地址不能为空";
                }
                else if (string.IsNullOrEmpty(dbConnInfo.DbUserName))
                {
                    result.ErrMsg = "访问用户不能为空";
                }
                else if (string.IsNullOrEmpty(dbConnInfo.DbPassword))
                {
                    result.ErrMsg = "访问密码不能为空";
                }
                if (dbConnInfo.DbType == "SqlServer")
                {
                    dBConnResult.ConnStr = string.Format("Server={0};Database={1};User id={2}; password={3};MultipleActiveResultSets=True;",dbConnInfo.DbAddress, dbConnInfo.DbName,dbConnInfo.DbUserName,dbConnInfo.DbPassword);
                    dBConnResult.EncryptConnStr = DEncrypt.Encrypt(dBConnResult.ConnStr);
                    result.Success = true;
                }else if (dbConnInfo.DbType == "MySql")
                {
                    dBConnResult.ConnStr = string.Format("server={0};database={1};uid={2}; pwd={3};", dbConnInfo.DbAddress, dbConnInfo.DbName, dbConnInfo.DbUserName, dbConnInfo.DbPassword);
                    dBConnResult.EncryptConnStr = DEncrypt.Encrypt(dBConnResult.ConnStr);
                    result.Success = true;
                }
                result.ResData = dBConnResult;

            }
            return Content(JsonHelper.ToJson(result));
        }


        /// <summary>
        /// 连接字符串解密
        /// </summary>
        /// <returns></returns>

        [HttpPost]
        public IActionResult ConnStrDecrypt(string strConn)
        {
            CommonResult result = new CommonResult();
            DBConnResult dBConnResult = new DBConnResult();
            if (string.IsNullOrEmpty(strConn))
            {
                result.ErrMsg = "数据库名称不能为空";
            }
            else
            {
                dBConnResult.ConnStr = DEncrypt.Decrypt(strConn);
                result.Success = true;
            }
            result.ResData = dBConnResult;
            return Content(JsonHelper.ToJson(result));
        }
    }
}