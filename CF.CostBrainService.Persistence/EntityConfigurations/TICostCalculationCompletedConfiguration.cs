using CF.CostBrainService.Application.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.CostBrainService.Persistence.EntityConfigurations
{
    class TICostCalculationCompletedConfiguration : BaseEntityConfiguration<TICostCalculationCompleted>
    {
        public override void Configure(EntityTypeBuilder<TICostCalculationCompleted> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);
        }
    }
}
