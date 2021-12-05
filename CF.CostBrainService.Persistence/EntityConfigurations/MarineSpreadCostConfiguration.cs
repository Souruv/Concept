using CF.CostBrainService.Application.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CF.CostBrainService.Persistence.EntityConfigurations
{
    class MarineSpreadCostConfiguration : BaseEntityConfiguration<MarineSpreadCost>
    {
        public override void Configure(EntityTypeBuilder<MarineSpreadCost> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);
        }
    }
}
