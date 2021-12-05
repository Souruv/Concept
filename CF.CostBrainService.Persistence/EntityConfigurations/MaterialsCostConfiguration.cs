using CF.CostBrainService.Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CF.CostBrainService.Persistence.EntityConfigurations
{
    class MaterialsCostConfiguration : BaseEntityConfiguration<MaterialsCost>
    {
        public override void Configure(EntityTypeBuilder<MaterialsCost> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);
        }
    }
}
