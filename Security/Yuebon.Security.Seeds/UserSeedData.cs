﻿namespace Yuebon.Security.SeedData;

public class UserSeedData : SeedDataEntity
{
    /// <summary>
    /// 种子数据
    /// </summary>
    /// <returns></returns>
    [IgnoreUpdate]
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
                ManagerId= 1,
                SecurityLevel= 1,
                Signature= null,
                CreateOrgId= 9165855286886470,
                RoleId= "9242772029964356",
                DutyId= 0,
                UserType=Commons.Enums.UserTypeEnum.SuperAdmin,
                MemberGradeId= null,
                ReferralUserId= null,
                SortCode= 1,
                Description= "拥有所有权限",
                DeleteMark= false,
                EnabledMark= true,
                CreatorTime= DateTime.Now,
                CreatorUserId= 9165855286886368,
                LastModifyTime= null,
                LastModifyUserId= null,
                DeleteTime= null,
                DeleteUserId= null,
                TenantId=9242772129579077
            }
        };
    }

}
