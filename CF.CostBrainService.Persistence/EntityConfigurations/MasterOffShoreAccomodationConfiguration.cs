using CF.CostBrainService.Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CF.CostBrainService.Persistence.EntityConfigurations
{
    class MasterOffShoreAccomodationConfiguration : BaseEntityConfiguration<MasterOffShoreAccomodation>
    {
        public override void Configure(EntityTypeBuilder<MasterOffShoreAccomodation> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);
        }
    }
}
