using CF.CostBrainService.Application.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.CostBrainService.Persistence.EntityConfigurations
{
    class DefaultEquipmentToolsConsConfiguration : BaseEntityConfiguration<DefaultEquipmentToolsCons>
    {
        public override void Configure(EntityTypeBuilder<DefaultEquipmentToolsCons> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);
        }
    }
}
