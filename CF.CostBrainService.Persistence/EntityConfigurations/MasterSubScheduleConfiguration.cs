using CF.CostBrainService.Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CF.CostBrainService.Persistence.EntityConfigurations
{
    class MasterSubScheduleConfiguration : BaseEntityConfiguration<MasterSubSchedule>
    {
        public override void Configure(EntityTypeBuilder<MasterSubSchedule> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);
        }
    }
}
