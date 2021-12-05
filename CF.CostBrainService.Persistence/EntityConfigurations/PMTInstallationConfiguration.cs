using CF.CostBrainService.Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CF.CostBrainService.Persistence.EntityConfigurations
{
    class PMTInstallationConfiguration : BaseEntityConfiguration<PMTInstallation>
    {
        public override void Configure(EntityTypeBuilder<PMTInstallation> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);
            entityTypeBuilder.HasOne(x => x.ProjectType).WithMany().OnDelete(DeleteBehavior.Restrict).HasForeignKey(x => x.ProjectId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
