using CF.CostBrainService.Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.CostBrainService.Persistence.EntityConfigurations
{
    class CostSummarySubTotalConfiguration : BaseEntityConfiguration<CostSummarySubTotal>
    {
        public override void Configure(EntityTypeBuilder<CostSummarySubTotal> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);
        }
    }
}
