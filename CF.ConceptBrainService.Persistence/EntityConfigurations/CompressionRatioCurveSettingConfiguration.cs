using CF.ConceptBrainService.Application.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CF.ConceptBrainService.Persistence.EntityConfigurations
{
    public class CompressionRatioCurveSettingConfiguration : BaseEntityConfiguration<CompressionRatioCurveSetting>
    {
        public override void Configure(EntityTypeBuilder<CompressionRatioCurveSetting> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);
            entityTypeBuilder.Property(p => p.Id).ValueGeneratedOnAdd();
        }
    }
}
