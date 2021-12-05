using CF.CostBrainService.Application.Common.Mappings;
using CF.CostBrainService.Application.Entities;

namespace CF.CostBrainService.Application.Features.HUCHookupCost.Dto
{
    public class MasterOffShoreAccomodationDto : IMapFrom<MasterOffShoreAccomodation>
    {
        public string Value { get; set; }
    }
}
