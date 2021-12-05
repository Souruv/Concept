using CF.CostBrainService.Application.Common.Mappings;
using CF.CostBrainService.Application.Entities;

namespace CF.CostBrainService.Application.Features.HUCHookupCost.Dto
{
    public class MasterTypicalManpowerDto : IMapFrom<MasterTypicalManpower>
    {
        public string ManPowerName { get; set; }
    }
}
