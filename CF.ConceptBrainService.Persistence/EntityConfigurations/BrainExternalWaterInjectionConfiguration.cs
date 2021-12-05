using CF.ConceptBrainService.Application.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CF.ConceptBrainService.Persistence.EntityConfigurations
{
    public class BrainExternalWaterInjectionConfiguration : BaseEntityConfiguration<BrainExternalWaterInjection>
    {
        public override void Configure(EntityTypeBuilder<BrainExternalWaterInjection> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);

           
            entityTypeBuilder.Property(t => t.Location).HasMaxLength(50);
            entityTypeBuilder.Property(t => t.ExternalWaterInjection).HasMaxLength(50);
            entityTypeBuilder.Property(t => t.ProcessText).HasMaxLength(300);
            entityTypeBuilder.Property(t => t.ProcessIds).HasMaxLength(300);
            entityTypeBuilder.Property(t => t.Pipeline).HasMaxLength(100);
        }
    }
}
