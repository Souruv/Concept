using CF.CostBrainService.Application.Entities.Base;
using System;

namespace CF.CostBrainService.Application.Entities
{
    public class MasterSubSchedule : BaseEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }

        public Guid? MasterScheduleId { get; set; }
        public MasterSchedule MasterSchedule { get; set; }
    }
}
