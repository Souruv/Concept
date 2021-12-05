using CF.CostBrainService.Application.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.CostBrainService.Persistence.EntityConfigurations
{
    class MasterWeightConfiguration : BaseEntityConfiguration<MasterWeight>
    {
        public override void Configure(EntityTypeBuilder<MasterWeight> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);
            entityTypeBuilder.Property(t => t.Weight).IsRequired(true);
        }
    }
}
