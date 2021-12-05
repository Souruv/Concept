using CF.ConceptBrainService.Application.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CF.ConceptBrainService.Persistence.EntityConfigurations
{
    public class BrainGasExportConfiguration : BaseEntityConfiguration<BrainGasExport>
    {
        public override void Configure(EntityTypeBuilder<BrainGasExport> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);

            entityTypeBuilder.Property(t => t.HydrocarbonType).HasMaxLength(50);
            entityTypeBuilder.Property(t => t.GasExport).HasMaxLength(50);
            entityTypeBuilder.Property(t => t.ProcessText).HasMaxLength(300);
            entityTypeBuilder.Property(t => t.ProcessIds).HasMaxLength(300);
            entityTypeBuilder.Property(t => t.Pipeline).HasMaxLength(500);
        }
    }
}
