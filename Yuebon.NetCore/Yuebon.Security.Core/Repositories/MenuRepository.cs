using System;
using System.Collections.Generic;
using Yuebon.Commons.Options;
using Yuebon.Commons.Repositories;
using Yuebon.Security.IRepositories;
using Yuebon.Security.Models;

namespace Yuebon.Security.Repositories
{
    public class MenuRepository : BaseRepository<Menu, string>, IMenuRepository
    {
        public MenuRepository()
        {
            this.tableName = "Sys_Menu";
            this.primaryKey = "Id";
        }
    }
}