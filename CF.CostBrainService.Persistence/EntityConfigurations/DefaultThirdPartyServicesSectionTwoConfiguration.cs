using CF.CostBrainService.Application.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.CostBrainService.Persistence.EntityConfigurations
{
    class DefaultThirdPartyServicesSectionTwoConfiguration : BaseEntityConfiguration<DefaultThirdPartyServicesSectionTwo>
    {
        public override void Configure(EntityTypeBuilder<DefaultThirdPartyServicesSectionTwo> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);
        }
    }
}
