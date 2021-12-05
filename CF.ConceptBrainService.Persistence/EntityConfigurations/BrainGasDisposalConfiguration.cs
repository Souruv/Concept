using CF.ConceptBrainService.Application.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CF.ConceptBrainService.Persistence.EntityConfigurations
{
    public class BrainGasDisposalConfiguration : BaseEntityConfiguration<BrainGasDisposal>
    {
        public override void Configure(EntityTypeBuilder<BrainGasDisposal> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);

            entityTypeBuilder.Property(t => t.HydrocarbonType).HasMaxLength(50);
            entityTypeBuilder.Property(t => t.GasDisposal).HasMaxLength(100);
            entityTypeBuilder.Property(t => t.Process).HasMaxLength(500);
            entityTypeBuilder.Property(t => t.Pipeline).HasMaxLength(500);
        }
    }
}
