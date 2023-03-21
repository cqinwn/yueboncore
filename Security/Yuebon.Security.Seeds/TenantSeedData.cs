using Yuebon.Commons.Attributes;
using Yuebon.Commons.Enums;

namespace Yuebon.Security.SeedData;

public class TenantSeedData : SeedDataEntity
{ /// <summary>
  /// 种子数据
  /// </summary>
  /// <returns></returns>
    [IgnoreUpdate]
    public IEnumerable<Tenant> HasData()
    {
        return new[] {
            new Tenant {
                Id=9242772129579077,
                TenantName="default",
                CompanyName="默认租户",
                TenantType=TenantTypeEnum.SYSTEM,
                HostDomain="localhost:8081",
                LinkMan="",
                Telphone="",
                Schema=TenantSchemaEnum.AloneDatabase,
                DataSource="",
                Description="",
                EnabledMark=true,
                DeleteMark=false,
                CreatorTime=DateTime.Now,
                CreatorUserId = 9165855286886368,
                CompanyId=9165855286886469,
                DeptId=9165855286886470,
                LastModifyTime=null,
                LastModifyUserId=null,
                DeleteTime=null,
                DeleteUserId=null
            },
            new Tenant {
                Id=9242772129579078,
                TenantName="tenant1",
                CompanyName="测试租户",
                TenantType=TenantTypeEnum.COMMON,
                HostDomain="localhost:8082",
                LinkMan="",
                Telphone="",
                Schema=TenantSchemaEnum.AloneDatabase,
                DataSource="",
                Description ="",
                EnabledMark=true,
                DeleteMark=false,
                CreatorTime=DateTime.Now,
                CreatorUserId = 9165855286886368,
                CompanyId=9165855286886469,
                DeptId=9165855286886470,
                LastModifyTime=null,
                LastModifyUserId=null,
                DeleteTime=null,
                DeleteUserId=null
            }
        };
    }
}
