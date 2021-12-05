using CF.CostBrainService.Application.Common.Mappings;
using CF.CostBrainService.Application.Entities;

namespace CF.CostBrainService.Application.Features.HUCHookupCost.Dto
{
    public class MasterProjectTypeDto : IMapFrom<MasterProjectType>
    {
        public string Type { get; set; }
    }
}
