using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using Yuebon.WebApp.Commons;
using Yuebon.WebApp.Models;
using Yuebon.WebApp.ViewModels;
using Yuebon.Commons.Helpers;
using Yuebon.Infrastructure.IServices;
using Yuebon.Commons.Json;
using Yuebon.Commons.Models;
using Yuebon.Security.Models;
using Yuebon.Commons.Extend;
using System;
using Yuebon.Commons.Log;
using Yuebon.Commons.Extensions;
using System.Reflection;
using Yuebon.Commons.Cache;
using System.Linq;
using Yuebon.Security.Dtos;
using Yuebon.Security.Application.SSO;
using Yuebon.Commons.IoC;
using Yuebon.Shop.Dtos;

namespace Yuebon.WebApp.Controllers
{
    /// <summary>
    /// 基本控制器，增删改查
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    /// <typeparam name="TService">Service类型</typeparam>
    public class BusinessMemberController<T, TService> : Controller
        where T : class
        where TService : IService<T>
    {
        #region 属性变量
        /// <summary>
        /// 
        /// 当前登录的会员用户属性
        /// </summary>
        public MembersDto CurrentMembers = new MembersDto();
        #endregion


        /// <summary>
        /// 服务接口
        /// </summary>
        public TService iService;

        private AuthHelper authHelper= IoCContainer.Resolve<AuthHelper>();

        #region 构造函数及常用
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="_iService"></param>
        public BusinessMemberController(TService _iService)
        {
            iService = _iService;
        }
        #endregion


        #region 异常处理及记录
        /// <summary>
        /// 重新基类在Action执行之前的事情
        /// </summary>
        /// <param name="filterContext">重写方法的参数</param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            byte[] currentMemberSession;
            filterContext.HttpContext.Session.TryGetValue("CurrentMember", out currentMemberSession);
            if (currentMemberSession == null)
            {
                filterContext.Result = new RedirectResult("/MemberLogin/Index");
                return;
            }
            else
            {
                //得到用户登录的信息
                CurrentMembers = ByteConvertHelper.Bytes2Object<MembersDto>(filterContext.HttpContext.Session.Get("CurrentMember"));
            }
            //UserWithAccessedCtrls userWithAccessedCtrls = authHelper.GetCurrentUser();
            if (CurrentMembers != null)
            {
                //User user = userWithAccessedCtrls.User;
                //UserLoginDto model = new UserLoginDto();
                //model.Account = user.Account;
                //model.Birthday = user.Birthday;
                //model.Email = user.Email;
                //model.Gender = user.Gender;
                //model.HeadIcon = user.HeadIcon;
                //model.Id = user.Id;
                //model.IsAdministrator = user.IsAdministrator;

                //model.MobilePhone = user.MobilePhone;
                //model.NickName = user.NickName;
                //model.OrganizeId = user.OrganizeId;
                //model.DepartmentId = user.DepartmentId;
                //model.RealName = user.RealName;
                //model.RoleId = user.RoleId;

                //model.SecurityLevel = user.SecurityLevel;
                //model.Signature = user.Signature;
                //model.WeChat = user.WeChat;
                //result.ResData = model;
                //CurrentUser = model;
            }
            else
            {
                filterContext.Result = new RedirectResult("/MemberLogin/Index");
                return;
            }
            base.OnActionExecuting(filterContext);
        }
        #endregion


        /// <summary>
        /// 列表页面
        /// </summary>
        /// <returns></returns>
        public virtual IActionResult Index()
        {
            ViewData["Account"] = CurrentMembers.UserName;
            ViewData["RealName"] = CurrentMembers.RealName;
            return View();
        }

        /// <summary>
        /// 编辑页面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual IActionResult Edit(string id)
        {
            ViewData["Account"] = CurrentMembers.UserName;
            ViewData["RealName"] = CurrentMembers.RealName;
            ViewData["Id"] = id;
            return View();
        }


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
        /// 新增数据
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        [HttpPost]
        public virtual IActionResult Insert(T info)
        {
            //检查用户是否有权限，否则抛出MyDenyAccessException异常
            
            CommonResult result = new CommonResult();
            OnBeforeInsert(info);
            long ln = iService.Insert(info);
            if (ln >= 0)
            {
                result.ErrCode = ErrCode.successCode;
                result.ErrMsg = ErrCode.err0;
                result.Success = true;
            }
            else
            {
                result.ErrMsg = ErrCode.err43001;
                result.ErrCode = "43001";
            }
            return ToJsonContent(result);
        }

