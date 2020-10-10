using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Yuebon.AspNetCore.Controllers;
using Yuebon.AspNetCore.Models;
using Yuebon.Commons.Helpers;
using Yuebon.Commons.Log;
using Yuebon.Commons.Mapping;
using Yuebon.Commons.Models;
using Yuebon.Commons.Pages;
using Yuebon.Security.Dtos;
using Yuebon.Security.Models;
using Yuebon.Security.IServices;
using Yuebon.AspNetCore.Mvc;
using Yuebon.AspNetCore.UI;

namespace Yuebon.WebApi.Areas.Security.Controllers
{
    /// <summary>
    /// 定时任务执行日志接口
    /// </summary>
    [ApiController]
    [Route("api/Security/[controller]")]
    public class TaskJobsLogController : AreaApiController<TaskJobsLog, TaskJobsLogOutputDto,TaskJobsLogInputDto,ITaskJobsLogService,string>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_iService"></param>
        public TaskJobsLogController(ITaskJobsLogService _iService) : base(_iService)
        {
            iService = _iService;
            AuthorizeKey.ListKey = "TaskJobsLog/List";
            AuthorizeKey.InsertKey = "TaskJobsLog/Add";
            AuthorizeKey.UpdateKey = "TaskJobsLog/Edit";
            AuthorizeKey.UpdateEnableKey = "TaskJobsLog/Enable";
            AuthorizeKey.DeleteKey = "TaskJobsLog/Delete";
            AuthorizeKey.DeleteSoftKey = "TaskJobsLog/DeleteSoft";
            AuthorizeKey.ViewKey = "TaskJobsLog/View";
        }
        /// <summary>
        /// 新增前处理数据
        /// </summary>
        /// <param name="info"></param>
        protected override void OnBeforeInsert(TaskJobsLog info)
        {
            info.Id = GuidUtils.CreateNo();
            info.CreatorTime = DateTime.Now;
        }
        
        /// <summary>
        /// 在更新数据前对数据的修改操作
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        protected override void OnBeforeUpdate(TaskJobsLog info)
        {
        }

        /// <summary>
        /// 在软删除数据前对数据的修改操作
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        protected override void OnBeforeSoftDelete(TaskJobsLog info)
        {
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        [HttpGet("FindWithPagerAsync")]
        [YuebonAuthorize("List")]
        public override async Task<IActionResult> FindWithPagerAsync([FromQuery] SearchModel search)
        {
            CommonResult result = new CommonResult();
            string orderByDir = string.IsNullOrEmpty(Request.Query["Order"].ToString()) ? "desc" : Request.Query["Order"].ToString();
            string orderFlied = string.IsNullOrEmpty(Request.Query["Sort"].ToString()) ? " CreatorTime " : Request.Query["Sort"].ToString();
            bool order = orderByDir == "asc" ? false : true;
            string where = GetPagerCondition();
            if (!string.IsNullOrEmpty(search.Keywords))
            {
                where += string.Format(" and (TaskId like '%{0}%' or  TaskName like '%{0}%')", search.Keywords);
            }
            PagerInfo pagerInfo = GetPagerInfo();
            List<TaskJobsLog> list = await iService.FindWithPagerAsync(where, pagerInfo, orderFlied, order);
            List<TaskJobsLogOutputDto> resultList = list.MapTo<TaskJobsLogOutputDto>();
            PageResult<TaskJobsLogOutputDto> pageResult = new PageResult<TaskJobsLogOutputDto>
            {
                CurrentPage = pagerInfo.CurrenetPageIndex,
                Items = resultList,
                ItemsPerPage = pagerInfo.PageSize,
                TotalItems = pagerInfo.RecordCount
            };
            result.ResData = pageResult;
            result.ErrCode = ErrCode.successCode;
            return ToJsonContent(result);
        }

        /// <summary>
        /// 根据任务Id查询最新的30条日志
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        [HttpGet("FindWithByTaskIdAsync")]
        [YuebonAuthorize("List")]
        public  async Task<IActionResult> FindWithByTaskIdAsync([FromQuery] SearchModel search)
        {
            CommonResult result = new CommonResult();
            string where = "";
            if (!string.IsNullOrEmpty(search.Keywords))
            {
                where += string.Format(" TaskId ='{0}' ", search.Keywords);
            }
            where += " order by CreatorTime desc";
            IEnumerable<TaskJobsLog> list = await iService.GetListTopWhereAsync(40,where);
            List<TaskJobsLogVueTimelineOutputDto> resultList = list.MapTo<TaskJobsLogVueTimelineOutputDto>();
            result.ResData = resultList;
            result.ErrCode = ErrCode.successCode;
            return ToJsonContent(result);
        }
    }
}