using CF.CostBrainService.Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.CostBrainService.Persistence.EntityConfigurations
{
    class TopsideModuleInstallationConfiguration : BaseEntityConfiguration<TopsideModuleInstallation>
    {
        public override void Configure(EntityTypeBuilder<TopsideModuleInstallation> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);
            entityTypeBuilder.HasOne(x => x.MasterInstallation).WithMany().OnDelete(DeleteBehavior.Restrict).HasForeignKey(x => x.InstallationId).OnDelete(DeleteBehavior.Restrict);
            entityTypeBuilder.HasOne(x => x.MasterWeight).WithMany().OnDelete(DeleteBehavior.Restrict).HasForeignKey(x => x.WeightId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
