using CF.ProjectService.Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.ProjectService.Persistence.EntityConfigurations
{
    class ProjectDeterministicValueConfiguration : BaseEntityConfiguration<ProjectDeterministicValue>
    {
        public override void Configure(EntityTypeBuilder<ProjectDeterministicValue> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);

            entityTypeBuilder.HasOne(x => x.DeterministicValue).WithMany().OnDelete(DeleteBehavior.Restrict).HasForeignKey(x => x.DeterministicValueId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
