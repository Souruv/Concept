using CF.CostBrainService.Application.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CF.CostBrainService.Persistence.EntityConfigurations
{
    class MasterDaysFactorperMonthConfiguration : BaseEntityConfiguration<MasterDaysFactorperMonth>
    {
        public override void Configure(EntityTypeBuilder<MasterDaysFactorperMonth> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);
        }
    }
}
