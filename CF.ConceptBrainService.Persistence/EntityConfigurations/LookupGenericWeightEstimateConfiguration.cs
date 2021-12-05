using CF.ConceptBrainService.Application.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.ConceptBrainService.Persistence.EntityConfigurations
{
    class LookupGenericWeightEstimateConfiguration : BaseEntityConfiguration<LookupGenericWeightEstimate>
    {
        public override void Configure(EntityTypeBuilder<LookupGenericWeightEstimate> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);
        
            //entityTypeBuilder.Property(t => t.PipeRating).HasMaxLength(100);
            entityTypeBuilder.Property(t => t.Formula).HasMaxLength(200);
            entityTypeBuilder.Property(t => t.Remarks).HasMaxLength(450);
        }
    }
}
