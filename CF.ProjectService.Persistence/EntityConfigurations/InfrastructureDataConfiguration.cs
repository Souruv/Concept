using CF.ProjectService.Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.ProjectService.Persistence.EntityConfigurations
{
    public class InfrastructureDataConfiguration : BaseEntityConfiguration<InfrastructureData>
    {
        public override void Configure(EntityTypeBuilder<InfrastructureData> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);

            entityTypeBuilder.HasMany(x => x.EvacuationOptions).WithOne(x => x.InfrastructureData).OnDelete(DeleteBehavior.NoAction);
            entityTypeBuilder.HasMany(x => x.EvacuationOptionCondensates).WithOne(x => x.InfrastructureData).OnDelete(DeleteBehavior.NoAction);
            entityTypeBuilder.HasMany(x => x.EvacuationOptionGas).WithOne(x => x.InfrastructureData).OnDelete(DeleteBehavior.NoAction);
            entityTypeBuilder.HasMany(x => x.EvacuationOptionOils).WithOne(x => x.InfrastructureData).OnDelete(DeleteBehavior.NoAction);
            entityTypeBuilder.HasMany(x => x.EvacuationOptionProducedWaters).WithOne(x => x.InfrastructureData).OnDelete(DeleteBehavior.NoAction);


        }
    }
}
