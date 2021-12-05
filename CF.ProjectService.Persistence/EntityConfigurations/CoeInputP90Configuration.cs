using CF.ProjectService.Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.ProjectService.Persistence.EntityConfigurations
{
    public class CoeInputP90Configuration : BaseEntityConfiguration<CoeInputP90>
    {
        public override void Configure(EntityTypeBuilder<CoeInputP90> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);

            entityTypeBuilder.HasOne(x => x.DrillingCenter).WithOne(x => x.CoeInputP90).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
