using CF.CostBrainService.Application.Common.Mappings;
using CF.CostBrainService.Application.Entities;

namespace CF.CostBrainService.Application.Features.HUCHookupCost.Dto
{
    public class DefaultThirdPartyServicesSectionTwoDto : IMapFrom<DefaultThirdPartyServicesSectionTwo>
    {
        public string Type { get; set; }
        public decimal? Value { get; set; }
    }
}
