using System;
using System.Collections.Generic;
using Yuebon.Commons.Helpers;
using Yuebon.Commons.SeedInitData;
using Yuebon.Security.Models;

namespace Yuebon.Security.SeedData
{
    public class RoleSeedData : SeedDataEntity
    {
        /// <summary>
        /// 种子数据
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Role> HasData()
        {
            return new[] {
                new Role{
                    Id= 9242772029964357,
                    OrganizeId= 9165855286886469,
                    Category= 1,
                    EnCode= "usermember",
                    FullName= "普通会员",
                    Type= "2",
                    AllowEdit= null,
                    AllowDelete= null,
                    SortCode= 99,
                    DeleteMark= false,
                    EnabledMark= true,
                    Description= "",
                    CreatorTime= DateTime.Now,
                    CreatorUserId = 9165855286886368,
                    LastModifyTime= null,
                    LastModifyUserId= null,
                    DeleteTime= null,
                    DeleteUserId= null
                },
                new Role{
                    Id= IdGeneratorHelper.IdSnowflake(),
                    OrganizeId= 9242772030095429,
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
                    DeleteUserId= null
                },
                new Role{
                    Id= 9242772030095430,
                    OrganizeId= 9165855286886469,
                    Category= 1,
                    EnCode= "guest",
                    FullName= "访客人员",
                    Type= "1",
                    AllowEdit= false,
                    AllowDelete= false,
                    SortCode= 7,
                    DeleteMark= false,
                    EnabledMark= true,
                    Description= null,
                    CreatorTime= DateTime.Now,
                    CreatorUserId = 9165855286886368,
                    LastModifyTime= null,
                    LastModifyUserId= null,
                    DeleteTime= null,
                    DeleteUserId= null
                },
                new Role{
                    Id= 9242772030095431,
                    OrganizeId= 9165855286886469,
                    Category= 1,
                    EnCode= "developer",
                    FullName= "系统开发人员",
                    Type= "2",
                    AllowEdit= false,
                    AllowDelete= false,
                    SortCode= 4,
                    DeleteMark= false,
                    EnabledMark= true,
                    Description= null,
                    CreatorTime= DateTime.Now,
                    CreatorUserId = 9165855286886368,
                    LastModifyTime= null,
                    LastModifyUserId= null,
                    DeleteTime= null,
                    DeleteUserId= null
                },
                new Role{
                    Id= 9242772030095432,
                    OrganizeId= 9165855286886469,
                    Category= 1,
                    EnCode= "configuration",
                    FullName= "系统配置员",
                    Type= "2",
                    AllowEdit= false,
                    AllowDelete= false,
                    SortCode= 3,
                    DeleteMark= false,
                    EnabledMark= true,
                    Description= null,
                    CreatorTime= DateTime.Now,
                    CreatorUserId = 9165855286886368,
                    LastModifyTime= null,
                    LastModifyUserId= null,
                    DeleteTime= null,
                    DeleteUserId= null
                },
                new Role{
                    Id= 9242772030095433,
                    OrganizeId= 9165855286886469,
                    Category= 1,
                    EnCode= "system",
                    FullName= "系统管理员",
                    Type= "1",
                    AllowEdit= false,
                    AllowDelete= false,
                    SortCode= 2,
                    DeleteMark= false,
                    EnabledMark= true,
                    Description= null,
                    CreatorTime= DateTime.Now,
                    CreatorUserId = 9165855286886368,
                    LastModifyTime= null,
                    LastModifyUserId= null,
                    DeleteTime= null,
                    DeleteUserId= null
                },
                new Role{
                    Id= 9242772029964356,
                    OrganizeId= 9165855286886469,
                    Category= 1,
                    EnCode= "administrators",
                    FullName= "超级管理员",
                    Type= "1",
                    AllowEdit= false,
                    AllowDelete= false,
                    SortCode= 1,
                    DeleteMark= false,
                    EnabledMark= true,
                    Description= null,
                    CreatorTime= DateTime.Now,
                    CreatorUserId = 9165855286886368,
                    LastModifyTime= null,
                    LastModifyUserId= null,
                    DeleteTime= null,
                    DeleteUserId= null
                }
            };
        }
    }
}
