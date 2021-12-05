using CF.CostBrainService.Application.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.CostBrainService.Persistence.EntityConfigurations
{
    class DefaultManpowerManHrsRateConfiguration : BaseEntityConfiguration<DefaultManpowerManHrsRate>
    {
        public override void Configure(EntityTypeBuilder<DefaultManpowerManHrsRate> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);
        }
    }
}
