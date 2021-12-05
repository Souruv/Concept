using CF.ConceptBrainService.Application.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CF.ConceptBrainService.Persistence.EntityConfigurations
{
    public class LiquidPressureCurveSettingConfiguration : BaseEntityConfiguration<LiquidPressureCurveSetting>
    {
        public override void Configure(EntityTypeBuilder<LiquidPressureCurveSetting> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);
            entityTypeBuilder.Property(p => p.Id).ValueGeneratedOnAdd();
        }
    }
}
