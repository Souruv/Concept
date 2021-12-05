using CF.ConceptBrainService.Application.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CF.ConceptBrainService.Persistence.EntityConfigurations
{
    public class OilDhydrationSettingConfiguration : BaseEntityConfiguration<OilDhydrationSetting>
    {
        public override void Configure(EntityTypeBuilder<OilDhydrationSetting> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);
            entityTypeBuilder.Property(p => p.Id).ValueGeneratedOnAdd();
        }
    }
}
