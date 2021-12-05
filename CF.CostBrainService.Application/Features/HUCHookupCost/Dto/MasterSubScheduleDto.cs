using CF.CostBrainService.Application.Common.Mappings;
using CF.CostBrainService.Application.Entities;
using System;

namespace CF.CostBrainService.Application.Features.HUCHookupCost.Dto
{
    public class MasterSubScheduleDto : IMapFrom<MasterSubSchedule>
    {
        public string Code { get; set; }
        public string Name { get; set; }

        public MasterScheduleDto MasterSchedule { get; set; }
    }
}
