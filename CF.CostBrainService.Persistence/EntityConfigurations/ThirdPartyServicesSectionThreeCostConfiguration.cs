using CF.CostBrainService.Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CF.CostBrainService.Persistence.EntityConfigurations
{
    class ThirdPartyServicesSectionThreeCostConfiguration : BaseEntityConfiguration<ThirdPartyServicesSectionThreeCost>
    {
        public override void Configure(EntityTypeBuilder<ThirdPartyServicesSectionThreeCost> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);
        }
    }
}
