using Yuebon.Commons.Attributes;

namespace Yuebon.Security.SeedData;

public class RoleSeedData : SeedDataEntity
{
    /// <summary>
    /// 种子数据
    /// </summary>
    /// <returns></returns>
    [IgnoreUpdate]
    public IEnumerable<Role> HasData()
    {
        return new[] {
            new Role{
                Id= 9242772029964357,
                Category= 1,
                EnCode= "usermember",
                FullName= "普通会员",
                Type= "2",
                AllowEdit= false,
                AllowDelete= false,
                SortCode= 99,
                DeleteMark= false,
                EnabledMark= true,
                Description= "",
                CreatorTime= DateTime.Now,
                CreatorUserId = 9165855286886368,
                LastModifyTime= null,
                LastModifyUserId= null,
                DeleteTime= null,
                DeleteUserId= null,
                OrganizeId= 9165855286886469,
                TenantId=9242772129579077
            },
            new Role{
                Id= 9242772030095429,
                Category= 1,
                EnCode= "default",
                FullName= "默认",
                Type= "2",
                AllowEdit= false,
                AllowDelete= false,
                SortCode= 8,
                DeleteMark= false,
                EnabledMark= true,
                Description= "",
                CreatorTime= DateTime.Now,
                CreatorUserId = 9165855286886368,
                LastModifyTime= null,
                LastModifyUserId= null,
                DeleteTime= null,
                DeleteUserId= null,
                OrganizeId= 9165855286886469,
                TenantId=9242772129579077
            },
            new Role{
                Id= 9242772030095430,
                Category= 1,
                EnCode= "guest",
                FullName= "访客人员",
                Type= "1",
                AllowEdit= false,
                AllowDelete= false,
                SortCode= 7,
                DeleteMark= false,
                EnabledMark= true,
                Description= "",
                CreatorTime= DateTime.Now,
                CreatorUserId = 9165855286886368,
                LastModifyTime= null,
                LastModifyUserId= null,
                DeleteTime= null,
                DeleteUserId= null,
                OrganizeId= 9165855286886469,
                TenantId=9242772129579077
            },
            new Role{
                Id= 9242772030095431,
                Category= 1,
                EnCode= "developer",
                FullName= "系统开发人员",
                Type= "2",
                AllowEdit= false,
                AllowDelete= false,
                SortCode= 4,
                DeleteMark= false,
                EnabledMark= true,
                Description= "",
                CreatorTime= DateTime.Now,
                CreatorUserId = 9165855286886368,
                LastModifyTime= null,
                LastModifyUserId= null,
                DeleteTime= null,
                DeleteUserId= null,
                OrganizeId= 9165855286886469,
                TenantId=9242772129579077
            },
            new Role{
                Id= 9242772030095432,
                Category= 1,
                EnCode= "configuration",
                FullName= "系统配置员",
                Type= "2",
                AllowEdit= false,
                AllowDelete= false,
                SortCode= 3,
                DeleteMark= false,
                EnabledMark= true,
                Description= "",
                CreatorTime= DateTime.Now,
                CreatorUserId = 9165855286886368,
                LastModifyTime= null,
                LastModifyUserId= null,
                DeleteTime= null,
                DeleteUserId= null,
                OrganizeId= 9165855286886469,
                TenantId=9242772129579077
            },
            new Role{
                Id= 9242772030095433,
                Category= 1,
                EnCode= "system",
                FullName= "系统管理员",
                Type= "1",
                AllowEdit= false,
                AllowDelete= false,
                SortCode= 2,
                DeleteMark= false,
                EnabledMark= true,
                Description= "",
                CreatorTime= DateTime.Now,
                CreatorUserId = 9165855286886368,
                LastModifyTime= null,
                LastModifyUserId= null,
                DeleteTime= null,
                DeleteUserId= null,
                OrganizeId= 9165855286886469,
                TenantId=9242772129579077
            },
            new Role{
                Id= 9242772029964356,
                Category= 1,
                EnCode= "administrators",
                FullName= "超级管理员",
                Type= "1",
                AllowEdit= false,
                AllowDelete= false,
                SortCode= 1,
                DeleteMark= false,
                EnabledMark= true,
                Description= "",
                CreatorTime= DateTime.Now,
                CreatorUserId = 9165855286886368,
                LastModifyTime= null,
                LastModifyUserId= null,
                DeleteTime= null,
                DeleteUserId= null,
                OrganizeId= 9165855286886469,
                TenantId=9242772129579077
            }
        };
    }
}
