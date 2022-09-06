using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Yuebon.AspNetCore.Models;
using Yuebon.AspNetCore.Mvc;
using Yuebon.AspNetCore.Mvc.Filter;
using Yuebon.AspNetCore.ViewModel;
using Yuebon.Commons.Core.Dtos;
using Yuebon.Commons.Dtos;
using Yuebon.Commons.Extensions;
using Yuebon.Commons.IServices;
using Yuebon.Commons.Mapping;
using Yuebon.Commons.Models;
using Yuebon.Commons.Pages;

namespace Yuebon.AspNetCore.Controllers
{
    /// <summary>
    /// 基本控制器，增删改查
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    /// <typeparam name="TODto">数据输出实体类型</typeparam>
    /// <typeparam name="TIDto">数据输入实体类型</typeparam>
    /// <typeparam name="TService">Service类型</typeparam>
    [ApiController]
    public abstract class AreaApiController<T,TODto, TIDto, TService> : ApiController
        where T : Entity
        where TService : IService<T, TODto>
        where TODto : class
        where TIDto : class
    {

        #region 属性变量


        /// <summary>
        /// 服务接口
        /// </summary>
        public TService iService;

        #endregion


        
        #region 构造函数及常用

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="_iService"></param>
        public AreaApiController(TService _iService)
        {
            iService = _iService;
        }

        #endregion

        #region 公共添加、修改、删除、软删除接口


        /// <summary>
        /// 在插入数据前对数据的修改操作
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        protected virtual void OnBeforeInsert(T info)
        {
            //留给子类对参数对象进行修改
        }

        /// <summary>
        /// 在更新数据前对数据的修改操作
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        protected virtual void OnBeforeUpdate(T info)
        {
            //留给子类对参数对象进行修改
        }

        /// <summary>
        /// 在软删除数据前对数据的修改操作
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        protected virtual void OnBeforeSoftDelete(T info)
        {
            //留给子类对参数对象进行修改
        }

        /// <summary>
        /// 异步新增数据
        /// </summary>
        /// <param name="tinfo"></param>
        /// <returns></returns>
        [HttpPost("Insert")]
        [YuebonAuthorize("Add")]
        public virtual async Task<IActionResult> InsertAsync(TIDto tinfo)
        {
            CommonResult result = new CommonResult();
            T info = tinfo.MapTo<T>();
            OnBeforeInsert(info);
            long ln = await iService.InsertAsync(info).ConfigureAwait(false);
            if (ln > 0)
            {
                result.ErrCode = ErrCode.successCode;
                result.ErrMsg = ErrCode.err0;
            }
            else
            {
                result.ErrMsg = ErrCode.err43001;
                result.ErrCode = "43001";
            }
            return ToJsonContent(result);
        }

        /// <summary>
        /// 异步更新数据，需要在业务模块控制器重写该方法,否则更新无效
        /// </summary>
        /// <param name="inInfo"></param>
        /// <returns></returns>
        [HttpPost("Update")]
        [YuebonAuthorize("Edit")]
        public virtual async Task<IActionResult> UpdateAsync(TIDto inInfo)
        {
            CommonResult result = new CommonResult();
            var prop = typeof(TIDto).GetProperty(nameof(IBaseEntity.Id));
            if (prop is null)
            {
                throw new NotImplementedException("No Id found!");
            }
            long id = (long)prop.GetValue(inInfo);
            var info = await iService.GetAsync(id);
            inInfo.MapTo<TIDto, T>(info);
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
        /// 物理删除
        /// </summary>
        /// <param name="id">主键Id</param>
        [HttpDelete("Delete")]
        [YuebonAuthorize("Delete")]
        public virtual IActionResult Delete(long id)
        {
            CommonResult result = new CommonResult();
            bool bl = iService.Delete(id);
            if (bl)
            {
                result.ErrCode = ErrCode.successCode;
                result.ErrMsg = ErrCode.err0;
            }
            else
            {
                result.ErrMsg = ErrCode.err43003;
                result.ErrCode = "43003";
            }
            return ToJsonContent(result);
        }

        /// <summary>
        /// 异步物理删除
        /// </summary>
        /// <param name="id">主键Id</param>
        [HttpDelete("DeleteAsync")]
        [YuebonAuthorize("Delete")]
        public virtual async Task<IActionResult> DeleteAsync(long id)
        {
            CommonResult result = new CommonResult();
                bool bl = await iService.DeleteAsync(id);
                if (bl)
                {
                    result.ErrCode = ErrCode.successCode;
                    result.ErrMsg = ErrCode.err0;
                }
                else
                {
                    result.ErrMsg = ErrCode.err43003;
                    result.ErrCode = "43003";
                }
            return ToJsonContent(result);
        }
        /// <summary>
        /// 异步批量物理删除
        /// </summary>
        /// <param name="info"></param>
        [HttpDelete("DeleteBatchAsync")]
        [YuebonAuthorize("Delete")]
        public virtual async Task<IActionResult> DeleteBatchAsync(DeletesInputDto info)
        {
            CommonResult result = new CommonResult();
            string where = string.Empty;
            where = "id in (" +String.Join(",", info.Ids) + ")";
            if (!string.IsNullOrEmpty(where))
            {
                bool bl = await iService.DeleteBatchWhereAsync(where).ConfigureAwait(false);
                if (bl)
                {
                    result.ErrCode = ErrCode.successCode;
                    result.ErrMsg = ErrCode.err0;
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
        /// 软删除信息
        /// </summary>
        /// <param name="id">主键Id</param>
        /// <param name="bltag">删除标识，默认为1：即设为删除,0：未删除</param>
        [HttpPost("DeleteSoft")]
        [YuebonAuthorize("DeleteSoft")]
        public virtual IActionResult DeleteSoft(string id, string bltag = "1")
        {
            CommonResult result = new CommonResult();
            bool bl = false;
            if (bltag == "0")
            {
                bl = true;
            }
            bool blResult = iService.DeleteSoft(bl, id, CurrentUser.UserId);
            if (blResult)
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
        /// 异步软删除信息
        /// </summary>
        /// <param name="id">主键Id</param>
        /// <param name="bltag">删除标识，默认为1：即设为删除,0：未删除</param>
        [HttpPost("DeleteSoftAsync")]
        [YuebonAuthorize("DeleteSoft")]
        public virtual async Task<IActionResult> DeleteSoftAsync(string id, string bltag = "1")
        {
            CommonResult result = new CommonResult();
            bool bl = false;
            if (bltag == "0")
            {
                bl = true;
            }
            bool blResult = await iService.DeleteSoftAsync(bl, id, CurrentUser.UserId);
            if (blResult)
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
        /// 异步批量软删除信息
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        [HttpPost("DeleteSoftBatchAsync")]
        [YuebonAuthorize("DeleteSoft")]
        public virtual async Task<IActionResult> DeleteSoftBatchAsync(UpdateEnableViewModel info)
        {
            CommonResult result = new CommonResult();
            string where = string.Empty;
            where = "id in (" + String.Join(",", info.Ids) + ")";
            if (!string.IsNullOrEmpty(where))
            {
                bool bl = false;
                if (info.Flag == "1")
                {
                    bl = true;
                }
                bool blResult = await iService.DeleteSoftBatchAsync(bl, where, CurrentUser.UserId);
                if (blResult)
                {
                    result.ErrCode = ErrCode.successCode;
                    result.ErrMsg = ErrCode.err0;
                }
                else
                {
                    result.ErrMsg = ErrCode.err43002;
                    result.ErrCode = "43002";
                }
            }
            return ToJsonContent(result);
        }

        /// <summary>
        /// 设为数据有效性
        /// </summary>
        /// <param name="id">主键Id</param>
        /// <param name="bltag">有效标识，默认为1：即设为无效,0：有效</param>
        [HttpPost("SetEnabledMark")]
        [YuebonAuthorize("Enable")]
        public virtual IActionResult SetEnabledMark(string id, string bltag="1")
        {
            CommonResult result = new CommonResult();
            bool bl = false;
            if (bltag == "1")
            {
                bl = true;
            }
            bool blresut = iService.SetEnabledMark(bl, id, CurrentUser.UserId);
            if (blresut)
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
        /// 异步设为数据有效性
        /// </summary>
        /// <param name="id">主键Id</param>
        /// <param name="bltag">有效标识，默认为1：即设为无效,0：有效</param>
        [HttpPost("SetEnabledMarkAsync")]
        [YuebonAuthorize("Enable")]
        public virtual async Task<IActionResult> SetEnabledMarkAsync(string id, string bltag = "1")
        {
            CommonResult result = new CommonResult();
            bool bl = false;
            if (bltag == "1")
            {
                bl = true;
            }
            bool blresut = await iService.SetEnabledMarkAsync(bl, id, CurrentUser.UserId);
            if (blresut)
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
        /// 异步批量设为数据有效性
        /// </summary>
        /// <param name="info"></param>
        [HttpPost("SetEnabledMarktBatchAsync")]
        [YuebonAuthorize("Enable")]
        public virtual async Task<IActionResult> SetEnabledMarktBatchAsync(UpdateEnableViewModel info)
        {
            CommonResult result = new CommonResult();
            bool bl = false;
            if (info.Flag == "1")
            {
                bl = true;
            }
            string where = string.Empty;
            where = "id in (" + String.Join(",", info.Ids) + ")";
            if (!string.IsNullOrEmpty(where))
            {
                bool blresut = await iService.SetEnabledMarkByWhereAsync(bl,where,CurrentUser.UserId);
                if (blresut)
                {
                    result.ErrCode = ErrCode.successCode;
                    result.ErrMsg = ErrCode.err0;
                }
                else
                {
                    result.ErrMsg = ErrCode.err43002;
                    result.ErrCode = "43002";
                }
            }
            return ToJsonContent(result);
        }

        #endregion

        #region 查询单个实体
        /// <summary>
        /// 根据主键Id获取一个对象信息
        /// </summary>
        /// <param name="id">主键Id</param>
        /// <returns></returns>
        [HttpGet("GetById")]
        [YuebonAuthorize("")]
        [NoPermissionRequired]
        public virtual async Task<CommonResult<TODto>> GetById(long id)
        {
            CommonResult<TODto> result = new CommonResult<TODto>();
            TODto info = await iService.GetOutDtoAsync(id);
            if (info != null)
            {
                result.ErrCode = ErrCode.successCode;
                result.ResData = info;
            }
            else
            {
                result.ErrMsg = ErrCode.err60001;
                result.ErrCode = "60001";
            }
            return result;
        }
        #endregion

        #region 返回集合的接口
        /// <summary>
        /// 根据条件查询数据库,并返回对象集合(用于分页数据显示)
        /// </summary>
        /// <param name="search">查询条件</param>
        /// <returns>指定对象的集合</returns>
        [HttpPost("FindWithPager")]
        [YuebonAuthorize("List")]
        public virtual CommonResult<PageResult<TODto>> FindWithPager(SearchInputDto<T> search)
        {
            CommonResult<PageResult<TODto>> result = new CommonResult<PageResult<TODto>>();
            result.ResData = iService.FindWithPager(search);
            result.ErrCode = ErrCode.successCode;
            return result;
        }



        /// <summary>
        /// 根据条件查询数据库,并返回对象集合(用于分页数据显示)
        /// 
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        [HttpPost("FindWithPagerAsync")]
        [YuebonAuthorize("List")]
        public virtual async Task<CommonResult<PageResult<TODto>>> FindWithPagerAsync(SearchInputDto<T> search)
        {
            CommonResult<PageResult<TODto>> result = new CommonResult<PageResult<TODto>>();
            result.ResData = await iService.FindWithPagerAsync(search);
            result.ErrCode = ErrCode.successCode;
            return result;
        }


        /// <summary>
        /// 获取所有可用的
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllEnable")]
        [YuebonAuthorize("List")]
        public virtual async Task<CommonResult<List<TODto>>> GetAllEnable()
        {
            CommonResult<List<TODto>> result = new CommonResult<List<TODto>>();
            IEnumerable<T> list = await iService.GetAllByIsNotDeleteAndEnabledMarkAsync();
            List<TODto> resultList = list.MapTo<TODto>();
            result.ResData = resultList;
            result.ErrCode = ErrCode.successCode;
            result.ErrMsg = ErrCode.err0;

            return result;
        }
        #endregion


        #region 辅助方法

        #endregion

    }
}
