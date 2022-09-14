using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Yuebon.Commons.EfDbContext
{
    /// <summary>
    /// 
    /// </summary>
    public class DefaultModelBuilder : ModelBuilder
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="conventions"></param>
        public DefaultModelBuilder(ConventionSet conventions) : base(conventions)
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public override ModelBuilder ApplyConfiguration<TEntity>(IEntityTypeConfiguration<TEntity> configuration)
        {
            return base.ApplyConfiguration(configuration);
        }
    }
}
