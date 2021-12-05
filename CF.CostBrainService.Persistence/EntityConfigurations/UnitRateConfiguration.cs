using CF.CostBrainService.Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.CostBrainService.Persistence.EntityConfigurations
{
    class UnitRateConfiguration : BaseEntityConfiguration<UnitRate>
    {
        public override void Configure(EntityTypeBuilder<UnitRate> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);
            entityTypeBuilder.HasOne(x => x.ProjectLocation).WithMany().OnDelete(DeleteBehavior.Restrict).HasForeignKey(x => x.LocationId).OnDelete(DeleteBehavior.Restrict);
            entityTypeBuilder.HasOne(x => x.ProjectType).WithMany().OnDelete(DeleteBehavior.Restrict).HasForeignKey(x => x.ProjectId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
