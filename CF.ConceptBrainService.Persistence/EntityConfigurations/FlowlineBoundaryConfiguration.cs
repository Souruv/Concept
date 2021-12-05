using CF.ConceptBrainService.Application.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CF.ConceptBrainService.Persistence.EntityConfigurations
{
    public class FlowlineBoundaryConfiguration : BaseEntityConfiguration<FlowlineBoundary>
    {
        public override void Configure(EntityTypeBuilder<FlowlineBoundary> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);
            entityTypeBuilder.Property(p => p.Id).ValueGeneratedOnAdd();
        }
    }
}
