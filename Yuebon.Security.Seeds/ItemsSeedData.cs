using System;
using System.Collections.Generic;
using Yuebon.Commons.SeedInitData;
using Yuebon.Security.Models;

namespace Yuebon.Security.SeedData
{
    public class ItemsSeedData:SeedDataEntity
    {
        /// <summary>
        /// 种子数据
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Items> HasData()
        {
            return new[]
            {
                new Items{
                    Id= 9165806220476485,
                    ParentId= 0,
                    EnCode= "Sys_Items",
                    FullName= "通用字典",
                    IsTree= false,
                    Layers= null,
                    SortCode= 99,
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
                new Items{
                    Id= 9165809527554117,
                    ParentId= 9165806220476485,
                    EnCode= "OrganizeCategory",
                    FullName= "机构分类",
                    IsTree= false,
                    Layers= null,
                    SortCode= 99,
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
                new Items{
                    Id= 9165813031108677,
                    ParentId= 9165806220476485,
                    EnCode= "RoleType",
                    FullName= "角色类型",
                    IsTree= false,
                    Layers= null,
                    SortCode= 99,
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
