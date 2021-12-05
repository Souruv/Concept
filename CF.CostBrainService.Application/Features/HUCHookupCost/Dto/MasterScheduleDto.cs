using CF.CostBrainService.Application.Common.Mappings;
using CF.CostBrainService.Application.Entities;

namespace CF.CostBrainService.Application.Features.HUCHookupCost.Dto
{
    public class MasterScheduleDto : IMapFrom<MasterSchedule>
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
