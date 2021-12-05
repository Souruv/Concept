using CF.CostBrainService.Application.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.CostBrainService.Persistence.EntityConfigurations
{
    class ProjectTypeConfiguration : BaseEntityConfiguration<ProjectType>
    {
        public override void Configure(EntityTypeBuilder<ProjectType> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);
            entityTypeBuilder.Property(t => t.ProjectTypeName).IsRequired(true);
        }
    }
}
