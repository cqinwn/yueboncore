using System;
using Yuebon.Commons.Repositories;
using Yuebon.CMS.IRepositories;
using Yuebon.CMS.Models;
using Yuebon.Commons.EfDbContext;

namespace Yuebon.CMS.Repositories
{
    public class ArticleBrowseTrajectoryRepository : BaseRepository<ArticleBrowseTrajectory, string>, IArticleBrowseTrajectoryRepository
    {
		public ArticleBrowseTrajectoryRepository()
        {
            this.tableName = "CMS_ArticleBrowseTrajectory";
            this.primaryKey = "Id";
        }

        public ArticleBrowseTrajectoryRepository(BaseDbContext context) : base(context)
        {
            this.tableName = "CMS_ArticleBrowseTrajectory";
            this.primaryKey = "Id";
        }
    }
}