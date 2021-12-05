using CF.ProjectService.Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.ProjectService.Persistence.EntityConfigurations
{
    public class DrillingCenterConfiguration : BaseEntityConfiguration<DrillingCenterData>
    {
        public override void Configure(EntityTypeBuilder<DrillingCenterData> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);

            entityTypeBuilder.HasOne(x => x.ProjectRevision).WithMany(x => x.DrillingCenter).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
