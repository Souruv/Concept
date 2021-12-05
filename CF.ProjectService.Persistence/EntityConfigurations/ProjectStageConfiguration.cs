using CF.ProjectService.Application.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.ProjectService.Persistence.EntityConfigurations
{
    public class ProjectStageConfiguration : BaseEntityConfiguration<ProjectStage>
    {
        public override void Configure(EntityTypeBuilder<ProjectStage> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);
            entityTypeBuilder.Property(t => t.Stage).IsRequired(true);

            //entityTypeBuilder.Property(t => t.Tag)
            //  .HasMaxLength(450);

            //entityTypeBuilder.HasOne(x => x.Project).WithMany().OnDelete(DeleteBehavior.Restrict).HasForeignKey(x => x.ProjectId).OnDelete(DeleteBehavior.Restrict);
            //entityTypeBuilder.HasOne(x => x.SubmittedByUser).WithMany().OnDelete(DeleteBehavior.Restrict).HasForeignKey(x => x.SubmittedByUserId).OnDelete(DeleteBehavior.Restrict);
            //entityTypeBuilder.Property(t => t.Id).IsRequired();
            //entityTypeBuilder.Property(t => t.CreatedByUserId).IsRequired();
            //entityTypeBuilder.Property(t => t.CreatedOn).IsRequired();
            //entityTypeBuilder.HasOne(x => x.DeletedByUser).WithMany().OnDelete(DeleteBehavior.Restrict).HasForeignKey(x => x.DeletedByUserId).OnDelete(DeleteBehavior.Restrict);


            //entityTypeBuilder.HasOne(x => x.CreatedByUser).WithMany().HasForeignKey(x => x.CreatedByUserId);//.HasConstraintName("FK_Appuser_CreatedBy");
            //entityTypeBuilder.HasOne(x => x.ModifiedByUser).WithMany().HasForeignKey(x => x.ModifiedByUserId);//.HasConstraintName("FK_Appuser_ModifiedBy");
            //entityTypeBuilder.HasOne(x => x.DeletedByUser).WithMany().HasForeignKey(x => x.DeletedByUserId);//.HasConstraintName("FK_Appuser_DeletedBy");
        }
    }
}
