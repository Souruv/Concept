using CF.ConceptBrainService.Application.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CF.ConceptBrainService.Persistence.EntityConfigurations
{
    public class BrainGasInjectionConfiguration : BaseEntityConfiguration<BrainGasInjection>
    {
        public override void Configure(EntityTypeBuilder<BrainGasInjection> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);

            entityTypeBuilder.Property(t => t.HydrocarbonType).HasMaxLength(50);
            entityTypeBuilder.Property(t => t.GasInjection).HasMaxLength(500);
            entityTypeBuilder.Property(t => t.ProcessText).HasMaxLength(300);
            entityTypeBuilder.Property(t => t.ProcessIds).HasMaxLength(300);
            entityTypeBuilder.Property(t => t.Pipeline).HasMaxLength(500);
        }
    }
}
