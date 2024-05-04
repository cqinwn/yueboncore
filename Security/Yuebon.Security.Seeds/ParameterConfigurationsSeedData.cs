using Yuebon.Commons.Attributes;

namespace Yuebon.Security.SeedData;

/// <summary>
/// 系统参数配置 初始化数据
/// </summary>
public class ParameterConfigurationsSeedData : SeedDataEntity
{
    /// <summary>
    /// 种子数据
    /// </summary>
    /// <returns></returns>
    [IgnoreUpdate]
    public IEnumerable<ParameterConfigurations> HasData()
    {
        return new[]
        {
            //new SysParametersConfigurations()
            //{
            //    Id = 1,
            //    ParameterName = "SoftName",
            //    ParameterValue = "yueboncore演示租户",
            //    Description="软件名称",
            //    DeleteMark=false,
            //    EnabledMark=true,
            //    CreatorTime=DateTime.Now,
            //    CreatorUserId = 9165855286886368,
            //    LastModifyTime= null,
            //    LastModifyUserId= null,
            //    DeleteTime= null,
            //    DeleteUserId= null,
            //    OrganizeId= 9165855286886469,
            //    DepartmentId= 9165855286886470,
            //    TenantId=9242772129579077
            //},
            //new SysParametersConfigurations()
            //{
            //    Id = 1,
            //    ParameterName = "SoftSummary",
            //    ParameterValue = "Net Vue前后端分离",
            //    Description="系统简介",
            //    DeleteMark=false,
            //    EnabledMark=true,
            //    CreatorTime=DateTime.Now,
            //    CreatorUserId = 9165855286886368,
            //    LastModifyTime= null,
            //    LastModifyUserId= null,
            //    DeleteTime= null,
            //    DeleteUserId= null,
            //    OrganizeId= 9165855286886469,
            //    DepartmentId= 9165855286886470,
            //    TenantId=9242772129579077
            //},
            //new SysParametersConfigurations()
            //{
            //    Id = 1,
            //    ParameterName = "SysLogo",
            //    ParameterValue = "",
            //    Description="系统Logo",
            //    DeleteMark=false,
            //    EnabledMark=true,
            //    CreatorTime=DateTime.Now,
            //    CreatorUserId = 9165855286886368,
            //    LastModifyTime= null,
            //    LastModifyUserId= null,
            //    DeleteTime= null,
            //    DeleteUserId= null,
            //    OrganizeId= 9165855286886469,
            //    DepartmentId= 9165855286886470,
            //    TenantId=9242772129579077
            //},
            //new SysParametersConfigurations()
            //{
            //    Id = 1,
            //    ParameterName = "CompanyName",
            //    ParameterValue = "XX集团",
            //    Description="公司名称",
            //    DeleteMark=false,
            //    EnabledMark=true,
            //    CreatorTime=DateTime.Now,
            //    CreatorUserId = 9165855286886368,
            //    LastModifyTime= null,
            //    LastModifyUserId= null,
            //    DeleteTime= null,
            //    DeleteUserId= null,
            //    OrganizeId= 9165855286886469,
            //    DepartmentId= 9165855286886470,
            //    TenantId=9242772129579077
            //},
            //new SysParametersConfigurations()
            //{
            //    Id = 1,
            //    ParameterName = "Address",
            //    ParameterValue = "上海市青浦区诸陆东路XX",
            //    Description="地址",
            //    DeleteMark=false,
            //    EnabledMark=true,
            //    CreatorTime=DateTime.Now,
            //    CreatorUserId = 9165855286886368,
            //    LastModifyTime= null,
            //    LastModifyUserId= null,
            //    DeleteTime= null,
            //    DeleteUserId= null,
            //    OrganizeId= 9165855286886469,
            //    DepartmentId= 9165855286886470,
            //    TenantId=9242772129579077
            //},
            //new SysParametersConfigurations()
            //{
            //    Id = 1,
            //    ParameterName = "Telphone",
            //    ParameterValue = "",
            //    Description="电话",
            //    DeleteMark=false,
            //    EnabledMark=true,
            //    CreatorTime=DateTime.Now,
            //    CreatorUserId = 9165855286886368,
            //    LastModifyTime= null,
            //    LastModifyUserId= null,
            //    DeleteTime= null,
            //    DeleteUserId= null,
            //    OrganizeId= 9165855286886469,
            //    DepartmentId= 9165855286886470,
            //    TenantId=9242772129579077
            //},
            //new SysParametersConfigurations()
            //{
            //    Id = 1,
            //    ParameterName = "Email",
            //    ParameterValue = "",
            //    Description="Email",
            //    DeleteMark=false,
            //    EnabledMark=true,
            //    CreatorTime=DateTime.Now,
            //    CreatorUserId = 9165855286886368,
            //    LastModifyTime= null,
            //    LastModifyUserId= null,
            //    DeleteTime= null,
            //    DeleteUserId= null,
            //    OrganizeId= 9165855286886469,
            //    DepartmentId= 9165855286886470,
            //    TenantId=9242772129579077
            //},
            //new SysParametersConfigurations()
            //{
            //    Id = 1,
            //    ParameterName = "ICPCode",
            //    ParameterValue = "",
            //    Description="ICP备案号",
            //    DeleteMark=false,
            //    EnabledMark=true,
            //    CreatorTime=DateTime.Now,
            //    CreatorUserId = 9165855286886368,
            //    LastModifyTime= null,
            //    LastModifyUserId= null,
            //    DeleteTime= null,
            //    DeleteUserId= null,
            //    OrganizeId= 9165855286886469,
            //    DepartmentId= 9165855286886470,
            //    TenantId=9242772129579077
            //},
            //new SysParametersConfigurations()
            //{
            //    Id = 1,
            //    ParameterName = "PublicSecurityCode",
            //    ParameterValue = "",
            //    Description="网安备案号",
            //    DeleteMark=false,
            //    EnabledMark=true,
            //    CreatorTime=DateTime.Now,
            //    CreatorUserId = 9165855286886368,
            //    LastModifyTime= null,
            //    LastModifyUserId= null,
            //    DeleteTime= null,
            //    DeleteUserId= null,
            //    OrganizeId= 9165855286886469,
            //    DepartmentId= 9165855286886470,
            //    TenantId=9242772129579077
            //},
            //new SysParametersConfigurations()
            //{
            //    Id = 1,
            //    ParameterName = "Webstatus",
            //    ParameterValue = "",
            //    Description="是否开启系统",
            //    DeleteMark=false,
            //    EnabledMark=true,
            //    CreatorTime=DateTime.Now,
            //    CreatorUserId = 9165855286886368,
            //    LastModifyTime= null,
            //    LastModifyUserId= null,
            //    DeleteTime= null,
            //    DeleteUserId= null,
            //    OrganizeId= 9165855286886469,
            //    DepartmentId= 9165855286886470,
            //    TenantId=9242772129579077
            //},
            //new SysParametersConfigurations()
            //{
            //    Id = 1,
            //    ParameterName = "Webclosereason",
            //    ParameterValue = "",
            //    Description="系统关闭原因",
            //    DeleteMark=false,
            //    EnabledMark=true,
            //    CreatorTime=DateTime.Now,
            //    CreatorUserId = 9165855286886368,
            //    LastModifyTime= null,
            //    LastModifyUserId= null,
            //    DeleteTime= null,
            //    DeleteUserId= null,
            //    OrganizeId= 9165855286886469,
            //    DepartmentId= 9165855286886470,
            //    TenantId=9242772129579077
            //},
            //new SysParametersConfigurations()
            //{
            //    Id = 1,
            //    ParameterName = "Webcountcode",
            //    ParameterValue = "",
            //    Description="系统统计代码",
            //    DeleteMark=false,
            //    EnabledMark=true,
            //    CreatorTime=DateTime.Now,
            //    CreatorUserId = 9165855286886368,
            //    LastModifyTime= null,
            //    LastModifyUserId= null,
            //    DeleteTime= null,
            //    DeleteUserId= null,
            //    OrganizeId= 9165855286886469,
            //    DepartmentId= 9165855286886470,
            //    TenantId=9242772129579077
            //},
            //new SysParametersConfigurations()
            //{
            //    Id = 1,
            //    ParameterName = "Smsapiurl",
            //    ParameterValue = "",
            //    Description="短信API地址",
            //    DeleteMark=false,
            //    EnabledMark=true,
            //    CreatorTime=DateTime.Now,
            //    CreatorUserId = 9165855286886368,
            //    LastModifyTime= null,
            //    LastModifyUserId= null,
            //    DeleteTime= null,
            //    DeleteUserId= null,
            //    OrganizeId= 9165855286886469,
            //    DepartmentId= 9165855286886470,
            //    TenantId=9242772129579077
            //},
            //new SysParametersConfigurations()
            //{
            //    Id = 1,
            //    ParameterName = "Smsusername",
            //    ParameterValue = "",
            //    Description="平台登录账户",
            //    DeleteMark=false,
            //    EnabledMark=true,
            //    CreatorTime=DateTime.Now,
            //    CreatorUserId = 9165855286886368,
            //    LastModifyTime= null,
            //    LastModifyUserId= null,
            //    DeleteTime= null,
            //    DeleteUserId= null,
            //    OrganizeId= 9165855286886469,
            //    DepartmentId= 9165855286886470,
            //    TenantId=9242772129579077
            //},
            //new SysParametersConfigurations()
            //{
            //    Id = 1,
            //    ParameterName = "Smspassword",
            //    ParameterValue = "",
            //    Description="平台通信密钥",
            //    DeleteMark=false,
            //    EnabledMark=true,
            //    CreatorTime=DateTime.Now,
            //    CreatorUserId = 9165855286886368,
            //    LastModifyTime= null,
            //    LastModifyUserId= null,
            //    DeleteTime= null,
            //    DeleteUserId= null,
            //    OrganizeId= 9165855286886469,
            //    DepartmentId= 9165855286886470,
            //    TenantId=9242772129579077
            //},
            //new SysParametersConfigurations()
            //{
            //    Id = 1,
            //    ParameterName = "SmsSignName",
            //    ParameterValue = "",
            //    Description="短信签名",
            //    DeleteMark=false,
            //    EnabledMark=true,
            //    CreatorTime=DateTime.Now,
            //    CreatorUserId = 9165855286886368,
            //    LastModifyTime= null,
            //    LastModifyUserId= null,
            //    DeleteTime= null,
            //    DeleteUserId= null,
            //    OrganizeId= 9165855286886469,
            //    DepartmentId= 9165855286886470,
            //    TenantId=9242772129579077
            //},
            new ParameterConfigurations()
            {
                Id = 1,
                ParameterName = "BaiduMapAk",
                ParameterValue = "",
                Description="百度地图应用AK",
                DeleteMark=false,
                EnabledMark=true,
                CreatorTime=DateTime.Now,
                CreatorUserId = 9165855286886368,
                LastModifyTime= null,
                LastModifyUserId= null,
                DeleteTime= null,
                DeleteUserId= null,
                OrganizeId= 9165855286886469,
                DepartmentId= 9165855286886470,
                TenantId=9242772129579077
            },
            new ParameterConfigurations()
            {
                Id = 2,
                ParameterName = "GaodeMapKey",
                ParameterValue = "",
                Description="高德地图应用Key",
                DeleteMark=false,
                EnabledMark=true,
                CreatorTime=DateTime.Now,
                CreatorUserId = 9165855286886368,
                LastModifyTime= null,
                LastModifyUserId= null,
                DeleteTime= null,
                DeleteUserId= null,
                OrganizeId= 9165855286886469,
                DepartmentId= 9165855286886470,
                TenantId=9242772129579077
            },
            new ParameterConfigurations()
            {
                Id = 3,
                ParameterName = "TencentMapKey",
                ParameterValue = "",
                Description="腾讯地图应用Key",
                DeleteMark=false,
                EnabledMark=true,
                CreatorTime=DateTime.Now,
                CreatorUserId = 9165855286886368,
                LastModifyTime= null,
                LastModifyUserId= null,
                DeleteTime= null,
                DeleteUserId= null,
                OrganizeId= 9165855286886469,
                DepartmentId= 9165855286886470,
                TenantId=9242772129579077
            }
        };
    }
}
