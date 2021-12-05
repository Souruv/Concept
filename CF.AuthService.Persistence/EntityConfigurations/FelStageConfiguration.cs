using CF.AuthService.Application.Entities;
using CF.AuthService.Persistence.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.ProjectService.Persistence.EntityConfigurations
{
    public class FelStageConfiguration : BaseEntityConfiguration<FelStage>
    {
        public override void Configure(EntityTypeBuilder<FelStage> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);

            entityTypeBuilder.Property(t => t.Name)
                .HasMaxLength(450)
                .IsRequired();

            
        }
    }
}
