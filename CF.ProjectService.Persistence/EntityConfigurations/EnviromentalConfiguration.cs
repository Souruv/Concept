using CF.ProjectService.Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.ProjectService.Persistence.EntityConfigurations
{
    public class EnviromentalConfiguration : BaseEntityConfiguration<Enviromental>
    {
         public override void Configure(EntityTypeBuilder<Enviromental> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);
          
              entityTypeBuilder.HasOne(x=> x.ProjectRevision).WithOne(x=>x.Enviromental).OnDelete(DeleteBehavior.NoAction);
            
        }
    }
}
