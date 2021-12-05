using CF.CostBrainService.Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.CostBrainService.Persistence.EntityConfigurations
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
        }
    }
}
