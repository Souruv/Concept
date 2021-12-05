using CF.CostBrainService.Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CF.CostBrainService.Persistence.EntityConfigurations
{
    class MasterMarineSpreadOptionConfiguration : BaseEntityConfiguration<MasterMarineSpreadOption>
    {
        public override void Configure(EntityTypeBuilder<MasterMarineSpreadOption> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);
        }
    }
}
