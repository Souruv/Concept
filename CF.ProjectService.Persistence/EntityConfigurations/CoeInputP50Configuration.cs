using CF.ProjectService.Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.ProjectService.Persistence.EntityConfigurations
{
    public class CoeInputP50Configuration : BaseEntityConfiguration<CoeInputP50>
    {
        public override void Configure(EntityTypeBuilder<CoeInputP50> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);

            entityTypeBuilder.HasOne(x => x.DrillingCenter).WithOne(x => x.CoeInputP50).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
