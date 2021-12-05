using CF.ProjectService.Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.ProjectService.Persistence.EntityConfigurations
{
    public class ProjectNotificationConfiguration : BaseEntityConfiguration<ProjectNotification>
    {
        public override void Configure(EntityTypeBuilder<ProjectNotification> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);

            entityTypeBuilder.HasOne(x => x.Sender).WithMany().OnDelete(DeleteBehavior.Restrict).HasForeignKey(x => x.SenderId).OnDelete(DeleteBehavior.Restrict);
            entityTypeBuilder.HasOne(x => x.Receiver).WithMany().OnDelete(DeleteBehavior.Restrict).HasForeignKey(x => x.ReceiverId).OnDelete(DeleteBehavior.Restrict);
            entityTypeBuilder.HasOne(x => x.ProjectRevision).WithMany().OnDelete(DeleteBehavior.Restrict).HasForeignKey(x => x.RevisionId).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
