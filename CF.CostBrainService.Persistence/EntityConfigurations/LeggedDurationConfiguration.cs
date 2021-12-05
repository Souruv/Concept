using CF.CostBrainService.Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CF.CostBrainService.Persistence.EntityConfigurations
{
    class LeggedDurationConfiguration : BaseEntityConfiguration<LeggedDuration>
    {
        public override void Configure(EntityTypeBuilder<LeggedDuration> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);
            entityTypeBuilder.HasOne(x => x.MasterLegged).WithMany().OnDelete(DeleteBehavior.Restrict).HasForeignKey(x => x.LeggedId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
