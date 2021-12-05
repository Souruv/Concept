using CF.ConceptBrainService.Application.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.ConceptBrainService.Persistence.EntityConfigurations
{
    class LevelInformationConfiguration : BaseEntityConfiguration<LevelInformation>
    {
        public override void Configure(EntityTypeBuilder<LevelInformation> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);

            entityTypeBuilder.Property(t => t.SecMinCriteriaValue).HasMaxLength(50);
            entityTypeBuilder.Property(t => t.SecMaxCriteriaValue).HasMaxLength(50);
        }
    }
}
