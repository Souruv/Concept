using CF.ProjectService.Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.ProjectService.Persistence.EntityConfigurations
{
    public class ProjectAuditLogConfiguration : BaseEntityConfiguration<ProjectAuditLog>
    {
        public override void Configure(EntityTypeBuilder<ProjectAuditLog> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);

            entityTypeBuilder.HasOne(x => x.ActionByUser).WithMany().OnDelete(DeleteBehavior.Restrict).HasForeignKey(x => x.ActionByUserId).OnDelete(DeleteBehavior.Restrict);
            entityTypeBuilder.HasOne(x => x.ProjectRevision).WithMany().OnDelete(DeleteBehavior.Restrict).HasForeignKey(x => x.RevisionId).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
