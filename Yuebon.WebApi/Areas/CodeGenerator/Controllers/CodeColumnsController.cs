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
    /// 表字段接口
    /// </summary>
    [ApiController]
    [Route("api/CodeGenerator/[controller]")]
    public class CodeColumnsController : AreaApiController<CodeColumns, CodeColumnsOutputDto, CodeColumnsInputDto, ICodeColumnsService>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_iService"></param>
        public CodeColumnsController(ICodeColumnsService _iService) : base(_iService)
        {
            iService = _iService;
        }
        /// <summary>
        /// 新增前处理数据
        /// </summary>
        /// <param name="info"></param>
        protected override void OnBeforeInsert(CodeColumns info)
        {
            info.Id = IdGeneratorHelper.IdSnowflake();
        }

        /// <summary>
        /// 在更新数据前对数据的修改操作
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        protected override void OnBeforeUpdate(CodeColumns info)
        {
        }

        /// <summary>
        /// 在软删除数据前对数据的修改操作
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        protected override void OnBeforeSoftDelete(CodeColumns info)
        {
        }
    }
}