using SqlSugar;
using Yuebon.AspNetCore.ViewModel;
using Yuebon.Commons.Pages;

namespace Yuebon.WebApi.Controllers;

/// <summary>
/// 代码生成器
/// </summary>
[ApiController]
[Produces("application/json")]
[Route("api/[controller]")]
public class CodeGeneratorController : ApiController
{

    private readonly IWebHostEnvironment _hostingEnvironment;
    /// <summary>
    /// 
    /// </summary>
    /// <param name="hostingEnvironment"></param>
    public CodeGeneratorController(IWebHostEnvironment hostingEnvironment)
    {
        _hostingEnvironment = hostingEnvironment;
    }

    /// <summary>
    /// 创建数据库连接
    /// </summary>
    /// <param name="dbConnInfo"></param>
    /// <returns></returns>
    [HttpPost("CreateDBConn")]
    [YuebonAuthorize("CreateDBConn")]
    [NoPermissionRequired]
    public async Task<IActionResult> CreateDBConn(DbConnInfo dbConnInfo)
    {
        CommonResult result = new CommonResult();
        string connstr = string.Empty;
        if (dbConnInfo != null)
        {
            if (string.IsNullOrEmpty(dbConnInfo.DbAddress))
            {
                result.ErrMsg = "访问地址不能为空";
            }
            YuebonCacheHelper yuebonCacheHelper = new YuebonCacheHelper();
            TimeSpan expiresSliding = DateTime.Now.AddMinutes(30) - DateTime.Now;
            yuebonCacheHelper.Add("CodeGeneratorDbConn", dbConnInfo.DbAddress, expiresSliding, false);
            yuebonCacheHelper.Add("CodeGeneratorDbType", dbConnInfo.DbType, expiresSliding, false);
            result.ResData=new Yuebon.Commons.CodeGenerator.CodeGenerator().GetDB().DbMaintenance.GetDataBaseList(new Yuebon.Commons.CodeGenerator.CodeGenerator().GetDB());
            result.Success = true;
            result.ErrCode = ErrCode.successCode;
           
        }
        return ToJsonContent(result);
    }

    /// <summary>
    /// 获取所有数据库的信息
    /// </summary>
    /// <returns></returns>
    [HttpGet("GetListDataBase")]
    [YuebonAuthorize("GetListDataBase")]
    [NoPermissionRequired]
    public async Task<IActionResult> GetListDataBase()
    {
        YuebonCacheHelper yuebonCacheHelper = new YuebonCacheHelper();
        yuebonCacheHelper.Remove("CodeGeneratorDbConn");
        yuebonCacheHelper.Remove("CodeGeneratorDbName");
        CommonResult result = new CommonResult();
        result.ResData = new Yuebon.Commons.CodeGenerator.CodeGenerator().GetDB().DbMaintenance.GetDataBaseList(new Yuebon.Commons.CodeGenerator.CodeGenerator().GetDB());
        result.ErrCode = ErrCode.successCode;
        return ToJsonContent(result);
    }

    /// <summary>
    /// 获取数据库的所有表信息
    /// </summary>
    /// <param name="search"></param>
    /// <returns></returns>
    [HttpPost("FindListTable")]
    [YuebonAuthorize("FindListTable")]
    [NoPermissionRequired]
    public CommonResult<PageResult<DbTableInfo>> FindListTable(SearchModel search)
    {
        CommonResult<PageResult<DbTableInfo>> result = new CommonResult<PageResult<DbTableInfo>>();
        
        PagerInfo pagerInfo = new PagerInfo
        {
            PageSize = search.PageSize,
            CurrenetPageIndex = search.CurrenetPageIndex
        };

        PageResult<DbTableInfo> pageResult = new PageResult<DbTableInfo>();
        pageResult.CurrentPage = pagerInfo.CurrenetPageIndex;
        pageResult.Items = new Yuebon.Commons.CodeGenerator.CodeGenerator().GetDB().DbMaintenance.GetTableInfoList().FindAll(o=>o.Name.Contains(search.Keywords));
        pageResult.ItemsPerPage = pagerInfo.PageSize;
        pageResult.TotalItems = pagerInfo.RecordCount;
        result.ResData = pageResult;
        result.ErrCode = ErrCode.successCode;
        return result;
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
                Commons.CodeGenerator.CodeGenerator.Generate(baseSpace, tables, replaceTableNameStr);
                var path = AppDomain.CurrentDomain.BaseDirectory;
                var parentPath = path.Substring(0, path.LastIndexOf("\\"));
                var servicesPath = parentPath + "\\" + baseSpace + "\\";
                //生成压缩包
                string zipReturnFileName = baseSpace+DateTime.Now.ToString("yyyyMMddHHmmss") + ".zip";
                string zipFileBasePath = "Generatecode";
                string zipFilesPath = _hostingEnvironment.WebRootPath + "\\"+ zipFileBasePath;
                if (!System.IO.Directory.Exists(zipFilesPath))
                {
                    System.IO.Directory.CreateDirectory(zipFilesPath);
                }
                string zipFileName = zipFilesPath + "\\" + zipReturnFileName;
                if (System.IO.File.Exists(zipFileName))
                {
                    System.IO.File.Delete(zipFileName);
                }
                FileHelper.ZipFileDirectory(servicesPath, zipFileName, 7, "", "", "*.*");
                FileHelper.DeleteDirectory(servicesPath);
                result.ErrCode = ErrCode.successCode;
                result.Success = true;
                result.ResData = new string[2] { zipFileBasePath+"/"+ zipReturnFileName, zipReturnFileName };
            }
        }catch(Exception ex)
        {
            Log4NetHelper.Error("代码生成异常",ex);
            result.ErrMsg = "代码生成异常:"+ex.Message;
            result.ErrCode = ErrCode.failCode;
        }
        return ToJsonContent(result);
    }
}