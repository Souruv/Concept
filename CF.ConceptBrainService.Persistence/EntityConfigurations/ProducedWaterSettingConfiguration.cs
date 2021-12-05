using CF.ConceptBrainService.Application.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CF.ConceptBrainService.Persistence.EntityConfigurations
{
    public class ProducedWaterSettingConfiguration : BaseEntityConfiguration<ProducedWaterSetting>
    {
        public override void Configure(EntityTypeBuilder<ProducedWaterSetting> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);
            entityTypeBuilder.Property(p => p.Id).ValueGeneratedOnAdd();
        }
    }
}
