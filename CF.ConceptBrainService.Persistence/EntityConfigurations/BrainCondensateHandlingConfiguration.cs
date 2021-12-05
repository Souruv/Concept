using CF.ConceptBrainService.Application.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CF.ConceptBrainService.Persistence.EntityConfigurations
{
    public class BrainCondensateHandlingConfiguration : BaseEntityConfiguration<BrainCondensateHandling>
    {
        public override void Configure(EntityTypeBuilder<BrainCondensateHandling> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);

            entityTypeBuilder.Property(t => t.ProcessingScheme).HasMaxLength(50);
            entityTypeBuilder.Property(t => t.EvacuationScheme).HasMaxLength(50);
            entityTypeBuilder.Property(t => t.CondensateProcessing).HasMaxLength(200);
            entityTypeBuilder.Property(t => t.ProcessText).HasMaxLength(500);
            entityTypeBuilder.Property(t => t.ProcessIds).HasMaxLength(500);
            entityTypeBuilder.Property(t => t.PipeLine).HasMaxLength(500);
        }
    }
}
