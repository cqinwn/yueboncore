using System;
using System.Collections.Generic;
using Yuebon.Commons.SeedInitData;
using Yuebon.Security.Models;

namespace Yuebon.Security.SeedData
{
    public class UserSeedData : SeedDataEntity
    {
         /// <summary>
         /// 种子数据
         /// </summary>
         /// <returns></returns>
        public IEnumerable<User> HasData()
        {
            return new[] { 
                new User
                {
                    Id= 9165855286886368,
                    Account= "admin",
                    RealName= "超级管理员",
                    NickName= "超级管理员",
                    HeadIcon= null,
                    Gender= 1,
                    Birthday= DateTime.Parse("2017-02-28 00:00:00"),
                    MobilePhone= "13524343287",
                    Email= "cqinwn@qq.com",
                    WeChat= "cqinwn",
                    Country= null,
                    Province= null,
                    City= null,
                    District= null,
                    IsMember= null,
                    MemberGradeId= null,
                    ReferralUserId= null,
                    ManagerId= 1,
                    SecurityLevel= 1,
                    Signature= null,
                    OrganizeId= 9165855286886469,
                    DepartmentId= 9165855286886470,
                    RoleId= "9165855286886369",
                    DutyId= null,
                    IsAdministrator= true,
                    SortCode= 1,
                    Description= "拥有所有权限",
                    DeleteMark= false,
                    EnabledMark= true,
                    CreatorTime= DateTime.Parse("2017-02-28 00:00:00"),
                    CreatorUserId= 9165855286886368,
                    LastModifyTime= null,
                    LastModifyUserId= null,
                    DeleteTime= null,
                    DeleteUserId= null
                }
            };
        }
    
    }
}
