using CF.CostBrainService.Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CF.CostBrainService.Persistence.EntityConfigurations
{
    class MasterPercentManPowerConfiguration : BaseEntityConfiguration<MasterPercentManPower>
    {
        public override void Configure(EntityTypeBuilder<MasterPercentManPower> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);
        }
    }
}
