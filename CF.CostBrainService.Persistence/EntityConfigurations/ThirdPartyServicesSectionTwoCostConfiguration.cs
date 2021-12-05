using CF.CostBrainService.Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CF.CostBrainService.Persistence.EntityConfigurations
{
    class ThirdPartyServicesSectionTwoCostConfiguration : BaseEntityConfiguration<ThirdPartyServicesSectionTwoCost>
    {
        public override void Configure(EntityTypeBuilder<ThirdPartyServicesSectionTwoCost> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);
        }
    }
}
