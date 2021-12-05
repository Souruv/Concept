using CF.CostBrainService.Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CF.CostBrainService.Persistence.EntityConfigurations
{
    class TypicalManpowerCostConfiguration : BaseEntityConfiguration<TypicalManpowerCost>
    {
        public override void Configure(EntityTypeBuilder<TypicalManpowerCost> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);
        }
    }
}
