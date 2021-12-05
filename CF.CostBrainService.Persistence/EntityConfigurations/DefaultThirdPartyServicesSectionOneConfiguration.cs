using CF.CostBrainService.Application.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.CostBrainService.Persistence.EntityConfigurations
{
    class DefaultThirdPartyServicesSectionOneConfiguration : BaseEntityConfiguration<DefaultThirdPartyServicesSectionOne>
    {
        public override void Configure(EntityTypeBuilder<DefaultThirdPartyServicesSectionOne> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);
        }
    }
}
