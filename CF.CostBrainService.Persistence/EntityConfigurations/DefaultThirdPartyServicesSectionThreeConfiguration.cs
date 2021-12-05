using CF.CostBrainService.Application.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.CostBrainService.Persistence.EntityConfigurations
{
    class DefaultThirdPartyServicesSectionThreeConfiguration : BaseEntityConfiguration<DefaultThirdPartyServicesSectionThree>
    {
        public override void Configure(EntityTypeBuilder<DefaultThirdPartyServicesSectionThree> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);
        }
    }
}
