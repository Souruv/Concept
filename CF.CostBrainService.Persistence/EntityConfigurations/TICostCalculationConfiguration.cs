using CF.CostBrainService.Application.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CF.CostBrainService.Persistence.EntityConfigurations
{
    class TICostCalculationConfiguration : BaseEntityConfiguration<TICostCalculation>
    {
        public override void Configure(EntityTypeBuilder<TICostCalculation> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);
            entityTypeBuilder.Property(t => t.ConceptId).IsRequired(true);
        }
    }
}
