using CF.ProjectService.Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.ProjectService.Persistence.EntityConfigurations
{
    public class CoeInputP10Configuration : BaseEntityConfiguration<CoeInputP10>
    {
        public override void Configure(EntityTypeBuilder<CoeInputP10> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);

            entityTypeBuilder.HasOne(x => x.DrillingCenter).WithOne(x => x.CoeInputP10).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
