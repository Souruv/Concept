using CF.ConceptBrainService.Application.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CF.ConceptBrainService.Persistence.EntityConfigurations
{
    public class PipelineRatingBoundaryConfiguration : BaseEntityConfiguration<PipelineRatingBoundary>
    {
        public override void Configure(EntityTypeBuilder<PipelineRatingBoundary> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);
            entityTypeBuilder.Property(p => p.Id).ValueGeneratedOnAdd();
        }
    }
}
