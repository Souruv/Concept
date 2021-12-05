using CF.CostBrainService.Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CF.CostBrainService.Persistence.EntityConfigurations
{
    class MasterProjectTypeConfiguration : BaseEntityConfiguration<MasterProjectType>
    {
        public override void Configure(EntityTypeBuilder<MasterProjectType> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);
        }
    }
}
