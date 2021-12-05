using CF.CostBrainService.Application.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.CostBrainService.Persistence.EntityConfigurations
{
    class ProjectLocationConfiguration : BaseEntityConfiguration<ProjectLocation>
    {
        public override void Configure(EntityTypeBuilder<ProjectLocation> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);
            entityTypeBuilder.Property(t => t.Location).IsRequired(true);
        }
    }
}
