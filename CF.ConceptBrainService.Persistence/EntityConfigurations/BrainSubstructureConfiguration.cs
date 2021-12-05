using CF.ConceptBrainService.Application.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CF.ConceptBrainService.Persistence.EntityConfigurations
{
    public class BrainSubstructureConfiguration :  BaseEntityConfiguration<BrainSubstructure>
    {
        public override void Configure(EntityTypeBuilder<BrainSubstructure> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);

            entityTypeBuilder.Property(t => t.Location).HasMaxLength(50);
            entityTypeBuilder.Property(t => t.TreeType).HasMaxLength(50);
            entityTypeBuilder.Property(t => t.ProcessingScheme).HasMaxLength(50);
            entityTypeBuilder.Property(t => t.SubStructureType).HasMaxLength(500);
        }
    }
}
