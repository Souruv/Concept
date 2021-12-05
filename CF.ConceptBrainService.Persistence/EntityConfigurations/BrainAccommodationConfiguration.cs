using CF.ConceptBrainService.Application.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace CF.ConceptBrainService.Persistence.EntityConfigurations
{
    public class BrainAccommodationConfiguration : BaseEntityConfiguration<BrainAccommodation>
    {
        public override void Configure(EntityTypeBuilder<BrainAccommodation> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);

            entityTypeBuilder.Property(t => t.ProcessingScheme).HasMaxLength(50);
            entityTypeBuilder.Property(t => t.Location).HasMaxLength(50);
            entityTypeBuilder.Property(t => t.Accommodation).HasMaxLength(500);
        }
    }
}
