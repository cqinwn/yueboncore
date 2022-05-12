﻿using CodeGenerator.Seed;
using log4net;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yuebon.Commons;
using Yuebon.Commons.Core.App;
using Yuebon.Commons.Helpers;

namespace CodeGenerator.Middlewares
{
    /// <summary>
    /// 生成种子数据中间件服务
    /// </summary>
    public static class SeedDataMiddleware
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(SeedDataMiddleware));
        public static void UseSeedDataMiddle(this IApplicationBuilder app, MyContext myContext, string webRootPath)
        {
            if (app == null) throw new ArgumentNullException(nameof(app));

            try
            {
                if (Appsettings.app("AppSettings", "SeedDBEnabled").ObjToBool() || Appsettings.app("AppSettings", "SeedDBDataEnabled").ObjToBool())
                {
                    DBSeed.SeedAsync(myContext, webRootPath).Wait();
                }
            }
            catch (Exception e)
            {
                Log.Error($"Error occured seeding the Database.\n{e.Message}");
                throw;
            }
        }
    }
}
