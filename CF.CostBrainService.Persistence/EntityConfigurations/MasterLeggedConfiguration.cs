using CF.CostBrainService.Application.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CF.CostBrainService.Persistence.EntityConfigurations
{
    class MasterLeggedConfiguration : BaseEntityConfiguration<MasterLegged>
    {
        public override void Configure(EntityTypeBuilder<MasterLegged> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);
            entityTypeBuilder.Property(t => t.NumberOfLeg).IsRequired(true);
        }
    }
}
