using CF.CostBrainService.Application.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.CostBrainService.Persistence.EntityConfigurations
{
    class MasterInstallationConfiguration : BaseEntityConfiguration<MasterInstallation>
    {
        public override void Configure(EntityTypeBuilder<MasterInstallation> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);
            entityTypeBuilder.Property(t => t.InstallationName).IsRequired(true);
        }
    }
}
