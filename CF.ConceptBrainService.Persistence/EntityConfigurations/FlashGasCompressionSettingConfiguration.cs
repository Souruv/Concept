using CF.ConceptBrainService.Application.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CF.ConceptBrainService.Persistence.EntityConfigurations
{
    public class FlashGasCompressionSettingConfiguration : BaseEntityConfiguration<FlashGasCompressionSetting>
    {
        public override void Configure(EntityTypeBuilder<FlashGasCompressionSetting> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);
            entityTypeBuilder.Property(p => p.Id).ValueGeneratedOnAdd();
        }
    }
}
