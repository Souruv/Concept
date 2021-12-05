using CF.CostBrainService.Application.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CF.CostBrainService.Persistence.EntityConfigurations
{
    class HUCSummaryCostConfiguration : BaseEntityConfiguration<HUCSummaryCost>
    {
        public override void Configure(EntityTypeBuilder<HUCSummaryCost> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);
        }
    }
}
