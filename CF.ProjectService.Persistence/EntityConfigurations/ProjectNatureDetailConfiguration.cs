using CF.ProjectService.Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.ProjectService.Persistence.EntityConfigurations
{
        public class ProjectNatureDetailConfiguration : BaseEntityConfiguration<ProjectNatureDetail>
    {
          public override void Configure(EntityTypeBuilder<ProjectNatureDetail> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);
          
           entityTypeBuilder.HasOne(x=>x.ProjectNature).WithMany().OnDelete(DeleteBehavior.NoAction).HasForeignKey(x=>x.ProjectNatureId).OnDelete(DeleteBehavior.NoAction);

            
        }
    }
}


