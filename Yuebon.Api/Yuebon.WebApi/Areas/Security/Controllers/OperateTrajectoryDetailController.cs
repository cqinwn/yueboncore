using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yuebon.AspNetCore.Controllers;
using Yuebon.AspNetCore.Models;
using Yuebon.Commons.Mapping;
using Yuebon.Commons.Models;
using Yuebon.Security.Application;
using Yuebon.Security.Dtos;
using Yuebon.Security.IServices;
using Yuebon.Security.Models;
using Yuebon.Security.Services;

namespace Yuebon.WebApi.Areas.Security.Controllers
{
    /// <summary>
    /// 浏览轨迹详情
    /// </summary>
    [Route("api/Security/[controller]")]
    [ApiController]
    public class OperateTrajectoryDetailController : AreaApiController<OperateTrajectoryDetail, IOperateTrajectoryDetailService>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iService"></param>
        public OperateTrajectoryDetailController(IOperateTrajectoryDetailService iService) : base(iService)
        {
        }
        /// <summary>
        /// 得到轨迹列表
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="currentpage"></param>
        /// <param name="pagesize"></param>
        /// <returns></returns>
        [HttpGet("GetTrajectoryListByPage")]
        public IActionResult GetTrajectoryListByPage(string filter, string currentpage,
            string pagesize)
        {

            string strWhereTime =DateTime.Now.AddDays(-3).ToShortDateString();
            CommonResult result = new CommonResult();
            result = CheckToken();
            if (result.ErrCode == ErrCode.successCode)
            {
                if (!String.IsNullOrEmpty(filter))
                {
                    DateTime ct = DateTime.Now;
                    string d3 = ct.AddDays(-3).ToShortDateString();
                    string d7 = ct.AddDays(-7).ToShortDateString();
                    string d15 = ct.AddDays(-15).ToShortDateString();
                    string d30 = ct.AddDays(-30).ToShortDateString();

                    switch (filter)
                    {
                        case "0": //最近3天
                            strWhereTime = d3;
                            break;
                        case "1": //最近7天
                            strWhereTime = d7;
                            break;
                        case "2": //最近15天
                            strWhereTime = d15;
                            break;
                        case "3": //最近30天
                            strWhereTime = d30;
                            break;
                        default:
                            strWhereTime = d3;
                            break;

                    }

                    OperateTrajectoryDetailApp app = new OperateTrajectoryDetailApp();
                    IEnumerable<OperateTrajectoryDetailOutputDto> traceOutputDto = app.GetTrajectoryListByPage(strWhereTime,currentpage,
                        pagesize, CurrentUser.UserId);
                    if (traceOutputDto != null)
                    {

                        result.ResData = traceOutputDto;
                        result.Success = true;
                    }
                    else
                    {
                        result.ErrMsg = ErrCode.err50001;
                        result.ErrCode = "50001";
                    }
                }
            }
            return ToJsonContent(result);
        }


        /// <summary>
        /// 得到总轨迹数
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetTotalCounts")]
        public IActionResult GetTotalCounts()
        {            
            CommonResult result = new CommonResult();
            result = CheckToken();
            if (result.ErrCode == ErrCode.successCode)
            {
                OperateTrajectoryDetailApp app = new OperateTrajectoryDetailApp();
                int totalnums = app.GetTotalCounts(CurrentUser.UserId);
                result.ResData = totalnums;
                result.Success = true;
            }
            
            return ToJsonContent(result);
        }

       /// <summary>
       /// 根据筛选得到轨迹数
       /// </summary>
       /// <param name="filter"></param>
       /// <returns></returns>
        [HttpGet("GetTotalCountsByFilter")]
        public IActionResult GetTotalCountsByFilter(string filter)
        {

            string strWhereTime = DateTime.Now.AddDays(-3).ToShortDateString();
            CommonResult result = new CommonResult();
            result = CheckToken();
            if (result.ErrCode == ErrCode.successCode)
            {
                if (!String.IsNullOrEmpty(filter))
                {
                    DateTime ct = DateTime.Now;
                    string d3 = ct.AddDays(-3).ToShortDateString();
                    string d7 = ct.AddDays(-7).ToShortDateString();
                    string d15 = ct.AddDays(-15).ToShortDateString();
                    string d30 = ct.AddDays(-30).ToShortDateString();

                    switch (filter)
                    {
                        case "0": //最近3天
                            strWhereTime = d3;
                            break;
                        case "1": //最近7天
                            strWhereTime = d7;
                            break;
                        case "2": //最近15天
                            strWhereTime = d15;
                            break;
                        case "3": //最近30天
                            strWhereTime = d30;
                            break;
                        default:
                            strWhereTime = d3;
                            break;

                    }

                    OperateTrajectoryDetailApp app = new OperateTrajectoryDetailApp();
                    int totalnums = app.GetTotalCountsByFilter(strWhereTime,CurrentUser.UserId);
                    result.ResData = totalnums;
                    result.Success = true;
                }
            }
            return ToJsonContent(result);
        }
    }
}
