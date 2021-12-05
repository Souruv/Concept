using CF.ConceptBrainService.Application.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CF.ConceptBrainService.Persistence.EntityConfigurations
{
    public class BrainTreeTypeConfiguration : BaseEntityConfiguration<BrainTreeType>
    {
        public override void Configure(EntityTypeBuilder<BrainTreeType> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);
            
            entityTypeBuilder.Property(t => t.Location).HasMaxLength(50);
            entityTypeBuilder.Property(t => t.TreeType).HasMaxLength(50);
        }
    }
}