        /// <summary>
        /// 异步新增数据
        /// </summary>
        /// <param name="info"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpPost]
        public virtual async Task<IActionResult> InsertAsync(T info, string token)
        {
            //检查用户是否有权限，否则抛出MyDenyAccessException异常
            CommonResult result = new CommonResult();
            OnBeforeInsert(info);
            long ln = await iService.InsertAsync(info);
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
        /// 更新数据
        /// </summary>
        /// <param name="info"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpPost]
        public virtual IActionResult Update(IFormCollection formValues, string id)
        {
            T obj = iService.Get(id);
            if (obj != null)
            {
                //遍历提交过来的数据（可能是实体类的部分属性更新）
                foreach (string key in formValues.Keys)
                {
                    string value = formValues[key];
                    System.Reflection.PropertyInfo propertyInfo = obj.GetType().GetProperty(key);
                    if (propertyInfo != null)
                    {
                        try
                        {
                            // obj对象有key的属性，把对应的属性值赋值给它(从字符串转换为合适的类型）
                            //如果转换失败，会抛出InvalidCastException异常
                            propertyInfo.SetValue(obj, ConvertHelper.ChangeType(value, propertyInfo.PropertyType), null);
                        }
                        catch { }
                    }
                }
            }
            CommonResult result = new CommonResult();
            OnBeforeUpdate(obj);
            bool bl = iService.Update(obj,id);
            if (bl)
            {
                result.ErrCode = ErrCode.successCode;
                result.ErrMsg = ErrCode.err0;
                result.Success = true;
            }
            else
            {
                result.ErrMsg = ErrCode.err43002;
                result.ErrCode = "43002";
            }
            return ToJsonContent(result);
        }

        /// <summary>
        /// 异步更新数据
        /// </summary>
        /// <param name="info"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpPost]
        public virtual async Task<IActionResult> UpdateAsync(IFormCollection formValues, string id, string token)
        {

            T obj = iService.Get(id);
            if (obj != null)
            {
                //遍历提交过来的数据（可能是实体类的部分属性更新）
                foreach (string key in formValues.Keys)
                {
                    string value = formValues[key];
                    System.Reflection.PropertyInfo propertyInfo = obj.GetType().GetProperty(key);
                    if (propertyInfo != null)
                    {
                        try
                        {
                            // obj对象有key的属性，把对应的属性值赋值给它(从字符串转换为合适的类型）
                            //如果转换失败，会抛出InvalidCastException异常
                            propertyInfo.SetValue(obj, ConvertHelper.ChangeType(value, propertyInfo.PropertyType), null);
                        }
                        catch { }
                    }
                }
            }
            CommonResult result = new CommonResult();
            OnBeforeUpdate(obj);
            bool bl = await iService.UpdateAsync(obj, id);
            if (bl)
            {
                result.ErrCode = ErrCode.successCode;
                result.ErrMsg = ErrCode.err0;
                result.Success = true;
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
        /// <param name="token">token令牌</param>
        [HttpDelete]
        public virtual IActionResult Delete(string id, string token)
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
        /// <param name="token">token令牌</param>
        [HttpDelete]
        public virtual async Task<IActionResult> DeleteAsync(string id, string token)
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
        /// 删除多个ID的记录
        /// </summary>
        /// <param name="ids">多个id组合，逗号分开（1,2,3,4,5）</param>
        /// <returns></returns>
        public virtual IActionResult DeleteByIds(string ids)
        {
            CommonResult result = new CommonResult();
            try
            {
                if (!string.IsNullOrEmpty(ids))
                {
                    List<string> idArray = ids.ToDelimitedList<string>(",");
                    foreach (string strId in idArray)
                    {
                        if (!string.IsNullOrEmpty(strId))
                        {
                            bool bl = iService.Delete(strId);
                            if (bl)
                            {
                                result.ErrCode = ErrCode.successCode;
                                result.ErrMsg = ErrCode.err0;
                                result.Success = true;
                            }
                            else
                            {
                                result.ErrMsg = ErrCode.err43003;
                                result.ErrCode = "43003";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                var type = MethodBase.GetCurrentMethod().DeclaringType;
                Log4NetHelper.WriteError(type, ex);//错误记录
                result.ErrMsg = ex.Message;
            }
            return ToJsonContent(result);
        }

        /// <summary>
        /// 软删除信息多个ID的记录
        /// </summary>
        /// <param name="ids">多个id组合，逗号分开（1,2,3,4,5）</param>
        /// <returns></returns>
        public virtual IActionResult DeleteSoftByIds(string ids, string bltag = "0")
        {
            CommonResult result = new CommonResult();
            try
            {
                if (!string.IsNullOrEmpty(ids))
                {
                    List<string> idArray = ids.ToDelimitedList<string>(",");
                    foreach (string strId in idArray)
                    {
                        if (!string.IsNullOrEmpty(strId))
                        {
                            bool bl = false;
                            if (bltag == "1")
                            {
                                bl = true;
                            }
                            bool blresut = iService.DeleteSoft(bl, strId, CurrentMembers.Id);
                            if (blresut)
                            {
                                result.ErrCode = ErrCode.successCode;
                                result.ErrMsg = ErrCode.err0;
                                result.Success = true;
                            }
                            else
                            {
                                result.ErrMsg = ErrCode.err43003;
                                result.ErrCode = "43003";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                var type = MethodBase.GetCurrentMethod().DeclaringType;
                Log4NetHelper.WriteError(type, ex);//错误记录
                result.ErrMsg = ex.Message;
            }
            return ToJsonContent(result);
        }

        /// <summary>
        /// 软删除信息
        /// </summary>
        /// <param name="id">主键Id</param>
        /// <param name="token">token令牌</param>
        /// <param name="bltag">删除标识，默认为1：即设为删除,0：未删除</param>
        [HttpDelete("DeleteSoft")]
        public virtual IActionResult DeleteSoft(string id, string bltag = "1")
        {
            CommonResult result = new CommonResult();
            bool bl = false;
            if (bltag == "0")
            {
                bl = true;
            }
            bool blResult = iService.DeleteSoft(bl, id, CurrentMembers.Id);
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
        /// <param name="token">token令牌</param>
        /// <param name="bltag">删除标识，默认为1：即设为删除,0：未删除</param>
        [HttpDelete("DeleteSoftAsync")]
        public virtual async Task<IActionResult> DeleteSoftAsync(string id, string bltag = "1")
        {
            CommonResult result = new CommonResult();
            bool bl = false;
            if (bltag == "0")
            {
                bl = true;
            }
            bool blResult = await iService.DeleteSoftAsync(bl, id, CurrentMembers.Id);
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
        /// 设为数据有效性
        /// </summary>
        /// <param name="id">主键Id</param>
        /// <param name="token">token令牌</param>
        /// <param name="bltag">有效标识，默认为1：即设为无效,0：有效</param>
        [HttpPost("SetEnabledMark")]
        public virtual IActionResult SetEnabledMark(string id, string token, string bltag = "1")
        {
            CommonResult result = new CommonResult();
            bool bl = false;
            if (bltag == "0")
            {
                bl = true;
            }
            bool blresut = iService.SetEnabledMark(bl, id, CurrentMembers.Id);
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
        /// <param name="token">token令牌</param>
        /// <param name="bltag">有效标识，默认为1：即设为无效,0：有效</param>
        [HttpPost("SetEnabledMarkAsync")]
        public virtual async Task<IActionResult> SetEnabledMarkAsync(string id, string token, string bltag = "1")
        {
            CommonResult result = new CommonResult();
            bool bl = false;
            if (bltag == "0")
            {
                bl = true;
            }
            bool blresut = await iService.SetEnabledMarkAsync(bl, id, CurrentMembers.Id);
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
        /// 设数据有效性多个ID的记录
        /// </summary>
        /// <param name="ids">多个id组合，逗号分开（1,2,3,4,5）</param>
        /// <returns></returns>
        [HttpPost]
        public virtual IActionResult SetEnabledMarkByIds(string ids, string bltag = "0")
        {
            CommonResult result = new CommonResult();
            try
            {
                if (!string.IsNullOrEmpty(ids))
                {
                    bool bl = false;
                    if (bltag == "1")
                    {
                        bl = true;
                    }
                    List<string> idArray = ids.ToDelimitedList<string>(",");
                    foreach (string strId in idArray)
                    {
                        if (!string.IsNullOrEmpty(strId))
                        {
                            bool blresut = iService.SetEnabledMark(bl, strId, CurrentMembers.Id);
                            if (blresut)
                            {
                                result.ErrCode = ErrCode.successCode;
                                result.ErrMsg = ErrCode.err0;
                                result.Success = true;
                            }
                            else
                            {
                                result.ErrMsg = ErrCode.err43002;
                                result.ErrCode = "43002";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                var type = MethodBase.GetCurrentMethod().DeclaringType;
                Log4NetHelper.WriteError(type, ex);//错误记录
                result.ErrMsg = ex.Message;
            }
            return ToJsonContent(result);
        }

        /// <summary>
        /// 根据ID获取详细信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual IActionResult GetById(string id)
        {
            CommonResult result = new CommonResult();
            try
            {
                result.ResData = iService.Get(id);
                result.Success = true;
            }
            catch (Exception ex)
            {
                var type = MethodBase.GetCurrentMethod().DeclaringType;
                Log4NetHelper.WriteError(type, ex);//错误记录
                result.ErrMsg = ex.Message;
            }
            return ToJsonContent(result);
        }
        #endregion


        #region 返回集合的接口
        /// <summary>
        /// 根据条件查询数据库,并返回对象集合(用于分页数据显示)
        /// </summary>
        /// <returns>指定对象的集合</returns>
        [HttpGet]
        public virtual IActionResult FindWithPager()
        {
            string keywords = Request.Query["search"].ToString() == null ? "" : Request.Query["search"].ToString();
            string orderByDir = Request.Query["order"].ToString() == null ? "" : Request.Query["order"].ToString();
            string orderFlied = Request.Query["sort"].ToString() == "" ? "Id" : Request.Query["sort"].ToString();
          
            bool order = orderByDir == "asc" ? false : true;
            string where ="";
            PagerInfo pagerInfo = GetPagerInfo();
            List<T> list = iService.FindWithPager(where, pagerInfo, orderFlied, order);
            //构造成Json的格式传递
            var result = new
            {
                total = pagerInfo.RecordCount,
                rows = list
            };
            return ToJsonContent(result);
        }

        /// <summary>
        /// 根据Request参数获取分页对象数据
        /// </summary>
        /// <returns></returns>
        protected virtual PagerInfo GetPagerInfo()
        {
            string start = Request.Query["offset"].ToString();
            int pageSize = Request.Query["limit"].ToString() == null ? 1 : int.Parse(Request.Query["limit"].ToString());
            int pageIndex = 1;
            if (!string.IsNullOrWhiteSpace(start))
            {
                pageIndex = (int.Parse(start) / pageSize) + 1;
            }
            PagerInfo pagerInfo = new PagerInfo();
            pagerInfo.CurrenetPageIndex = pageIndex;
            pagerInfo.PageSize = pageSize;
            return pagerInfo;
        }

        /// <summary>
        /// 获取分页操作的查询条件
        /// </summary>
        /// <param name="blDeptCondition">是否开启权限数据</param>
        /// <returns></returns>
        protected virtual string GetPagerCondition(bool blDeptCondition = true)
        {
            string where = "1=1";
            if (blDeptCondition)
            {
                //如果公司过滤条件不为空，那么需要进行过滤
                string DataFilterCondition = new YuebonCacheHelper().Get("DataFilterCondition_"+CurrentMembers.Id).ToString();
                if (!string.IsNullOrEmpty(DataFilterCondition))
                {
                    where += string.Format(" {0}", DataFilterCondition);
                }
            }
            return where;
        }
        #endregion


        #region 辅助方法
        /// <summary>
        /// 退出登录
        /// </summary>
        /// <returns></returns>
        public IActionResult Logout()
        {
            CurrentMembers = null;
            return new RedirectResult("/MemberLogin/Index");
        }

        /// <summary>
        /// 把object对象转换为ContentResult
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost]
        protected IActionResult ToJsonContent(object obj)
        {
            string result = JsonConvert.SerializeObject(obj, Formatting.Indented);
            return Content(obj.ToJson());
        }
        #endregion
    }
}