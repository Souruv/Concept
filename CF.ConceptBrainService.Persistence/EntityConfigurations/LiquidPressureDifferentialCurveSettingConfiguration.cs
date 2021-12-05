using CF.ConceptBrainService.Application.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CF.ConceptBrainService.Persistence.EntityConfigurations
{
    public class LiquidPressureDifferentialCurveSettingConfiguration : BaseEntityConfiguration<LiquidPressureDifferentialCurveSetting>
    {
        public override void Configure(EntityTypeBuilder<LiquidPressureDifferentialCurveSetting> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);
            entityTypeBuilder.Property(p => p.Id).ValueGeneratedOnAdd();
        }
    }
}
