using CF.ConceptBrainService.Application.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CF.ConceptBrainService.Persistence.EntityConfigurations
{
    public class OilDesaltingSettingConfiguration : BaseEntityConfiguration<OilDesaltingSetting>
    {
        public override void Configure(EntityTypeBuilder<OilDesaltingSetting> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);
            entityTypeBuilder.Property(p => p.Id).ValueGeneratedOnAdd();
        }
    }
}
