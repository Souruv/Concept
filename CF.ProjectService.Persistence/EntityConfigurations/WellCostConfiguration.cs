using CF.ProjectService.Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.ProjectService.Persistence.EntityConfigurations
{
    public class WellCostConfiguration : BaseEntityConfiguration<WellCost>
    {
        public override void Configure(EntityTypeBuilder<WellCost> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);

            entityTypeBuilder.HasOne(x => x.ProjectRevision).WithMany(x => x.WellCosts).OnDelete(DeleteBehavior.Restrict).HasForeignKey(x => x.RevisionId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
