using CF.CostBrainService.Application.Common.Mappings;
using CF.CostBrainService.Application.Entities;

namespace CF.CostBrainService.Application.Features.HUCHookupCost.Dto
{
    public class DefaultThirdPartyServicesSectionOneDto : IMapFrom<DefaultThirdPartyServicesSectionOne>
    {
        public string Type { get; set; }
        public decimal? MOBANDDEMOB_RATE_RM_MOB { get; set; }
        public decimal? Equipment_Per_Set { get; set; }
        public decimal? Technician_Per_Set { get; set; }
    }
}
