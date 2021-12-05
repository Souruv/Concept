using CF.ProjectService.Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace CF.ProjectService.Persistence.EntityConfigurations
{
   public  class ProjectConfiguration : BaseEntityConfiguration<Project>
    {
        public override  void Configure(EntityTypeBuilder<Project> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);

            entityTypeBuilder.Property(t => t.Name)
                .HasMaxLength(450);


            entityTypeBuilder.HasMany(x => x.ProjectRevisions).WithOne(x => x.Project).OnDelete(DeleteBehavior.NoAction);
            entityTypeBuilder.HasMany(x => x.ProjectUsers).WithOne(x => x.Project).OnDelete(DeleteBehavior.NoAction);
            entityTypeBuilder.HasMany(x=>x.ProjectNatureDetails).WithOne(x => x.Project).OnDelete(DeleteBehavior.NoAction);
            //entityTypeBuilder.HasOne(x => x.TechicalManager).WithMany().OnDelete(DeleteBehavior.Restrict).HasForeignKey(x => x.TechicalManagerId).OnDelete(DeleteBehavior.Restrict);
            //entityTypeBuilder.HasOne(x => x.SpeciaListUser).WithMany().OnDelete(DeleteBehavior.Restrict).HasForeignKey(x => x.SpecialistUserId).OnDelete(DeleteBehavior.Restrict);
            //entityTypeBuilder.HasOne(x => x.SpecialistsAlternateUser).WithMany().OnDelete(DeleteBehavior.Restrict).HasForeignKey(x => x.SpecialistsAlternateUserId).OnDelete(DeleteBehavior.Restrict);
            //  entityTypeBuilder.HasOne(x => x.TechicalManagerCostimator).WithMany().OnDelete(DeleteBehavior.Restrict).HasForeignKey(x => x.TechicalManagerCostimatorId).OnDelete(DeleteBehavior.Restrict);
            //entityTypeBuilder.HasOne(x => x.SpeciaListUserCostimator).WithMany().OnDelete(DeleteBehavior.Restrict).HasForeignKey(x => x.SpecialistUserCostimatorId).OnDelete(DeleteBehavior.Restrict);
            //entityTypeBuilder.HasOne(x => x.SpecialistsAlternateUserCostimator).WithMany().OnDelete(DeleteBehavior.Restrict).HasForeignKey(x => x.SpecialistsAlternateUserCostimatorId).OnDelete(DeleteBehavior.Restrict);
            entityTypeBuilder.HasOne(x => x.LastSubmittedByUser).WithMany().OnDelete(DeleteBehavior.Restrict).HasForeignKey(x => x.LastSubmittedBy).OnDelete(DeleteBehavior.Restrict);
            //entityTypeBuilder.Property(t => t.Details)
            //    .HasMaxLength(450);

            //entityTypeBuilder.HasOne(x => x.CreatedByUser).WithMany().HasForeignKey(x => x.CreatedBy);//.HasConstraintName("FK_Appuser_CreatedBy");
            //entityTypeBuilder.HasOne(x => x.ModifiedByUser).WithMany().HasForeignKey(x => x.ModifiedBy);//.HasConstraintName("FK_Appuser_ModifiedBy");
            //entityTypeBuilder.HasOne(x => x.DeletedByUser).WithMany().HasForeignKey(x => x.DeletedBy);//.HasConstraintName("FK_Appuser_DeletedBy");
            //entityTypeBuilder.Property(t => t.Id).IsRequired();
            //entityTypeBuilder.Property(t => t.CreatedByUserId).IsRequired();
            //entityTypeBuilder.Property(t => t.CreatedOn).IsRequired();
            //entityTypeBuilder.HasOne(x => x.TechicalManager).WithMany().OnDelete(DeleteBehavior.NoAction);
            //entityTypeBuilder.HasOne(x => x.SpecialistsAlternateUser).WithMany().OnDelete(DeleteBehavior.NoAction);
            //entityTypeBuilder.HasMany(x => x.SharedWith).WithOne(x => x.Project).OnDelete(DeleteBehavior.NoAction);

            //entityTypeBuilder.HasMany(x => x.ProjectRevisions).WithOne(x => x.Project).OnDelete(DeleteBehavior.NoAction);
            //entityTypeBuilder.HasOne(x => x.CreatedByUser).WithMany().HasForeignKey(x => x.CreatedByUserId);//.HasConstraintName("FK_Appuser_CreatedBy");
            //entityTypeBuilder.HasOne(x => x.ModifiedByUser).WithMany().HasForeignKey(x => x.ModifiedByUserId);//.HasConstraintName("FK_Appuser_ModifiedBy");
            //entityTypeBuilder.HasOne(x => x.DeletedByUser).WithMany().HasForeignKey(x => x.DeletedByUserId);//.HasConstraintName("FK_Appuser_DeletedBy");

        }
    }
}
