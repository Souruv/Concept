using CF.ConceptBrainService.Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace CF.ConceptBrainService.Persistence.EntityConfigurations
{
    public class ConceptConfiguration : BaseEntityConfiguration<Concept>
    {
        public override void Configure(EntityTypeBuilder<Concept> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);

            entityTypeBuilder.Property(t => t.ConceptName).HasMaxLength(100);
            entityTypeBuilder.Property(t => t.Location).HasMaxLength(50);
            entityTypeBuilder.Property(t => t.Plevel).HasMaxLength(50);
            //entityTypeBuilder.Property(t => t.Accomodation).HasMaxLength(50);
            entityTypeBuilder.HasOne(x => x.ProjectConceptQueue).WithMany().OnDelete(DeleteBehavior.Restrict).HasForeignKey(x => x.ProjectConceptQueueId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
