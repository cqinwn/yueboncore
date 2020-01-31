using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Yuebon.AspNetCore.Controllers;
using Yuebon.AspNetCore.Models;
using Yuebon.Commons.Log;
using Yuebon.Commons.Models;
using Yuebon.Security.Application;
using Yuebon.Security.Dtos;
using Yuebon.Security.IServices;
using Yuebon.Security.Models;

namespace Yuebon.WebApi.Areas.Security.Controllers
{
    /// <summary>
    /// 用户接口控制器
    /// </summary>
    [Route("api/Security/[controller]")]
    public class UserFocusController : AreaApiController<UserFocus, IUserFocusService>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_iService"></param>
        public UserFocusController(IUserFocusService _iService) : base(_iService)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="focusid"></param>
        /// <returns></returns>
        [HttpGet("InsertUserFocus")]
        public IActionResult InsertUserFocus(string focusid)
        {
            CommonResult result = new CommonResult();
            result = CheckToken();
            if (result.ErrCode == ErrCode.successCode)
            {
                UserFocusApp app = new UserFocusApp();
                long insertResult = app.InsertFocus(focusid,CurrentUser.UserId);

                if(insertResult>0)
                {
                    result.ResData = true;
                    result.Success = true;
                }
                else
                {
                    result.ErrMsg = ErrCode.err43001;
                    result.ErrCode = "43001";
                }
                
            }

            return ToJsonContent(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="focusid"></param>
        /// <returns></returns>
        [HttpGet("DeleteUserFocus")]
        public IActionResult DeleteUserFocus(string focusid)
        {
            CommonResult result = new CommonResult();
            result = CheckToken();
            if (result.ErrCode == ErrCode.successCode)
            {
                UserFocusApp app = new UserFocusApp();
                int deleteResult = app.DeleteFocus(focusid, CurrentUser.UserId);

                if (deleteResult > 0)
                {
                    result.ResData = true;
                    result.Success = true;
                }
                else
                {
                    result.ErrMsg = ErrCode.err43003;
                    result.ErrCode = "43003";
                }

            }

            return ToJsonContent(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="focusid"></param>
        /// <returns></returns>
        [HttpGet("GetIfFocusStatus")]
        public IActionResult GetIfFocusStatus(string focusid)
        {
            CommonResult result = new CommonResult();
            result = CheckToken();
            if (result.ErrCode == ErrCode.successCode)
            {
                UserFocusApp app = new UserFocusApp();
                bool queryResult = app.GetIfFocusStatus(focusid, CurrentUser.UserId);

                if (queryResult)
                {
                    result.ResData = true;
                    result.Success = true;
                }
                else
                {
                    result.ResData = false;
                    result.Success = true;
                }

            }

            return ToJsonContent(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetTotalFocusByUserId")]
        public IActionResult GetTotalFocusByUserId()
        {
            CommonResult result = new CommonResult();
            result = CheckToken();
            if (result.ErrCode == ErrCode.successCode)
            {
                UserFocusApp app = new UserFocusApp();
                int queryResult = app.GetTotalFocus(CurrentUser.UserId);

                if (queryResult > 0)
                {
                    result.ResData = queryResult;
                    result.Success = true;
                }
                else
                {
                    result.ResData = 0;
                    result.Success = true;
                }

            }

            return ToJsonContent(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="currentpage"></param>
        /// <param name="pagesize"></param>
        /// <returns></returns>
        [HttpGet("GetUserFocusListByPage")]
        public IActionResult GetUserFocusListByPage(string filter, string currentpage,
            string pagesize)
        {
           
            CommonResult result = new CommonResult();
            result = CheckToken();
            if (result.ErrCode == ErrCode.successCode)
            {

                UserFocusApp app = new UserFocusApp();
                IEnumerable<UserFocusExtendOutPutDto> outputDto = app.GetUserFocusListByPage(filter, currentpage,
                    pagesize, CurrentUser.UserId);
                if (outputDto != null)
                {

                    result.ResData = outputDto;
                    result.Success = true;
                }
                else
                {
                    result.ErrMsg = ErrCode.err50001;
                    result.ErrCode = "50001";
                }
            }
            return ToJsonContent(result);
        }
    }
}
