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
using Yuebon.CodeGenerator.Dtos;
using Yuebon.CodeGenerator.Models;
using Yuebon.CodeGenerator.IServices;

namespace Yuebon.WebApi.Areas.CodeGenerator.Controllers
{
    /// <summary>
    /// 表信息接口
    /// </summary>
    [ApiController]
    [Route("api/CodeGenerator/[controller]")]
    public class CodeTableController : AreaApiController<CodeTable, CodeTableOutputDto, CodeTableInputDto, ICodeTableService>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_iService"></param>
        public CodeTableController(ICodeTableService _iService) : base(_iService)
        {
            iService = _iService;
        }
        /// <summary>
        /// 新增前处理数据
        /// </summary>
        /// <param name="info"></param>
        protected override void OnBeforeInsert(CodeTable info)
        {
            info.Id = IdGeneratorHelper.IdSnowflake();
        }

        /// <summary>
        /// 在更新数据前对数据的修改操作
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        protected override void OnBeforeUpdate(CodeTable info)
        {
            info.LastModifyTime = DateTime.Now;
        }

        /// <summary>
        /// 在软删除数据前对数据的修改操作
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        protected override void OnBeforeSoftDelete(CodeTable info)
        {
            info.DeleteMark = true;
        }
    }
}