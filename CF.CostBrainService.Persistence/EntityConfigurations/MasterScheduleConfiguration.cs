using CF.CostBrainService.Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CF.CostBrainService.Persistence.EntityConfigurations
{
    class MasterScheduleConfiguration : BaseEntityConfiguration<MasterSchedule>
    {
        public override void Configure(EntityTypeBuilder<MasterSchedule> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);
        }
    }
}
