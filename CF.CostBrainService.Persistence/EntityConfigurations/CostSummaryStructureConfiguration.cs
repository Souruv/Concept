using CF.CostBrainService.Application.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.CostBrainService.Persistence.EntityConfigurations
{
    class CostSummaryStructureConfiguration : BaseEntityConfiguration<CostSummaryStructure>
    {
        public override void Configure(EntityTypeBuilder<CostSummaryStructure> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);
        }
    }
}
