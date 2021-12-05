using CF.ConceptBrainService.Application.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CF.ConceptBrainService.Persistence.EntityConfigurations
{
    public class BrainDrillingAndWorkoverStrategyConfiguration : BaseEntityConfiguration<BrainDrillingAndWorkoverStrategy>
    {
        public override void Configure(EntityTypeBuilder<BrainDrillingAndWorkoverStrategy> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);

            entityTypeBuilder.Property(t => t.TreeType).HasMaxLength(50);
            
            entityTypeBuilder.Property(t => t.Strategy).HasMaxLength(500);
        }
    }
}
