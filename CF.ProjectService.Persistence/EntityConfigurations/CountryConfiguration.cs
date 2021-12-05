using CF.ProjectService.Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.ProjectService.Persistence.EntityConfigurations
{
    public class CountryConfiguration : BaseEntityConfiguration<Country>
    {
         public override void Configure(EntityTypeBuilder<Country> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);
          
             entityTypeBuilder.HasMany(x=> x.UTCCosts).WithOne(x=>x.Country).OnDelete(DeleteBehavior.NoAction);
            
        }
    }
}
