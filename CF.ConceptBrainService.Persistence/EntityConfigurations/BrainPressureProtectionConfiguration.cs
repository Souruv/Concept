using CF.ConceptBrainService.Application.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CF.ConceptBrainService.Persistence.EntityConfigurations
{
    public class BrainPressureProtectionConfiguration : BaseEntityConfiguration<BrainPressureProtection>
    {
        public override void Configure(EntityTypeBuilder<BrainPressureProtection> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);
            entityTypeBuilder.Property(t => t.Pressureprotection).HasMaxLength(50);
        }
    }
}
