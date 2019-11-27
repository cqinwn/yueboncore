using System;
using Yuebon.Commons.Repositories;
using Yuebon.CMS.IRepositories;
using Yuebon.CMS.Models;

namespace Yuebon.CMS.Repositories
{
    public class ArticleBrowseTrajectoryRepository : BaseRepository<ArticleBrowseTrajectory, string>, IArticleBrowseTrajectoryRepository
    {
		public ArticleBrowseTrajectoryRepository()
        {
            this.tableName = "CMS_ArticleBrowseTrajectory";
            this.primaryKey = "Id";
        }
    }
}