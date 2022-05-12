using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Yuebon.AspNetCore.Controllers;
using Yuebon.AspNetCore.Models;
using Yuebon.AspNetCore.Mvc;
using Yuebon.Commons.Helpers;
using Yuebon.Commons.Mapping;
using Yuebon.Commons.Models;
using Yuebon.Security.Dtos;
using Yuebon.Security.IServices;
using Yuebon.Security.Models;

namespace Yuebon.WebApi.Areas.Security.Controllers
{
    /// <summary>
    /// 角色接口
    /// </summary>
    [ApiController]
    [Route("api/Security/[controller]")]
    public class RoleController : AreaApiController<Role, RoleOutputDto, RoleInputDto, IRoleService>
    {
        private IOrganizeService organizeService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_iService"></param>
        /// <param name="_organizeService"></param>
        public RoleController(IRoleService _iService, IOrganizeService _organizeService) : base(_iService)
        {
            iService = _iService;
            organizeService = _organizeService;
        }
        /// <summary>
        /// 新增前处理数据
        /// </summary>
        /// <param name="info"></param>
        protected override void OnBeforeInsert(Role info)
        {
            info.Id = IdGeneratorHelper.IdSnowflake();
            info.CreatorTime = DateTime.Now;
            info.CreatorUserId = CurrentUser.UserId;
            info.DeleteMark = false;
            info.Category = 1;
            if (info.SortCode == null)
            {
                info.SortCode = 99;
            }
        }
        
        /// <summary>
        /// 在更新数据前对数据的修改操作
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        protected override void OnBeforeUpdate(Role info)
        {
            info.LastModifyUserId = CurrentUser.UserId;
            info.LastModifyTime = DateTime.Now;
        }

        /// <summary>
        /// 在软删除数据前对数据的修改操作
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        protected override void OnBeforeSoftDelete(Role info)
        {
            info.DeleteMark = true;
            info.DeleteTime = DateTime.Now;
            info.DeleteUserId = CurrentUser.UserId;
        }


        /// <summary>
        /// 异步更新数据
        /// </summary>
        /// <param name="tinfo"></param>
        /// <returns></returns>
        [HttpPost("Update")]
        [YuebonAuthorize("Edit")]
        public override async Task<IActionResult> UpdateAsync(RoleInputDto tinfo)
        {
            CommonResult result = new CommonResult();

            Role info = iService.Get(tinfo.Id);
            info.OrganizeId = tinfo.OrganizeId;
            info.FullName = tinfo.FullName;
            info.EnCode = tinfo.EnCode;
            info.EnabledMark = tinfo.EnabledMark;
            info.SortCode = tinfo.SortCode;
            info.Description = tinfo.Description;
            info.Type = tinfo.Type;

            OnBeforeUpdate(info);
            bool bl = await iService.UpdateAsync(info);
            if (bl)
            {
                result.ErrCode = ErrCode.successCode;
                result.ErrMsg = ErrCode.err0;
            }
            else
            {
                result.ErrMsg = ErrCode.err43002;
                result.ErrCode = "43002";
            }
            return ToJsonContent(result);
        }


        /// <summary>
        /// 获取所有可用的
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllEnable")]
        [YuebonAuthorize("")]
        public override async Task<CommonResult<List<RoleOutputDto>>> GetAllEnable()
        {
            CommonResult<List<RoleOutputDto>> result = new CommonResult<List<RoleOutputDto>>();
            IEnumerable<Role> list = await iService.GetAllByIsNotDeleteAndEnabledMarkAsync();
            List<RoleOutputDto> resultList = list.MapTo<RoleOutputDto>();
            result.ResData = resultList;
            result.ErrCode = ErrCode.successCode;
            result.ErrMsg = ErrCode.err0;
            return result;
        }
    }
}