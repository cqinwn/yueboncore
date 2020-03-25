using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using Yuebon.AspNetCore.Models;
using Yuebon.AspNetCore.Mvc;
using Yuebon.AspNetCore.SSO;
using Yuebon.Commons.Cache;
using Yuebon.Commons.IoC;
using Yuebon.Commons.Json;
using Yuebon.Commons.Models;
using Yuebon.Commons.Options;
using Yuebon.Security.Application;
using Yuebon.Security.Dtos;
using Yuebon.Security.Models;
using Yuebon.Commons.CodeGenerator;
using System.Collections.Generic;
using Yuebon.Commons.Log;
using Yuebon.Commons.Pages;
using Yuebon.AspNetCore.UI;
using Yuebon.AspNetCore.Mvc.Filter;

namespace Yuebon.AspNetCore.Controllers
{
    /// <summary>
    /// 代码生成器
    /// </summary>
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class CodeGeneratorController : ApiController
    {
        /// <summary>
        /// 获取数据库的所有表信息
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        [HttpGet("GetListTable")]
        [YuebonAuthorize("GetListTable")]
        [NoPermissionRequired]
        public async Task<IActionResult> GetListTable([FromQuery]SearchModel search)
        {
            CommonResult result = new CommonResult();

            string orderByDir = Request.Query["Order"].ToString() == null ? "" : Request.Query["Order"].ToString();
            string orderFlied = string.IsNullOrEmpty(Request.Query["Sort"].ToString()) ? "TableName" : Request.Query["Sort"].ToString();
            bool order = orderByDir == "asc" ? false : true;
            string where = "1=1";
            if (!string.IsNullOrEmpty(search.Keywords))
            {
                where += " and TableName like '%"+ search.Keywords + "%'";
            }
            PagerInfo pagerInfo = GetPagerInfo();
            MssqlExtractor mssqlExtractor = new MssqlExtractor();
            List<DbTableInfo> listTable = mssqlExtractor.GetAllTables(where, orderFlied, order,pagerInfo);
           
            PageResult<DbTableInfo> pageResult = new PageResult<DbTableInfo>();
            pageResult.CurrentPage = pagerInfo.CurrenetPageIndex;
            pageResult.Items = listTable;
            pageResult.ItemsPerPage = pagerInfo.PageSize;
            pageResult.TotalItems = pagerInfo.RecordCount;
            result.ResData = pageResult;
            result.ErrCode = ErrCode.successCode;
            return ToJsonContent(result);
        }
        /// <summary>
        /// 代码生成器
        /// </summary>
        /// <param name="tables">要生成代码的表</param>
        /// <param name="baseSpace">项目命名空间</param>
        /// <param name="replaceTableNameStr">要删除表名的字符串用英文逗号","隔开</param>
        /// <returns></returns>
        [HttpGet("Generate")]
        [YuebonAuthorize("GetGenerate")]
        [NoPermissionRequired]
        public async Task<IActionResult> GetGenerate(string tables,string baseSpace,string replaceTableNameStr)
        {
            CommonResult result = new CommonResult();
            try
            {
                if (string.IsNullOrEmpty(baseSpace))
                {
                    result.ErrMsg = "项目命名空间不能为空";
                    result.ErrCode = ErrCode.failCode;
                }
                else
                {
                    CodeGenerator.Generate(baseSpace, tables, replaceTableNameStr);
                    result.ErrMsg = "代码生成完毕";
                    result.ErrCode = ErrCode.successCode;
                }
            }catch(Exception ex)
            {
                Log4NetHelper.Error("代码生成异常",ex);
                result.ErrMsg = "代码生成异常:"+ex.Message;
                result.ErrCode = ErrCode.successCode;
            }
            return ToJsonContent(result);
        }
    }
}