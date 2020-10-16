using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Yuebon.Commons.EfDbContext
{
    public class DefaultModelBuilder : ModelBuilder
    {
        public DefaultModelBuilder(ConventionSet conventions) : base(conventions)
        {
        }

        public override ModelBuilder ApplyConfiguration<TEntity>(IEntityTypeConfiguration<TEntity> configuration)
        {
            return base.ApplyConfiguration(configuration);
        }
    }
}
