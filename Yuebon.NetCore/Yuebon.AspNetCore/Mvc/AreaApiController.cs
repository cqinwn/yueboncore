using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Yuebon.AspNetCore.Common;
using Yuebon.AspNetCore.Models;
using Yuebon.AspNetCore.Mvc;
using Yuebon.AspNetCore.Mvc.Filter;
using Yuebon.AspNetCore.UI;
using Yuebon.Commons.Cache;
using Yuebon.Commons.Extensions;
using Yuebon.Commons.Helpers;
using Yuebon.Commons.IServices;
using Yuebon.Commons.Json;
using Yuebon.Commons.Log;
using Yuebon.Commons.Mapping;
using Yuebon.Commons.Models;
using Yuebon.Commons.Pages;
using Yuebon.Security.Dtos;

namespace Yuebon.AspNetCore.Controllers
{
    /// <summary>
    /// 基本控制器，增删改查
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    /// <typeparam name="TDto">数据输出实体类型</typeparam>
    /// <typeparam name="TIDto">数据输入实体类型</typeparam>
    /// <typeparam name="TService">Service类型</typeparam>
    /// <typeparam name="TKey">主键数据类型</typeparam>
    [ApiController]
    public abstract class AreaApiController<T,TDto, TIDto, TService, TKey> : ApiController
        where T : Entity
        where TService : IService<T, TDto, TKey>
        where TDto : class
        where TIDto : class
        where TKey : IEquatable<TKey>
    {

        #region 属性变量

        /// <summary>
        /// 定义常用功能的控制ID，方便基类控制器对用户权限的控制
        /// </summary>
        protected AuthorizeKey AuthorizeKey= new AuthorizeKey();

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

        #region 公共添加、修改、删除、查询接口


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
        /// 异步更新数据
        /// </summary>
        /// <param name="tinfo"></param>
        /// <param name="id">主键Id</param>
        /// <returns></returns>
        [HttpPost("Update")]
        [YuebonAuthorize("Edit")]
        public virtual async Task<IActionResult> UpdateAsync(TIDto tinfo, TKey id)
        {
            CommonResult result = new CommonResult();
            T info = tinfo.MapTo<T>();
            OnBeforeUpdate(info);
            bool bl = await iService.UpdateAsync(info, id).ConfigureAwait(false);
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
        public virtual IActionResult Delete(TKey id)
        {
            CommonResult result = new CommonResult();
                bool bl =iService.Delete(id);
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
        public virtual async Task<IActionResult> DeleteAsync(TKey id)
        {
            CommonResult result = new CommonResult();
                bool bl = await iService.DeleteAsync(id).ConfigureAwait(false);
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
        /// <param name="ids">主键Id</param>
        [HttpDelete("DeleteBatchAsync")]
        [YuebonAuthorize("Delete")]
        public virtual async Task<IActionResult> DeleteBatchAsync(TKey ids)
        {
            CommonResult result = new CommonResult();
            string where = string.Empty;
            if (typeof(TKey) == typeof(string))
            {
                string newIds = ids.ToString();
                where = "id in ('" + newIds.Trim(',').Replace(",", "','") + "')";
            }
            else if (typeof(TKey) == typeof(int))
            {
                where = "id in ("+ids+")";
            }
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
        public virtual IActionResult DeleteSoft(TKey id,string bltag="1")
        {
            CommonResult result = new CommonResult();  
                bool bl = false;
                if (bltag == "0")
                {
                    bl = true;
                }
                bool blResult =iService.DeleteSoft(bl,id,CurrentUser.UserId);
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
        public virtual async Task<IActionResult> DeleteSoftAsync(TKey id,string bltag="1")
        {
            CommonResult result = new CommonResult();
                bool bl = false;
                if (bltag == "0")
                {
                    bl = true;
                }
                bool blResult = await iService.DeleteSoftAsync(bl,id,CurrentUser.UserId);
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
        /// <param name="ids">主键Id</param>
        /// <param name="bltag">删除标识，默认为1：即设为删除,0：未删除</param>
        [HttpPost("DeleteSoftBatchAsync")]
        [YuebonAuthorize("DeleteSoft")]
        public virtual async Task<IActionResult> DeleteSoftBatchAsync(TKey ids, string bltag = "1")
        {
            CommonResult result = new CommonResult();
            string where = string.Empty;
            if (typeof(TKey) == typeof(string))
            {
                string newIds = ids.ToString();
                where = "id in ('" + newIds.Trim(',').Replace(",", "','") + "')";
            }
            else if (typeof(TKey) == typeof(int))
            {
                where = "id in (" + ids + ")";
            }
            if (!string.IsNullOrEmpty(where))
            {
                bool bl = false;
                if (bltag == "1")
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
        public virtual IActionResult SetEnabledMark(TKey id, string bltag="1")
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
        public virtual async Task<IActionResult> SetEnabledMarkAsync(TKey id, string bltag = "1")
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
        /// <param name="ids">主键Id集合</param>
        /// <param name="bltag">有效标识，默认为1：即设为无效,0：有效</param>
        [HttpPost("SetEnabledMarktBatchAsync")]
        [YuebonAuthorize("Enable")]
        public virtual async Task<IActionResult> SetEnabledMarktBatchAsync(TKey ids, string bltag = "1")
        {
            CommonResult result = new CommonResult();
            bool bl = false;
            if (bltag == "1")
            {
                bl = true;
            }
            string where = string.Empty;
            if (typeof(TKey) == typeof(string))
            {
                string newIds = ids.ToString();
                where = "id in ('" + newIds.Trim(',').Replace(",", "','") + "')";
            }
            else if (typeof(TKey) == typeof(int))
            {
                where = "id in (" + ids + ")";
            }
            if (!string.IsNullOrEmpty(where))
            {
                bool blresut = await iService.SetEnabledMarkByWhereAsync(bl, where, CurrentUser.UserId);
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

        /// <summary>
        /// 根据主键Id获取一个对象信息
        /// </summary>
        /// <param name="id">主键Id</param>
        /// <returns></returns>
        [HttpGet("GetById")]
        [YuebonAuthorize("")]
        [NoPermissionRequired]
        public virtual async Task<IActionResult> GetById(TKey id)
        {
            CommonResult result = new CommonResult();
                TDto info =await iService.GetOutDtoAsync(id);
               
                if (info != null)
                {
                    result.ErrCode = ErrCode.successCode;
                    result.ResData = info;
                }
                else
                {
                    result.ErrMsg = ErrCode.err50001;
                    result.ErrCode = "50001";
                }
            return ToJsonContent(result);
        }
        #endregion

        #region 返回集合的接口
        /// <summary>
        /// 根据条件查询数据库,并返回对象集合(用于分页数据显示)
        /// </summary>
        /// <param name="info">info</param>
        /// <returns>指定对象的集合</returns>
        [HttpGet("FindWithPager")]
        [YuebonAuthorize("List")]
        public virtual IActionResult FindWithPager(T info)
        {
            CommonResult result = new CommonResult();
                string keywords = Request.Query["search"].ToString() == null ? "" : Request.Query["search"].ToString();
                string orderByDir = Request.Query["order"].ToString() == null ? "" : Request.Query["order"].ToString();
                string orderFlied = string.IsNullOrEmpty(Request.Query["sort"].ToString()) ? "Id" : Request.Query["sort"].ToString();

                bool order = orderByDir == "asc" ? false : true;
                string where = GetPagerCondition();
                PagerInfo pagerInfo =GetPagerInfo();
                List<T> list = iService.FindWithPager(where, pagerInfo, orderFlied, order);
                result.ErrCode = ErrCode.successCode;
                //构造成Json的格式传递
                result.ResData = new
                {
                    recordsTotal = pagerInfo.RecordCount,
                    recordsFiltered = pagerInfo.RecordCount,
                    data = list
                };
            return ToJsonContent(result);
        }



        /// <summary>
        /// 异步分页查询
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        [HttpGet("FindWithPagerAsync")]
        [YuebonAuthorize("List")]
        public virtual async Task<IActionResult> FindWithPagerAsync([FromQuery]SearchModel search)
        {
            CommonResult result = new CommonResult();
            string orderByDir = string.IsNullOrEmpty(Request.Query["Order"].ToString()) ? "" : Request.Query["Order"].ToString();
            string orderFlied = string.IsNullOrEmpty(Request.Query["Sort"].ToString()) ? "Id" : Request.Query["Sort"].ToString();
            bool order = orderByDir == "asc" ? false : true;
            string where = GetPagerCondition();
            if (search != null)
            {
                if (!string.IsNullOrEmpty(search.Keywords))
                {
                    where += " and Title like '%" + search.Keywords + "%'";
                };
            }
            PagerInfo pagerInfo = GetPagerInfo();
            List<T> list = await iService.FindWithPagerAsync(where, pagerInfo, orderFlied, order);
            List<TDto> resultList = list.MapTo<TDto>();
            PageResult<TDto> pageResult = new PageResult<TDto>
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
        /// 获取分页操作的查询条件
        /// </summary>
        /// <returns></returns>
        protected virtual string GetPagerCondition(bool blDeptCondition = true)
        {
            string where = "1=1";
            //if (blDeptCondition)
            //{
            //    //如果公司过滤条件不为空，那么需要进行过滤
            //    string DataFilterCondition = Session["DataFilterCondition"].ToString();
            //    if (!string.IsNullOrEmpty(DataFilterCondition))
            //    {
            //        where += string.Format(" {0}", DataFilterCondition);
            //    }
            //}
            return where;
        }


        /// <summary>
        /// 获取所有可用的
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllEnable")]
        [YuebonAuthorize("List")]
        public virtual async Task<IActionResult> GetAllEnable()
        {
            CommonResult result = new CommonResult();
            IEnumerable<T> list = await iService.GetAllByIsNotDeleteAndEnabledMarkAsync();
            List<TDto> resultList = list.MapTo<TDto>();
            result.ResData = resultList;
            result.ErrCode = ErrCode.successCode;
            result.ErrMsg = ErrCode.err0;

            return ToJsonContent(result);
        }
        #endregion


        #region 辅助方法

        #endregion

    }
}
