using CF.CostBrainService.Application.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CF.CostBrainService.Persistence.EntityConfigurations
{
    class ConceptConfiguration
    {
        public void Configure(EntityTypeBuilder<CostCalculation> entityTypeBuilder)
        {
            entityTypeBuilder.Property(t => t.Id).IsRequired();
            entityTypeBuilder.Property(t => t.CreatedOn).IsRequired();            
        }
    }
}
