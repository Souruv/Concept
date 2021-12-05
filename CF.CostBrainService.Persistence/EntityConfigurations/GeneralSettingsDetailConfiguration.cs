using CF.CostBrainService.Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CF.CostBrainService.Persistence.EntityConfigurations
{
    class GeneralSettingsDetailConfiguration : BaseEntityConfiguration<GeneralSettingsDetails>
    {
        public override void Configure(EntityTypeBuilder<GeneralSettingsDetails> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);
            entityTypeBuilder.HasOne(x => x.MasterGeneralSettings).WithMany().OnDelete(DeleteBehavior.Restrict).HasForeignKey(x => x.MasterGeneralSettingsId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
