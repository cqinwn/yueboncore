using System;
using System.Collections.Generic;
using Yuebon.Commons.SeedInitData;
using Yuebon.Security.Models;

namespace Yuebon.Security.SeedData
{
    public class OrganizeSeedData : SeedDataEntity
    {
        /// <summary>
        /// 种子数据
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Organize> HasData()
        {
            return new[] { 
                new Organize{
                    Id= 9165855286886469,
                    ParentId= 0,
                    Layers= 1,
                    EnCode= "Company",
                    FullName= "上海越邦网络科技有限公司",
                    ShortName= "越邦科技",
                    CategoryId= "Group",
                    ManagerId= "陈青文",
                    TelePhone= "021-61974937",
                    MobilePhone= "13800013800",
                    WeChat= "cqinwn",
                    Fax= null,
                    Email= "admin@qq.com",
                    AreaId= null,
                    Address= "上海市松江区",
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
                },
                new Organize{
                    Id= 9165855286886470,
                    ParentId= 9165855286886469,
                    Layers= 2,
                    EnCode= "Department",
                    FullName= "开发部",
                    ShortName= "越邦科技",
                    CategoryId= "Department",
                    ManagerId= "陈青文",
                    TelePhone= "021-61974937",
                    MobilePhone= "13800013800",
                    WeChat= "cqinwn",
                    Fax= null,
                    Email= "admin@qq.com",
                    AreaId= null,
                    Address= "上海市松江区",
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
                },
            };
        }
    }
}
