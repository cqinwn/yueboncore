﻿using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Yuebon.Commons.EfDbContext;
using Yuebon.Commons.Repositories;
using Yuebon.Security.IRepositories;
using Yuebon.Security.Models;

namespace Yuebon.Security.Repositories
{
    /// <summary>
    /// 系统类型，也是子系统
    /// </summary>
    public class SystemTypeRepository : BaseRepository<SystemType, string>, ISystemTypeRepository
    {
        public SystemTypeRepository()
        {
        }

        public SystemTypeRepository(BaseDbContext dbContext) : base(dbContext)
        {
        }

        /// <summary>
        /// 根据系统编码查询系统对象
        /// </summary>
        /// <param name="appkey">系统编码</param>
        /// <returns></returns>
        public SystemType GetByCode(string appkey)
        {
            using (IDbConnection conn = OpenSharedConnection())
            {
                string sql = @"SELECT * FROM "+this.tableName+" t WHERE t.EnCode = @EnCode";
                return conn.QueryFirstOrDefault<SystemType>(sql, new { EnCode = appkey });
            }
        }
    }
}
