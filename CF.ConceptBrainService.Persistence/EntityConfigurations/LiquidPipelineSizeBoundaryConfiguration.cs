using CF.ConceptBrainService.Application.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.ConceptBrainService.Persistence.EntityConfigurations
{
    public class LiquidPipelineSizeBoundaryConfiguration : BaseEntityConfiguration<LiquidPipelineSizeBoundary>
    {
        public override void Configure(EntityTypeBuilder<LiquidPipelineSizeBoundary> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);
        }
    }
}