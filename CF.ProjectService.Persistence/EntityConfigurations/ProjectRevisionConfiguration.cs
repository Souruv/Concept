using CF.ProjectService.Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace CF.ProjectService.Persistence.EntityConfigurations
{
    public class ProjectRevisionConfiguration : BaseEntityConfiguration<ProjectRevision>
    {
        public override void Configure(EntityTypeBuilder<ProjectRevision> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);
            entityTypeBuilder.Property(t => t.RevisionNo).IsRequired(true);

            entityTypeBuilder.Property(t => t.ProjectStageId).IsRequired(true);


            //entityTypeBuilder.HasOne(x => x.Project).WithMany().OnDelete(DeleteBehavior.Restrict).HasForeignKey(x => x.ProjectId).OnDelete(DeleteBehavior.Restrict);
            entityTypeBuilder.HasOne(x => x.SubmittedByUser).WithMany().OnDelete(DeleteBehavior.Restrict).HasForeignKey(x => x.SubmittedByUserId).OnDelete(DeleteBehavior.Restrict);
            entityTypeBuilder.HasOne(x => x.ProjectStage).WithMany().OnDelete(DeleteBehavior.Restrict).HasForeignKey(x => x.ProjectStageId).OnDelete(DeleteBehavior.Restrict);
            entityTypeBuilder.HasOne(x => x.RespondedByUser).WithMany().OnDelete(DeleteBehavior.Restrict).HasForeignKey(x => x.RespondedByUserId).OnDelete(DeleteBehavior.Restrict);
            entityTypeBuilder.HasMany(x => x.RevisionTeamMembers).WithOne(x => x.Revision).OnDelete(DeleteBehavior.NoAction);
            //entityTypeBuilder.HasOne(x=> x.Enviromental).WithOne(x=>x.ProjectRevision).OnDelete(DeleteBehavior.NoAction).HasForeignKey<ProjectRevision>(x=>x.EnviromentalId);
            entityTypeBuilder.HasOne(x => x.Enviromental).WithOne(x => x.ProjectRevision).OnDelete(DeleteBehavior.NoAction).HasForeignKey<Enviromental>(x => x.ProjectRevisionId);
            entityTypeBuilder.HasOne(x => x.InfrastructureData).WithOne(x => x.ProjectRevision).OnDelete(DeleteBehavior.NoAction);
            entityTypeBuilder.HasMany(x => x.WellCosts).WithOne(x => x.ProjectRevision).OnDelete(DeleteBehavior.NoAction);

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
