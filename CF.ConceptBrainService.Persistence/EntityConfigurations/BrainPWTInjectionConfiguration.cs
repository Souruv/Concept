using CF.ConceptBrainService.Application.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace CF.ConceptBrainService.Persistence.EntityConfigurations
{
    public class BrainPWTInjectionConfiguration : BaseEntityConfiguration<BrainPWTInjection>
    {
        public override void Configure(EntityTypeBuilder<BrainPWTInjection> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);

            entityTypeBuilder.Property(t => t.PwtInjection).HasMaxLength(50);
            entityTypeBuilder.Property(t => t.ProcessText).HasMaxLength(300);
            entityTypeBuilder.Property(t => t.ProcessIds).HasMaxLength(300);
            entityTypeBuilder.Property(t => t.Pipeline).HasMaxLength(100);
        }
    }
}
