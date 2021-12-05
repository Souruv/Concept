using CF.CostBrainService.Application.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.CostBrainService.Persistence.EntityConfigurations
{
    class EquipmentToolsConstCostConfiguration : BaseEntityConfiguration<EquipmentToolsConsCost>
    {
        public override void Configure(EntityTypeBuilder<EquipmentToolsConsCost> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);
        }
    }
}
