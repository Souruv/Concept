using CF.CostBrainService.Application.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.CostBrainService.Persistence.EntityConfigurations
{
    class DefaultFuelAndPWConfiguration : BaseEntityConfiguration<DefaultOthersFuelAndPW>
    {
        public override void Configure(EntityTypeBuilder<DefaultOthersFuelAndPW> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);
        }
    }
}
