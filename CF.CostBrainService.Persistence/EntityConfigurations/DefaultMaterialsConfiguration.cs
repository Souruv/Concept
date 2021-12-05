using CF.CostBrainService.Application.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.CostBrainService.Persistence.EntityConfigurations
{
    class DefaultMaterialsConfiguration : BaseEntityConfiguration<DefaultMaterials>
    {
        public override void Configure(EntityTypeBuilder<DefaultMaterials> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);
        }
    }
}
