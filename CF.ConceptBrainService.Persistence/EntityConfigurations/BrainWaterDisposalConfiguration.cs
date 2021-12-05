using CF.ConceptBrainService.Application.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CF.ConceptBrainService.Persistence.EntityConfigurations
{
    public class BrainWaterDisposalConfiguration : BaseEntityConfiguration<BrainWaterDisposal>
    {
        public override void Configure(EntityTypeBuilder<BrainWaterDisposal> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);

            entityTypeBuilder.Property(t => t.AvailabilityOfDisposalReservoir).HasMaxLength(50);
            entityTypeBuilder.Property(t => t.Location).HasMaxLength(50);
            entityTypeBuilder.Property(t => t.WaterDisposal).HasMaxLength(100);
            entityTypeBuilder.Property(t => t.ProcessText).HasMaxLength(500);
            entityTypeBuilder.Property(t => t.ProcessIds).HasMaxLength(500);
            entityTypeBuilder.Property(t => t.Pipeline).HasMaxLength(200);
        }
    }
}
