using CF.CostBrainService.Application;
using CF.CostBrainService.Application.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.CostBrainService.Persistence.EntityConfigurations
{
    public class BaseEntityConfiguration<TBase> : IEntityTypeConfiguration<TBase>
        where TBase : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<TBase> entityTypeBuilder)
        {
            entityTypeBuilder.Property(t => t.Id).IsRequired();
            entityTypeBuilder.Property(t => t.CreatedByUserId).IsRequired();
            entityTypeBuilder.Property(t => t.CreatedOn).IsRequired();

            entityTypeBuilder.HasOne(x => x.CreatedByUser).WithMany().OnDelete(DeleteBehavior.Restrict).HasForeignKey(x => x.CreatedByUserId).OnDelete(DeleteBehavior.Restrict);
            entityTypeBuilder.HasOne(x => x.ModifiedByUser).WithMany().OnDelete(DeleteBehavior.Restrict).HasForeignKey(x => x.ModifiedByUserId).OnDelete(DeleteBehavior.Restrict);
            entityTypeBuilder.HasOne(x => x.DeletedByUser).WithMany().OnDelete(DeleteBehavior.Restrict).HasForeignKey(x => x.DeletedByUserId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}