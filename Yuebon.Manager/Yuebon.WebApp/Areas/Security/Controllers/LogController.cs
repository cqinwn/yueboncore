using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Yuebon.WebApp.Controllers;
using Yuebon.Commons.Models;
using Yuebon.Security.IServices;
using Yuebon.Security.Models;
using Yuebon.Commons.Pages;

namespace Yuebon.WebApp.Areas.Security.Controllers
{
    [Area("Security")]
    [Route("Security/[controller]/[action]")]
    public class LogController : BusinessController<Log, ILogService>
    {
        private IOrganizeService organizeService;
        public LogController(ILogService _iService, IOrganizeService _organizeService) : base(_iService)
        {
            iService = _iService;
            organizeService = _organizeService;

            AuthorizeKey.DeleteKey = "Log/Delete";
            AuthorizeKey.ListKey = "Log/List";
            AuthorizeKey.ViewKey = "Log/View";
        }

        /// <summary>
        /// 根据条件查询数据库,并返回对象集合(用于分页数据显示)
        /// </summary>
        /// <returns>指定对象的集合</returns>
        [HttpGet]
        public override IActionResult FindWithPager()
        {
            //检查用户是否有权限，否则抛出MyDenyAccessException异常
            //base.CheckAuthorized(AuthorizeKey.ListKey);
            string keywords = Request.Query["search"].ToString() == null ? "" : Request.Query["search"].ToString();
            string orderByDir = Request.Query["order"].ToString() == null ? "" : Request.Query["order"].ToString();
            string orderFlied = Request.Query["sort"].ToString() == "" ? "CreatorTime" : Request.Query["sort"].ToString();
            string where = "1=1";
            bool order = orderByDir == "asc" ? false : true;
            if (!string.IsNullOrEmpty(keywords))
            {
                where += string.Format(" and (Account like '%{0}%' or ModuleName like '%{0}%' or IPAddress like '%{0}%' or IPAddressName like '%{0}%' or Description like '%{0}%')", keywords);
            }

            PagerInfo pagerInfo = GetPagerInfo();
            List<Log> list = iService.FindWithPager(where, pagerInfo, orderFlied, order);

            //构造成Json的格式传递
            var result = new
            {
                total = pagerInfo.RecordCount,
                rows = list
            };
            return ToJsonContent(result);
        }
    }
}