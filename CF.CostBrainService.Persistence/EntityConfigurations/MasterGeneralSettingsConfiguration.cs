using CF.CostBrainService.Application.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace CF.CostBrainService.Persistence.EntityConfigurations
{
    public class MasterGeneralSettingsConfiguration : BaseEntityConfiguration<MasterGeneralSettings>
    {
        public override void Configure(EntityTypeBuilder<MasterGeneralSettings> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);
            entityTypeBuilder.Property(t => t.LabelName).IsRequired(true);
        }
    }
}
