using CF.ConceptBrainService.Application.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.ConceptBrainService.Persistence.EntityConfigurations
{
    class EquipmentConfiguration : BaseEntityConfiguration<Equipment>
    {
        public override void Configure(EntityTypeBuilder<Equipment> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);
            entityTypeBuilder.Property(t => t.Manifolding).IsRequired(true);
        }
    }
}
