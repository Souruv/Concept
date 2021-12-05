using CF.CostBrainService.Application.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.CostBrainService.Persistence.EntityConfigurations
{
    class DefaultMarineSpreadAndOthersConfiguration : BaseEntityConfiguration<DefaultMarineSpreadAndOthers>
    {
        public override void Configure(EntityTypeBuilder<DefaultMarineSpreadAndOthers> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);
        }
    }
}
