using CF.CostBrainService.Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CF.CostBrainService.Persistence.EntityConfigurations
{
    class MasterTypicalManpowerConfiguration : BaseEntityConfiguration<MasterTypicalManpower>
    {
        public override void Configure(EntityTypeBuilder<MasterTypicalManpower> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);
        }
    }
}
