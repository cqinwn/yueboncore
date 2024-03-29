﻿using System;
using System.Collections.Generic;
using Yuebon.Commons.SeedInitData;
using Yuebon.Security.Models;

namespace Yuebon.Security.SeedData
{
    public class UserLogOnSeedData : SeedDataEntity
    {
        /// <summary>
        /// 种子数据
        /// </summary>
        /// <returns></returns>
        public IEnumerable<UserLogOn> HasData()
        {
            return new[] {
                new UserLogOn
                {
                    Id=9242772031406149,
                    UserId=9165855286886368,
                    UserPassword= "10d24d52118495f97e2b4ed8b55b0388",
                    UserSecretkey= "fcec738e883ac408",
                    AllowStartTime=DateTime.Now,
                    AllowEndTime=DateTime.Now.AddYears(10),
                    LockStartDate=DateTime.Now,
                    LockEndDate=DateTime.Now,
                    FirstVisitTime=DateTime.Now,
                    LastVisitTime=DateTime.Now,
                    PreviousVisitTime=DateTime.Now,
                    ChangePasswordDate=DateTime.Now,
                    MultiUserLogin=true,
                    LogOnCount=0,
                    UserOnLine=false,
                    CheckIPAddress=false,


                    Theme= "{\"Theme\": \"#409EFF\",\"SideTheme\": \"theme-dark\",\"FixedHeader\": false,\"TagsView\": true,\"SidebarLogo\": true,\"DynamicTitle\": false,\"TopNav\": false}"
                }
            };
        }
    }
}
