using CF.CostBrainService.Application.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CF.CostBrainService.Persistence.EntityConfigurations
{
    class EquipmentConfiguration : BaseEntityConfiguration<Equipment>
    {
        public override void Configure(EntityTypeBuilder<Equipment> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);
            entityTypeBuilder.Property(t => t.Manifolding).IsRequired(true);
        }
    }
}
