using CF.ConceptBrainService.Application.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CF.ConceptBrainService.Persistence.EntityConfigurations
{
    public class BrainOilHandlingConfiguration : BaseEntityConfiguration<BrainOilHandling>
    {
        public override void Configure(EntityTypeBuilder<BrainOilHandling> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);

            entityTypeBuilder.Property(t => t.ProcessingScheme).HasMaxLength(50);
            entityTypeBuilder.Property(t => t.EvacuationScheme).HasMaxLength(50);
            entityTypeBuilder.Property(t => t.OilProcessing).HasMaxLength(100);
            entityTypeBuilder.Property(t => t.ProcessText).HasMaxLength(300);
            entityTypeBuilder.Property(t => t.ProcessIds).HasMaxLength(300);
            entityTypeBuilder.Property(t => t.Pipeline).HasMaxLength(100);
        }
    }
}
