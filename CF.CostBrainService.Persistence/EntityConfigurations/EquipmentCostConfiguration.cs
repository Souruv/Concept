using CF.CostBrainService.Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CF.CostBrainService.Persistence.EntityConfigurations
{
    class EquipmentCostConfiguration : BaseEntityConfiguration<EquipmentCost>
    {
        public override void Configure(EntityTypeBuilder<EquipmentCost> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);
            entityTypeBuilder.HasOne(x => x.Equipment).WithMany().OnDelete(DeleteBehavior.Restrict).HasForeignKey(x => x.EquipmentId).OnDelete(DeleteBehavior.Restrict);
            entityTypeBuilder.HasOne(x => x.CountryData).WithMany().OnDelete(DeleteBehavior.Restrict).HasForeignKey(x => x.CountryCode).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
