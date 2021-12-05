using CF.CostBrainService.Application.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CF.CostBrainService.Persistence.EntityConfigurations
{
    class DefaultEquipmentManPowerPercentageConfiguration : BaseEntityConfiguration<DefaultEquipmentManPowerPercentage>
    {
        public override void Configure(EntityTypeBuilder<DefaultEquipmentManPowerPercentage> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);
        }
    }
}
