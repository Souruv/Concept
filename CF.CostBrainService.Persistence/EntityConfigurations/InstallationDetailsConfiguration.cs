using CF.CostBrainService.Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.CostBrainService.Persistence.EntityConfigurations
{
    class InstallationDetailsConfiguration : BaseEntityConfiguration<InstallationDetails>
    {
        public override void Configure(EntityTypeBuilder<InstallationDetails> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);
            entityTypeBuilder.HasOne(x => x.MasterInstallation).WithMany().OnDelete(DeleteBehavior.Restrict).HasForeignKey(x => x.InstallationId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
