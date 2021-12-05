using CF.CostBrainService.Application.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CF.CostBrainService.Persistence.EntityConfigurations
{
    class FuelAndPWCostConfiguration : BaseEntityConfiguration<FuelAndPWCost>
    {
        public override void Configure(EntityTypeBuilder<FuelAndPWCost> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);
        }
    }
}
