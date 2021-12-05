using CF.CostBrainService.Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace CF.CostBrainService.Persistence.EntityConfigurations
{
    class GeneralSettingsValuesConfigurations : BaseEntityConfiguration<GeneralSettingsValues>
    {
        public override void Configure(EntityTypeBuilder<GeneralSettingsValues> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);
            entityTypeBuilder.HasOne(x => x.GeneralSettingsDetails).WithMany().OnDelete(DeleteBehavior.Restrict).HasForeignKey(x => x.GeneralSettingsDetailsId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
