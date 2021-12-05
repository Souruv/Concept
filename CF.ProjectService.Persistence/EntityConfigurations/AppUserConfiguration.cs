using CF.ProjectService.Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.ProjectService.Persistence.EntityConfigurations
{
    public class AppUserConfiguration : BaseEntityConfiguration<AppUser>
    {
        public override void Configure(EntityTypeBuilder<AppUser> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);

            entityTypeBuilder.Property(t => t.Name)
                .HasMaxLength(450)
                .IsRequired();

            entityTypeBuilder.Property(t => t.Email)
                .HasMaxLength(450)
                .IsRequired();
            entityTypeBuilder.Property(t => t.Role)
                .IsRequired();

            entityTypeBuilder.Property(t => t.DepartmentName)
                .HasMaxLength(450)
                .IsRequired();

            entityTypeBuilder.Property(t => t.UserPrincipal)
                .HasMaxLength(450)
                .IsRequired();
            //entityTypeBuilder.Property(t => t.Id).IsRequired();
            //entityTypeBuilder.Property(t => t.CreatedByUserId).IsRequired();
            //entityTypeBuilder.Property(t => t.CreatedOn).IsRequired();



            //entityTypeBuilder.HasOne(x => x.CreatedByUser).WithMany().OnDelete(DeleteBehavior.Restrict).HasForeignKey(x => x.CreatedByUserId).OnDelete(DeleteBehavior.Restrict);
            //entityTypeBuilder.HasOne(x => x.ModifiedByUser).WithMany().OnDelete(DeleteBehavior.Restrict).HasForeignKey(x => x.ModifiedByUserId).OnDelete(DeleteBehavior.Restrict);
            //entityTypeBuilder.HasOne(x => x.DeletedByUser).WithMany().OnDelete(DeleteBehavior.Restrict).HasForeignKey(x => x.DeletedByUserId).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
