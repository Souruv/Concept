using CF.CostBrainService.Application.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace CF.CostBrainService.Persistence.EntityConfigurations
{
    class BargeDurationConfiguration : BaseEntityConfiguration<BargeDuration>
    {
        public override void Configure(EntityTypeBuilder<BargeDuration> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);
            entityTypeBuilder.Property(t => t.Barge).IsRequired(true);
        }
    }
}
