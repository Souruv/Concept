using CF.CostBrainService.Application.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.CostBrainService.Persistence.EntityConfigurations
{
    class DefaultManpowerConfiguration : BaseEntityConfiguration<DefaultManpower>
    {
        public override void Configure(EntityTypeBuilder<DefaultManpower> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);
        }
    }
}
