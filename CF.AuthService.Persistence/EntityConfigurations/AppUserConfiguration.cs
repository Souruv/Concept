using CF.AuthService.Application.Entities;
using CF.AuthService.Persistence.EntityConfigurations;
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
            //entityTypeBuilder.Property(t => t.RoleId)
            //    .IsRequired();

            entityTypeBuilder.Property(t => t.DepartmentName)
                .HasMaxLength(450)
                .IsRequired();

            entityTypeBuilder.Property(t => t.UserPrincipal)
                .HasMaxLength(450)
                .IsRequired();


            entityTypeBuilder.HasOne(x => x.Role).WithMany().OnDelete(DeleteBehavior.Restrict).HasForeignKey(x => x.RoleId).OnDelete(DeleteBehavior.Restrict); ;
            entityTypeBuilder.HasOne(x => x.FelStage).WithMany().OnDelete(DeleteBehavior.Restrict).HasForeignKey(x => x.FelStageId).OnDelete(DeleteBehavior.Restrict); ;
        }
    }
}
